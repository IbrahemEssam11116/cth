#pragma checksum "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "564cb6525f64b86fb4ccab2b6fd51af41750486e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Staging_Index), @"mvc.1.0.view", @"/Views/Staging/Index.cshtml")]
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
#line 1 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\_ViewImports.cshtml"
using SStorm.CTH.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\_ViewImports.cshtml"
using SStorm.CTH.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\_ViewImports.cshtml"
using SStorm.CTH.Web.TagHelpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
using SStorm.CTH.Web.Resources;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"564cb6525f64b86fb4ccab2b6fd51af41750486e", @"/Views/Staging/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"665dbf0bb945a0251073fd268bdaca02f9e4cb26", @"/Views/_ViewImports.cshtml")]
    public class Views_Staging_Index : SStorm.CTH.Web.Infrastructure.BaseViewPage<SStorm.CTH.DAL.HelperClasses.EntityCollection<SStorm.CTH.DAL.EntityClasses.CTHStagingEntity>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "StagingMatrix", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 4 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
  
    ViewData["Title"] = @SharedLocalizer.GetLocalizedHtmlString("EditCreate");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
Write(Html.SmartModal("modal-delete-entity", modalType: ModalType.Danger, backdrop: "true"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
Write(Html.SmartModal("modal-add-entity", modalType: ModalType.Danger, backdrop: "true"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<!-- start page title -->
<div class=""row"">
    <div class=""col-12"">
        <div class=""page-title-box"">
            <div class=""page-title-right"">
                <ol class=""breadcrumb m-0"">
                    <li class=""breadcrumb-item""><a href=""javascript: void(0);"">");
#nullable restore
#line 17 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                                                          Write(SharedLocalizer.GetLocalizedHtmlString("Staging"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n                    <li class=\"breadcrumb-item active\">");
#nullable restore
#line 18 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                                  Write(SharedLocalizer.GetLocalizedHtmlString("Staging"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                </ol>\r\n            </div>\r\n            <h4 class=\"page-title\">");
#nullable restore
#line 21 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                              Write(SharedLocalizer.GetLocalizedHtmlString("Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
        </div>
    </div>
</div>
<!-- end page title -->
<div class=""card"">
    <div class=""card-body"">
        <div class=""modal-body"">
            <ul class=""nav nav-tabs"" role=""tablist"">
                <li class=""nav-item"">
                    <a class=""nav-link active"" id=""StagingList-tab"" data-toggle=""tab"" href=""#StagingList"" role=""tab"" aria-controls=""StagingList"" aria-selected=""false"">
                        <span class=""d-block d-sm-none""><i class=""fa fa-home""></i></span>
                        <span class=""d-none d-sm-block"">");
#nullable restore
#line 33 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                                   Write(SharedLocalizer.GetLocalizedHtmlString("StagingList"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                    </a>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link"" id=""StagingMatrix-tab"" data-toggle=""tab"" href=""#StagingMatrix"" role=""tab"" aria-controls=""StagingMatrix"" aria-selected=""true"">
                        <span class=""d-block d-sm-none""><i class=""fa fa-user""></i></span>
                        <span class=""d-none d-sm-block"">");
#nullable restore
#line 39 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                                   Write(SharedLocalizer.GetLocalizedHtmlString("StagingMatrix"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                    </a>
                </li>

            </ul>
            <div class=""tab-content"">
                <div id=""StagingList"" class=""tab-pane show active"" role=""tabpanel"" aria-labelledby=""StagingList-tab"">
                    <div class=""card"">
                        <div class=""card-body"">
");
#nullable restore
#line 48 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                             if (Authorize(UserPermission.TNMStaging_EditCreateStaging))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a href=\"#modal-add-entity\" data-toggle=\"modal\"\r\n                               data-url=\"");
#nullable restore
#line 51 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                    Write(Url.Action("EditCreate", "Staging", new { ID = 0}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n                               data-modalsize=\"modal-lg\"\r\n                               data-modalcolor=\"hmodal-danger\" class=\"btn btn-info\">\r\n                                <i class=\"fas fa-plus\"></i> ");
#nullable restore
#line 54 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                                       Write(SharedLocalizer.GetLocalizedHtmlString("NewStaging"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </a>\r\n");
#nullable restore
#line 56 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""table-responsive"">
                                <table class=""table m-0 table-colored-bordered table-bordered-info table-bordered table-hover"">
                                    <thead>
                                        <tr>
                                            <th>");
#nullable restore
#line 61 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                           Write(SharedLocalizer.GetLocalizedHtmlString("Name"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                            <th>");
#nullable restore
#line 62 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                           Write(SharedLocalizer.GetLocalizedHtmlString("Number"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                            <th>");
#nullable restore
#line 63 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                           Write(SharedLocalizer.GetLocalizedHtmlString("Remarks"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                            <th>");
#nullable restore
#line 64 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                           Write(SharedLocalizer.GetLocalizedHtmlString("Actions"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n\r\n                                        </tr>\r\n                                    </thead>\r\n                                    <tbody>\r\n");
#nullable restore
#line 69 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                         if (Model.Count() == 0)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <th scope=\"row\" colspan=\"7\">");
#nullable restore
#line 72 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                                                       Write(SharedLocalizer.GetLocalizedHtmlString("NoData"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                            </tr>\r\n");
#nullable restore
#line 74 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                         for (int i = 0; i < Model.Count(); i++)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td>");
#nullable restore
#line 78 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                               Write(Model[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 79 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                               Write(Model[i].Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 80 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                               Write(Model[i].Remarks);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>\r\n");
#nullable restore
#line 82 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                                     if (Authorize(UserPermission.TNMStaging_EditCreateStaging))
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <a href=\"#modal-add-entity\" data-toggle=\"modal\"\r\n                                                           data-url=\"");
#nullable restore
#line 85 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                                                Write(Url.Action("EditCreate", "Staging", new { ID = @Model[i].ID}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""
                                                           data-modalsize=""modal-lg""
                                                           data-modalcolor=""hmodal-danger"" class=""btn btn-info"">
                                                            <i class=""fas fa-edit""></i>
                                                        </a>
");
#nullable restore
#line 90 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 91 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                                     if (Authorize(UserPermission.TNMStaging_DeleteStaging))
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <a href=\"#modal-delete-entity\" data-toggle=\"modal\"\r\n                                                           data-url=\"");
#nullable restore
#line 94 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                                                Write(Url.Action("Delete", "Staging", new { ID = @Model[i].ID}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""
                                                           data-modalsize=""modal-lg""
                                                           data-modalcolor=""hmodal-danger"" class=""btn btn-danger"">
                                                            <i class=""fas fa-times""></i>
                                                        </a>
");
#nullable restore
#line 99 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                </td>\r\n                                            </tr>\r\n");
#nullable restore
#line 102 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </tbody>
                                </table>
                            </div>

                        </div>
                    </div>

                </div>

                <div id=""StagingMatrix"" class=""tab-pane"" role=""tabpanel"" aria-labelledby=""N-tab"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "564cb6525f64b86fb4ccab2b6fd51af41750486e17476", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 114 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Staging\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

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
            WriteLiteral("\r\n                </div>\r\n\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public LocService SharedLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHtmlLocalizer<SharedResource> SharedHtmlLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SStorm.CTH.DAL.HelperClasses.EntityCollection<SStorm.CTH.DAL.EntityClasses.CTHStagingEntity>> Html { get; private set; }
    }
}
#pragma warning restore 1591