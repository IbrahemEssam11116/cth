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
    public class TreatementController : SmartController
    {
        public TreatementController(IClientNotification _clientNotification)
           : base(_clientNotification)
        {

        }

        #region Treament Types
        [SmartAuthorize(UserPermission.TreatmentType_View)]
        public IActionResult TreatmentType(SearchFacade<CTHTreatmentTypeEntity> model)
        {
            EntityCollection<CTHTreatmentTypeEntity> treatementCollection = new EntityCollection<CTHTreatmentTypeEntity>();

            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(CTHTreatmentTypeFields.WhatTreatment == 1);

            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHTreatmentTypeFields.TreatmentType % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(treatementCollection, filter, model.PageSize, null, null, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHTreatmentTypeFields.ID, filter);

            model.DataPagedList = new StaticPagedList<CTHTreatmentTypeEntity>(treatementCollection, model.Page, model.PageSize, Count);

            return View(model);
        }


        [SmartAuthorize(UserPermission.TreatmentType_EditCreate)]
        [HttpGet]
        public IActionResult EditCreateTreatmentType(int ID)
        {
            CTHTreatmentTypeEntity treatementType = new CTHTreatmentTypeEntity();
            if (ID > 0)
            {
                treatementType = new CTHTreatmentTypeEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(treatementType, null);
            }

            return PartialView(treatementType);
        }

        [SmartAuthorize(UserPermission.TreatmentType_EditCreate)]
        [HttpPost]
        public IActionResult EditCreateTreatmentType(CTHTreatmentTypeEntity treatement)
        {
            if (treatement.ID == 0)
            {
                treatement.WhatTreatment = 1;
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(treatement, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHTreatmentTypeFields.ID == treatement.ID);
                treatement.WhatTreatment = 1;
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(treatement, filter, 0);
            }
            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("TreatmentType");
        }

        [SmartAuthorize(UserPermission.TreatmentType_Delete)]
        [HttpGet]
        public ActionResult DeleteTreatmentType(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.TreatmentType_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteTreatmentType")]
        public ActionResult ConfirmDeleteTreatmentType(int ItemID)
        {
            CTHTreatmentTypeEntity item = new CTHTreatmentTypeEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHTreatmentTypeEntity);
            path.Add(CTHTreatmentTypeEntity.PrefetchPathCTHKimoSurveyCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            if (item.CTHKimoSurveyCollection.Count == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);
            }

            return RedirectToAction("TreatmentType");
        }
        #endregion

        #region Treatment Plans
        [SmartAuthorize(UserPermission.TreatmentType_View)]
        public IActionResult TreatmentPlan(SearchFacade<CTHTreatmentTypeEntity> model)
        {
            EntityCollection<CTHTreatmentTypeEntity> treatementCollection = new EntityCollection<CTHTreatmentTypeEntity>();

            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(CTHTreatmentTypeFields.WhatTreatment == 2);

            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHTreatmentTypeFields.TreatmentType % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(treatementCollection, filter, model.PageSize, null, null, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHTreatmentTypeFields.ID, filter);

            model.DataPagedList = new StaticPagedList<CTHTreatmentTypeEntity>(treatementCollection, model.Page, model.PageSize, Count);

            return View(model);
        }


        [SmartAuthorize(UserPermission.TreatmentType_EditCreate)]
        [HttpGet]
        public IActionResult EditCreateTreatmentPlan(int ID)
        {
            CTHTreatmentTypeEntity treatementType = new CTHTreatmentTypeEntity();
            if (ID > 0)
            {
                treatementType = new CTHTreatmentTypeEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(treatementType, null);
            }

            return PartialView(treatementType);
        }

        [SmartAuthorize(UserPermission.TreatmentType_EditCreate)]
        [HttpPost]
        public IActionResult EditCreateTreatmentPlan(CTHTreatmentTypeEntity treatement)
        {
            if (treatement.ID == 0)
            {
                treatement.WhatTreatment = 2;
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(treatement, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHTreatmentTypeFields.ID == treatement.ID);
                treatement.WhatTreatment = 2;
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(treatement, filter, 0);
            }
            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("TreatmentPlan");
        }

        [SmartAuthorize(UserPermission.TreatmentType_Delete)]
        [HttpGet]
        public ActionResult DeleteTreatmentPlan(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.TreatmentType_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteTreatmentPlan")]
        public ActionResult ConfirmDeleteTreatmentPlan(int ItemID)
        {
            CTHTreatmentTypeEntity item = new CTHTreatmentTypeEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHTreatmentTypeEntity);
            path.Add(CTHTreatmentTypeEntity.PrefetchPathCTHKimoSurveyCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            if (item.CTHKimoSurveyCollection.Count == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);
            }

            return RedirectToAction("TreatmentPlan");
        }
        #endregion

        #region Treatement Response
        [SmartAuthorize(UserPermission.TreatmentType_View)]
        public IActionResult TreatmentResponse(SearchFacade<CTHTreatmentTypeEntity> model)
        {
            EntityCollection<CTHTreatmentTypeEntity> treatementCollection = new EntityCollection<CTHTreatmentTypeEntity>();

            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(CTHTreatmentTypeFields.WhatTreatment == 3);

            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHTreatmentTypeFields.TreatmentType % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(treatementCollection, filter, model.PageSize, null, null, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHTreatmentTypeFields.ID, filter);

            model.DataPagedList = new StaticPagedList<CTHTreatmentTypeEntity>(treatementCollection, model.Page, model.PageSize, Count);

            return View(model);
        }


        [SmartAuthorize(UserPermission.TreatmentType_EditCreate)]
        [HttpGet]
        public IActionResult EditCreateTreatmentResponse(int ID)
        {
            CTHTreatmentTypeEntity treatementType = new CTHTreatmentTypeEntity();
            if (ID > 0)
            {
                treatementType = new CTHTreatmentTypeEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(treatementType, null);
            }

            return PartialView(treatementType);
        }

        [SmartAuthorize(UserPermission.TreatmentType_EditCreate)]
        [HttpPost]
        public IActionResult EditCreateTreatmentResponse(CTHTreatmentTypeEntity treatement)
        {
            if (treatement.ID == 0)
            {
                treatement.WhatTreatment = 3;
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(treatement, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHTreatmentTypeFields.ID == treatement.ID);
                treatement.WhatTreatment = 3;
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(treatement, filter, 0);
            }
            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("TreatmentResponse");
        }

        [SmartAuthorize(UserPermission.TreatmentType_Delete)]
        [HttpGet]
        public ActionResult DeleteTreatmentResponse(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.TreatmentType_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteTreatmentResponse")]
        public ActionResult ConfirmDeleteTreatmentResponse(int ItemID)
        {
            CTHTreatmentTypeEntity item = new CTHTreatmentTypeEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHTreatmentTypeEntity);
            path.Add(CTHTreatmentTypeEntity.PrefetchPathCTHKimoSurveyCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            if (item.CTHKimoSurveyCollection.Count == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);
            }

            return RedirectToAction("TreatmentResponse");
        }
        #endregion
    }
}