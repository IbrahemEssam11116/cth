#pragma checksum "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2a2caebc36c023470f7f87771abb97b48ec369b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Patient__ChemoSessionList), @"mvc.1.0.view", @"/Views/Patient/_ChemoSessionList.cshtml")]
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
#line 2 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
using SStorm.CTH.Web.Resources;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2a2caebc36c023470f7f87771abb97b48ec369b", @"/Views/Patient/_ChemoSessionList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"665dbf0bb945a0251073fd268bdaca02f9e4cb26", @"/Views/_ViewImports.cshtml")]
    public class Views_Patient__ChemoSessionList : SStorm.CTH.Web.Infrastructure.BaseViewPage<SStorm.CTH.Web.Models.PatientModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "PatientClinicalData", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditCreateKimoSurvey", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-ID", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Discharge", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DischargeNote", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ChemotherapySheet", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PrintOutSheet", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
  
    var i = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
Write(Html.SmartModal("modal-delete-entity", modalType: ModalType.Danger, backdrop: "true"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-12\">\r\n            <div class=\"table-responsive\">\r\n                <a href=\"#\" id=\"KimoBtn\"><h4>");
#nullable restore
#line 12 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                        Write(SharedLocalizer.GetLocalizedHtmlString("ChemicalSurveySessions"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4></a>\r\n");
#nullable restore
#line 13 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                 if (Authorize(UserPermission.Patient_EditCreateChemo))
                {
                    if (Model.PatientEntity.CTHPatientClinicalDataCollection.First().CTHKimoSurveyCollection.Count == 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2a2caebc36c023470f7f87771abb97b48ec369b8194", async() => {
                WriteLiteral("<i class=\"fa fa-plus\"></i> ");
#nullable restore
#line 17 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                                                                                                                                                                       Write(SharedLocalizer.GetLocalizedHtmlString("NewSession"));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-ID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"] = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-DataID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 17 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                                                                                                              WriteLiteral(Model.ClinicalDataID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["DataID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-DataID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["DataID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 18 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                <table class=""table m-0 table-colored-bordered table-bordered-info table-bordered table-hover"" id=""KimoDv"">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>");
#nullable restore
#line 25 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                           Write(SharedLocalizer.GetLocalizedHtmlString("Date"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>");
#nullable restore
#line 26 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                           Write(SharedLocalizer.GetLocalizedHtmlString("ChemotherapyProtocol"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>");
#nullable restore
#line 27 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                           Write(SharedLocalizer.GetLocalizedHtmlString("Cyclenumber"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>");
#nullable restore
#line 28 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                           Write(SharedLocalizer.GetLocalizedHtmlString("Dayno"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>");
#nullable restore
#line 29 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                           Write(SharedLocalizer.GetLocalizedHtmlString("Actions"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 33 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                         if (Model.PatientEntity.CTHPatientClinicalDataCollection.First().CTHKimoSurveyCollection.Count == 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <th scope=\"row\" colspan=\"7\">");
#nullable restore
#line 36 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                       Write(SharedLocalizer.GetLocalizedHtmlString("NoData"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            </tr>\r\n");
#nullable restore
#line 38 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                        }
                        else
                        {
                            foreach (var item in Model.PatientEntity.CTHPatientClinicalDataCollection.First().CTHKimoSurveyCollection)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 44 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 45 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                   Write(item.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 46 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                   Write(item.CTHChemotherapyProtocolItem.ProtocolName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 47 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                   Write(item.CycleNum);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 48 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                   Write(item.Days);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                    <td>
                                        <div class=""btn-group"">
                                            <button type=""button"" class=""btn btn-info dropdown-toggle waves-effect"" data-toggle=""dropdown"" aria-expanded=""false""> ");
#nullable restore
#line 51 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                                                                                                                             Write(SharedLocalizer.GetLocalizedHtmlString("Actions"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <i class=\"mdi mdi-chevron-down\"></i> </button>\r\n                                            <ul class=\"dropdown-menu\" x-placement=\"top-start\">\r\n");
#nullable restore
#line 53 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                 if (Authorize(UserPermission.Patient_Delete))
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <li>\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2a2caebc36c023470f7f87771abb97b48ec369b18024", async() => {
                WriteLiteral("<i class=\"fa fa-edit\"></i> ");
#nullable restore
#line 57 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                                                                                                Write(SharedLocalizer.GetLocalizedHtmlString("Edit"));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-ID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 56 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                                                                                                                          WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-ID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 57 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                                 WriteLiteral(item.PatientClinicalDataID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["DataID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-DataID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["DataID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    </li>\r\n");
#nullable restore
#line 59 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                 if (Authorize(UserPermission.Patient_ChemoDischargeNote))
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <li>\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2a2caebc36c023470f7f87771abb97b48ec369b22455", async() => {
                WriteLiteral("\r\n                                                            <i class=\"fa fa-notes-medical\"></i> ");
#nullable restore
#line 64 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                                                           Write(SharedLocalizer.GetLocalizedHtmlString("DischargeNote"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-ID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                                                                                                         WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-ID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    </li>\r\n");
#nullable restore
#line 67 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                 if (Authorize(UserPermission.Patient_ChemoPrintOutSheet))
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <li>\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2a2caebc36c023470f7f87771abb97b48ec369b26252", async() => {
                WriteLiteral("\r\n                                                            <i class=\"fa fa-print\"></i> ");
#nullable restore
#line 72 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                                                   Write(SharedLocalizer.GetLocalizedHtmlString("PrintOutSheet"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-ID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 71 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                                                                                                                 WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-ID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    </li>\r\n");
#nullable restore
#line 75 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                 if (Authorize(UserPermission.Patient_DeleteChemo))
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <li>\r\n                                                        <a href=\"#modal-delete-entity\" data-toggle=\"modal\"\r\n                                                           data-url=\"");
#nullable restore
#line 80 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                                Write(Url.Action("DeleteKimoSurvey", "PatientClinicalData", new { id = item.ID}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""
                                                           data-modalsize=""modal-lg""
                                                           data-modalcolor=""hmodal-danger"" class=""dropdown-item"">
                                                            <i class=""fas fa-times""></i> ");
#nullable restore
#line 83 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                                                    Write(SharedLocalizer.GetLocalizedHtmlString("Delete"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </a>\r\n                                                    </li>\r\n");
#nullable restore
#line 86 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </ul>\r\n                                        </div>\r\n                                    </td>\r\n\r\n                                </tr>\r\n");
#nullable restore
#line 92 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Patient\_ChemoSessionList.cshtml"
                                i++;
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SStorm.CTH.Web.Models.PatientModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
