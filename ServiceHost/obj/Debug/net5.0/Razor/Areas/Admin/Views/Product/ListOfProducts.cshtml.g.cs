#pragma checksum "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "707c8cd3011e09d78aa2c60f34322d198392b3f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Product_ListOfProducts), @"mvc.1.0.view", @"/Areas/Admin/Views/Product/ListOfProducts.cshtml")]
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
#line 1 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\_ViewImports.cshtml"
using ServiceHost.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
using Framework.Application;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"707c8cd3011e09d78aa2c60f34322d198392b3f5", @"/Areas/Admin/Views/Product/ListOfProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Product_ListOfProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MarketPlace.ApplicationContract.ViewModels.ProductAgg.AdminProductVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/AdminTheme/assets/datatables/jquery.dataTables.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/AdminTheme/assets/datatables/dataTables.bootstrap.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
  
    ViewData["Title"] = "?????????????? ?????? ?????? ??????????";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-sm-12\">\r\n        <h4 class=\"page-title pull-right\">");
#nullable restore
#line 10 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                     Write(ViewData["title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
    </div>
</div>

<div class=""row"" id=""ProductCategoriesDiv"">
    <div class=""col-md-12"">
        <div class=""panel panel-default"">
            <div class=""panel-heading"">
                <h3 class=""panel-title"">???????? ?????????????? ????</h3>
            </div>
            <div class=""panel-body"">
                <div class=""row"">
                    <div class=""col-md-12 col-sm-12 col-xs-12"">
                        <table id=""datatable"" class=""table table-striped table-bordered"">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>?????? ??????????????</th>
                                    <th>?????? ??????????</th>
                                    <th>?????????? ??????????</th>
                                    <th>???????? ??????????</th>
                                    <th>???????? ??????????(??????????)</th>
                                    <th>??????????</th>
                                    <th>????????????</th>
     ");
            WriteLiteral("                           </tr>\r\n                            </thead>\r\n                            <tbody>\r\n");
#nullable restore
#line 37 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                 foreach (var entity in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr class=\"text-center\">\r\n                                        <td>");
#nullable restore
#line 40 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                       Write(entity.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 41 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                       Write(entity.OwnerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 42 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                       Write(entity.StoreName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 43 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                       Write(entity.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n");
#nullable restore
#line 45 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                             foreach (var cat in entity.CategoriesName)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <p class=\"badge badge-info\">");
#nullable restore
#line 47 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                                                       Write(cat);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 48 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </td>\r\n                                        <td>");
#nullable restore
#line 50 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                       Write(entity.Price.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n");
#nullable restore
#line 52 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                             switch (entity.State)
                                            {
                                                case ProductAcceptanceState.Accepted:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <p class=\"badge badge-success\">");
#nullable restore
#line 55 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                                                              Write(entity.State.GetEnumName());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 56 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                                    break;

                                                case ProductAcceptanceState.Rejected:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <p class=\"badge badge-danger\">");
#nullable restore
#line 59 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                                                             Write(entity.State.GetEnumName());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 60 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                                    break;

                                                case ProductAcceptanceState.UnderProgress:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <p class=\"badge badge-warning\">");
#nullable restore
#line 63 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                                                              Write(entity.State.GetEnumName());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 64 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                                    break;
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </td>\r\n                                        <td class=\"text-center\">\r\n\r\n");
#nullable restore
#line 69 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                             if (entity.State == ProductAcceptanceState.UnderProgress)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <a class=\"btn btn-success\"");
            BeginWriteAttribute("href", "\r\n                                                   href=\"", 3687, "\"", 3827, 2);
            WriteAttributeValue("", 3746, "#showmodal=", 3746, 11, true);
#nullable restore
#line 72 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
WriteAttributeValue("", 3757, Url.Action("Confirm", "Product",new {id = entity.Id , area= "Admin"}), 3757, 70, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                    <i class=\"fa fa-thumbs-up\"></i>\r\n                                                </a>\r\n");
            WriteLiteral("                                                <a class=\"btn btn-danger\"");
            BeginWriteAttribute("href", "\r\n                                                   href=\"", 4045, "\"", 4189, 2);
            WriteAttributeValue("", 4104, "#showmodal=", 4104, 11, true);
#nullable restore
#line 77 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
WriteAttributeValue("", 4115, Url.Action("DissConfirm", "Product",new {id = entity.Id , area= "Admin"}), 4115, 74, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                    <i class=\"fa fa-thumbs-down\"></i>\r\n                                                </a>\r\n");
#nullable restore
#line 80 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                            }

                                            else if (entity.State == ProductAcceptanceState.Accepted)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <a class=\"btn btn-danger\"");
            BeginWriteAttribute("href", "\r\n                                                   href=\"", 4606, "\"", 4750, 2);
            WriteAttributeValue("", 4665, "#showmodal=", 4665, 11, true);
#nullable restore
#line 85 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
WriteAttributeValue("", 4676, Url.Action("DissConfirm", "Product",new {id = entity.Id , area= "Admin"}), 4676, 74, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                    <i class=\"fa fa-thumbs-down\"></i>\r\n                                                </a>\r\n");
#nullable restore
#line 88 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                            }

                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <a class=\"btn btn-success\"");
            BeginWriteAttribute("href", "\r\n                                                   href=\"", 5115, "\"", 5255, 2);
            WriteAttributeValue("", 5174, "#showmodal=", 5174, 11, true);
#nullable restore
#line 93 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
WriteAttributeValue("", 5185, Url.Action("Confirm", "Product",new {id = entity.Id , area= "Admin"}), 5185, 70, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                    <i class=\"fa fa-thumbs-up\"></i>\r\n                                                </a>\r\n");
#nullable restore
#line 96 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 100 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Product\ListOfProducts.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "707c8cd3011e09d78aa2c60f34322d198392b3f518235", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "707c8cd3011e09d78aa2c60f34322d198392b3f519335", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    <script type=\"text/javascript\">\r\n        $(document).ready(function () {\r\n            $(\'#datatable\').dataTable();\r\n        });\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MarketPlace.ApplicationContract.ViewModels.ProductAgg.AdminProductVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
