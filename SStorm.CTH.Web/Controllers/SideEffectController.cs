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
using SStorm.CTH.BL.Helpers;
using X.PagedList;
using System.IO;

namespace SStorm.CTH.Web.Controllers
{
    public class SideEffectController : SmartController
    {
        private readonly IFileService _fileService;

        public SideEffectController(IClientNotification notifier, IFileService _fileService)
            : base(notifier)
        {
            this._fileService = _fileService;
        }

        #region sideEffects

        [SmartAuthorize(UserPermission.Symptom_View)]
        public IActionResult SideEffect(SearchFacade<CTHSymptomEntity> model)
        {
            EntityCollection<CTHSymptomEntity> SymptomCollection = new EntityCollection<CTHSymptomEntity>();
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(CTHSymptomFields.IsDoseLimitingToxicity == false);

            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHSymptomFields.Name % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(SymptomCollection, filter, model.PageSize, null, null, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHSymptomFields.ID, filter);

            model.DataPagedList = new StaticPagedList<CTHSymptomEntity>(SymptomCollection, model.Page, model.PageSize, Count);
            return View(model);
        }

        [SmartAuthorize(UserPermission.Symptom_EditCreate)]
        [HttpGet]
        public IActionResult EditCreateSideEffect(int ID)
        {
            SymptomModel model = new SymptomModel();
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHSymptomEntity);
            path.Add(CTHSymptomEntity.PrefetchPathCTHSymptomDrugCollection).SubPath.Add(CTHSymptomDrugEntity.PrefetchPathCTHDrugItem);
            model.SymptomEntity = new CTHSymptomEntity(ID);

            if (ID > 0)
            {
                model.SymptomEntity = new CTHSymptomEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(model.SymptomEntity, path);
            }

            return PartialView(model);
        }

        [SmartAuthorize(UserPermission.Symptom_EditCreate)]
        [HttpPost]
        public ActionResult EditCreateSideEffect(SymptomModel Symptom)
        {
            if (Symptom.SymptomEntity.ID == 0)
            {
                Symptom.SymptomEntity.IsDoseLimitingToxicity = false;
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(Symptom.SymptomEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHSymptomFields.ID == Symptom.SymptomEntity.ID);
                filter.PredicateExpression.Add(CTHSymptomFields.IsDoseLimitingToxicity == false);
                Symptom.SymptomEntity.IsDoseLimitingToxicity = false;
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(Symptom.SymptomEntity, filter, 0);
            }
            AddSweetNotification("Done","Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("SideEffect");
        }

        [SmartAuthorize(UserPermission.Symptom_Delete)]
        [HttpGet]
        public ActionResult DeleteSideEffect(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id,
            });
        }

        [SmartAuthorize(UserPermission.Symptom_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteSideEffect")]
        public ActionResult ConfirmDeleteSideEffect(int ItemID)
        {
            CTHSymptomEntity symptomEntity = new CTHSymptomEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHSymptomEntity);
            path.Add(CTHSymptomEntity.PrefetchPathCTHDrugSymptomCollection, true);
            path.Add(CTHSymptomEntity.PrefetchPathCTHPatientSymptomCollection, true);
            path.Add(CTHSymptomEntity.PrefetchPathCTHSymptomDrugCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(symptomEntity, path);
           if(symptomEntity.CTHDrugSymptomCollection.Count == 0 && symptomEntity.CTHPatientSymptomCollection.Count == 0
                && symptomEntity.CTHSymptomDrugCollection.Count == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(symptomEntity, 0);
                AddSweetNotification("Success","Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "You Cannot Delete This Item", Helper.NotificationHelper.NotificationType.error);
            }
            return RedirectToAction("SideEffect");
        }
        #endregion

        #region Dose limiting toxicity
        public IActionResult Doselimitingtoxicity(SearchFacade<CTHSymptomEntity> model)
        {
            EntityCollection<CTHSymptomEntity> SymptomCollection = new EntityCollection<CTHSymptomEntity>();
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(CTHSymptomFields.IsDoseLimitingToxicity == true);

            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHSymptomFields.Name % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(SymptomCollection, filter, model.PageSize, null, null, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHSymptomFields.ID, filter);

            model.DataPagedList = new StaticPagedList<CTHSymptomEntity>(SymptomCollection, model.Page, model.PageSize, Count);
            return View(model);
        }

        [SmartAuthorize(UserPermission.Symptom_EditCreate)]
        [HttpGet]
        public IActionResult DoselimitingtoxicityEditCreate(int ID)
        {
            SymptomModel model = new SymptomModel();
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHSymptomEntity);
            path.Add(CTHSymptomEntity.PrefetchPathCTHSymptomDrugCollection).SubPath.Add(CTHSymptomDrugEntity.PrefetchPathCTHDrugItem);
            model.SymptomEntity = new CTHSymptomEntity(ID);

            if (ID > 0)
            {
                model.SymptomEntity = new CTHSymptomEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(model.SymptomEntity, path);
            }

            return PartialView(model);
        }

        [SmartAuthorize(UserPermission.Symptom_EditCreate)]
        [HttpPost]
        public ActionResult DoselimitingtoxicityEditCreate(SymptomModel Symptom)
        {
            if (Symptom.SymptomEntity.ID == 0)
            {
                Symptom.SymptomEntity.IsDoseLimitingToxicity = true;
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(Symptom.SymptomEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHSymptomFields.ID == Symptom.SymptomEntity.ID);
                filter.PredicateExpression.Add(CTHSymptomFields.IsDoseLimitingToxicity == true);
                Symptom.SymptomEntity.IsDoseLimitingToxicity = true;
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(Symptom.SymptomEntity, filter, 0);
            }
            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Doselimitingtoxicity");
        }

        [SmartAuthorize(UserPermission.Symptom_Delete)]
        [HttpGet]
        public ActionResult DeleteDoselimitingtoxicity(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id,
            });
        }

        [SmartAuthorize(UserPermission.Symptom_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteDoselimitingtoxicity")]
        public ActionResult ConfirmDeleteDoselimitingtoxicity(int ItemID)
        {
            CTHSymptomEntity symptomEntity = new CTHSymptomEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHSymptomEntity);
            path.Add(CTHSymptomEntity.PrefetchPathCTHDrugSymptomCollection, true);
            path.Add(CTHSymptomEntity.PrefetchPathCTHPatientSymptomCollection, true);
            path.Add(CTHSymptomEntity.PrefetchPathCTHSymptomDrugCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(symptomEntity, path);
            if (symptomEntity.CTHDrugSymptomCollection.Count == 0 && symptomEntity.CTHPatientSymptomCollection.Count == 0
                 && symptomEntity.CTHSymptomDrugCollection.Count == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(symptomEntity, 0);
                AddSweetNotification("Success", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "You Cannot Delete This Item", Helper.NotificationHelper.NotificationType.error);
            }
            return RedirectToAction("Doselimitingtoxicity");
        }
        #endregion

        #region Drug

        [SmartAuthorize(UserPermission.Symptom_EditCreate)]
        [HttpGet]
        public IActionResult EditCreateDrug(int ID, int SymptonID)
        {
            SymptomModel symptomModel = new SymptomModel();
            RelationPredicateBucket filter = new RelationPredicateBucket();
            symptomModel.SymptomDrugEntity = new CTHSymptomDrugEntity();
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHSymptomDrugEntity);
            path.Add(CTHSymptomDrugEntity.PrefetchPathCTHDrugItem, true);
            symptomModel.SymptomEntity = new CTHSymptomEntity(SymptonID);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(symptomModel.SymptomEntity, null);
            EntityCollection<CTHSymptomDrugEntity> SymptomDrugCollection = new EntityCollection<CTHSymptomDrugEntity>();
            RelationPredicateBucket SymDrugfilter = new RelationPredicateBucket(CTHSymptomDrugFields.SymptomId == SymptonID);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(SymptomDrugCollection, SymDrugfilter, 0, null, null, 0, 0);
           
            if (ID == 0)
            {
                foreach (var item in SymptomDrugCollection)
                {
                    filter.PredicateExpression.Add(CTHDrugFields.ID != item.DrugID);
                }
            }
            else
            {
                symptomModel.SymptomDrugEntity = new CTHSymptomDrugEntity(ID);
                PrefetchPath2 path2 = new PrefetchPath2(EntityType.CTHSymptomDrugEntity);
                path2.Add(CTHSymptomDrugEntity.PrefetchPathCTHDrugItem, true);
                path2.Add(CTHSymptomDrugEntity.PrefetchPathCTHSymptomItem, true);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(symptomModel.SymptomDrugEntity, path2);
                foreach (var item in SymptomDrugCollection)
                {
                    if (item.DrugID != symptomModel.SymptomDrugEntity.DrugID)
                    {
                        filter.PredicateExpression.Add(CTHDrugFields.ID != item.DrugID);
                    }
                }
            }
            symptomModel.DrugList = DataHelper.GetSelectList<CTHDrugEntity>(CTHDrugFields.ID, CTHDrugFields.Name,filter);
            symptomModel.SymptomDrugEntity.SymptomId = SymptonID;
            return PartialView(symptomModel);
        }

        [SmartAuthorize(UserPermission.Symptom_EditCreate)]
        [HttpPost]
        public IActionResult EditCreateDrug(SymptomModel symptom)
        {
            if (symptom.SymptomDrugEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(symptom.SymptomDrugEntity, true, false, 0);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHSymptomDrugEntity);
                path.Add(CTHSymptomDrugEntity.PrefetchPathCTHDrugItem, true);
                BL.DataBaseClassHelper.FillEntity(symptom.SymptomDrugEntity, path);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHSymptomDrugFields.ID == symptom.SymptomDrugEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(symptom.SymptomDrugEntity, filter, 0);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHSymptomDrugEntity);
                path.Add(CTHSymptomDrugEntity.PrefetchPathCTHDrugItem, true);
                path.Add(CTHSymptomDrugEntity.PrefetchPathCTHSymptomItem, true);
                BL.DataBaseClassHelper.FillEntity(symptom.SymptomDrugEntity, path);
            }

            AddSweetNotification("Done","Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("EditCreate", new { ID = symptom.SymptomDrugEntity.SymptomId});
        }


        [SmartAuthorize(UserPermission.Symptom_Delete)]
        [HttpGet]
        public ActionResult DeleteSymptomDrug(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id,
            });
        }

        [SmartAuthorize(UserPermission.Symptom_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteSymptomDrug")]
        public ActionResult ConfirmDeleteSymptomDrug(int ItemID)
        {

            CTHSymptomDrugEntity symptomDrugEntity = new CTHSymptomDrugEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHSymptomDrugEntity);
            path.Add(CTHSymptomDrugEntity.PrefetchPathCTHSymptomItem, true);
            path.Add(CTHSymptomDrugEntity.PrefetchPathCTHDrugItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(symptomDrugEntity, path);
            int ID = (int)symptomDrugEntity.SymptomId;
            SStorm.CTH.BL.DataBaseClassHelper.Delete(symptomDrugEntity, 0);
            return RedirectToAction("EditCreate", new { ID = ID});
        }
        #endregion

        public IActionResult AttachmentCollection(int DrugID)
        {
            CTHDrugEntity CTHDrugEntity = new CTHDrugEntity(DrugID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugEntity);
            path.Add(CTHDrugEntity.PrefetchPathCTHDrugAttachmentCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CTHDrugEntity, path);
            return PartialView(CTHDrugEntity);
        }
        public ActionResult DownloadFile(int ID)
        {
            CTHDrugAttachmentEntity fileEntity = new CTHDrugAttachmentEntity(ID);
            CTH.BL.DataBaseClassHelper.FillEntity(fileEntity, null);

            if (fileEntity.IsNew)
            {
                AddSweetNotification("Error","Failed to download attachment.", Helper.NotificationHelper.NotificationType.error);
                return Content("");
            }

            var file = _fileService.ReadFile(fileEntity.Attachment);
            if (file == null || file.Length < 1)
                return Content("");

            return File(file, System.Net.Mime.MediaTypeNames.Application.Octet, Path.ChangeExtension(fileEntity.Attachment, Path.GetExtension(fileEntity.Attachment)));
        }
    }
}