using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using SStorm.CTH.DAL.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SStorm.CTH.Web.Models
{
    public class UserPermissionModel
    {
        public CTHUserEntity User { get; set; }
        public EntityCollection<CTHPermissionGroupEntity> PermissionGroupList { get; set; }
    }
}
