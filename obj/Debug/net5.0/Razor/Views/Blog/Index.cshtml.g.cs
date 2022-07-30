#pragma checksum "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0adb737f8a1a288bbc25c7ddb87ba7610a0dda42"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_Index), @"mvc.1.0.view", @"/Views/Blog/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Agile\web-agile-hc-1\Views\_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Agile\web-agile-hc-1\Views\_ViewImports.cshtml"
using WebApplication1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
using PagedList.Core.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0adb737f8a1a288bbc25c7ddb87ba7610a0dda42", @"/Views/Blog/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03350a0a69106539bd5bc7a986cfffe7a4c319da", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedList.Core.IPagedList<OnlineMarket.Models.Post>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-full"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
  
    ViewData["Title"] = "Blog Index - " + ViewBag.CurrentPage;
    Layout = "~/Views/Shared/_Layout.cshtml";
    int PageCurrent = ViewBag.CurrentPage;
    int PageNext = ViewBag.CurrentPage + 1;

#line default
#line hidden
#nullable disable
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n\r\n    <style type=\"text/css\">\r\n        .bg-image {\r\n            background-image: url(\'");
#nullable restore
#line 13 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
                              Write(Url.Content("~/assets/images/breadcrumb/bg.jpg"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n            background-size: cover;\r\n            height: 600px;\r\n        }\r\n    </style>\r\n");
            }
            );
            WriteLiteral(@"<main class=""main-content"">
    <div class=""breadcrumb-area breadcrumb-height bg-image"">
        <div class=""container h-100"">
            <div class=""row h-100"">
                <div class=""col-lg-12"">
                    <div class=""breadcrumb-item"">
                        <h2 class=""breadcrumb-heading text-white"">Tin nổi bật</h2>
                        <ul>
                            <li>
                                <a class=""text-white"" href=""/"">Home <i class=""pe-7s-angle-right text-white""></i></a>
                            </li>
                            <li class=""text-white"">Tin nổi bật</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""blog-area blog-column-2 section-space-y-axis-100"">
        <div class=""container"">
            <div class=""row"">
");
#nullable restore
#line 40 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
                 if (Model != null && Model.Count() > 0)
                {
                    foreach (var item in Model)
                    {
                        string url = $"/tin-tuc/{item.Alias}-{item.PostId}.html";

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-md-6\">\r\n                            <div class=\"blog-item\">\r\n                                <div class=\"blog-img img-zoom-effect\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1882, "\"", 1893, 1);
#nullable restore
#line 48 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
WriteAttributeValue("", 1889, url, 1889, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0adb737f8a1a288bbc25c7ddb87ba7610a0dda426359", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1964, "~/images/news/", 1964, 14, true);
#nullable restore
#line 49 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
AddHtmlAttributeValue("", 1978, item.Thumb, 1978, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 49 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
AddHtmlAttributeValue("", 1996, item.Title, 1996, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                    </a>
                                </div>
                                <div class=""blog-content"">
                                    <div class=""blog-meta text-dim-gray pb-3"">
                                        <ul>
                                            <li class=""date""><i class=""fa fa-calendar-o me-2""></i>");
#nullable restore
#line 55 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
                                                                                             Write(item.CreateDate.Value.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                                            <li>
                                                <span class=""comments me-3"">
                                                    <a href=""javascript:void(0)"">2 Comments</a>
                                                </span>
                                                <span class=""link-share"">
                                                    <a href=""javascript:void(0)"">Share</a>
                                                </span>
                                            </li>
                                        </ul>
                                    </div>
                                    <h5 class=""title mb-4"">
                                        <a");
            BeginWriteAttribute("href", " href=\"", 3177, "\"", 3188, 1);
#nullable restore
#line 67 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
WriteAttributeValue("", 3184, url, 3184, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 67 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
                                                  Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    </h5>\r\n                                    <p class=\"short-desc mb-5\">");
#nullable restore
#line 69 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
                                                          Write(item.Scontents);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    <div class=\"button-wrap\">\r\n                                        <a class=\"btn btn-custom-size lg-size btn-dark rounded-0\"");
            BeginWriteAttribute("href", " href=\"", 3494, "\"", 3505, 1);
#nullable restore
#line 71 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
WriteAttributeValue("", 3501, url, 3501, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Xem thêm</a>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 76 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"

                    }
                }
                else
                {

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-lg-12\">\r\n                    <div class=\"pagination-area pt-10\">\r\n                        <nav aria-label=\"Page navigation example\">\r\n                            <ul class=\"pagination justify-content-center\">\r\n");
#nullable restore
#line 88 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
                                 if (PageCurrent > 1)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li class=\"page-item\">\r\n                                        <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 4233, "\"", 4273, 2);
            WriteAttributeValue("", 4240, "/blogs.html?page=", 4240, 17, true);
#nullable restore
#line 91 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
WriteAttributeValue("", 4257, PageCurrent-1, 4257, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-label=\"Previous\">\r\n                                            <span class=\"fa fa-chevron-left\"></span>\r\n                                        </a>\r\n                                    </li>\r\n");
#nullable restore
#line 95 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <li class=""page-item"">
                                        <a class=""page-link"" href=""/blogs.html"" aria-label=""Previous"">
                                            <span class=""fa fa-chevron-left""></span>
                                        </a>
                                    </li>
");
#nullable restore
#line 103 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"page-item active\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 5037, "\"", 5073, 2);
            WriteAttributeValue("", 5044, "/blogs.html?page=", 5044, 17, true);
#nullable restore
#line 104 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
WriteAttributeValue("", 5061, PageCurrent, 5061, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 104 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
                                                                                                                  Write(PageCurrent);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n                                <li class=\"page-item \"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 5173, "\"", 5206, 2);
            WriteAttributeValue("", 5180, "/blogs.html?page=", 5180, 17, true);
#nullable restore
#line 105 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
WriteAttributeValue("", 5197, PageNext, 5197, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 105 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
                                                                                                         Write(PageNext);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n                                <li class=\"page-item \">\r\n                                    <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 5341, "\"", 5374, 2);
            WriteAttributeValue("", 5348, "/blogs.html?page=", 5348, 17, true);
#nullable restore
#line 107 "D:\Agile\web-agile-hc-1\Views\Blog\Index.cshtml"
WriteAttributeValue("", 5365, PageNext, 5365, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" aria-label=""Next"">
                                        <span class=""fa fa-chevron-right""></span>
                                    </a>
                                </li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </div>
</main>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedList.Core.IPagedList<OnlineMarket.Models.Post>> Html { get; private set; }
    }
}
#pragma warning restore 1591
