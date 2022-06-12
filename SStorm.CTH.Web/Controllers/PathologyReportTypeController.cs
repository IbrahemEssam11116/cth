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
    public class PathologyReportTypeController : SmartController
    {
        public PathologyReportTypeController(IClientNotification _clientNotification)
           : base(_clientNotification)
        {

        }
        [SmartAuthorize(UserPermission.PathologyReport_View)]
        public IActionResult Index(SearchFacade<CTHPathologyReportTypeEntity> model)
        {
            EntityCollection<CTHPathologyReportTypeEntity> PathologyReportTypeCollection = new EntityCollection<CTHPathologyReportTypeEntity>();
            RelationPredicateBucket filter = new RelationPredicateBucket();
            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHPathologyReportTypeFields.Name % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(PathologyReportTypeCollection, filter, model.PageSize, null, null, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHPathologyReportTypeFields.ID, filter);

            model.DataPagedList = new StaticPagedList<CTHPathologyReportTypeEntity>(PathologyReportTypeCollection, model.Page, model.PageSize, Count);
            return View(model);
        }


        [SmartAuthorize(UserPermission.PathologyReport_EditCreate)]
        [HttpGet]
        public IActionResult EditCreate(int ID)
        {
            CTHPathologyReportTypeEntity PathologyReportTypeName = new CTHPathologyReportTypeEntity();
            if (ID > 0)
            {
                PathologyReportTypeName = new CTHPathologyReportTypeEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(PathologyReportTypeName, null);
            }

            return PartialView(PathologyReportTypeName);
        }

        [SmartAuthorize(UserPermission.PathologyReport_EditCreate)]
        [HttpPost]
        public IActionResult EditCreate(CTHPathologyReportTypeEntity PathologyReportType)
        {
            if (PathologyReportType.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(PathologyReportType, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHPathologyReportTypeFields.ID == PathologyReportType.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(PathologyReportType, filter, 0);
            }
            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index");
        }

        [SmartAuthorize(UserPermission.PathologyReport_Delete)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.PathologyReport_Delete)]

        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHPathologyReportTypeEntity item = new CTHPathologyReportTypeEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPathologyReportTypeEntity);
            path.Add(CTHPathologyReportTypeEntity.PrefetchPathCTHPatientPathologyReportCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            if(item.CTHPatientPathologyReportCollection.Count == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
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