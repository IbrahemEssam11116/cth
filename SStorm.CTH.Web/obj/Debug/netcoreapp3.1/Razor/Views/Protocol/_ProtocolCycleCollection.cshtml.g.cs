#pragma checksum "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "170807805a522b0fae36f431b8f62db2d6b56435"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Protocol__ProtocolCycleCollection), @"mvc.1.0.view", @"/Views/Protocol/_ProtocolCycleCollection.cshtml")]
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
#line 2 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
using SStorm.CTH.Web.Resources;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"170807805a522b0fae36f431b8f62db2d6b56435", @"/Views/Protocol/_ProtocolCycleCollection.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"665dbf0bb945a0251073fd268bdaca02f9e4cb26", @"/Views/_ViewImports.cshtml")]
    public class Views_Protocol__ProtocolCycleCollection : SStorm.CTH.Web.Infrastructure.BaseViewPage<SStorm.CTH.Web.Models.ChemotherapyProtocolModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Protocol", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditCreateProtocolCycle", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-ID", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
  
    ViewData["Title"] = @SharedLocalizer.GetLocalizedHtmlString("ProtocolCyclesList");
    Layout = null;

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
#line 16 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                                                              Write(SharedLocalizer.GetLocalizedHtmlString("ProtocolCycles"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n                        <li class=\"breadcrumb-item active\">");
#nullable restore
#line 17 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                                      Write(SharedLocalizer.GetLocalizedHtmlString("ProtocolCyclesList"));

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
                    <button type=""button"" class=""close"" id=""btnCloseProtocolCycleDiv"">
                        <span aria-hidden=""true"">×</span>
                    </button>
                    <div id=""ProtocolCycleDiv"">
");
#nullable restore
#line 33 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                         if (Authorize(UserPermission.CancerType_EditCreateCycle))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "170807805a522b0fae36f431b8f62db2d6b564357472", async() => {
                WriteLiteral(" <i class=\"fas fa-plus\"></i> ");
#nullable restore
#line 35 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                                                                                                                                                                                                    Write(SharedLocalizer.GetLocalizedHtmlString("AddNew"));

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
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-ID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"] = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-ProtocolID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 35 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                                                                                                     WriteLiteral(Model.ChemotherapyProtocolEntity.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ProtocolID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-ProtocolID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ProtocolID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 36 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                        }

                        

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        <div class=""table-responsive"">
                            <table class=""table m-0 table-colored-bordered table-bordered-info table-bordered table-hover"">
                                <thead>
                                    <tr>
                                        <th>");
#nullable restore
#line 49 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                       Write(SharedLocalizer.GetLocalizedHtmlString("Number"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
            WriteLiteral("                                        <th>");
#nullable restore
#line 51 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                       Write(SharedLocalizer.GetLocalizedHtmlString("Description"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                        <th>");
#nullable restore
#line 52 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                       Write(SharedLocalizer.GetLocalizedHtmlString("Recycle Date"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                        <th>");
#nullable restore
#line 53 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                       Write(SharedLocalizer.GetLocalizedHtmlString("Recycling After"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                        <th>");
#nullable restore
#line 54 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                       Write(SharedLocalizer.GetLocalizedHtmlString("Actions"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    </tr>\r\n                                </thead>\r\n                                <tbody>\r\n");
#nullable restore
#line 58 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                     if (Model.ChemotherapyProtocolEntity.CTHProtocolCycleCollection.Count() == 0)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <th scope=\"row\" colspan=\"7\">");
#nullable restore
#line 61 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                                                   Write(SharedLocalizer.GetLocalizedHtmlString("NoData"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                        </tr>\r\n");
#nullable restore
#line 63 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                     foreach (var item in Model.ChemotherapyProtocolEntity.CTHProtocolCycleCollection)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 67 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                   Write(item.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 68 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                   Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 69 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                   Write(item.RecycleDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 70 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                   Write(item.RecyclingAfter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("                                    <td>\r\n");
#nullable restore
#line 73 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                         if (Authorize(UserPermission.CancerType_EditCreateCycle))
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "170807805a522b0fae36f431b8f62db2d6b5643516710", async() => {
                WriteLiteral(" <i class=\"fas fa-edit\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-ID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 75 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                                                                                                WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-ID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 75 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                                                                                                                                WriteLiteral(Model.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["protocolID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-protocolID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["protocolID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 76 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                         if (Authorize(UserPermission.CancerType_DeleteCycle))
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <a href=\"#modal-delete-entity\" data-toggle=\"modal\"\r\n                                               data-url=\"");
#nullable restore
#line 80 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                                    Write(Url.Action("DeleteProtocolCycle", "Protocol", new {ID = item.ID}));

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
#line 85 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 88 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Protocol\_ProtocolCycleCollection.cshtml"
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
        </div>
    </div>
</div>

<script>
    $(document).ready(function () {
        $(""#btnCloseProtocolCycleDiv"").click(function () {
            $(""#ProtocolCycleDiv"").slideToggle(1000);
        });
    });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SStorm.CTH.Web.Models.ChemotherapyProtocolModel> Html { get; private set; }
    }
}
#pragma warning restore 1591