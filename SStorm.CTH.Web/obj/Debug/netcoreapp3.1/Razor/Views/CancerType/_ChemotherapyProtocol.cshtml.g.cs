#pragma checksum "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c943491aa4942f69edcf87d541cff999c0afba9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CancerType__ChemotherapyProtocol), @"mvc.1.0.view", @"/Views/CancerType/_ChemotherapyProtocol.cshtml")]
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
#line 2 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
using SStorm.CTH.Web.Resources;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c943491aa4942f69edcf87d541cff999c0afba9", @"/Views/CancerType/_ChemotherapyProtocol.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"665dbf0bb945a0251073fd268bdaca02f9e4cb26", @"/Views/_ViewImports.cshtml")]
    public class Views_CancerType__ChemotherapyProtocol : SStorm.CTH.Web.Infrastructure.BaseViewPage<SStorm.CTH.Web.Models.TreeViewNode>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
Write(Html.SmartModal("modal-add-entity", modalType: ModalType.Danger, backdrop: "true"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card\">\r\n    <div class=\"card-body\">\r\n        <div class=\"modal-body\">\r\n");
#nullable restore
#line 9 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
             if (Authorize(UserPermission.CancerType_EditCreateProtocol))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a href=\"#modal-add-entity\" data-toggle=\"modal\"\r\n                   data-url=\"");
#nullable restore
#line 12 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                        Write(Url.Action("EditCreateChemotherapyProtocol", "CancerType", new { ID = 0 ,CancerTypeID = Model.CancerType.ID}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n                   data-modalsize=\"modal-lg\"\r\n                   data-modalcolor=\"hmodal-danger\" class=\"btn btn-info\">\r\n                    <i class=\"fas fa-plus\"></i> ");
#nullable restore
#line 15 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                                           Write(SharedLocalizer.GetLocalizedHtmlString("NewChemotherapyProtocol"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </a>\r\n");
#nullable restore
#line 17 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""table-responsive"">
                <table class=""table m-0 table-colored-bordered table-bordered-info table-bordered table-hover"" border=""1"">
                    <thead>
                        <tr>
                            <th>");
#nullable restore
#line 22 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                           Write(SharedLocalizer.GetLocalizedHtmlString("ProtocolName"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>");
#nullable restore
#line 23 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                           Write(SharedLocalizer.GetLocalizedHtmlString("Days"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>");
#nullable restore
#line 24 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                           Write(SharedLocalizer.GetLocalizedHtmlString("Actions"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        </tr>\r\n                    </thead>\r\n");
#nullable restore
#line 27 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                     if (Model.CancerType.CTHChemotherapyProtocolCollection.Count == 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td colspan=\"5\"><span>");
#nullable restore
#line 30 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                                             Write(SharedLocalizer.GetLocalizedHtmlString("NoData"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                        </tr>\r\n");
#nullable restore
#line 32 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                    }
                    else
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                         foreach (var item in Model.CancerType.CTHChemotherapyProtocolCollection)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 38 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                               Write(item.ProtocolName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 39 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                               Write(item.Days);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n");
#nullable restore
#line 41 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                                     if (Authorize(UserPermission.CancerType_EditCreateProtocol))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a href=\"#modal-add-entity\" data-toggle=\"modal\"\r\n                                           data-url=\"");
#nullable restore
#line 44 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                                                Write(Url.Action("EditCreateChemotherapyProtocol", "CancerType", new { ID = item.ID, CancerTypeID = Model.CancerType.ID }));

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
#line 49 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                                    }
                                    else
                                    {

                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                                     if (Authorize(UserPermission.CancerType_DeleteProtocol))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a href=\"#modal-delete-entity\" data-toggle=\"modal\"\r\n                                           data-url=\"");
#nullable restore
#line 57 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                                                Write(Url.Action("DeleteChemotherapyProtocol", "CancerType", new {ID = item.ID}));

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
#line 62 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 67 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n<script>\r\n    function RefreshChemotherapyProtocol(response) {\r\n        if (response[0] == 3) {\r\n            $.ajax({\r\n                url: \'");
#nullable restore
#line 81 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                 Write(Url.Action("GetChemotherapyProtocol", "CancerType"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n                type: \'GET\',\r\n                cache: false,\r\n                data: { CancerTypeID: ");
#nullable restore
#line 84 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_ChemotherapyProtocol.cshtml"
                                 Write(Model.CancerType.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"}
            }).done(function (result) {
                $('#dvProtocol').html(result);
                swal(""Done"", ""Data Deleted successfully"", ""success"");
            });
        }
        else {
             swal(""Error"", ""Data Not Deleted successfully"", ""error"");
        }

    }
</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SStorm.CTH.Web.Models.TreeViewNode> Html { get; private set; }
    }
}
#pragma warning restore 1591