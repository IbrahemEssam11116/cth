#pragma checksum "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e45b54a874faf35e94191f585166a7ea6e603e58"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Protocol__SymptomCollection), @"mvc.1.0.view", @"/Views/Protocol/_SymptomCollection.cshtml")]
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
#line 2 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
using SStorm.CTH.Web.Resources;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
using Microsoft.AspNetCore.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e45b54a874faf35e94191f585166a7ea6e603e58", @"/Views/Protocol/_SymptomCollection.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"665dbf0bb945a0251073fd268bdaca02f9e4cb26", @"/Views/_ViewImports.cshtml")]
    public class Views_Protocol__SymptomCollection : SStorm.CTH.Web.Infrastructure.BaseViewPage<SStorm.CTH.Web.Models.DrugModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 6 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
  
    var requestCulture = Context.Features.Get<IRequestCultureFeature>();
    ViewData["Title"] = @SharedLocalizer.GetLocalizedHtmlString("SymptomList");
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container-fluid"">
    <!-- start page title -->
    <div class=""row"">
        <div class=""col-12"">
            <div class=""page-title-box"">
                <div class=""page-title-right"">
                    <ol class=""breadcrumb m-0"">
                        <li class=""breadcrumb-item""><a href=""javascript: void(0);"">");
#nullable restore
#line 18 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                                                              Write(SharedLocalizer.GetLocalizedHtmlString("Doselimitingtoxicity"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n                        <li class=\"breadcrumb-item active\">");
#nullable restore
#line 19 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                                      Write(SharedLocalizer.GetLocalizedHtmlString("DoseLimitingToxicityList"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
    <!-- end page title -->
    <div class=""row"">
        <div class=""col-sm-12"">
            <div class=""card"">
                <div class=""card-body"">
                    <button type=""button"" class=""close"" id=""btnCloseDrag"">
                        <span aria-hidden=""true"">??</span>
                    </button>
                    <div id=""DragDiv"">
");
#nullable restore
#line 34 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                         if (Authorize(UserPermission.CancerType_AssignSymptomToDrug))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a href=\"#modal-add-entity\" data-toggle=\"modal\"\r\n                               data-url=\"");
#nullable restore
#line 37 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                    Write(Url.Action("EditCreateSymptom", "Protocol", new { ID = 0, DrugID = Model.DrugEntity.ID, ProtocolID = Model.DrugEntity.ProtocolID}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n                               data-modalsize=\"modal-lg\"\r\n                               data-modalcolor=\"hmodal-danger\" class=\"btn btn-info\">\r\n                                <i class=\"fas fa-plus\"></i>");
#nullable restore
#line 40 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                                      Write(SharedLocalizer.GetLocalizedHtmlString("AddNew"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </a>\r\n");
#nullable restore
#line 42 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        <br />
                        <div class=""table-responsive"">
                            <table class=""table m-0 table-colored-bordered table-bordered-info table-bordered table-hover"">
                                <thead>
                                    <tr>
                                        <th>");
#nullable restore
#line 49 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                       Write(SharedLocalizer.GetLocalizedHtmlString("Name"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                        <th>");
#nullable restore
#line 50 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                       Write(SharedLocalizer.GetLocalizedHtmlString("Grade"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                        <th>");
#nullable restore
#line 51 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                       Write(SharedLocalizer.GetLocalizedHtmlString("Description"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                        <th>");
#nullable restore
#line 52 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                       Write(SharedLocalizer.GetLocalizedHtmlString("Recommendation"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                        <th>");
#nullable restore
#line 53 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                       Write(SharedLocalizer.GetLocalizedHtmlString("Actions"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n\r\n                                    </tr>\r\n                                </thead>\r\n                                <tbody>\r\n");
#nullable restore
#line 58 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                     if (Model.DrugEntity.CTHDrugSymptomCollection.Count() == 0)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <th scope=\"row\" colspan=\"7\">");
#nullable restore
#line 61 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                                                   Write(SharedLocalizer.GetLocalizedHtmlString("NoData"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                        </tr>\r\n");
#nullable restore
#line 63 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    \r\n");
#nullable restore
#line 65 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                     foreach (var item in Model.DrugEntity.CTHDrugSymptomCollection)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td>");
#nullable restore
#line 68 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                               Write(item.CTHSymptomItem.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 69 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                               Write(item.CTHSymptomItem.Grade);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 70 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                               Write(item.CTHSymptomItem.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 71 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                               Write(item.CTHSymptomItem.Recommendation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>\r\n");
#nullable restore
#line 73 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                                     if (Authorize(UserPermission.CancerType_AssignSymptomToDrug))
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <a href=\"#modal-add-entity\" data-toggle=\"modal\"\r\n                                                           data-url=\"");
#nullable restore
#line 76 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                                                Write(Url.Action("EditCreateSymptom", "Protocol", new { ID = item.ID, DrugID = Model.DrugEntity.ID, ProtocolID = Model.DrugEntity.ProtocolID}));

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
#line 81 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                                     if (Authorize(UserPermission.CancerType_DeleteSymptomFromDrug))
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <a href=\"#modal-delete-entity\" data-toggle=\"modal\"\r\n                                                           data-url=\"");
#nullable restore
#line 85 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                                                Write(Url.Action("DeleteSymptom", "Protocol", new { ID = item.ID}));

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
#line 90 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                </td>\r\n                                            </tr>\r\n");
#nullable restore
#line 93 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_SymptomCollection.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </tbody>\r\n                            </table>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SStorm.CTH.Web.Models.DrugModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
