﻿using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.TagHelpers
{
    [HtmlTargetElement("input", Attributes = ForAttributeName)]
    public class InputIsDisabledTagHelper : InputTagHelper
    {
        private const string ForAttributeName = "asp-for";

        [HtmlAttributeName("asp-is-disabled")]
        public bool IsDisabled { set; get; }

        public InputIsDisabledTagHelper(IHtmlGenerator generator) : base(generator)
        {
            
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (IsDisabled)
            {
                var d = new TagHelperAttribute("disabled", "disabled");
                output.Attributes.Add(d);
            }
            base.Process(context, output);
        }


    }
}
