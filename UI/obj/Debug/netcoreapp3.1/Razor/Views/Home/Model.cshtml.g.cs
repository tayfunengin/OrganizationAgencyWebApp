#pragma checksum "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Views\Home\Model.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb4de6f4a82767caba6f59932db4e1e31fff27e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Model), @"mvc.1.0.view", @"/Views/Home/Model.cshtml")]
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
#line 1 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Views\_ViewImports.cshtml"
using UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Views\_ViewImports.cshtml"
using UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Views\_ViewImports.cshtml"
using Repository.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Views\_ViewImports.cshtml"
using Repository.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Views\_ViewImports.cshtml"
using Repository.Authentication;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb4de6f4a82767caba6f59932db4e1e31fff27e1", @"/Views/Home/Model.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f9a20f0100038127e79d504f2e06fa39d0ecd29", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Model : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Model>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ModelDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Views\Home\Model.cshtml"
  
    ViewData["Title"] = "Model";
    Layout = "~/Views/Shared/_Layout.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"jumbotron\" style=\"background: aliceblue\";>\r\n\r\n    <div class=\"container mt-4\">\r\n        <h4>Our Models</h4>\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n<div class=\"container model\">\r\n\r\n    <div class=\"row\">\r\n\r\n");
#nullable restore
#line 21 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Views\Home\Model.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card col-sm-6 col-md-4 col-lg-3\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 444, "\"", 491, 2);
            WriteAttributeValue("", 450, "/images/modelImage/", 450, 19, true);
#nullable restore
#line 24 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Views\Home\Model.cshtml"
WriteAttributeValue("", 469, item.ProfilePhotoPath, 469, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 492, "\"", 498, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top img-thumbnail h-50 modelProfile\">\r\n            <div class=\"card-header\">\r\n                <h4 class=\"card-title\">");
#nullable restore
#line 26 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Views\Home\Model.cshtml"
                                  Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 26 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Views\Home\Model.cshtml"
                                                  Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n            </div>\r\n            <div class=\"card-body\">\r\n                <ul class=\"list-group\">\r\n                    <li class=\"list-group-item\">Height: ");
#nullable restore
#line 30 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Views\Home\Model.cshtml"
                                                   Write(item.Height);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\">Weight: ");
#nullable restore
#line 31 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Views\Home\Model.cshtml"
                                                   Write(item.Weight);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\">Eye Color: ");
#nullable restore
#line 32 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Views\Home\Model.cshtml"
                                                      Write(item.EyeColor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\">Hair Color: ");
#nullable restore
#line 33 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Views\Home\Model.cshtml"
                                                       Write(item.HairColor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\">Body Size: ");
#nullable restore
#line 34 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Views\Home\Model.cshtml"
                                                      Write(item.BodySize);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                </ul>\r\n            </div>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb4de6f4a82767caba6f59932db4e1e31fff27e18802", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 37 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Views\Home\Model.cshtml"
                                                                   WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("         \r\n        </div>        \r\n");
#nullable restore
#line 39 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Views\Home\Model.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Model>> Html { get; private set; }
    }
}
#pragma warning restore 1591
