using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SStorm.CTH.DAL;
using SStorm.CTH.DAL.EntityClasses;
using SStorm.CTH.DAL.HelperClasses;
using SStorm.CTH.Web.Infrastructure;
using SStorm.CTH.Web.Models;
using X.PagedList;

namespace SStorm.CTH.Web.Controllers
{
    public class UserController : SmartController
    {
        public UserController(IClientNotification _clientNotification)
         : base(_clientNotification)
        {

        }

        [SmartAuthorize(UserPermission.User_View)]
        public IActionResult Index(SearchFacade<CTHUserEntity> model)
        {
            EntityCollection<CTHUserEntity> UserCollection = new EntityCollection<CTHUserEntity>();
            RelationPredicateBucket filter = new RelationPredicateBucket();
            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHUserFields.UserName % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(UserCollection, filter, model.PageSize, null, null, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHUserFields.ID, filter);

            model.DataPagedList = new StaticPagedList<CTHUserEntity>(UserCollection, model.Page, model.PageSize, Count);
            return View(model);
            
        }

        [SmartAuthorize(UserPermission.User_EditCreate)]
        [HttpGet]
        public IActionResult EditCreate(int ID)
        {
            CTHUserEntity User = new CTHUserEntity();
            if (ID > 0)
            {
                User = new CTHUserEntity(ID);

                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(User, null);
            }

            return View(User);
        }

        [SmartAuthorize(UserPermission.User_EditCreate)]
        [HttpPost]
        public IActionResult EditCreate(CTHUserEntity USer)
        {
            USer.Password = Helper.TextEncryption.Encrypt(USer.Password);
            EntityCollection<CTHUserEntity> users = new EntityCollection<CTHUserEntity>();
            RelationPredicateBucket usersfilter = new RelationPredicateBucket();
            usersfilter.PredicateExpression.Add(CTHUserFields.UserName == USer.UserName | CTHUserFields.Email == USer.Email);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(users, usersfilter, 0, null, null, 0, 0);
            if (USer.ID == 0)
            {
                if (users.Count == 0)
                {
                    SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(USer, true, false, 0);
                }
                else
                {
                    AddSweetNotification("Error", "This username or email is already existing", Helper.NotificationHelper.NotificationType.error);
                }

            }
            else
            {
                var oldUser = new CTHUserEntity(USer.ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(oldUser, null);
                users.Remove(oldUser);
                if (users.Count == 0)
                {
                    RelationPredicateBucket filter = new RelationPredicateBucket();
                    filter.PredicateExpression.Add(CTHUserFields.ID == USer.ID);
                    SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(USer, filter, 0);
                }
                else
                {
                    AddSweetNotification("Error", "This username or email is already existing", Helper.NotificationHelper.NotificationType.error);
                }
            }
            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index");
        }

        [SmartAuthorize(UserPermission.User_Delete)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.User_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHUserEntity USer = new CTHUserEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHUserEntity);
            path.Add(CTHUserEntity.PrefetchPathCTHDoctorCollection);
            path.Add(CTHUserEntity.PrefetchPathCTHPatientCollection);
            path.Add(CTHUserEntity.PrefetchPathCTHUserRoleCollection);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(USer, path);
            if (USer.CTHDoctorCollection.Count == 0 && USer.CTHPatientCollection.Count == 0 && USer.CTHUserRoleCollection.Count == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(USer, 0);
                AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);
            }
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public ActionResult UserPermission(int UserID)
        //{
        //    UserPermissionModel UserPermissionModel = new UserPermissionModel();

        //    UserPermissionModel.PermissionGroupList = new EntityCollection<CTHPermissionGroupEntity>();
        //    PrefetchPath2 PermissionGroupPath = new PrefetchPath2(EntityType.CTHPermissionGroupEntity);
        //    PermissionGroupPath.Add(CTHPermissionGroupEntity.PrefetchPathCTHPermissionCollection);
        //    SStorm.CTH.BL.DataBaseClassHelper.FillCollection(UserPermissionModel.PermissionGroupList, null, 0, null, PermissionGroupPath, 0, 0);

        //    UserPermissionModel.User = new CTHUserEntity(UserID);
        //    PrefetchPath2 UserPath = new PrefetchPath2(EntityType.CTHUserEntity);
        //    UserPath.Add(CTHUserEntity.PrefetchPathCTHUserRoleCollection)
        //        .SubPath.Add(CTHUserRoleEntity.PrefetchPathCTHRoleItem);
        //    SStorm.CTH.BL.DataBaseClassHelper.FillEntity(UserPermissionModel.User, UserPath);

        //    return View(UserPermissionModel);
        //}

        //[HttpPost]
        //public ActionResult UserPermission(int User_ID, List<int> PermissionIDsToCreate, List<int> PermissionIDsToDelete)
        //{
        //    if(PermissionIDsToCreate.Count != 0)
        //    {
        //        foreach (var item in PermissionIDsToCreate)
        //        {
        //            CTHUserPermissionEntity UserPermission = new CTHUserPermissionEntity()
        //            {
        //                UserID = User_ID,
        //                PermissionID = item
        //            };
        //            SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(UserPermission, true, false, 0);
        //        }
        //    }
        //    if(PermissionIDsToDelete.Count != 0)
        //    {
        //        foreach(var item in PermissionIDsToDelete)
        //        {
        //            CTHUserPermissionEntity UserPermission = new CTHUserPermissionEntity(item);
        //            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(UserPermission,null);
        //            SStorm.CTH.BL.DataBaseClassHelper.Delete(UserPermission, 0);
        //        }
        //    }
        //    AddSweetNotification("Done","Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
        //    return RedirectToAction("UserPermission", new { UserID = User_ID });
        //}

    }
}