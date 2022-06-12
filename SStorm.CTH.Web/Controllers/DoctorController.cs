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
using System.IO;
using X.PagedList;
using Microsoft.Extensions.Localization;

namespace SStorm.CTH.Web.Controllers
{

    public class DoctorController : SmartController
    {
        public DoctorController(IClientNotification _clientNotification)
         : base(_clientNotification)
        {
        }

       

        [SmartAuthorize(UserPermission.Doctor_View)]
        public IActionResult Index(SearchFacade<CTHDoctorEntity> model)
        {
            EntityCollection<CTHDoctorEntity> DoctorCollection = new EntityCollection<CTHDoctorEntity>();
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDoctorEntity);
            path.Add(CTHDoctorEntity.PrefetchPathCTHUserItem, true);
            RelationPredicateBucket filter = new RelationPredicateBucket();
            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHDoctorFields.Name % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(DoctorCollection, filter, model.PageSize, null, path, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHDoctorFields.ID, filter);

            model.DataPagedList = new StaticPagedList<CTHDoctorEntity>(DoctorCollection, model.Page, model.PageSize, Count);
            return View(model);
        }

        [SmartAuthorize(UserPermission.Doctor_EditCreate)]

        [HttpGet]
        public IActionResult EditCreate(int ID)
        {
            DoctorModel model = new DoctorModel();
            if (ID > 0)
            {
                model.DoctorEntity = new CTHDoctorEntity(ID);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDoctorEntity);
                path.Add(CTHDoctorEntity.PrefetchPathCTHUserItem, true);
                BL.DataBaseClassHelper.FillEntity(model.DoctorEntity, path);
            }

            return PartialView(model);
        }

        [SmartAuthorize(UserPermission.Doctor_EditCreate)]

        [HttpPost]
        public IActionResult EditCreate(DoctorModel model)
        {
            EntityCollection<CTHUserEntity> userCollection = new EntityCollection<CTHUserEntity>();
            RelationPredicateBucket userfilter = new RelationPredicateBucket(CTHUserFields.UserName == model.DoctorEntity.CTHUserItem.UserName | CTHUserFields.Email == model.DoctorEntity.CTHUserItem.Email);
            BL.DataBaseClassHelper.FillCollection(userCollection, userfilter, 0, null, null, 0, 0);
            var result = false;
            model.DoctorEntity.CTHUserItem.Password = Helper.TextEncryption.Encrypt(model.DoctorEntity.CTHUserItem.Password);
            if (model.DoctorEntity.ID == 0 && model.DoctorEntity.CTHUserItem.ID==0)
            {
                if (userCollection.Count == 0)
                {
                    SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.DoctorEntity.CTHUserItem, true, true, 0);
                    model.DoctorEntity.UserID = model.DoctorEntity.CTHUserItem.ID;
                    SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.DoctorEntity, true, true, 0);
                    result = true;
                }
            }
            else
            {
                if (userCollection.Count == 0)
                {
                    RelationPredicateBucket Docfilter = new RelationPredicateBucket(CTHDoctorFields.ID == model.DoctorEntity.ID);
                    RelationPredicateBucket Userfilter = new RelationPredicateBucket(CTHUserFields.ID == model.DoctorEntity.CTHUserItem.ID);
                    SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(model.DoctorEntity.CTHUserItem, Userfilter, 0);
                    model.DoctorEntity.UserID = model.DoctorEntity.CTHUserItem.ID;
                    SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(model.DoctorEntity, Docfilter, 0);
                    result = true;
                }
                else
                {
                    CTHUserEntity OldUserData = new CTHUserEntity(model.DoctorEntity.CTHUserItem.ID);
                    BL.DataBaseClassHelper.FillEntity(OldUserData, null);
                    if (userCollection.Count == 1 && userCollection[0].UserName == OldUserData.UserName)
                    {
                        RelationPredicateBucket Docfilter = new RelationPredicateBucket(CTHDoctorFields.ID == model.DoctorEntity.ID);
                        RelationPredicateBucket Userfilter = new RelationPredicateBucket(CTHUserFields.ID == model.DoctorEntity.CTHUserItem.ID);
                        SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(model.DoctorEntity.CTHUserItem, Userfilter, 0);
                        model.DoctorEntity.UserID = model.DoctorEntity.CTHUserItem.ID;
                        SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(model.DoctorEntity, Docfilter, 0);
                        result = true;
                    }
                }
            }
            if (result == true)
            {
                AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                AddSweetNotification("Error", "Error ,Change Your UserName Or Email", Helper.NotificationHelper.NotificationType.error);
                return RedirectToAction("Index");
            }
        }

        [SmartAuthorize(UserPermission.Doctor_EditCreate)]
        [HttpGet]
        public IActionResult Profile(int ID)
        {
            DoctorModel model = new DoctorModel();
            if (ID > 0)
            {
                model.DoctorEntity = new CTHDoctorEntity(ID);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDoctorEntity);
                path.Add(CTHDoctorEntity.PrefetchPathCTHUserItem, true);
                BL.DataBaseClassHelper.FillEntity(model.DoctorEntity, path);
            }

            return PartialView(model);
        }

        [SmartAuthorize(UserPermission.Doctor_EditCreate)]

        [HttpPost]
        public IActionResult Profile(DoctorModel model)
        {
            EntityCollection<CTHUserEntity> userCollection = new EntityCollection<CTHUserEntity>();
            RelationPredicateBucket userfilter = new RelationPredicateBucket(CTHUserFields.UserName == model.DoctorEntity.CTHUserItem.UserName | CTHUserFields.Email == model.DoctorEntity.CTHUserItem.Email);
            BL.DataBaseClassHelper.FillCollection(userCollection, userfilter, 0, null, null, 0, 0);
            var result = false;
            model.DoctorEntity.CTHUserItem.Password = Helper.TextEncryption.Encrypt(model.DoctorEntity.CTHUserItem.Password);
            if (model.DoctorEntity.ID == 0 && model.DoctorEntity.CTHUserItem.ID == 0)
            {
                if (userCollection.Count == 0)
                {
                    SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.DoctorEntity.CTHUserItem, true, true, 0);
                    model.DoctorEntity.UserID = model.DoctorEntity.CTHUserItem.ID;
                    SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.DoctorEntity, true, true, 0);
                    result = true;
                }
            }
            else
            {
                if (userCollection.Count == 0)
                {
                    RelationPredicateBucket Docfilter = new RelationPredicateBucket(CTHDoctorFields.ID == model.DoctorEntity.ID);
                    RelationPredicateBucket Userfilter = new RelationPredicateBucket(CTHUserFields.ID == model.DoctorEntity.CTHUserItem.ID);
                    SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(model.DoctorEntity.CTHUserItem, Userfilter, 0);
                    model.DoctorEntity.UserID = model.DoctorEntity.CTHUserItem.ID;
                    SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(model.DoctorEntity, Docfilter, 0);
                    result = true;
                }
                else
                {
                    CTHUserEntity OldUserData = new CTHUserEntity(model.DoctorEntity.CTHUserItem.ID);
                    BL.DataBaseClassHelper.FillEntity(OldUserData, null);
                    if (userCollection.Count == 1 && userCollection[0].UserName == OldUserData.UserName)
                    {
                        RelationPredicateBucket Docfilter = new RelationPredicateBucket(CTHDoctorFields.ID == model.DoctorEntity.ID);
                        RelationPredicateBucket Userfilter = new RelationPredicateBucket(CTHUserFields.ID == model.DoctorEntity.CTHUserItem.ID);
                        SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(model.DoctorEntity.CTHUserItem, Userfilter, 0);
                        model.DoctorEntity.UserID = model.DoctorEntity.CTHUserItem.ID;
                        SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(model.DoctorEntity, Docfilter, 0);
                        result = true;
                    }
                }
            }
            if (result == true)
            {
                AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
                return RedirectToAction("Index","Home");
            }
            else
            {
                AddSweetNotification("Error", "Error ,Change Your UserName Or Email", Helper.NotificationHelper.NotificationType.error);
                return RedirectToAction("Profile",new { ID = model.DoctorEntity.ID});
            }
        }

        [SmartAuthorize(UserPermission.Doctor_Delete)]

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = ID,
            });
        }

        [SmartAuthorize(UserPermission.Doctor_Delete)]

        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHDoctorEntity Doc = new CTHDoctorEntity(ItemID);
            PrefetchPath2 pathDoc = new PrefetchPath2(EntityType.CTHDoctorEntity);
            pathDoc.Add(CTHDoctorEntity.PrefetchPathCTHPatientCollection, true);
            pathDoc.Add(CTHDoctorEntity.PrefetchPathCTHNotificationCollection, true);
            pathDoc.Add(CTHDoctorEntity.PrefetchPathCTHUserItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(Doc, pathDoc);
            CTHUserEntity User = new CTHUserEntity((int)Doc.UserID);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(User, null);
            if (Doc.CTHPatientCollection.Count==0)
            {
                foreach(var item in Doc.CTHNotificationCollection)
                {
                    CTHNotificationEntity noti = new CTHNotificationEntity(item.ID);
                    SStorm.CTH.BL.DataBaseClassHelper.FillEntity(noti, null);
                    SStorm.CTH.BL.DataBaseClassHelper.Delete(noti, 0);
                }
                SStorm.CTH.BL.DataBaseClassHelper.Delete(Doc, 0);
                SStorm.CTH.BL.DataBaseClassHelper.Delete(User, 0);
                AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                AddSweetNotification("Error", "Error ,This Row Is Related To Another Row", Helper.NotificationHelper.NotificationType.error);
                return RedirectToAction("Index");
            }

        }

    }
}