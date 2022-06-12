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
    public class ImagingController : SmartController
    {
        public ImagingController(IClientNotification _clientNotification)
           : base(_clientNotification)
        {

        }

        [SmartAuthorize(UserPermission.Imaging_View)]
        public IActionResult Index(SearchFacade<CTHImagingEntity> model)
        {
            EntityCollection<CTHImagingEntity> ImagingCollection = new EntityCollection<CTHImagingEntity>();
            RelationPredicateBucket filter = new RelationPredicateBucket();
            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHImagingFields.ImageName % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(ImagingCollection, filter, model.PageSize, null, null, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHImagingFields.ID, filter);

            model.DataPagedList = new StaticPagedList<CTHImagingEntity>(ImagingCollection, model.Page, model.PageSize, Count);
            return View(model);
        }


        [SmartAuthorize(UserPermission.Imaging_EditCreate)]
        [HttpGet]
        public IActionResult EditCreate(int ID)
        {
            CTHImagingEntity ImagingName = new CTHImagingEntity();
            if (ID > 0)
            {
                ImagingName = new CTHImagingEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(ImagingName, null);
            }

            return PartialView(ImagingName);
        }

        [SmartAuthorize(UserPermission.Imaging_EditCreate)]
        [HttpPost]
        public IActionResult EditCreate(CTHImagingEntity Imaging)
        {
            if (Imaging.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(Imaging, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHImagingFields.ID == Imaging.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(Imaging, filter, 0);
            }
            AddSweetNotification("Done","Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index");
        }

        [SmartAuthorize(UserPermission.Imaging_Delete)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.Imaging_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHImagingEntity item = new CTHImagingEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHImagingEntity);
            path.Add(CTHImagingEntity.PrefetchPathCTHPatientImagingCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            if(item.CTHPatientImagingCollection.Count == 0)
            {

                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);

            }
            return RedirectToAction("Index");
        }
    }
}