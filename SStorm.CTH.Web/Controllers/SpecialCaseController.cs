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
    public class SpecialCaseController : SmartController
    {
        public SpecialCaseController(IClientNotification _clientNotification)
           : base(_clientNotification)
        {

        }
        [SmartAuthorize(UserPermission.SpecialCase_View)]
        public IActionResult Index(SearchFacade<CTHSpecialCaseEntity> model)
        {
            EntityCollection<CTHSpecialCaseEntity> SpecialCaseCollection = new EntityCollection<CTHSpecialCaseEntity>();
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHSpecialCaseEntity);
            path.Add(CTHSpecialCaseEntity.PrefetchPathCTHSpecialCasePartCollection);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(SpecialCaseCollection, null, 0, null, path, 0, 0);
            RelationPredicateBucket filter = new RelationPredicateBucket();
            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHSpecialCaseFields.CaseName % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(SpecialCaseCollection, filter, model.PageSize, null, null, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHSpecialCaseFields.ID, filter);

            model.DataPagedList = new StaticPagedList<CTHSpecialCaseEntity>(SpecialCaseCollection, model.Page, model.PageSize, Count);

            return View(model);
        }


        [SmartAuthorize(UserPermission.SpecialCase_EditCreate)]
        [HttpGet]
        public IActionResult EditCreate(int ID)
        {
            CTHSpecialCaseEntity SpecialCaseName = new CTHSpecialCaseEntity();
            if (ID > 0)
            {
                SpecialCaseName = new CTHSpecialCaseEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(SpecialCaseName, null);
            }

            return PartialView(SpecialCaseName);
        }

        [SmartAuthorize(UserPermission.SpecialCase_EditCreate)]
        [HttpPost]
        public IActionResult EditCreate(CTHSpecialCaseEntity SpecialCase)
        {
            if (SpecialCase.HasParts == null)
            {
                SpecialCase.HasParts = false;
            }
            if (SpecialCase.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(SpecialCase, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHSpecialCaseFields.ID == SpecialCase.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(SpecialCase, filter, 0);
            }
            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index");
        }


        [SmartAuthorize(UserPermission.SpecialCase_Delete)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.SpecialCase_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHSpecialCaseEntity item = new CTHSpecialCaseEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHSpecialCaseEntity);
            path.Add(CTHSpecialCaseEntity.PrefetchPathCTHKimoSurveyCollection, true);
            path.Add(CTHSpecialCaseEntity.PrefetchPathCTHSpecialCasePartCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            if (item.CTHKimoSurveyCollection.Count == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Done", "You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);
            }
            return RedirectToAction("Index");
        }


        #region Parts
        [SmartAuthorize(UserPermission.SpecialCase_EditCreatePart)]
        [HttpGet]
        public IActionResult EditCreatePart(int ID, int CaseID)
        {
            CTHSpecialCasePartEntity Part = new CTHSpecialCasePartEntity();
            if (ID > 0)
            {
                Part = new CTHSpecialCasePartEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(Part, null);
            }
            Part.CaseID = CaseID;

            return PartialView(Part);
        }

        [SmartAuthorize(UserPermission.SpecialCase_EditCreatePart)]
        [HttpPost]
        public IActionResult EditCreatePart(CTHSpecialCasePartEntity Part)
        {
            if (Part.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(Part, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHSpecialCasePartFields.ID == Part.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(Part, filter, 0);
            }
            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index", new { ID = Part.CaseID });
        }
        #endregion
    }
}