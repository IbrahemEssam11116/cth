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
    public class DrugController : SmartController
    {
        public DrugController(IClientNotification notifier) : base(notifier)
        {
        }

        [SmartAuthorize(UserPermission.Drug_GetProtocolDrugs)]
        [HttpGet]
        public ActionResult GetProtocolDrugs(int ProtocolID)
        {
            CTHChemotherapyProtocolEntity protocol = new CTHChemotherapyProtocolEntity(ProtocolID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHChemotherapyProtocolEntity);
            path.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHDrugCollection, true)
                .SubPath.Add(CTHDrugEntity.PrefetchPathCTHDoseUnitItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(protocol, path);
            return View(protocol);
        }

        [SmartAuthorize(UserPermission.Drug_EditCreate)]
        [HttpGet]
        public ActionResult EditCreateDrug(int ID , int ProtocolID, int CancerID)
        {
            DrugModel model = new DrugModel();
            model.DrugEntity = new CTHDrugEntity();
            model.RouteList = DataHelper.GetDirectionSelectList<Route>();
            model.DoseUnitList = DataHelper.GetSelectList<CTHDoseUnitEntity>(CTHDoseUnitFields.ID, CTHDoseUnitFields.Name);
            model.DurationUnitList = DataHelper.GetDirectionSelectList<DurationUnit>();
            model.SolutionList = DataHelper.GetSelectList<CTHSolutionEntity>(CTHSolutionFields.ID, CTHSolutionFields.Name);
            if (ID > 0)
            {
                model.DrugEntity = new CTHDrugEntity(ID);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugEntity);
                path.Add(CTHDrugEntity.PrefetchPathCTHDrugDayCollection, true);
                path.Add(CTHDrugEntity.PrefetchPathCTHDrugSymptomCollection, true)
                    .SubPath.Add(CTHDrugSymptomEntity.PrefetchPathCTHSymptomItem);

                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(model.DrugEntity, path);
            }
            model.DrugEntity.ProtocolID = ProtocolID;
            model.CancerID = CancerID;
            return PartialView(model);
        }

        [SmartAuthorize(UserPermission.Drug_EditCreate)]
        [HttpPost]
        public ActionResult EditCreateDrug(DrugModel model, List<int> Days)
        {
            if(model.DrugEntity.ID > 0)
            {
                RelationPredicateBucket filter = new RelationPredicateBucket(CTHDrugFields.ID == model.DrugEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(model.DrugEntity, filter, 0);
            }
            else
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.DrugEntity, true, false, 0);
            }
            var drug = new CTHDrugEntity(model.DrugEntity.ID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugEntity);
            path.Add(CTHDrugEntity.PrefetchPathCTHDrugDayCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(drug, path);
            var DrugDays = drug.CTHDrugDayCollection;
            foreach (var i in Days)
            {
                var check = false;
                foreach(var dd in drug.CTHDrugDayCollection)
                {
                    if(dd.Day == i)
                    {
                        var DrugDay = new CTHDrugDayEntity(dd.ID);
                        SStorm.CTH.BL.DataBaseClassHelper.FillEntity(DrugDay,null);
                        DrugDays.Remove(DrugDay);
                        check = true;
                        break;
                    }
                }
                if(check == false)
                {
                    CTHDrugDayEntity DrugDay = new CTHDrugDayEntity()
                    {
                        DrugID = model.DrugEntity.ID,
                        Day = i
                    };
                    SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(DrugDay, true, false, 0);
                    DrugDays.Remove(DrugDay);
                }
            }
            if(DrugDays.Count > 0)
            {
                foreach (var i in DrugDays)
                {
                    var item = new CTHDrugDayEntity(i.ID);
                    SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, null);
                    SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                }
            }
            

            return RedirectToAction("EditCreateChemotherapyProtocol", "Protocol", new { ID  = model.DrugEntity.ProtocolID, CancerTypeID = model.CancerID});
        }

        [SmartAuthorize(UserPermission.Drug_Delete)]
        [HttpGet]
        public ActionResult DeleteDrug(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.Drug_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteDrug")]
        public ActionResult ConfirmDeleteDrug(int ItemID)
        {
            CTHDrugEntity item = new CTHDrugEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugEntity);
            path.Add(CTHDrugEntity.PrefetchPathCTHCycleDrugCollection, true);
            //path.Add(CTHDrugEntity.PrefetchPathCTHDrugAttachmentCollection, true);
            path.Add(CTHDrugEntity.PrefetchPathCTHDrugDayCollection, true);
            path.Add(CTHDrugEntity.PrefetchPathCTHDrugSymptomCollection, true);
            path.Add(CTHDrugEntity.PrefetchPathCTHPatientDrugCollection, true);
            path.Add(CTHDrugEntity.PrefetchPathCTHSymptomDrugCollection, true);
            path.Add(CTHDrugEntity.PrefetchPathCTHChemotherapyProtocolItem,true, CTHChemotherapyProtocolFields.CancerTypeID);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            int DrugID = item.ID;
            int ProtocolID = (int)item.ProtocolID;
            int CancerID = (int)item.CTHChemotherapyProtocolItem.CancerTypeID;
            //&& item.CTHDrugAttachmentCollection.Count==0 
            if (item.CTHCycleDrugCollection.Count ==0 && item.CTHDrugDayCollection.Count ==0 && item.CTHDrugSymptomCollection.Count == 0 && item.CTHPatientDrugCollection.Count==0 && item.CTHSymptomDrugCollection.Count==0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);

            }
            else
            {
                AddSweetNotification("Error", "Error,You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);

            }
            return RedirectToAction("EditCreateChemotherapyProtocol", "Protocol", new { ID = ProtocolID, CancerTypeID = CancerID });
        }

        #region Symptom

        [SmartAuthorize(UserPermission.Symptom_EditeCreate)]
        [HttpGet]
        public IActionResult EditCreateSymptom(int ID, int DrugID)
        {
            DrugSymptomModel DrugSymptom = new DrugSymptomModel();
            //DrugSymptom.DrugList = DataHelper.GetSelectList<CTHDrugEntity>(CTHDrugFields.ID, CTHDrugFields.Name);
            DrugSymptom.SymptomList = DataHelper.GetSelectList<CTHSymptomEntity>(CTHSymptomFields.ID, CTHSymptomFields.Name);
            DrugSymptom.DrugSymptomEntity = new CTHDrugSymptomEntity();
            if (ID > 0)
            {
                DrugSymptom.DrugSymptomEntity = new CTHDrugSymptomEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(DrugSymptom.DrugSymptomEntity, null);
            }
            DrugSymptom.DrugSymptomEntity.DrugID = DrugID;
            return PartialView(DrugSymptom);
        }

        [SmartAuthorize(UserPermission.Symptom_EditeCreate)]
        [HttpPost]
        public IActionResult EditCreateSymptom(DrugSymptomModel model)
        {
            if (model.DrugSymptomEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.DrugSymptomEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHDrugSymptomFields.ID == model.DrugSymptomEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(model.DrugSymptomEntity, filter, 0);
            }
            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index", new { DrugID = model.DrugSymptomEntity.DrugID });
        }

        [HttpGet]
        public ActionResult DeleteSymptom(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDeleteSymptom(int ItemID)
        {
            CTHDrugSymptomEntity item = new CTHDrugSymptomEntity(ItemID);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, null);
            int Drudid = (int)item.DrugID;
            SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
            AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index", new { DrugID = Drudid });
        }
        #endregion

        [SmartAuthorize(UserPermission.Drug_AttachmentCollection)]
        public IActionResult AttachmentCollection(int DrugID)
        {
            CTHDrugEntity CTHDrugEntity = new CTHDrugEntity(DrugID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugEntity);
            path.Add(CTHDrugEntity.PrefetchPathCTHDrugAttachmentCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CTHDrugEntity, path);
            return PartialView(CTHDrugEntity);
        }
    }
}