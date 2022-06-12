using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Infrastructure
{

    public abstract class BaseViewPage<TModel> : RazorPage<TModel>
    {

        [RazorInject]
        public IAuthorizationService AuthorizationService { get; set; }
        protected BaseViewPage()
        {

        }
        public bool Authorize(UserPermission userPermission)
        {
            return Task.Run(async () => await AuthorizationService.AuthorizeAsync(User, Model, userPermission.ToString()))
                .Result.Succeeded;

        }
    }

}
