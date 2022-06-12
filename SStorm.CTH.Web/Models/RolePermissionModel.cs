using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using SStorm.CTH.DAL.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class RolePermissionModel
    {
        public CTHRoleEntity Role { get; set; }
        public EntityCollection<CTHPermissionGroupEntity> GroupPermissionList { get; set; }
    }
}
