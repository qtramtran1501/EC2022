using AspNetCoreHero.ToastNotification.Abstractions;
using BraintreeHttp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using OnlineMarket.Extension;
using OnlineMarket.Models;
using OnlineMarket.ModelViews;
using OnlineMarket.Others;
using PayPal.Core;
using PayPal.v1.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarket.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly OnlineShopContext _context;
        public INotyfService _notyfService { get; }
        private readonly string _clientId;
        private readonly string _secretKey;
        public int TyGiaUSD = 23300;//store in Database

        public ShoppingCartController(OnlineShopContext context, INotyfService notifyfService, IConfiguration config)
        {
            _context = context;
            _notyfService = notifyfService;
            _clientId = config["PaypalSettings:ClientId"];
            _secretKey = config["PaypalSettings:SecretKey"];

        }
        
        public List<CartItem> GioHang
        {
            get
            {
                var gh = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if ( gh == default(List<CartItem>))
                {
                    gh = new List<CartItem>();
                }
                return gh;
            }
        }

        [HttpPost]
        [Route("api/cart/add")]
        public IActionResult AddToCart(int productID, int? quantity)
        {
            List<CartItem> cart = GioHang;
            // thêm sản phảm vào giỏ hàng
            try
            {
                CartItem item = cart.SingleOrDefault(p => p.product.ProductId == productID);
                if (item != null)
                {
                    item.quantity = item.quantity + quantity.Value;
                    //Lưu lại session
                    HttpContext.Session.Set<List<CartItem>>("GioHang", cart);
                }
                else
                {
                    Product hh = _context.Products.SingleOrDefault(p => p.ProductId == productID);
                    item = new CartItem
                    {
                        quantity = quantity.HasValue ? quantity.Value : 1,
                        product = hh
                    };
                    cart.Add(item); // thêm vào giỏ
                }
                // lưu lại session
                HttpContext.Session.Set<List<CartItem>>("GioHang", cart);
                _notyfService.Success("Sản phẩm đã được thêm vào giỏ hàng");
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
          
        }

        [HttpPost]
        [Route("api/cart/update")]
        public IActionResult UpdateCart (int productID, int? quantity)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            try
            {
                if(cart != null )
                {
                    CartItem item = cart.SingleOrDefault(p => p.product.ProductId == productID);
                    if(item != null && quantity.HasValue)
                    {
                        item.quantity = quantity.Value;
                    }
                    // Lưu lại session
                    HttpContext.Session.Set<List<CartItem>>("GioHang", cart);
                }
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }



        [HttpPost]
        [Route("api/cart/remove")]
        public IActionResult Remove(int productID)
        {
            try
            {
                List<CartItem> gioHang = GioHang;
                CartItem item = gioHang.SingleOrDefault(p => p.product.ProductId == productID);
                if (item != null)
                {
                    gioHang.Remove(item);
                }
                // lưu lại session
                HttpContext.Session.Set<List<CartItem>>("GioHang", gioHang);
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
            
        }


        [Route("cart.html",Name = "Cart")]
        public IActionResult Index()
        {          
            return View(GioHang);
        }
        [Authorize]
        public async System.Threading.Tasks.Task<IActionResult> PaypalCheckout()
        {
            var environment = new SandboxEnvironment(_clientId, _secretKey);
            var client = new PayPalHttpClient(environment);

            #region Create Paypal Order
            var itemList = new ItemList()
            {
                Items = new List<Item>()
            };
            var total = Math.Round(GioHang.Sum(p => p.TotalMoney) / TyGiaUSD, 2);
            foreach (var item in GioHang)
            {
                itemList.Items.Add(new Item()
                {
                    Name = item.product.ProductName,
                    Currency = "USD",
                    Price = Math.Round(Convert.ToDecimal(item.product.Price) / TyGiaUSD, 2).ToString(),
                    Quantity = item.quantity.ToString(),
                    Sku = "sku",
                    Tax = "0"
                });
            }
            #endregion

            var paypalOrderId = DateTime.Now.Ticks;
            var hostname = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            var payment = new Payment()
            {
                Intent = "sale",
                Transactions = new List<Transaction>()
                {
                    new Transaction()
                    {
                        Amount = new Amount()
                        {
                            Total = total.ToString(),
                            Currency = "USD",
                            Details = new AmountDetails
                            {
                                Tax = "0",
                                Shipping = "0",
                                Subtotal = total.ToString()
                            }
                        },
                        ItemList = itemList,
                        Description = $"Invoice #{paypalOrderId}",
                        InvoiceNumber = paypalOrderId.ToString()
                    }
                },
                RedirectUrls = new RedirectUrls()
                {
                    CancelUrl = $"{hostname}/ShoppingCart/CheckoutFail",
                    ReturnUrl = $"{hostname}/ShoppingCart/CheckoutSuccess"
                },
                Payer = new Payer()
                {
                    PaymentMethod = "paypal"
                }
            };

            PaymentCreateRequest request = new PaymentCreateRequest();
            request.RequestBody(payment);

            try
            {
                var response = await client.Execute(request);
                var statusCode = response.StatusCode;
                Payment result = response.Result<Payment>();

                var links = result.Links.GetEnumerator();
                string paypalRedirectUrl = null;
                while (links.MoveNext())
                {
                    LinkDescriptionObject lnk = links.Current;
                    if (lnk.Rel.ToLower().Trim().Equals("approval_url"))
                    {
                        //saving the payapalredirect URL to which user will be redirected for payment  
                        paypalRedirectUrl = lnk.Href;
                    }
                }

                return Redirect(paypalRedirectUrl);
            }
            catch (HttpException httpException)
            {
                var statusCode = httpException.StatusCode;
                var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();

                //Process when Checkout with Paypal fails
                return Redirect("/ShoppingCart/CheckoutFail");
            }
        }

        public IActionResult CheckoutFail()
        {
            _notyfService.Error("Thanh toán PayPal thất bại");
            return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult CheckoutSuccess()
        {
            HttpContext.Session.Remove("GioHang");
            //Tạo đơn hàng trong database với trạng thái thanh toán là "Paypal" và thành công
            //Xóa session
            _notyfService.Success("Thanh toán PayPal thành công");
            return View();
        }
        [Authorize]
        public ActionResult Payment(int? id)
        {
            var total = Math.Round(GioHang.Sum(p => p.TotalMoney));
            //request params need to request to MoMo system
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOM14D20220402";
            string accessKey = "lx4obWa7G5ciBj9x";
            string serectkey = "MEKW0gpaWQO7pHqSMUFjY16AJ4lSJegh";
            string orderInfo = "webshoe";
            string returnUrl = "https://localhost:44379/ShoppingCart/ConfirmPaymentClient";
            string notifyurl = "http://ba1adf48beba.ngrok.io/Home/SavePayment"; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test
            string amount = total.ToString();
            string orderid = DateTime.Now.Ticks.ToString();
            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                {"amount",amount},
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);

            return Redirect(jmessage.GetValue("payUrl").ToString());
        }

        //Khi thanh toán xong ở cổng thanh toán Momo, Momo sẽ trả về một số thông tin, trong đó có errorCode để check thông tin thanh toán
        //errorCode = 0 : thanh toán thành công (Request.QueryString["errorCode"])
        //Tham khảo bảng mã lỗi tại: https://developers.momo.vn/#/docs/aio/?id=b%e1%ba%a3ng-m%c3%a3-l%e1%bb%97i
        public IActionResult ConfirmPaymentClient()
        {
            //hiển thị thông báo cho người dùng
            return View();
        }

        [HttpPost]
        public void SavePayment()
        {
            //cập nhật dữ liệu vào db

        }
    }
}
