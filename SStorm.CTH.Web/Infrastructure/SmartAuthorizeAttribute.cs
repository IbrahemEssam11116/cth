using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Infrastructure
{

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class SmartAuthorizeAttribute : AuthorizeAttribute
    {

        public SmartAuthorizeAttribute():base()
        {

        }
        public SmartAuthorizeAttribute(UserPermission privilegeName) : base(privilegeName.ToString())
        {

        }

    }
}
