
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
using X.PagedList;

namespace SStorm.CTH.Web.Controllers
{
    public class PreMedicationController : SmartController
    {
        public PreMedicationController(IClientNotification _clientNotification)
         : base(_clientNotification)
        {

        }
        [SmartAuthorize(UserPermission.Premedication_View)]
        public IActionResult Index(SearchFacade<CTHPreMedicationEntity> model)
        {
            EntityCollection<CTHPreMedicationEntity> PreMedicationCollection = new EntityCollection<CTHPreMedicationEntity>();
            RelationPredicateBucket filter = new RelationPredicateBucket();
            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHPreMedicationFields.Title % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(PreMedicationCollection, filter, model.PageSize, null, null, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHPreMedicationFields.ID, filter);
            model.DataPagedList = new StaticPagedList<CTHPreMedicationEntity>(PreMedicationCollection, model.Page, model.PageSize, Count);
            return View(model);
        }

        [SmartAuthorize(UserPermission.Premedication_EditCreate)]
        [HttpGet]
        public IActionResult EditCreate(int ID)
        {
            PremedicationModel model = new PremedicationModel();
            model.PreMedicationEntity = new CTHPreMedicationEntity();
            if (ID > 0)
            {
                model.PreMedicationEntity = new CTHPreMedicationEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(model.PreMedicationEntity, null);
            }
            model.EmetogenicList = DataHelper.GetDirectionSelectList<EmatogenicRisk>();
            return PartialView(model);
        }

        [SmartAuthorize(UserPermission.Premedication_EditCreate)]
        [HttpPost]
        public IActionResult EditCreate(PremedicationModel model)
        {
            if (model.PreMedicationEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.PreMedicationEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket(CTHPreMedicationFields.ID == model.PreMedicationEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(model.PreMedicationEntity, filter, 0);
            }
            AddSweetNotification("Done","Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index");
        }

        [SmartAuthorize(UserPermission.Premedication_Delete)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.Premedication_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHPreMedicationEntity item = new CTHPreMedicationEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPreMedicationEntity);
            path.Add(CTHPreMedicationEntity.PrefetchPathCTHChemotherapyProtocolCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            if (item.CTHChemotherapyProtocolCollection.Count == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Done","Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);
            }
            return RedirectToAction("Index");
        }


    }
}