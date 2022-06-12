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
    public class LabController : SmartController
    {
        public LabController(IClientNotification _clientNotification)
           : base(_clientNotification)
        {

        }
        #region Lab
        [SmartAuthorize(UserPermission.IntialLab_View)]
        public IActionResult Index()
        {
            EntityCollection<CTHLabEntity> LabCollection = new EntityCollection<CTHLabEntity>();
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(LabCollection, null, 0, null, null, 0, 0);
            return View(LabCollection);
        }

        [SmartAuthorize(UserPermission.IntialLab_EditCreate)]
        [HttpGet]
        public IActionResult EditCreate(int ID)
        {
            LabModel LabModel = new LabModel();
            LabModel.LabEntity = new CTHLabEntity();
            if (ID > 0)
            {
                LabModel.LabEntity = new CTHLabEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(LabModel.LabEntity, null);
            }
            LabModel.ProtocolList = DataHelper.GetSelectList<CTHChemotherapyProtocolEntity>(CTHChemotherapyProtocolFields.ID, CTHChemotherapyProtocolFields.ProtocolName);
            return PartialView(LabModel);
        }

        [SmartAuthorize(UserPermission.IntialLab_EditCreate)]
        [HttpPost]
        public IActionResult EditCreate(LabModel Lab, bool LabEntity_IsMandatory)
        {
            Lab.LabEntity.IsMandatory = LabEntity_IsMandatory;
            if (Lab.LabEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(Lab.LabEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHLabFields.ID == Lab.LabEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(Lab.LabEntity, filter, 0);
            }
            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index");
        }

        [SmartAuthorize(UserPermission.IntialLab_Delete)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.IntialLab_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHLabEntity item = new CTHLabEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabEntity);
            path.Add(CTHLabEntity.PrefetchPathCTHLabDetailCollection, true);
            path.Add(CTHLabEntity.PrefetchPathCTHPatientIntialLabCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            if (item.CTHLabDetailCollection.Count == 0 && item.CTHPatientIntialLabCollection.Count == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "Error, You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);

            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Lab Detail Conditions
        [SmartAuthorize(UserPermission.IntialLab_View)]
        public IActionResult GetLabDetailCondition(int LabDetailID)
        {
            LabDetailConditionModel LabDetailCondition = new LabDetailConditionModel();
            LabDetailCondition.LabDetailEntity = new CTHLabDetailEntity(LabDetailID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabDetailEntity);
            path.Add(CTHLabDetailEntity.PrefetchPathCTHLabDetailConditionCollection, true)
                .SubPath.Add(CTHLabDetailConditionEntity.PrefetchPathCTHOperatorItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(LabDetailCondition.LabDetailEntity, path);
            //LabDetailCondition.OpertorList = DataHelper.GetSelectList<CTHOperatorEntity>( CTHOperatorFields.ID, CTHOperatorFields.OpertorName);
            return View(LabDetailCondition);
        }


        [SmartAuthorize(UserPermission.IntialLab_EditCreate)]
        [HttpGet]
        public IActionResult EditCreateLabDetailCondition(int ID, int LabDetailID)
        {
            LabDetailConditionModel LabDetailCondition = new LabDetailConditionModel();
            LabDetailCondition.LabDetailConditionEntity = new CTHLabDetailConditionEntity();
            LabDetailCondition.OpertorList = DataHelper.GetSelectList<CTHOperatorEntity>(CTHOperatorFields.ID, CTHOperatorFields.OpertorName);
            if (ID > 0)
            {
                LabDetailCondition.LabDetailConditionEntity = new CTHLabDetailConditionEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(LabDetailCondition.LabDetailConditionEntity, null);
            }
            LabDetailCondition.LabDetailConditionEntity.LabDetailID = LabDetailID;
            return PartialView(LabDetailCondition);
        }

        [SmartAuthorize(UserPermission.IntialLab_EditCreate)]
        [HttpPost]
        public IActionResult EditCreateLabDetailCondition(LabDetailConditionModel LabDetailCondition)
        {
            if (LabDetailCondition.LabDetailConditionEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(LabDetailCondition.LabDetailConditionEntity, true, false, 0);
                AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHLabDetailConditionFields.ID == LabDetailCondition.LabDetailConditionEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(LabDetailCondition.LabDetailConditionEntity, filter, 0);
                AddSweetNotification("Done", "Data Updated Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            return RedirectToAction("GetLabDetailCondition", new { LabDetailID = LabDetailCondition.LabDetailConditionEntity.LabDetailID });
        }


        [SmartAuthorize(UserPermission.IntialLab_Delete)]
        [HttpGet]
        public ActionResult DeleteLabDetailCondition(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.IntialLab_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteLabDetailCondition")]
        public ActionResult ConfirmDeleteLabDetailCondition(int ItemID)
        {
            CTHLabDetailConditionEntity item = new CTHLabDetailConditionEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabDetailConditionEntity);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, null);
            int LabDetailID = (int)item.LabDetailID;
            SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
            AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("GetLabDetailCondition", new { LabDetailID = LabDetailID });
        }
        #endregion

        #region Lab Details

        [SmartAuthorize(UserPermission.IntialLab_View)]
        [HttpGet]
        public IActionResult GetLabDetails(int ID)
        {
            CTHLabEntity CTHLabEntity = new CTHLabEntity(ID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabEntity);
            path.Add(CTHLabEntity.PrefetchPathCTHLabDetailCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CTHLabEntity, path);
            return View(CTHLabEntity);
        }

        [SmartAuthorize(UserPermission.IntialLab_EditCreate)]
        [HttpGet]
        public IActionResult EditCreateLabDetail(int ID, int LabID)
        {
            CTHLabDetailEntity CTHLabDetailEntity = new CTHLabDetailEntity();
            if (ID > 0)
            {
                CTHLabDetailEntity = new CTHLabDetailEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CTHLabDetailEntity, null);
            }
            CTHLabDetailEntity.LabID = LabID;

            return PartialView(CTHLabDetailEntity);
        }

        [SmartAuthorize(UserPermission.IntialLab_EditCreate)]
        [HttpPost]
        public IActionResult EditCreateLabDetail(CTHLabDetailEntity CTHLabDetailEntity)
        {
            if (CTHLabDetailEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(CTHLabDetailEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHLabDetailFields.ID == CTHLabDetailEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(CTHLabDetailEntity, filter, 0);
            }
            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("GetLabDetails", new { ID = CTHLabDetailEntity.LabID });
        }

        [SmartAuthorize(UserPermission.IntialLab_Delete)]
        [HttpGet]
        public ActionResult DeleteLabDetail(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.IntialLab_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteLabDetail")]
        public ActionResult ConfirmDeleteLabDetail(int ItemID)
        {
            CTHLabDetailEntity item = new CTHLabDetailEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabDetailEntity);
            path.Add(CTHLabDetailEntity.PrefetchPathCTHChemoLabCollection, true);
            path.Add(CTHLabDetailEntity.PrefetchPathCTHCycleLabCollection, true);
            path.Add(CTHLabDetailEntity.PrefetchPathCTHLabDetailConditionCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            int LabID = (int)item.LabID;
            if (item.CTHChemoLabCollection.Count == 0 && item.CTHCycleLabCollection.Count == 0 && item.CTHLabDetailConditionCollection.Count == 0)
            {

                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "Error, You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);

            }
            return RedirectToAction("GetLabDetails", new { ID = LabID });
        }

        [SmartAuthorize(UserPermission.IntialLab_View)]
        public ActionResult GetLabsInfo()
        {
            EntityCollection<CTHLabEntity> Labs = new EntityCollection<CTHLabEntity>();
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabEntity);
            path.Add(CTHLabEntity.PrefetchPathCTHLabDetailCollection, true)
                .SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabDetailConditionCollection, true)
                .SubPath.Add(CTHLabDetailConditionEntity.PrefetchPathCTHOperatorItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(Labs, null, 0, null, path, 0, 0);
            return View(Labs);
        }
        #endregion
    }
}
