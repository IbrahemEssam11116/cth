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
    public class TNMStagingController : SmartController
    {
        public TNMStagingController(IClientNotification _clientNotification)
          : base(_clientNotification)
        {

        }

        [SmartAuthorize(UserPermission.TNMStaging_ViewStaging)]
        public IActionResult Index()
        {
            TNMStagingModel TNMStagingModel = new TNMStagingModel();
            TNMStagingModel.TNMStagingCollection = new EntityCollection<CTHTNMStagingEntity>();
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(TNMStagingModel.TNMStagingCollection, null, 0, null, null,0,0);
            TNMStagingModel.StagingCollection = new EntityCollection<CTHStagingEntity>();
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(TNMStagingModel.StagingCollection, null, 0, null, null, 0, 0);
            return View(TNMStagingModel);
        }

        [SmartAuthorize(UserPermission.TNMStaging_EditCreateStaging)]
        [HttpGet]
        public IActionResult EditCreate(int ID , int TNMTypeID)
        {
            CTHTNMStagingEntity TNM = new CTHTNMStagingEntity();

            if (ID > 0)
            {
                TNM = new CTHTNMStagingEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(TNM, null);
            }
            else
            {
                TNM.TNMTypeID = TNMTypeID;
            }

            return PartialView(TNM);
        }

        [SmartAuthorize(UserPermission.TNMStaging_EditCreateStaging)]
        [HttpPost]
        public IActionResult EditCreate(CTHTNMStagingEntity TNM)
        {
            if (TNM.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(TNM, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket(CTHTNMStagingFields.ID == TNM.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(TNM, filter, 0);
            }
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(TNM,null);
            int TNMTypeID = (int)TNM.TNMTypeID;
            return GETTNMStagingList(TNMTypeID);
        }

        [SmartAuthorize(UserPermission.TNMStaging_DeleteStaging)]
        [HttpGet]
        public ActionResult Delete(int id ,int TNMTypeID)
        {
            if (TNMTypeID == 1)
            {
                return PartialView("DeleteItem", new DeleteItemModel
                {
                    ItemID = id,
                    ActionName = "Delete",
                    ControllerName = "TNMStaging",
                    DataAjaxMethod = "post",
                    DataAjax = true,
                    DataAjaxSuccess = "LoadTumorsize"
                });
            }
            else if (TNMTypeID == 2)
            {
                return PartialView("DeleteItem", new DeleteItemModel
                {
                    ItemID = id,
                    ActionName = "Delete",
                    ControllerName = "TNMStaging",
                    DataAjaxMethod = "post",
                    DataAjax = true,
                    DataAjaxSuccess = "LoadLymphNode"
                });
            }
            else 
            {
                return PartialView("DeleteItem", new DeleteItemModel
                {
                    ItemID = id,
                    ActionName = "Delete",
                    ControllerName = "TNMStaging",
                    DataAjaxMethod = "post",
                    DataAjax = true,
                    DataAjaxSuccess = "LoadDistantMetastasis"
                });
            }
           
        }

        [SmartAuthorize(UserPermission.TNMStaging_DeleteStaging)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHTNMStagingEntity item = new CTHTNMStagingEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHTNMStagingEntity);
            path.Add(CTHTNMStagingEntity.PrefetchPathCTHTNMStagingMatrixCollection, true);
            path.Add(CTHTNMStagingEntity.PrefetchPathCTHTNMStagingMatrixCollection1, true);
            path.Add(CTHTNMStagingEntity.PrefetchPathCTHTNMStagingMatrixCollection2, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            if (item.CTHTNMStagingMatrixCollection.Count != 0 || item.CTHTNMStagingMatrixCollection1.Count != 0 || item.CTHTNMStagingMatrixCollection2.Count != 0)
            {
               // AddSweetNotification("Error", "Can not remove this item", Helper.NotificationHelper.NotificationType.error);
                return Json(JsonReturnType.DeleteFail);
            }
            else
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                // AddSweetNotification("Done","Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
                return Json(JsonReturnType.DeleteSuccess);
            }

        }

        [SmartAuthorize(UserPermission.TNMStaging_DeleteStaging)]
        [HttpGet]
        public IActionResult GETTNMStagingList( int TNMTypeID)
        {
            TNMStagingModel TNMStagingModel = new TNMStagingModel();
            TNMStagingModel.TNMStagingCollection = new EntityCollection<CTHTNMStagingEntity>();
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(TNMStagingModel.TNMStagingCollection, null, 0, null, null, 0, 0);
            TNMStagingModel.StagingCollection = new EntityCollection<CTHStagingEntity>();
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(TNMStagingModel.StagingCollection, null, 0, null, null, 0, 0);
            if (TNMTypeID==1)
            {
                return PartialView("_TStagingList", TNMStagingModel);
            }
            else if (TNMTypeID == 2)
            {
                return PartialView("_NStagingList", TNMStagingModel);
            }
            else
            {
                return PartialView("_MStagingList", TNMStagingModel);
            }
        }
    }
}