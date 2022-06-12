using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SStorm.CTH.DAL.EntityClasses;
using SStorm.CTH.DAL.HelperClasses;
using SStorm.CTH.BL.Helpers;
using SStorm.CTH.DAL;
using SStorm.CTH.Web.Models;
using SStorm.CTH.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SStorm.CTH.Web.Controllers
{
    public class PermissionController : SmartController
    {
        private readonly IUserService _userService;
        public PermissionController(IClientNotification notifier, IUserService userService) : base(notifier)
        {
            _userService = userService;
        }

        [SmartAuthorize(UserPermission.Role_AssignPermissionsToRole)]
        [HttpGet]
        public IActionResult EditCreate(int ID)
        {
            RolePermissionModel MyRolePermission = new RolePermissionModel();

            MyRolePermission.GroupPermissionList = new EntityCollection<CTHPermissionGroupEntity>();
            PrefetchPath2 path0 = new PrefetchPath2(EntityType.CTHPermissionGroupEntity);
            path0.Add(CTHPermissionGroupEntity.PrefetchPathCTHPermissionCollection, true);
           BL.DataBaseClassHelper.FillCollection(MyRolePermission.GroupPermissionList, null, 0, null, path0, 0, 0);

            MyRolePermission.Role = new CTHRoleEntity(ID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHRoleEntity);
            path.Add(CTHRoleEntity.PrefetchPathCTHRolePermissionCollection, true);
            BL.DataBaseClassHelper.FillEntity(MyRolePermission.Role, path);
            return View(MyRolePermission);
        }

        [SmartAuthorize(UserPermission.Role_AssignPermissionsToRole)]
        [HttpPost]
        public IActionResult EditCreate(int RoleID, List<int> PermissionIDs1, List<int> PermissionIDs2)
        {
            EntityCollection<CTHRolePermissionEntity> MyRolePermission = new EntityCollection<CTHRolePermissionEntity>();
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHRolePermissionFields.RoleID == RoleID);
            BL.DataBaseClassHelper.FillCollection(MyRolePermission, filter);
            foreach (var i in MyRolePermission)
            {
                var check = false;
                foreach (var x in PermissionIDs1)
                {
                    if (i.PermissionID == x)
                    {
                        check = true;
                    }
                }
                if (check == false)
                {
                  BL.DataBaseClassHelper.Delete(i, 0);
                }
            }
            foreach (var item in PermissionIDs2)
            {
                CTHRolePermissionEntity RolePermission = new CTHRolePermissionEntity()
                {
                    PermissionID = item,
                    RoleID = RoleID
                };
               BL.DataBaseClassHelper.SaveEntity(RolePermission, true, false, 0);
            }
            AddSweetNotification("Done", "Saved successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("EditCreate", new { ID = RoleID });
        }
    }
}