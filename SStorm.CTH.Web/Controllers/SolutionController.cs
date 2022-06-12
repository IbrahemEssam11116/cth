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
    public class SolutionController : SmartController
    {
        public SolutionController(IClientNotification _clientNotification)
         : base(_clientNotification)
        {

        }

        [SmartAuthorize(UserPermission.Solution_View)]
        public IActionResult Index(SearchFacade<CTHSolutionEntity> model)
        {
            EntityCollection<CTHSolutionEntity> Collection = new EntityCollection<CTHSolutionEntity>();
            RelationPredicateBucket filter = new RelationPredicateBucket();
            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHSolutionFields.Name % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(Collection, filter, model.PageSize, null, null, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHSolutionFields.ID, filter);

            model.DataPagedList = new StaticPagedList<CTHSolutionEntity>(Collection, model.Page, model.PageSize, Count);
            return View(model);
        }


        [SmartAuthorize(UserPermission.Solution_EditCreate)]
        [HttpGet]
        public IActionResult EditCreate(int ID)
        {
            CTHSolutionEntity masterEntity = new CTHSolutionEntity();
            if (ID > 0)
            {
                masterEntity = new CTHSolutionEntity(ID);

                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(masterEntity, null);
            }

            return View(masterEntity);
        }

        [SmartAuthorize(UserPermission.Solution_EditCreate)]
        [HttpPost]
        public IActionResult EditCreate(CTHSolutionEntity masterEntity)
        {
            if (masterEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(masterEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHSolutionFields.ID == masterEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(masterEntity, filter, 0);
            }
            AddSweetNotification("Done","Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index");
        }


        [SmartAuthorize(UserPermission.Solution_Delete)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.Solution_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHSolutionEntity masterEntity = new CTHSolutionEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHSolutionEntity);
            path.Add(CTHSolutionEntity.PrefetchPathCTHDrugCollection);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(masterEntity, path);
            if(masterEntity.CTHDrugCollection.Count == 0)
            {

                SStorm.CTH.BL.DataBaseClassHelper.Delete(masterEntity, 0);
                AddSweetNotification("Done","Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Done","You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);

            }
            return RedirectToAction("Index");
        }

        public IActionResult AttachmentCollection(int DrugID)
        {
            CTHDrugEntity CTHDrugEntity = new CTHDrugEntity(DrugID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugEntity);
            path.Add(CTHDrugEntity.PrefetchPathCTHDrugAttachmentCollection);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CTHDrugEntity, path);
            return PartialView(CTHDrugEntity);
        }

    }
}