#pragma checksum "c:\Users\admin\Documents\GitHub\Project\Project\Presentation\Pages\Process.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99bd67e7977f11d50b386fb496cc64bdf8589858"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Presentation.Pages.Pages_Process), @"mvc.1.0.razor-page", @"/Pages/Process.cshtml")]
namespace Presentation.Pages
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
#line 1 "c:\Users\admin\Documents\GitHub\Project\Project\Presentation\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "c:\Users\admin\Documents\GitHub\Project\Project\Presentation\Pages\_ViewImports.cshtml"
using Presentation;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99bd67e7977f11d50b386fb496cc64bdf8589858", @"/Pages/Process.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"125d785150303032fe93770293060c6b82d9a3de", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Process : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "c:\Users\admin\Documents\GitHub\Project\Project\Presentation\Pages\Process.cshtml"
  
    ViewData["Title"] = "Quy Trình";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""section-welcome bg1-pattern p-t-120 p-b-105"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-md-6 p-t-45 p-b-30"">
                    <div class=""wrap-text-welcome t-center"">
                        <span class=""tit2 t-center"">
                            Quy trình đặt lịch khám chữa bệnh
                        </span>

                        <p class=""t-center m-b-22 size3 m-l-r-auto"">
                              Bước 1: Đặt Lịch Khám.<br>
                              Bước 2: Thanh toán tiền khám.<br>
                              Bước 3: Xác nhận người bệnh đến bệnh viện khám theo lịch hẹn.<br>
                              Bước 4: Khám và thực hiện cận lâm sàng.<br>
                              Bước 5: Nhận Thuốc.<br>
                        </p>
                    </div>
                </div>

                <div class=""col-md-6 p-b-30"">
                    <div class=""wrap-pic-welcome size2 bo-rad-10 hov-img-zoo");
            WriteLiteral("m m-l-r-auto\">\r\n                        <img src=\"images/qtkb.jpg\">\r\n                        \r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n \r\n\r\n    \r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProcessModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ProcessModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ProcessModel>)PageContext?.ViewData;
        public ProcessModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
