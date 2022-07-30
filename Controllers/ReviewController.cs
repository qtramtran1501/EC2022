using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarket.Controllers
{
    public class ReviewController : Controller
    {
        private readonly OnlineShopContext _context;
        public INotyfService _notyfService { get; }

        public ReviewController(OnlineShopContext context, INotyfService notifyfService)
        {
            _context = context;
            _notyfService = notifyfService;
        }
        [Route("review.html")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reviews.ToListAsync());
        }
        // GET: Admin/AdminProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,,FullName,Email,Phone,Review1,CreateDay")] Review review, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (ModelState.IsValid)
            {
                review.CreateDay = DateTime.Now;
                _context.Add(review);
                await _context.SaveChangesAsync();
                _notyfService.Success("Cảm ơn bạn đã phản hồi");
                return RedirectToAction("Index", "Product");
            }
            return View(review);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }
        // GET: Admin/AdminRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Admin/AdminRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa phản hồi thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewExits(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
