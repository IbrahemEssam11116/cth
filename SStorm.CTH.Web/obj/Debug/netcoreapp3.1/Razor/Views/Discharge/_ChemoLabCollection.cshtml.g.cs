#pragma checksum "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed96010a313b387e11c0047750f50acba2a30371"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Discharge__ChemoLabCollection), @"mvc.1.0.view", @"/Views/Discharge/_ChemoLabCollection.cshtml")]
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
#line 2 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
using Microsoft.AspNetCore.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
using SStorm.CTH.Web.Resources;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed96010a313b387e11c0047750f50acba2a30371", @"/Views/Discharge/_ChemoLabCollection.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"665dbf0bb945a0251073fd268bdaca02f9e4cb26", @"/Views/_ViewImports.cshtml")]
    public class Views_Discharge__ChemoLabCollection : SStorm.CTH.Web.Infrastructure.BaseViewPage<KimoSurveyModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
  
    var requestCulture = Context.Features.Get<IRequestCultureFeature>();
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table m-0 table-colored-bordered table-bordered-info table-bordered table-hover\" id=\"tablabid\">\r\n    <thead>\r\n        <tr>\r\n            <th class=\"text-center border-right-0 border-bottom-0\"> ");
#nullable restore
#line 13 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
                                                               Write(SharedLocalizer.GetLocalizedHtmlString("Actions"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th class=\"text-center border-right-0 border-bottom-0\"> ");
#nullable restore
#line 14 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
                                                               Write(SharedLocalizer.GetLocalizedHtmlString("LabCategory"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th class=\"text-center border-right-0 border-bottom-0\"> ");
#nullable restore
#line 15 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
                                                               Write(SharedLocalizer.GetLocalizedHtmlString("LabItem"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th class=\"text-center border-right-0 border-bottom-0\"> ");
#nullable restore
#line 16 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
                                                               Write(SharedLocalizer.GetLocalizedHtmlString("Date"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 20 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
         for (int i = 0; i < Model.KimoSurveyEntity.CTHChemoLabCollection.Count; i++)
        {
            var x = "Lab" + i;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr");
            BeginWriteAttribute("id", " id=\"", 1108, "\"", 1115, 1);
#nullable restore
#line 23 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
WriteAttributeValue("", 1113, x, 1113, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <td hidden>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ed96010a313b387e11c0047750f50acba2a303717592", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 25 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.KimoSurveyEntity.CTHChemoLabCollection[i].ID);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
                                                                                           WriteLiteral(Model.KimoSurveyEntity.CTHChemoLabCollection[i].ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ed96010a313b387e11c0047750f50acba2a3037110060", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 26 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.KimoSurveyEntity.CTHChemoLabCollection[i].ChemoID);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 26 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
                                                                                                WriteLiteral(Model.KimoSurveyEntity.CTHChemoLabCollection[i].ChemoID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            WriteLiteral("KimoSurveyEntity.CTHChemoLabCollection[");
#nullable restore
#line 26 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
                                                                                                                                                                                                       WriteLiteral(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("].ChemoID");
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("name", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ed96010a313b387e11c0047750f50acba2a3037113476", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 27 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.KimoSurveyEntity.CTHChemoLabCollection[i].Date);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 27 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
                                                                                                    WriteLiteral(Model.KimoSurveyEntity.CTHChemoLabCollection[i].Date);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            WriteLiteral("KimoSurveyEntity.CTHChemoLabCollection[");
#nullable restore
#line 27 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
                                                                                                                                                                                                        WriteLiteral(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("].Date");
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("name", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ed96010a313b387e11c0047750f50acba2a3037116764", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 28 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.KimoSurveyEntity.CTHChemoLabCollection[i].LabDetailsID);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 28 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
                                                                                                            WriteLiteral(Model.KimoSurveyEntity.CTHChemoLabCollection[i].LabDetailsID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            WriteLiteral("KimoSurveyEntity.CTHChemoLabCollection[");
#nullable restore
#line 28 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
                                                                                                                                                                                                                        WriteLiteral(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("].LabDetailsID");
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("name", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                </td>\r\n                <td class=\"text-center border-right-0 border-bottom-0\">\r\n                    <button type=\"button\" data-toggle=\"tooltip\" class=\"btn btn-icon btn-outline-danger btn-lg\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2216, "\"", 2294, 3);
            WriteAttributeValue("", 2226, "DeleteRowlab2(\'", 2226, 15, true);
#nullable restore
#line 32 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
WriteAttributeValue("", 2241, Model.KimoSurveyEntity.CTHChemoLabCollection[i].ID, 2241, 51, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2292, "\')", 2292, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <i class=\"fa fa-trash\"></i>\r\n                    </button>\r\n                </td>\r\n                <td class=\"width-xl\">\r\n                    ");
#nullable restore
#line 37 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
               Write(Model.KimoSurveyEntity.CTHChemoLabCollection[i].CTHLabDetailItem.CTHLabItem.LabName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </td>\r\n                <td class=\"width-xl\">\r\n                    ");
#nullable restore
#line 41 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
               Write(Model.KimoSurveyEntity.CTHChemoLabCollection[i].CTHLabDetailItem.LabDetailsName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"width-xl\">\r\n                    ");
#nullable restore
#line 44 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
               Write(Model.KimoSurveyEntity.CTHChemoLabCollection[i].Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 47 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n<script>\r\n    function DeleteRowlab2(id) {\r\n        $.ajax({\r\n            url: \'");
#nullable restore
#line 55 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
             Write(Url.Action("ConfirmDeleteChemoLab", "Discharge"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n            type: \'GET\',\r\n            cache: false,\r\n            data: { ID:id}\r\n        }).done(function (result) {\r\n            $.ajax({\r\n            url: \'");
#nullable restore
#line 61 "C:\Users\Ibrahem\Desktop\CTH\SStorm.CTH.Web\Views\Discharge\_ChemoLabCollection.cshtml"
             Write(Url.Action("ChemoLabList", "Discharge"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            type: 'GET',
            cache: false,
            data: { kimoid: result}
             }).done(function (result) {
               $('#ChemoLabCollection').empty();
               $('#ChemoLabCollection').html(result);
           });
         });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KimoSurveyModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
