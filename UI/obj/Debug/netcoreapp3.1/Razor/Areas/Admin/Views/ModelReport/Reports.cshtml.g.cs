#pragma checksum "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e5e091bf665947a4ab57987aada41c99b2728e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_ModelReport_Reports), @"mvc.1.0.view", @"/Areas/Admin/Views/ModelReport/Reports.cshtml")]
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
#line 1 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\_ViewImports.cshtml"
using UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\_ViewImports.cshtml"
using UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\_ViewImports.cshtml"
using Repository.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\_ViewImports.cshtml"
using Repository.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\_ViewImports.cshtml"
using Repository.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e5e091bf665947a4ab57987aada41c99b2728e5", @"/Areas/Admin/Views/ModelReport/Reports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee23a8b4e6a3b041029a40fb010478124b34d22b", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_ModelReport_Reports : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Report>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ModelReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
  
    ViewData["Title"] = "Reports";
    Layout = "~/Areas/Admin/Views/Shared/AdminLayout.cshtml";

    Model entityModel = TempData["model"] as Model;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""card"">
    <div class=""card-header"">
        <div class=""row"">
            <div class=""col-md-9"">
                <div class=""row"">
                    <div class=""col-md-6"">
                        <span class=""text-secondary"">First Name: </span> <span>");
#nullable restore
#line 15 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
                                                                          Write(entityModel.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> - <span class=\"text-secondary\">Last Name: </span> <span>");
#nullable restore
#line 15 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
                                                                                                                                                                Write(entityModel.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n                    <div class=\"col-md-6\">\r\n                        <span class=\"text-secondary\">Category:</span> <span>");
#nullable restore
#line 18 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
                                                                       Write(entityModel.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-3 text-right\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0e5e091bf665947a4ab57987aada41c99b2728e57465", async() => {
                WriteLiteral("Back to Model List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div>
    <div class=""card-body"">
        <table id=""organizationTable"" class=""table table-striped table-responsive"">
            <thead>
                <tr>

                    <th>Organization Name</th>
                    <th>Start Date</th>
                    <th>End Date</th>
                    <th>Location</th>
                    <th>Org. Revenue</th>
                    <th>Days</th>
                    <th>Paid to Model</th>
                    <th>Org. Status</th>

                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 44 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
                 foreach (var report in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 49 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
                       Write(Html.ActionLink(report.Organization.OrganizationName, "Details", "Organization", new { id = report.Organization.ID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>");
#nullable restore
#line 51 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
                       Write(report.Organization.StartDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 52 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
                       Write(report.Organization.EndDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 53 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
                       Write(report.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 54 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
                       Write(report.Revenue.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL</td>\r\n                        <td>");
#nullable restore
#line 55 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
                       Write(report.Organization.NumberOfDays);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n");
#nullable restore
#line 57 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
                             if (entityModel.Category == Domain.Enums.ModelCategory.One)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
                           Write(report.Wage1Total);

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
                                                  
                            }
                            else if (entityModel.Category == Domain.Enums.ModelCategory.Two)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
                           Write(report.Wage2Total);

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
                                                  
                            }
                            else if (entityModel.Category == Domain.Enums.ModelCategory.Three)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
                           Write(report.Wage3.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
                                                                  
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            TL\r\n                        </td>\r\n                        <td>");
#nullable restore
#line 71 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
                       Write(report.Organization.OrgStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 73 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Admin\Views\ModelReport\Reports.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Report>> Html { get; private set; }
    }
}
#pragma warning restore 1591
