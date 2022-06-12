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
    public class LabGroupController : SmartController
    {
        public LabGroupController(IClientNotification _clientNotification)
        : base(_clientNotification)
        {

        }

        [SmartAuthorize(UserPermission.LabGroup_View)]
        [HttpGet]
        public IActionResult Index(SearchFacade<CTHLabGroupEntity> model)
        {
            EntityCollection<CTHLabGroupEntity> Collection = new EntityCollection<CTHLabGroupEntity>();
            RelationPredicateBucket filter = new RelationPredicateBucket();
            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHLabGroupFields.LabGroupName % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(Collection, filter, model.PageSize, null, null, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHLabGroupFields.ID, filter);
            model.DataPagedList = new StaticPagedList<CTHLabGroupEntity>(Collection, model.Page, model.PageSize, Count);
            return View(model);
        }

        [SmartAuthorize(UserPermission.LabGroup_EditCreate)]
        [HttpGet]
        public IActionResult EditCreate(int ID)
        {
            CTHLabGroupEntity masterEntity = new CTHLabGroupEntity();
            if (ID > 0)
            {
                masterEntity = new CTHLabGroupEntity(ID);

                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(masterEntity, null);
            }

            return PartialView(masterEntity);
        }

        [SmartAuthorize(UserPermission.LabGroup_EditCreate)]
        [HttpPost]
        public IActionResult EditCreate(CTHLabGroupEntity masterEntity)
        {
            if (masterEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(masterEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHLabGroupFields.ID == masterEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(masterEntity, filter, 0);
            }
            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index");
        }

        [SmartAuthorize(UserPermission.LabGroup_Delete)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.LabGroup_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHLabGroupEntity masterEntity = new CTHLabGroupEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabGroupEntity);
            path.Add(CTHLabGroupEntity.PrefetchPathCTHLabCollectionViaCTHLabGroupLab);
            path.Add(CTHLabGroupEntity.PrefetchPathCTHLabGroupLabCollection);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(masterEntity, path);
            if (masterEntity.CTHLabCollectionViaCTHLabGroupLab.Count == 0 && masterEntity.CTHLabGroupLabCollection.Count == 0)
            {

                SStorm.CTH.BL.DataBaseClassHelper.Delete(masterEntity, 0);
                AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "Error, You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);
            }
            return RedirectToAction("Index");
        }
    }
}