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
using X.PagedList;

namespace SStorm.CTH.Web.Controllers
{
    public class RoleController : SmartController
    {
        private readonly IUserService _userService;
        public RoleController(IClientNotification notifier, IUserService userService) 
            : base(notifier)
        {
            _userService = userService;
        }

        #region Role

        [SmartAuthorize(UserPermission.Role_View)]
        public IActionResult Index(SearchFacade<CTHRoleEntity> model)
        {
            EntityCollection<CTHRoleEntity> RoleEntityCollection = new EntityCollection<CTHRoleEntity>();
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHRoleEntity);
            path.Add(CTHRoleEntity.PrefetchPathCTHUserRoleCollection, true)
            .SubPath.Add(CTHUserRoleEntity.PrefetchPathCTHUserItem, true);
            RelationPredicateBucket filter = new RelationPredicateBucket();
            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHRoleFields.RoleNmae % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(RoleEntityCollection, filter, model.PageSize, null, path, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHRoleFields.ID, filter);
            model.DataPagedList = new StaticPagedList<CTHRoleEntity>(RoleEntityCollection, model.Page, model.PageSize, Count);

            return View(model);
        }

        [SmartAuthorize(UserPermission.Role_EditCreate)]
        [HttpGet]
        public IActionResult EditCreate(int ID)
        {
            CTHRoleEntity Role = new CTHRoleEntity();
            if (ID > 0)
            {
                Role = new CTHRoleEntity(ID);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHRoleEntity);
                path.Add(CTHRoleEntity.PrefetchPathCTHRolePermissionCollection, true);
                path.Add(CTHRoleEntity.PrefetchPathCTHUserRoleCollection, true)
                    .SubPath.Add(CTHUserRoleEntity.PrefetchPathCTHUserItem, true);
                BL.DataBaseClassHelper.FillEntity(Role, path);
            }
            return View(Role);
        }

        [SmartAuthorize(UserPermission.Role_EditCreate)]
        [HttpPost]
        public IActionResult EditCreate(CTHRoleEntity Role)
        {
            if (Role.ID == 0)
            {
                BL.DataBaseClassHelper.SaveEntity(Role, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHRoleFields.ID == Role.ID);
                BL.DataBaseClassHelper.UpdateEntityDirectly(Role, filter, 0);
            }
            AddSweetNotification("Done", "Data Successfully Saved", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("EditCreate", new { ID = Role.ID });
        }

        [SmartAuthorize(UserPermission.Role_Delete)]
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = ID
            });
        }

        [SmartAuthorize(UserPermission.Role_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHRoleEntity Role = new CTHRoleEntity();
            Role = new CTHRoleEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHRoleEntity);
            path.Add(CTHRoleEntity.PrefetchPathCTHUserRoleCollection, true);
            path.Add(CTHRoleEntity.PrefetchPathCTHRolePermissionCollection, true);
            BL.DataBaseClassHelper.FillEntity(Role, path);

            if (Role.CTHUserRoleCollection.Count == 0)
            {
                BL.DataBaseClassHelper.Delete(Role, 0);
                AddSweetNotification("Done", "Deletion successful", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "Data Can't Be Deleted", Helper.NotificationHelper.NotificationType.error);
            }
            return RedirectToAction("Index");

        }
        #endregion

        #region UserRole

        [SmartAuthorize(UserPermission.Role_AssignUserToRole)]
        [HttpGet]
        public IActionResult AssignUser(int ID, int RoleID)
        {
            UserRoleModel UserRole = new UserRoleModel();
            UserRole.UserRoleEntity = new CTHUserRoleEntity();
            RelationPredicateBucket userfilter = new RelationPredicateBucket();
            userfilter.PredicateExpression.Add(
                new FieldCompareSetPredicate(CTHUserFields.ID, null, CTHUserRoleFields.UserID, null, SetOperator.In, new PredicateExpression(CTHUserRoleFields.RoleID == RoleID), true));
            UserRole.UserList = DataHelper.GetSelectList<CTHUserEntity>(CTHUserFields.ID, CTHUserFields.UserName, userfilter ,null);
            if (ID > 0)
            {
                UserRole.UserRoleEntity = new CTHUserRoleEntity(ID);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHUserRoleEntity);
                path.Add(CTHUserRoleEntity.PrefetchPathCTHRoleItem, true);
                BL.DataBaseClassHelper.FillEntity(UserRole.UserRoleEntity, path);
            }
            UserRole.UserRoleEntity.RoleID = RoleID;
            return PartialView(UserRole);
        }

        [SmartAuthorize(UserPermission.Role_AssignUserToRole)]
        [HttpPost]
        public IActionResult AssignUser(UserRoleModel UserRole)
        {
            if (UserRole.UserRoleEntity.ID == 0)
            {
                BL.DataBaseClassHelper.SaveEntity(UserRole.UserRoleEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHUserRoleFields.ID == UserRole.UserRoleEntity.ID);
                BL.DataBaseClassHelper.UpdateEntityDirectly(UserRole.UserRoleEntity, filter, 0);
            }
            AddSweetNotification("Done", "Data successfully saved", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("EditCreate", new { ID = UserRole.UserRoleEntity.RoleID});
        }

        [SmartAuthorize(UserPermission.Role_DeleteUserFromRole)]
        [HttpGet]
        public IActionResult DeleteUserRole(int ID)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ControllerName = "Role",
                ActionName = "DeleteUserRole",
                ItemID = ID
            });
        }

        [SmartAuthorize(UserPermission.Role_DeleteUserFromRole)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteUserRole")]
        public ActionResult ConfirmDeleteUserRole(int ItemID)
        {
            CTHUserRoleEntity UserRole = new CTHUserRoleEntity(ItemID);
            BL.DataBaseClassHelper.FillEntity(UserRole, null);
            int RoleID = (int)UserRole.RoleID;
            BL.DataBaseClassHelper.Delete(UserRole, 0);
            AddSweetNotification("Done", "Deletion successful", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("EditCreate", new { ID = RoleID });
        }
        #endregion

    }
}