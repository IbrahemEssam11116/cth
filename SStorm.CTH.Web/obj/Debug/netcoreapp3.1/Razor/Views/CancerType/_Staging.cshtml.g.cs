#pragma checksum "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b68ac9e525fb76af20f41d59cffadd533da8f85d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CancerType__Staging), @"mvc.1.0.view", @"/Views/CancerType/_Staging.cshtml")]
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
#line 2 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
using SStorm.CTH.Web.Resources;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b68ac9e525fb76af20f41d59cffadd533da8f85d", @"/Views/CancerType/_Staging.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"665dbf0bb945a0251073fd268bdaca02f9e4cb26", @"/Views/_ViewImports.cshtml")]
    public class Views_CancerType__Staging : SStorm.CTH.Web.Infrastructure.BaseViewPage<SStorm.CTH.Web.Models.TreeViewNode>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/ajax/jquery.unobtrusive-ajax.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
Write(Html.SmartModal("modal-add-entity", modalType: ModalType.Danger, backdrop: "true"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card\">\r\n    <div class=\"card-body\">\r\n        <div class=\"modal-body\">\r\n");
#nullable restore
#line 9 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
             if (Authorize(UserPermission.CancerType_AssignStageToTNM))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a href=\"#modal-add-entity\" data-toggle=\"modal\"\r\n                   data-url=\"");
#nullable restore
#line 12 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
                        Write(Url.Action("EditCreateStaging", "CancerType", new { CancerTypeID = Model.CancerType.ID , ID = 0}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n                   data-modalsize=\"modal-lg\"\r\n                   data-modalcolor=\"hmodal-danger\" class=\"btn btn-info\">\r\n                    <i class=\"fas fa-plus\"></i>New Stage\r\n                </a>\r\n");
#nullable restore
#line 17 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""table-responsive"">
                <table class=""table m-0 table-colored-bordered table-bordered-info table-bordered table-hover"">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Number</th>
                            <th>Remarks</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
");
#nullable restore
#line 28 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
                     if (Model.CancerType.CTHStagingCollection.Count == 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td colspan=\"5\"><span>No Data</span></td>\r\n                        </tr>\r\n");
#nullable restore
#line 33 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
                    }
                    else
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
                         foreach (var item in Model.CancerType.CTHStagingCollection)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 39 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
                               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td");
            BeginWriteAttribute("title", " title=\"", 1775, "\"", 1795, 1);
#nullable restore
#line 40 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
WriteAttributeValue("", 1783, item.Number, 1783, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"cursor:pointer;\">");
#nullable restore
#line 40 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
                                                                            Write(item.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td");
            BeginWriteAttribute("title", " title=\"", 1875, "\"", 1896, 1);
#nullable restore
#line 41 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
WriteAttributeValue("", 1883, item.Remarks, 1883, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"cursor:pointer;\">");
#nullable restore
#line 41 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
                                                                             Write(item.Remarks);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                \r\n                                <td>\r\n");
#nullable restore
#line 44 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
                                     if (Authorize(UserPermission.CancerType_AssignStageToTNM))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a href=\"#modal-add-entity\" data-toggle=\"modal\"\r\n                                           data-url=\"");
#nullable restore
#line 47 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
                                                Write(Url.Action("EditCreateStaging", "CancerType", new { CancerTypeID = Model.CancerType.ID, ID = item.ID}));

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
#line 52 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
                                     if (Authorize(UserPermission.CancerType_DeleteTNMStaging))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a href=\"#modal-delete-entity\" data-toggle=\"modal\"\r\n                                           data-url=\"");
#nullable restore
#line 56 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
                                                Write(Url.Action("DeleteStagingMatrix", "CancerType", new {ID = item.ID}));

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
#line 61 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 64 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </table>
            </div>
        </div>
    </div>
</div>


<script>
    function LoadStagingList(response) {
        $('#modal-add-entity').modal('hide');
        if (response == 2) {
            swal(""Error"", ""Data not Saved"", ""error"");
        }
        else {
            $.ajax({
                url: '");
#nullable restore
#line 82 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
                 Write(Url.Action("GetStaging", "CancerType"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n                type: \'GET\',\r\n                cache: false,\r\n                data: { CancerTypeID: ");
#nullable restore
#line 85 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\CancerType\_Staging.cshtml"
                                 Write(Model.CancerType.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("}\r\n            }).done(function (result) {\r\n                $(\'#dvStaging\').html(result);\r\n                console.log(result)\r\n                swal(\"Done\", \"Data Saved Successfully\", \"success\");\r\n            });\r\n        }\r\n    }\r\n</script>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b68ac9e525fb76af20f41d59cffadd533da8f85d13442", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
