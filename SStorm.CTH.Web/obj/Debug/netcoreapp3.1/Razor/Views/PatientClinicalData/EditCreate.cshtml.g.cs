#pragma checksum "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\PatientClinicalData\EditCreate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "828128b5897a6b5c2dded75e001746d9e735375d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PatientClinicalData_EditCreate), @"mvc.1.0.view", @"/Views/PatientClinicalData/EditCreate.cshtml")]
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
#line 2 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\PatientClinicalData\EditCreate.cshtml"
using SStorm.CTH.Web.Resources;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"828128b5897a6b5c2dded75e001746d9e735375d", @"/Views/PatientClinicalData/EditCreate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"665dbf0bb945a0251073fd268bdaca02f9e4cb26", @"/Views/_ViewImports.cshtml")]
    public class Views_PatientClinicalData_EditCreate : SStorm.CTH.Web.Infrastructure.BaseViewPage<SStorm.CTH.Web.Models.PatientClinicalDataModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_PatientDiagnosis", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Investigationlist", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_PatientSurgeryList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/ajax/jquery.unobtrusive-ajax.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\PatientClinicalData\EditCreate.cshtml"
Write(Html.SmartModal("modal-delete-entity", modalType: ModalType.Danger, backdrop: "true"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\PatientClinicalData\EditCreate.cshtml"
Write(Html.SmartModal("modal-add-entity", modalType: ModalType.Danger, backdrop: "true"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card\">\r\n    <div class=\"card-body\">\r\n\r\n        <div class=\"modal-body\">\r\n            <ul class=\"nav nav-tabs\" role=\"tablist\">\r\n");
#nullable restore
#line 11 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\PatientClinicalData\EditCreate.cshtml"
                 if (Authorize(UserPermission.Patient_Diagnosis))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <li class=""nav-item"">
                        <a class=""nav-link active"" id=""Diagnosis-tab"" data-toggle=""tab"" href=""#Diagnosis"" role=""tab"" aria-controls=""Diagnosis"" aria-selected=""false"">
                            <span class=""d-block d-sm-none""><i class=""fa fa-home""></i></span>
                            <span class=""d-none d-sm-block"">");
#nullable restore
#line 16 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\PatientClinicalData\EditCreate.cshtml"
                                                       Write(SharedLocalizer.GetLocalizedHtmlString("Diagnosis"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </a>\r\n                    </li>\r\n");
#nullable restore
#line 19 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\PatientClinicalData\EditCreate.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\PatientClinicalData\EditCreate.cshtml"
                 if (Authorize(UserPermission.Patient_ViewPatientInvestigations))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <li class=""nav-item"">
                        <a class=""nav-link"" id=""Investigation-tab"" data-toggle=""tab"" href=""#Investigation"" role=""tab"" aria-controls=""Investigation"" aria-selected=""true"">
                            <span class=""d-block d-sm-none""><i class=""fa fa-user""></i></span>
                            <span class=""d-none d-sm-block"">");
#nullable restore
#line 25 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\PatientClinicalData\EditCreate.cshtml"
                                                       Write(SharedLocalizer.GetLocalizedHtmlString("Investigation"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </a>\r\n                    </li>\r\n");
#nullable restore
#line 28 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\PatientClinicalData\EditCreate.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\PatientClinicalData\EditCreate.cshtml"
                 if (Authorize(UserPermission.Patient_ViewPatientSurgeries))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <li class=""nav-item"">
                        <a class=""nav-link"" id=""Surgery-tab"" data-toggle=""tab"" href=""#Surgery"" role=""tab"" aria-controls=""Surgery"" aria-selected=""true"">
                            <span class=""d-block d-sm-none""><i class=""fa fa-user""></i></span>
                            <span class=""d-none d-sm-block"">");
#nullable restore
#line 34 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\PatientClinicalData\EditCreate.cshtml"
                                                       Write(SharedLocalizer.GetLocalizedHtmlString("Surgery"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </a>\r\n                    </li>\r\n");
#nullable restore
#line 37 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\PatientClinicalData\EditCreate.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n\r\n\r\n            <div class=\"tab-content\">\r\n");
#nullable restore
#line 42 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\PatientClinicalData\EditCreate.cshtml"
                 if (Authorize(UserPermission.Patient_Diagnosis))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div id=\"Diagnosis\" class=\"tab-pane show active\" role=\"tabpanel\" aria-labelledby=\"Diagnosis-tab\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "828128b5897a6b5c2dded75e001746d9e735375d10436", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 45 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\PatientClinicalData\EditCreate.cshtml"
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
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 47 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\PatientClinicalData\EditCreate.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div id=\"Investigation\" class=\"tab-pane\" role=\"tabpanel\" aria-labelledby=\"Investigation-tab\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "828128b5897a6b5c2dded75e001746d9e735375d12402", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 49 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\PatientClinicalData\EditCreate.cshtml"
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
            WriteLiteral("\r\n                </div>\r\n\r\n                <div id=\"Surgery\" class=\"tab-pane\" role=\"tabpanel\" aria-labelledby=\"Surgery-tab\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "828128b5897a6b5c2dded75e001746d9e735375d14137", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 53 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\PatientClinicalData\EditCreate.cshtml"
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
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "828128b5897a6b5c2dded75e001746d9e735375d15807", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SStorm.CTH.Web.Models.PatientClinicalDataModel> Html { get; private set; }
    }
}
#pragma warning restore 1591