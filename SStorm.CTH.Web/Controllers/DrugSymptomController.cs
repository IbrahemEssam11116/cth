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
using SStorm.CTH.BL.Helpers;

namespace SStorm.CTH.Web.Controllers
{
    public class DrugSymptomController : SmartController
    {
        public DrugSymptomController(IClientNotification notifier) 
            : base(notifier)
        {
        }

        [SmartAuthorize(UserPermission.DrugSymptom_view)]
        public IActionResult Index(int DrugID)
        {
            EntityCollection<CTHDrugSymptomEntity> CTHDrugSymptomCollection = new EntityCollection<CTHDrugSymptomEntity>();
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugSymptomEntity);
            //path.Add(CTHDrugSymptomEntity.PrefetchPathCTHDrugItem, true);
            path.Add(CTHDrugSymptomEntity.PrefetchPathCTHSymptomItem, true);
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(CTHDrugSymptomFields.DrugID == DrugID);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(CTHDrugSymptomCollection, filter, 0, null, path, 0, 0);
            ViewBag.DrugID = DrugID;
            return View(CTHDrugSymptomCollection);
        }

        [SmartAuthorize(UserPermission.DrugSymptom_EditCreate)]
        [HttpGet]
        public IActionResult EditCreate(int ID,int DrugID)
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

        [SmartAuthorize(UserPermission.DrugSymptom_EditCreate)]
        [HttpPost]
        public IActionResult  EditCreate(DrugSymptomModel model)
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

        [SmartAuthorize(UserPermission.DrugSymptom_Delete)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.DrugSymptom_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHDrugSymptomEntity item = new CTHDrugSymptomEntity(ItemID);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, null);
            int Drudid = (int)item.DrugID;
            SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
            AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index", new { DrugID = Drudid });
        }

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