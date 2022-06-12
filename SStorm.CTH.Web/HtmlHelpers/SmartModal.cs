using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SStorm.CTH.Web
{
    public enum ModalSize
    {
        Small,
        Medium,
        Large
    }

    public enum ModalType
    {
        Info,
        Success,
        Default,
        Warning,
        Danger
    }

    public static class SmartModalExtensions
    {
        public static IHtmlContent SmartModal(this IHtmlHelper htmlHelper, string modelId,
            ModalSize modalSize = ModalSize.Medium,
            ModalType modalType = ModalType.Default,
            string backdrop = "static",
            string entranceAnimation = "bounceIn",
            string exitAnimation = "flipOutY")
        {
            var modalContentTag = new TagBuilder("div");
            modalContentTag.TagRenderMode = TagRenderMode.Normal;
            modalContentTag.AddCssClass("modal-content" + (modalSize == ModalSize.Small ? " modal-sm" : " modal-lg"));

            var modalDialogTag = new TagBuilder("div");
            if (modalSize != ModalSize.Medium)
                modalDialogTag.AddCssClass("modal-dialog " + (modalSize == ModalSize.Small ? "modal-sm" : "modal-lg"));
            else
                modalDialogTag.AddCssClass("modal-dialog");
            modalDialogTag.InnerHtml.SetHtmlContent(modalContentTag);

            var modalTag = new TagBuilder("div");
            if (modalType != ModalType.Default)
                modalTag.AddCssClass("modal fade " + (modalType == ModalType.Info ? "hmodal-info" : (modalType == ModalType.Success ? "hmodal-success" : (modalType == ModalType.Warning ? "hmodal-warning" : "hmodal-danger"))));
            else
                modalTag.AddCssClass("modal fade");
            modalTag.MergeAttribute("id", modelId);
            //modalTag.MergeAttribute("tabindex", "-1");
            modalTag.MergeAttribute("role", "dialog");
            modalTag.MergeAttribute("aria-hidden", "true");
            modalTag.MergeAttribute("data-keyboard", "true");
            modalTag.MergeAttribute("data-keyboard", "true");

            modalDialogTag.TagRenderMode = TagRenderMode.Normal;
            
            modalTag.InnerHtml.SetHtmlContent(modalDialogTag);
            
            var script =
                "<script>" + Environment.NewLine +
                "   $(document).ready(function () {" + Environment.NewLine +
                "       $('#" + modelId + "').modal({show:false}).on('show.bs.modal', function (e) {" + Environment.NewLine +
                "           var that = $(this);" + Environment.NewLine +
                "           that.find('.modal-dialog').attr('class', 'modal-dialog " + entranceAnimation + " animated');" +
                "           that.find('.modal-content').load($(e.relatedTarget).data('url'), function (response, error, xhr) {" + Environment.NewLine +
                "               if (xhr.status !== 400) {" + Environment.NewLine +
                "                   that.modal('handleUpdate');" + Environment.NewLine +
                "               }" + Environment.NewLine +
                "               else" + Environment.NewLine +
                "                   that.modal('hide');" + Environment.NewLine +
                "           });" + Environment.NewLine +
                "       }).on('hidden.bs.modal', function () {" + Environment.NewLine +
                "           $(this).find('.modal-content').empty();" + Environment.NewLine +
                "       }).on('hide.bs.modal', function () {" + Environment.NewLine +
                "           $(this).find('.modal-dialog').attr('class', 'modal-dialog " + exitAnimation + " animated');" +
                "       });" + Environment.NewLine +
                "   });" + Environment.NewLine +
                "</script>";

            HtmlContentBuilder hcb = new HtmlContentBuilder();
            
            hcb.AppendHtml(modalTag);

            hcb.AppendLine();

            hcb.AppendHtml(script);
            return hcb;
           
        }
    }
}