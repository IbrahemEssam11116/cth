#pragma checksum "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1abaad7dcbc8c5ce8c599b1cc910e4c4427abf0a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SpecialCasePart_Index), @"mvc.1.0.view", @"/Views/SpecialCasePart/Index.cshtml")]
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
#line 5 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
using SStorm.CTH.Web.Resources;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
using Microsoft.AspNetCore.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1abaad7dcbc8c5ce8c599b1cc910e4c4427abf0a", @"/Views/SpecialCasePart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"665dbf0bb945a0251073fd268bdaca02f9e4cb26", @"/Views/_ViewImports.cshtml")]
    public class Views_SpecialCasePart_Index : SStorm.CTH.Web.Infrastructure.BaseViewPage<SStorm.CTH.DAL.EntityClasses.CTHSpecialCaseEntity>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "SpecialCase", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary waves-effect"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 6 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
  
    var requestCulture = Context.Features.Get<IRequestCultureFeature>();
    ViewData["Title"] = @SharedLocalizer.GetLocalizedHtmlString("SpecialCasePartList");

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
Write(Html.SmartModal("modal-delete-entity", modalType: ModalType.Danger, backdrop: "true"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 11 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
Write(Html.SmartModal("modal-add-entity", modalType: ModalType.Danger, backdrop: "true"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">

    <!-- start page title -->
    <div class=""row"">
        <div class=""col-12"">
            <div class=""page-title-box"">
                <div class=""page-title-right"">
                    <ol class=""breadcrumb m-0"">
                        <li class=""breadcrumb-item""><a href=""javascript: void(0);"">");
#nullable restore
#line 20 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                                                              Write(SharedLocalizer.GetLocalizedHtmlString("SpecialCasePartList"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n                        <li class=\"breadcrumb-item active\">");
#nullable restore
#line 21 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                                      Write(SharedLocalizer.GetLocalizedHtmlString("SpecialCasePartList"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    </ol>\r\n                </div>\r\n                <h4 class=\"page-title\">");
#nullable restore
#line 24 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                  Write(SharedLocalizer.GetLocalizedHtmlString("Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <!-- end page title -->\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-12\">\r\n");
#nullable restore
#line 32 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
             if (Authorize(UserPermission.SpecialCase_EditCreatePart))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a href=\"#modal-add-entity\" data-toggle=\"modal\"\r\n                   data-url=\"");
#nullable restore
#line 35 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                        Write(Url.Action("EditCreate", "SpecialCasePart", new { ID = 0, CaseID = Model.ID}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n                   data-modalsize=\"modal-lg\"\r\n                   data-modalcolor=\"hmodal-danger\" class=\"btn btn-info\">\r\n                    <i class=\"fas fa-plus\"></i> ");
#nullable restore
#line 38 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                           Write(SharedLocalizer.GetLocalizedHtmlString("NewPart"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </a>\r\n");
#nullable restore
#line 40 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            <div class=""card"">
                <div class=""card-body"">


                    <div class=""table-responsive"">
                        <table class=""table m-0 table-hover"">
                            <thead class=""btn-info text-white"">
                                <tr>
                                    <th colspan=""4"">
                                        ");
#nullable restore
#line 51 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                   Write(SharedLocalizer.GetLocalizedHtmlString("SpecialCaseName"));

#line default
#line hidden
#nullable disable
            WriteLiteral(": ");
#nullable restore
#line 51 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                                                                               Write(Model.CaseName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </th>\r\n                                </tr>\r\n                                <tr>\r\n                                    <th>#</th>\r\n                                    <th>");
#nullable restore
#line 56 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                   Write(SharedLocalizer.GetLocalizedHtmlString("Part"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <th>");
#nullable restore
#line 57 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                   Write(SharedLocalizer.GetLocalizedHtmlString("Remarks"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <th>");
#nullable restore
#line 58 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                   Write(SharedLocalizer.GetLocalizedHtmlString("Actions"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n\r\n                                </tr>\r\n                            </thead>\r\n                            <tbody>\r\n");
#nullable restore
#line 63 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                 if (Model.CTHSpecialCasePartCollection.Count() == 0)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <th scope=\"row\" colspan=\"7\">");
#nullable restore
#line 66 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                                               Write(SharedLocalizer.GetLocalizedHtmlString("NoData"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    </tr>\r\n");
#nullable restore
#line 68 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                 for (int i = 0; i < Model.CTHSpecialCasePartCollection.Count(); i++)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <th scope=\"row\">");
#nullable restore
#line 72 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                                        Write(i + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                            <td>");
#nullable restore
#line 73 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                           Write(Model.CTHSpecialCasePartCollection[i].PartName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 74 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                           Write(Model.CTHSpecialCasePartCollection[i].Remarks);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>\r\n");
#nullable restore
#line 76 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                                 if (Authorize(UserPermission.SpecialCase_EditCreatePart))
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <a href=\"#modal-add-entity\" data-toggle=\"modal\"\r\n                                                       data-url=\"");
#nullable restore
#line 79 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                                            Write(Url.Action("EditCreate", "SpecialCasePart", new { ID = Model.CTHSpecialCasePartCollection[i].ID, CaseID = Model.ID}));

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
#line 84 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 85 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                                 if (Authorize(UserPermission.SpecialCase_DeletePart))
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <a href=\"#modal-delete-entity\" data-toggle=\"modal\"\r\n                                                       data-url=\"");
#nullable restore
#line 88 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                                            Write(Url.Action("Delete", "SpecialCasePart", new { ID = @Model.CTHSpecialCasePartCollection[i].ID}));

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
#line 93 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 96 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n\r\n                    <div class=\"modal-footer\">\r\n");
#nullable restore
#line 102 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                         if (Authorize(UserPermission.SpecialCase_View))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1abaad7dcbc8c5ce8c599b1cc910e4c4427abf0a17484", async() => {
#nullable restore
#line 104 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                                                                                                                 Write(SharedLocalizer.GetLocalizedHtmlString("Back"));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 105 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\SpecialCasePart\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SStorm.CTH.DAL.EntityClasses.CTHSpecialCaseEntity> Html { get; private set; }
    }
}
#pragma warning restore 1591
