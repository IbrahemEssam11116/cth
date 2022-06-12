

using Microsoft.AspNetCore.Mvc.Filters;

namespace SStorm.CTH.Web.Infrastructure
{
    public class ParameterBasedOnFormNameAttribute : ActionFilterAttribute, IActionFilter
    {
        private readonly string _name;
        private readonly string _actionParameterName;

        public ParameterBasedOnFormNameAttribute(string name, string actionParameterName)
        {
            this._name = name;
            this._actionParameterName = actionParameterName;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var formValue = context.HttpContext.Request.Form[_name];
            context.ActionArguments.Add(_actionParameterName, !string.IsNullOrEmpty(formValue));

        }
    }
}