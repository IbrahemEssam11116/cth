using Microsoft.AspNetCore.Mvc;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SStorm.CTH.DAL;
using SStorm.CTH.DAL.EntityClasses;
using SStorm.CTH.DAL.HelperClasses;
using SStorm.CTH.Web.Infrastructure;
using SStorm.CTH.Web.Models;
using System.Linq;
using X.PagedList;

namespace SStorm.CTH.Web.Controllers
{
    public class DoseUnitController : SmartController
    {
        public DoseUnitController(IClientNotification _clientNotification)
         : base(_clientNotification)
        {

        }

        [SmartAuthorize(UserPermission.DoseUnit_View)]
        public IActionResult Index(SearchFacade<CTHDoseUnitEntity> model)
        {
            EntityCollection<CTHDoseUnitEntity> Collection = new EntityCollection<CTHDoseUnitEntity>();
            RelationPredicateBucket filter = new RelationPredicateBucket();
            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHDoseUnitFields.Name % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(Collection, filter, model.PageSize, null, null, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHDoseUnitFields.ID, filter);

            model.DataPagedList = new StaticPagedList<CTHDoseUnitEntity>(Collection, model.Page, model.PageSize, Count);
            return View(model);
        }

        /////////////////////////////////*Edit and Create Solution*/////////////////////////////////

        [SmartAuthorize(UserPermission.DoseUnit_EditCreate)]
        [HttpGet]
        public IActionResult EditCreate(int ID)
        {
            CTHDoseUnitEntity masterEntity = new CTHDoseUnitEntity();
            if (ID > 0)
            {
                masterEntity = new CTHDoseUnitEntity(ID);

                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(masterEntity, null);
            }

            return View(masterEntity);
        }

        [SmartAuthorize(UserPermission.DoseUnit_EditCreate)]
        [HttpPost]
        public IActionResult EditCreate(CTHDoseUnitEntity masterEntity)
        {
            if (masterEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(masterEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHDoseUnitFields.ID == masterEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(masterEntity, filter, 0);
            }
            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index");
        }

        /////////////////////////////////*Delete Solution*/////////////////////////////////

        [SmartAuthorize(UserPermission.DoseUnit_Delete)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.DoseUnit_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHDoseUnitEntity masterEntity = new CTHDoseUnitEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDoseUnitEntity);
            path.Add(CTHDoseUnitEntity.PrefetchPathCTHDrugCollection);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(masterEntity, path);
            if (masterEntity.CTHDrugCollection.Count() == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(masterEntity, 0);
                AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "Error,You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);

            }

            return RedirectToAction("Index");
        }
    }
}