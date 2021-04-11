#pragma checksum "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a5f3f0c95b13434febd9cbf24d86ef4a4f59309"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Accounting_Views_Organization_Details), @"mvc.1.0.view", @"/Areas/Accounting/Views/Organization/Details.cshtml")]
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
#line 1 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\_ViewImports.cshtml"
using UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\_ViewImports.cshtml"
using UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\_ViewImports.cshtml"
using Repository.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a5f3f0c95b13434febd9cbf24d86ef4a4f59309", @"/Areas/Accounting/Views/Organization/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4895d6d79eac560d5355b745554ec89d304b76f7", @"/Areas/Accounting/_ViewImports.cshtml")]
    public class Areas_Accounting_Views_Organization_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Report>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Organization", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
  
    ViewData["Title"] = "Organization Report";
    Layout = "~/Areas/Accounting/Views/Shared/AccountingLayout.cshtml";

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
                        <span class=""text-secondary"">Organization: </span> <span>");
#nullable restore
#line 14 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                                                                            Write(Model.Organization.OrganizationName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> - <span class=\"text-secondary\">Budget: </span> <span>");
#nullable restore
#line 14 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                                                                                                                                                                             Write(Model.Budget.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL</span>\r\n                    </div>\r\n                    <div class=\"col-md-6\">\r\n                        <span class=\"text-secondary\">Location:</span> <span >");
#nullable restore
#line 17 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                                                                        Write(Model.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-3 text-right\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a5f3f0c95b13434febd9cbf24d86ef4a4f593096778", async() => {
                WriteLiteral("Back to Org. List");
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

    <div class=""card-body"">
        <table id=""organizationDetailTable"" class=""table table-striped table-responsive"">
            <thead>
                <tr>
                    <th>Model Name</th>
                    <th>Model Surname</th>
                    <th>Model Category</th>
                    <th>Days</th>
                    <th>Accommodation</th>
                    <th>Food</th>
                    <th>Wage</th>
                    <th>Total Payment</th>
                    <th>Total Expense</th>
                    
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 43 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                 foreach (var item in Model.Organization.Models)
                {
                   

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>                        \r\n                        <td>");
#nullable restore
#line 47 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                       Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 48 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                       Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 49 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                       Write(item.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 50 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                       Write(Model.Organization.NumberOfDays);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                          ");
#nullable restore
#line 52 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                     Write(Model.Accommodation);

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 55 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                       Write(Model.Food);

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL\r\n                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 58 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                             if (item.Category == Domain.Enums.ModelCategory.One)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                           Write(Model.Wage1);

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                                            
                            }
                            else if (item.Category == Domain.Enums.ModelCategory.Two)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                           Write(Model.Wage2);

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                                            
                            }
                            else if (item.Category == Domain.Enums.ModelCategory.Three)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                           Write(Model.Wage3.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                                                                 
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            TL\r\n                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 73 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                             if (item.Category == Domain.Enums.ModelCategory.One)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                           Write(Model.Wage1Total);

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                                                 
                            }
                            else if (item.Category == Domain.Enums.ModelCategory.Two)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 79 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                           Write(Model.Wage2Total);

#line default
#line hidden
#nullable disable
#nullable restore
#line 79 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                                                 
                            }
                            else if (item.Category == Domain.Enums.ModelCategory.Three)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 83 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                           Write(Model.Wage3.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 83 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                                                                 
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            TL\r\n                        </td>\r\n                        <td class=\"text-right\">\r\n                            ");
#nullable restore
#line 88 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                       Write(Model.Expense);

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 91 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td colspan=\"7\" class=\"text-right text-bold\">\r\n                            Total\r\n                        </td>\r\n                        <td>");
#nullable restore
#line 97 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                       Write(Model.TotalWage.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL</td>\r\n                        <td class=\"text-right\">");
#nullable restore
#line 98 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                                          Write(Model.TotalExpense);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" TL</td>
                    </tr>
                       <tr>
                           <td colspan=""7"" class=""text-right text-bold"">
                               General Total
                           </td>
                           <td colspan=""2"" class=""text-right"">
                                ");
#nullable restore
#line 105 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                           Write(Model.TotalExpenseAndWage.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" TL
                           </td>
                      </tr>
                <tr>
                    <td colspan=""6"" class=""text-primary text-right"">
                        Revenue
                    </td>
                    <td colspan=""3"" class=""text-right"">
                        ");
#nullable restore
#line 113 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                   Write(Model.Budget.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 113 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                                                        Write(Model.TotalExpenseAndWage.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" = ");
#nullable restore
#line 113 "C:\Users\Tayfun\Documents\.NET EĞİTİM\.NET Bitirme Projesi\OrganizationAgencyWebApplication\UI\Areas\Accounting\Views\Organization\Details.cshtml"
                                                                                                          Write(Model.Revenue.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL\r\n                    </td>\r\n                </tr>\r\n\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n\r\n        $(document).ready(function () {\r\n            $(\'#organizationDetailTable\').DataTable();\r\n        });\r\n\r\n    </script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Report> Html { get; private set; }
    }
}
#pragma warning restore 1591