
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace SStorm.CTH.DataCollection.Web
{
    public enum ButtonTypes
    {
        Info,
        Success,
        Default,
        Warning,
        Danger,
        Primary
    }

    public static class SmartSubmitExtensions
    {
        public static IHtmlContent SmartSubmit(this IHtmlHelper htmlHelper,
           object htmlAttributes = null,
           string textLabel = "",
           string loadingTextLabel = "",
           ButtonTypes type = ButtonTypes.Success,
           string icon = "fa fa-save")
        {

            if (string.IsNullOrWhiteSpace(loadingTextLabel))
                loadingTextLabel = "جاري الحفظ...";
            if (string.IsNullOrWhiteSpace(textLabel))
                textLabel = "حفظ";

            var iconTag = new TagBuilder("i");
            iconTag.AddCssClass(icon + " mr-1");

            var dic = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            dic.Add("type", "submit");
            if (dic.ContainsKey("class"))
                dic["class"] += " btn btn-" + type.ToString().ToLower() + " waves-effect waves-light btn-rounded width-md ";
            else
                dic.Add("class", "btn btn-" + type.ToString().ToLower() + " waves-effect waves-light btn-rounded width-md ");

            dic.Add("data-loading-text", "<i ID=\"loadingSubmit\" class=\"fa fa-fw fa-spinner fa-pulse\"></i> " + loadingTextLabel);

            var builder = new TagBuilder("button");
            builder.MergeAttributes(dic);
            iconTag.TagRenderMode = TagRenderMode.Normal;
            if (!string.IsNullOrWhiteSpace(icon))
                builder.InnerHtml.AppendHtml(iconTag);

            builder.InnerHtml.Append(textLabel);

            return new HtmlContentBuilder().AppendHtml(builder);
        }
    }
}