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
using X.PagedList;
using SStorm.CTH.BL.Helpers;

namespace SStorm.CTH.Web.Controllers
{
    public class TumorGradeController : SmartController
    {
        public TumorGradeController(IClientNotification notifier) : base(notifier)
        {
        }

        //[SmartAuthorize(UserPermission.TumorGrade_View)]
        public IActionResult Index(SearchFacade<CTHTumorGradeEntity> model)
        {
            EntityCollection<CTHTumorGradeEntity> TumorGradeCollection = new EntityCollection<CTHTumorGradeEntity>();
            RelationPredicateBucket filter = new RelationPredicateBucket();
            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHTumorGradeFields.TumorGrade % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(TumorGradeCollection, filter, model.PageSize, null, null, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHImagingFields.ID, filter);

            model.DataPagedList = new StaticPagedList<CTHTumorGradeEntity>(TumorGradeCollection, model.Page, model.PageSize, Count);
            return View(model);
        }

        //[SmartAuthorize(UserPermission.Imaging_EditCreate)]
        [HttpGet]
        public IActionResult EditCreate(int ID)
        {
            CTHTumorGradeEntity TumorGrade = new CTHTumorGradeEntity();
            if (ID > 0)
            {
                TumorGrade = new CTHTumorGradeEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(TumorGrade, null);
            }

            return PartialView(TumorGrade);
        }

       // [SmartAuthorize(UserPermission.Imaging_EditCreate)]
        [HttpPost]
        public IActionResult EditCreate(CTHTumorGradeEntity Tumor)
        {
            if (Tumor.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(Tumor, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHTumorGradeFields.ID == Tumor.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(Tumor, filter, 0);
            }
            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index");
        }

        //[SmartAuthorize(UserPermission.Imaging_Delete)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        //[SmartAuthorize(UserPermission.Imaging_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHTumorGradeEntity item = new CTHTumorGradeEntity(ItemID);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item,null);
            SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
            AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index");
        }
    }
}