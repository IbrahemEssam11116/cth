#pragma checksum "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb5a8bb58df7d3855886071190672e905ddbbc8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Treatement_TreatmentPlan), @"mvc.1.0.view", @"/Views/Treatement/TreatmentPlan.cshtml")]
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
#line 2 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
using X.PagedList.Mvc.Core.Fluent;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
using SStorm.CTH.Web.Resources;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
using Microsoft.AspNetCore.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb5a8bb58df7d3855886071190672e905ddbbc8c", @"/Views/Treatement/TreatmentPlan.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"665dbf0bb945a0251073fd268bdaca02f9e4cb26", @"/Views/_ViewImports.cshtml")]
    public class Views_Treatement_TreatmentPlan : SStorm.CTH.Web.Infrastructure.BaseViewPage<SearchFacade<SStorm.CTH.DAL.EntityClasses.CTHTreatmentTypeEntity>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/css/PagedList.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/css/footable.bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "TreatmentPlan", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Treatement", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/footable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/moment.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 7 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
  
    var requestCulture = Context.Features.Get<IRequestCultureFeature>();
    ViewData["Title"] = @SharedLocalizer.GetLocalizedHtmlString("TreatmentPlanList");

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
Write(Html.SmartModal("modal-delete-entity", modalType: ModalType.Danger, backdrop: "true"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 12 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
Write(Html.SmartModal("modal-add-entity", modalType: ModalType.Danger, backdrop: "true"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fb5a8bb58df7d3855886071190672e905ddbbc8c7957", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fb5a8bb58df7d3855886071190672e905ddbbc8c9071", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
#line 25 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                                                              Write(SharedLocalizer.GetLocalizedHtmlString("TreatmentTPlanList"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n                        <li class=\"breadcrumb-item active\">");
#nullable restore
#line 26 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                                      Write(SharedLocalizer.GetLocalizedHtmlString("TreatmentPlanList"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    </ol>\r\n                </div>\r\n                <h4 class=\"page-title\">");
#nullable restore
#line 29 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                  Write(SharedLocalizer.GetLocalizedHtmlString("Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
            </div>
        </div>
    </div>
    <!-- end page title -->
    <div class=""row"">
        <div class=""col-sm-12"">

            <div class=""card"">
                <div class=""card-body"">


                    <div class="" form-group row"">
                        <div class=""col-md-12"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb5a8bb58df7d3855886071190672e905ddbbc8c12024", async() => {
                WriteLiteral("\r\n                                <div class=\"input-group\">\r\n                                    ");
#nullable restore
#line 45 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                               Write(Html.TextBox("searchString", "", new { @class = "form-control", placeholder = "Search" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                                    <button type=\"submit\" class=\"btn  btn-sm btn-info\"><i class=\"fa fa-search\"></i></button>\r\n                                </div>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
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

                    <div class=""row"">
                        <div class=""col-12"">
                            <div class=""page-title-box"">
                                <div class=""float-left"">
");
#nullable restore
#line 57 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                     if (Authorize(UserPermission.TreatmentType_EditCreate))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a href=\"#modal-add-entity\" data-toggle=\"modal\"\r\n                                           data-url=\"");
#nullable restore
#line 60 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                                Write(Url.Action("EditCreateTreatmentPlan", "Treatement", new { ID = 0}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n                                           data-modalsize=\"modal-lg\"\r\n                                           data-modalcolor=\"hmodal-danger\" class=\"btn btn-info\">\r\n                                            <i class=\"fas fa-plus\"></i>");
#nullable restore
#line 63 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                                                  Write(SharedLocalizer.GetLocalizedHtmlString("AddNew"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </a>\r\n");
#nullable restore
#line 65 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n                                <div class=\"float-right\">\r\n                                    ");
#nullable restore
#line 68 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                Write(Html.Pager(Model.DataPagedList).Url(Page => Url.Action("TreatmentPlan", new { Page })).Build());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""table-responsive"">
                        <table class=""table m-0 table-colored-bordered table-bordered-info table-bordered table-hover"">
                            <thead class=""btn-primary text-white"">
                                <tr>
                                    <th>#</th>
                                    <th>");
#nullable restore
#line 78 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                   Write(SharedLocalizer.GetLocalizedHtmlString("TreatmentPlans"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <th>");
#nullable restore
#line 79 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                   Write(SharedLocalizer.GetLocalizedHtmlString("Actions"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n\r\n                                </tr>\r\n                            </thead>\r\n                            <tbody>\r\n");
#nullable restore
#line 84 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                 if (Model.DataPagedList.Count() == 0)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <th scope=\"row\">");
#nullable restore
#line 87 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                                   Write(SharedLocalizer.GetLocalizedHtmlString("NoData"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    </tr>\r\n");
#nullable restore
#line 89 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                 for (int i = 0; i < Model.DataPagedList.Count(); i++)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <th scope=\"row\">");
#nullable restore
#line 93 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                                        Write(i + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                            <td>");
#nullable restore
#line 94 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                           Write(Model.DataPagedList[i].TreatmentType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>\r\n");
#nullable restore
#line 96 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                                 if (Authorize(UserPermission.TreatmentType_EditCreate))
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <a href=\"#modal-add-entity\" data-toggle=\"modal\"\r\n                                                       data-url=\"");
#nullable restore
#line 99 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                                            Write(Url.Action("EditCreateTreatmentPlan", "Treatement", new { ID = @Model.DataPagedList[i].ID}));

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
#line 104 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 106 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                                 if (Authorize(UserPermission.TreatmentType_Delete))
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <a href=\"#modal-delete-entity\" data-toggle=\"modal\"\r\n                                                       data-url=\"");
#nullable restore
#line 109 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                                            Write(Url.Action("DeleteTreatmentPlan", "Treatement", new { ID = @Model.DataPagedList[i].ID}));

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
#line 114 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 118 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Treatement\TreatmentPlan.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb5a8bb58df7d3855886071190672e905ddbbc8c23524", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb5a8bb58df7d3855886071190672e905ddbbc8c24564", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n\r\n    jQuery(function ($) {\r\n        $(\'.table\').footable();\r\n    });\r\n\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SearchFacade<SStorm.CTH.DAL.EntityClasses.CTHTreatmentTypeEntity>> Html { get; private set; }
    }
}
#pragma warning restore 1591
