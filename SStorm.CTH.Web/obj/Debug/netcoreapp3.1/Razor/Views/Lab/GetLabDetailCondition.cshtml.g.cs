#pragma checksum "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a2fc8069711592310762e013fcd02e3e7707c82b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Lab_GetLabDetailCondition), @"mvc.1.0.view", @"/Views/Lab/GetLabDetailCondition.cshtml")]
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
#line 2 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
using SStorm.CTH.Web.Resources;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2fc8069711592310762e013fcd02e3e7707c82b", @"/Views/Lab/GetLabDetailCondition.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"665dbf0bb945a0251073fd268bdaca02f9e4cb26", @"/Views/_ViewImports.cshtml")]
    public class Views_Lab_GetLabDetailCondition : SStorm.CTH.Web.Infrastructure.BaseViewPage<SStorm.CTH.Web.Models.LabDetailConditionModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
  
    ViewData["Title"] =@SharedLocalizer.GetLocalizedHtmlString("GetLabDetailCondition");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
Write(Html.SmartModal("modal-delete-entity", modalType: ModalType.Danger, backdrop: "true"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
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
#line 18 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
                                                                              Write(SharedLocalizer.GetLocalizedHtmlString("LabDetailCondition"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n                        <li class=\"breadcrumb-item active\">");
#nullable restore
#line 19 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
                                                      Write(SharedLocalizer.GetLocalizedHtmlString("LabDetailConditionList"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    </ol>\r\n                </div>\r\n                <h4 class=\"page-title\">");
#nullable restore
#line 22 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
                                  Write(SharedLocalizer.GetLocalizedHtmlString("Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <!-- end page title -->\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-12\">\r\n");
#nullable restore
#line 30 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
             if (Authorize(UserPermission.CancerType_EditCreateLab))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a href=\"#modal-add-entity\" data-toggle=\"modal\"\r\n               data-url=\"");
#nullable restore
#line 33 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
                    Write(Url.Action("EditCreateLabDetailCondition", "Lab", new { ID = 0, LabDetailID = Model.LabDetailEntity.ID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n               data-modalsize=\"modal-lg\"\r\n               data-modalcolor=\"hmodal-danger\" class=\"btn btn-primary\">\r\n                <i class=\"fas fa-plus\"></i>");
#nullable restore
#line 36 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
                                      Write(SharedLocalizer.GetLocalizedHtmlString("NewLabDetailCondition"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </a>\r\n");
#nullable restore
#line 38 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""card"">
                <div class=""card-body"">


                    <div class=""table-responsive"">
                        <table class=""table m-0 table-hover"">
                            <thead class=""btn-primary text-white"">
                                <tr>
                                    <th>");
#nullable restore
#line 47 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
                                   Write(SharedLocalizer.GetLocalizedHtmlString("Condition"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <th>");
#nullable restore
#line 48 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
                                   Write(SharedLocalizer.GetLocalizedHtmlString("Actions"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n\r\n                                </tr>\r\n                            </thead>\r\n                            <tbody>\r\n");
#nullable restore
#line 53 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
                                 if (Model.LabDetailEntity.CTHLabDetailConditionCollection.Count() == 0)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <th scope=\"row\" colspan=\"7\">");
#nullable restore
#line 56 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
                                                               Write(SharedLocalizer.GetLocalizedHtmlString("NoData"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    </tr>\r\n");
#nullable restore
#line 58 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
                                 foreach (var item in Model.LabDetailEntity.CTHLabDetailConditionCollection)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr");
            BeginWriteAttribute("title", " title=\"", 2933, "\"", 2954, 1);
#nullable restore
#line 61 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
WriteAttributeValue("", 2941, item.Message, 2941, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <td>");
#nullable restore
#line 62 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
                                       Write(item.Condition);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n");
#nullable restore
#line 64 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
                                             if (Authorize(UserPermission.CancerType_EditCreateLab))
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <a href=\"#modal-add-entity\" data-toggle=\"modal\"\r\n                                                   data-url=\"");
#nullable restore
#line 67 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
                                                        Write(Url.Action("EditCreateLabDetailCondition", "Lab", new { ID = item.ID, LabDetailID = item.LabDetailID }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""
                                                   data-modalsize=""modal-lg""
                                                   data-modalcolor=""hmodal-danger"" class=""btn btn-primary"">
                                                    <i class=""fas fa-edit""></i>
                                                </a>
");
#nullable restore
#line 72 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
                                             if (Authorize(UserPermission.CancerType_DeleteLab))
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <a href=\"#modal-delete-entity\" data-toggle=\"modal\"\r\n                                                   data-url=\"");
#nullable restore
#line 76 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
                                                        Write(Url.Action("DeleteLabDetailCondition", "Lab", new { ID = item.ID }));

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
#line 81 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 84 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Lab\GetLabDetailCondition.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SStorm.CTH.Web.Models.LabDetailConditionModel> Html { get; private set; }
    }
}
#pragma warning restore 1591