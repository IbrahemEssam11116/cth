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

namespace SStorm.CTH.Web.Controllers
{
    public class StagingController : SmartController
    {
        public StagingController(IClientNotification _clientNotification)
         : base(_clientNotification)
        {

        }
        [SmartAuthorize(UserPermission.TNMStaging_ViewStaging)]
        public IActionResult Index()
        {
            EntityCollection<CTHStagingEntity> Staging = new EntityCollection<CTHStagingEntity>();
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHStagingEntity);
            var xx = path.Add(CTHStagingEntity.PrefetchPathCTHTNMStagingMatrixCollection, true);
            xx.SubPath.Add(CTHTNMStagingMatrixEntity.PrefetchPathCTHTNMStagingItem,true);
            xx.SubPath.Add(CTHTNMStagingMatrixEntity.PrefetchPathCTHTNMStagingItem1, true);
            xx.SubPath.Add(CTHTNMStagingMatrixEntity.PrefetchPathCTHTNMStagingItem2, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(Staging, null, 0, null, path, 0, 0);
            return View(Staging);
        }

        [SmartAuthorize(UserPermission.TNMStaging_EditCreateStaging)]
        [HttpGet]
        public IActionResult EditCreate(int ID)
        {
            CTHStagingEntity staging = new CTHStagingEntity();

            if (ID > 0)
            {
                staging = new CTHStagingEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(staging, null);
            }          
            return PartialView(staging);
        }

        [SmartAuthorize(UserPermission.TNMStaging_EditCreateStaging)]
        [HttpPost]
        public IActionResult EditCreate(CTHStagingEntity staging)
        {
            if (staging.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(staging, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket(CTHStagingFields.ID == staging.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(staging, filter, 0);
            }
            AddSweetNotification("Done","Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index","TNMStaging");
        }

        [SmartAuthorize(UserPermission.TNMStaging_DeleteStaging)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.TNMStaging_DeleteStaging)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHStagingEntity item = new CTHStagingEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHStagingEntity);
            path.Add(CTHStagingEntity.PrefetchPathCTHTNMStagingMatrixCollection, true);
            path.Add(CTHStagingEntity.PrefetchPathCTHPatientClinicalDataCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            if (item.CTHTNMStagingMatrixCollection.Count == 0 && item.CTHPatientClinicalDataCollection.Count == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Done","Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "Can not remove this item", Helper.NotificationHelper.NotificationType.error);
            }

            return RedirectToAction("Index", "TNMStaging");
        }

        
    }
}