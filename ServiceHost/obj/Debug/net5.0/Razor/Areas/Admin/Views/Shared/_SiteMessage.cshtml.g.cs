#pragma checksum "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Shared\_SiteMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17bdc4f97ab4538c911e6f9df38dbca221a50e45"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared__SiteMessage), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_SiteMessage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17bdc4f97ab4538c911e6f9df38dbca221a50e45", @"/Areas/Admin/Views/Shared/_SiteMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared__SiteMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Shared\_SiteMessage.cshtml"
 if (
    TempData["SuccessMessage"] != null ||
    TempData["ErrorMessage"] != null ||
    TempData["InfoMessage"] != null ||
    TempData["WarningMessage"] != null
    )
{
    if (TempData["SuccessMessage"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n            $(document).ready(function () {\r\n                ShowMessage(\'?????????? ????????????\', \'");
#nullable restore
#line 12 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Shared\_SiteMessage.cshtml"
                                        Write(TempData["SuccessMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'success\');\r\n            });\r\n        </script>\r\n");
#nullable restore
#line 15 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Shared\_SiteMessage.cshtml"
    }

    if (TempData["ErrorMessage"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n            $(document).ready(function () {\r\n                ShowMessage(\'?????????? ??????\', \'");
#nullable restore
#line 21 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Shared\_SiteMessage.cshtml"
                                     Write(TempData["ErrorMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'error\');\r\n            });\r\n        </script>\r\n");
#nullable restore
#line 24 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Shared\_SiteMessage.cshtml"
    }

    if (TempData["WarningMessage"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n            $(document).ready(function () {\r\n                ShowMessage(\'?????????? ??????????\', \'");
#nullable restore
#line 30 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Shared\_SiteMessage.cshtml"
                                       Write(TempData["WarningMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'warning\');\r\n            });\r\n        </script>\r\n");
#nullable restore
#line 33 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Shared\_SiteMessage.cshtml"
    }

    if (TempData["InfoMessage"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n            $(document).ready(function () {\r\n                ShowMessage(\'?????????? ??????????????\', \'");
#nullable restore
#line 39 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Shared\_SiteMessage.cshtml"
                                         Write(TempData["InfoMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'info\');\r\n            });\r\n        </script>\r\n");
#nullable restore
#line 42 "C:\Users\DANESH\Documents\Visual Studio 2019\Projects\MarketPlace\ServiceHost\Areas\Admin\Views\Shared\_SiteMessage.cshtml"
    }
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
