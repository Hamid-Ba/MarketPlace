#pragma checksum "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\User\Views\Ticket\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d3287d42b9d7622797bc8ddd1bb7033d73723359"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_Ticket_Detail), @"mvc.1.0.view", @"/Areas/User/Views/Ticket/Detail.cshtml")]
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
#line 1 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\User\Views\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\User\Views\_ViewImports.cshtml"
using ServiceHost.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\User\Views\Ticket\Detail.cshtml"
using MarketPlace.ApplicationContract.ViewModels.Tickets;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3287d42b9d7622797bc8ddd1bb7033d73723359", @"/Areas/User/Views/Ticket/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Areas/User/Views/_ViewImports.cshtml")]
    public class Areas_User_Views_Ticket_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MarketPlace.Query.Contract.Tickets.TicketQueryVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_UserAccountSideBarVM", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_AnswerTicketPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\User\Views\Ticket\Detail.cshtml"
  
    ViewData["Title"] = Model.Title;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"/css/ChatRoom.css\" />\r\n");
            }
            );
            WriteLiteral(@"


<div class=""breadcrumbs_area"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""breadcrumb_content"">
                    <ul>
                        <li><a href=""/"">????????</a></li>
                        <li>");
#nullable restore
#line 22 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\User\Views\Ticket\Detail.cshtml"
                       Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>


<section class=""main_content_area"">
    <div class=""container"">
        <div class=""account_dashboard"">
            <div class=""row"">
                <div class=""col-sm-12 col-md-3 col-lg-3"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d3287d42b9d7622797bc8ddd1bb7033d737233595565", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
                <div class=""col-sm-12 col-md-9 col-lg-9"">
                    <!-- Tab panes -->
                    <div class=""tab-content dashboard_content"">
                        <div class=""tab-pane fade active show"" id=""account-details"">
                            <h3>");
#nullable restore
#line 42 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\User\Views\Ticket\Detail.cshtml"
                           Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h3>\r\n\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d3287d42b9d7622797bc8ddd1bb7033d737233597318", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 44 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\User\Views\Ticket\Detail.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = (new AddMessageTicketVM{TicketId = Model.Id});

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                            <hr />\r\n                            <ul class=\"messages\" id=\"messages\">\r\n");
#nullable restore
#line 48 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\User\Views\Ticket\Detail.cshtml"
                                 if (Model.Messages != null && Model.Messages.Any())
                                {
                                    foreach (var message in Model.Messages)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li");
            BeginWriteAttribute("class", " class=\"", 1767, "\"", 1844, 3);
            WriteAttributeValue("", 1775, "message", 1775, 7, true);
#nullable restore
#line 52 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\User\Views\Ticket\Detail.cshtml"
WriteAttributeValue(" ", 1782, message.UserId == Model.UserId ? "right" : "left", 1783, 52, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1835, "appeared", 1836, 9, true);
            EndWriteAttribute();
            WriteLiteral(@">
                                            <div class=""avatar"">
                                                <img src=""/img/avatar.jpg"" alt=""Alternate Text"">
                                            </div>
                                            <div class=""text_wrapper"">
                                                <div class=""time"">
                                                    ");
#nullable restore
#line 58 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\User\Views\Ticket\Detail.cshtml"
                                               Write(message.SentDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </div>\r\n                                                <div class=\"text\" style=\"font-size: 16px\">\r\n                                                    ");
#nullable restore
#line 61 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\User\Views\Ticket\Detail.cshtml"
                                               Write(Html.Raw(message.Text));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </div>\r\n                                            </div>\r\n                                        </li>\r\n");
#nullable restore
#line 65 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\User\Views\Ticket\Detail.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </ul>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MarketPlace.Query.Contract.Tickets.TicketQueryVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
