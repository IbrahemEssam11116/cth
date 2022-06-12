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
    public class IntialLabController : SmartController
    {
        public IntialLabController(IClientNotification _clientNotification)
        : base(_clientNotification)
        {

        }

        [SmartAuthorize(UserPermission.IntialLab_View)]
        [HttpGet]
        public IActionResult Index(SearchFacade<CTHLabEntity> model)
        {
            EntityCollection<CTHLabEntity> Collection = new EntityCollection<CTHLabEntity>();
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(CTHLabFields.IsIntial == true);
            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHLabFields.LabName % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(Collection, filter, model.PageSize, null, null, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHLabFields.ID, filter);
            model.DataPagedList = new StaticPagedList<CTHLabEntity>(Collection, model.Page, model.PageSize, Count);
            return View(model);
        }

        [SmartAuthorize(UserPermission.IntialLab_EditCreate)]
        [HttpGet]
        public IActionResult EditCreate(int ID)
        {
            CTHLabEntity masterEntity = new CTHLabEntity();
            if (ID > 0)
            {
                masterEntity = new CTHLabEntity(ID);

                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(masterEntity, null);
            }

            return PartialView(masterEntity);
        }

        [SmartAuthorize(UserPermission.IntialLab_EditCreate)]
        [HttpPost]
        public IActionResult EditCreate(CTHLabEntity masterEntity)
        {
            masterEntity.IsIntial = true;
            if (masterEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(masterEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHLabFields.ID == masterEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(masterEntity, filter, 0);
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
            CTHLabEntity masterEntity = new CTHLabEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabEntity);
            path.Add(CTHLabEntity.PrefetchPathCTHLabDetailCollection);
            path.Add(CTHLabEntity.PrefetchPathCTHPatientIntialLabCollection);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(masterEntity, path);
            if(masterEntity.CTHLabDetailCollection.Count == 0 && masterEntity.CTHPatientIntialLabCollection.Count == 0)
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