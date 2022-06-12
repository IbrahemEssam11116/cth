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
    public class SurgeryTypeController : SmartController
    {
        public SurgeryTypeController(IClientNotification _clientNotification)
          : base(_clientNotification)
        {

        }
        [SmartAuthorize(UserPermission.SurgeryType_View)]
        public IActionResult Index(SearchFacade<CTHSurgeryTypeEntity> model)
        {
            EntityCollection<CTHSurgeryTypeEntity> surgeryTypeCollection = new EntityCollection<CTHSurgeryTypeEntity>();
            RelationPredicateBucket filter = new RelationPredicateBucket();
            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHSurgeryTypeFields.SurgeryType % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(surgeryTypeCollection, filter, model.PageSize, null, null, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHSurgeryTypeFields.ID, filter);
            model.DataPagedList = new StaticPagedList<CTHSurgeryTypeEntity>(surgeryTypeCollection, model.Page, model.PageSize, Count);
            return View(model);
        }


        [SmartAuthorize(UserPermission.SurgeryType_EditCreate)]
        [HttpGet]
        public IActionResult EditCreate(int ID)
        {
            CTHSurgeryTypeEntity surgeryType = new CTHSurgeryTypeEntity();
            if (ID > 0)
            {
                surgeryType = new CTHSurgeryTypeEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(surgeryType, null);
            }

            return PartialView(surgeryType);
        }

        [SmartAuthorize(UserPermission.SurgeryType_EditCreate)]
        [HttpPost]
        public IActionResult EditCreate(CTHSurgeryTypeEntity surgery)
        {
            if (surgery.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(surgery, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHSurgeryTypeFields.ID == surgery.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(surgery, filter, 0);
            }
            AddSweetNotification("Done","Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index");
        }

        [SmartAuthorize(UserPermission.SurgeryType_Delete)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.SurgeryType_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHSurgeryTypeEntity item = new CTHSurgeryTypeEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHSurgeryTypeEntity);
            path.Add(CTHSurgeryTypeEntity.PrefetchPathCTHPatientSurgeryCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            if(item.CTHPatientSurgeryCollection.Count == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Done","You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);
            }
            return RedirectToAction("Index");
        }
    }
}