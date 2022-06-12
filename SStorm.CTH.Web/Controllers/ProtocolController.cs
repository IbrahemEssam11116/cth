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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace SStorm.CTH.Web.Controllers
{
    public class ProtocolController : SmartController
    {
        private readonly IFileService _fileService;
        public ProtocolController(IClientNotification _clientNotification, IFileService _fileService)
         : base(_clientNotification)
        {
            this._fileService = _fileService;
        }

        #region ChemotherapyProtocol

        [SmartAuthorize(UserPermission.CancerType_ViewCancerTypeProtocols)]
        public IActionResult Index(SearchFacade<CTHChemotherapyProtocolEntity> model)
        {
            EntityCollection<CTHChemotherapyProtocolEntity> ChemotherapyProtocolCollection = new EntityCollection<CTHChemotherapyProtocolEntity>();
            RelationPredicateBucket filter = new RelationPredicateBucket();
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHChemotherapyProtocolEntity);
            path.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHCancerTypeItem,true,CTHCancerTypeFields.TypeName);
            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHChemotherapyProtocolFields.ProtocolName % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(ChemotherapyProtocolCollection, filter, model.PageSize, null, path, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHChemotherapyProtocolFields.ID, filter);
            model.DataPagedList = new StaticPagedList<CTHChemotherapyProtocolEntity>(ChemotherapyProtocolCollection, model.Page, model.PageSize, Count);
            return View(model);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateProtocol)]
        [HttpGet]
        public IActionResult EditCreateChemotherapyProtocol(int ID)
        {
            ChemotherapyProtocolModel ProtocolModel = new ChemotherapyProtocolModel();
            ProtocolModel.ChemotherapyProtocolEntity = new CTHChemotherapyProtocolEntity();
            ProtocolModel.PreMedicationList = null;
            ProtocolModel.EmatogenicRiskList = DataHelper.GetDirectionSelectList<EmatogenicRisk>();
            ProtocolModel.CancerTypeList = DataHelper.GetSelectList<CTHCancerTypeEntity>(CTHCancerTypeFields.ID, CTHCancerTypeFields.TypeName);
            if (ID > 0)
            {
                ProtocolModel.ChemotherapyProtocolEntity = new CTHChemotherapyProtocolEntity(ID);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHChemotherapyProtocolEntity);
                path.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHLabCollection, true)
                  .SubPath.Add(CTHLabEntity.PrefetchPathCTHLabDetailCollection, true)
                  .SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabDetailConditionCollection, true)
                  .SubPath.Add(CTHLabDetailConditionEntity.PrefetchPathCTHOperatorItem, true);
                path.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHDrugCollection, true)
                    .SubPath.Add(CTHDrugEntity.PrefetchPathCTHDoseUnitItem, true);
                path.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHProtocolCycleCollection, true);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(ProtocolModel.ChemotherapyProtocolEntity, path);
                RelationPredicateBucket filter = new RelationPredicateBucket(CTHPreMedicationFields.EmetogenicID == ProtocolModel.ChemotherapyProtocolEntity.EmetodenicRiskID);
                ProtocolModel.PreMedicationList = DataHelper.GetSelectList<CTHPreMedicationEntity>(CTHPreMedicationFields.ID, CTHPreMedicationFields.Title, filter);
            }
            return View(ProtocolModel);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateProtocol)]
        [HttpPost]
        public IActionResult EditCreateChemotherapyProtocol(ChemotherapyProtocolModel ProtocolModel)
        {
            if (ProtocolModel.ChemotherapyProtocolEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(ProtocolModel.ChemotherapyProtocolEntity, true, false, 0);
                AddSweetNotification("Success", "Data Saves Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket(CTHChemotherapyProtocolFields.ID == ProtocolModel.ChemotherapyProtocolEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(ProtocolModel.ChemotherapyProtocolEntity, filter, 0);
                AddSweetNotification("Done", "Data Updated Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            return RedirectToAction("EditCreateChemotherapyProtocol", new { ID = ProtocolModel.ChemotherapyProtocolEntity.ID });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteProtocol)]
        [HttpGet]
        public ActionResult DeleteChemotherapyProtocol(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id,
            });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteProtocol)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteChemotherapyProtocol")]
        public ActionResult ConfirmDeleteChemotherapyProtocol(int ItemID)
        {
            CTHChemotherapyProtocolEntity item = new CTHChemotherapyProtocolEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHChemotherapyProtocolEntity);
            path.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHDrugCollection, true);
            path.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHKimoSurveyCollection, true);
            path.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHLabCollection, true);
            path.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHProtocolCycleCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            if (item.CTHDrugCollection.Count == 0 && item.CTHKimoSurveyCollection.Count == 0 && item.CTHLabCollection.Count == 0 && item.CTHProtocolCycleCollection.Count == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Success","Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error","You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);
            }
            return RedirectToAction("Index");
        }

        public ActionResult GetPremedicationList(int EmetogenicRiskID)
        {
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHPreMedicationFields.EmetogenicID == EmetogenicRiskID);
            var PreMedicationList = DataHelper.GetSelectList<CTHPreMedicationEntity>(CTHPreMedicationFields.ID, CTHPreMedicationFields.Title, filter);
            return Json(PreMedicationList);
        }
        #endregion

        #region Drag
        public ActionResult DownloadFile(int ID)
        {
            CTHDrugAttachmentEntity fileEntity = new CTHDrugAttachmentEntity(ID);
            CTH.BL.DataBaseClassHelper.FillEntity(fileEntity, null);

            if (fileEntity.IsNew)
            {
                AddSweetNotification("Error", "Failed to download attachment.", Helper.NotificationHelper.NotificationType.error);
                return Content("");
            }

            var file = _fileService.ReadFile(fileEntity.Attachment);
            if (file == null || file.Length < 1)
                return Content("");

            return File(file, System.Net.Mime.MediaTypeNames.Application.Octet, Path.ChangeExtension(fileEntity.Attachment, Path.GetExtension(fileEntity.Attachment)));
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateDrug)]
        public ActionResult EditCreateDrug(int ID, int ProtocolID)
        {
            DrugModel model = new DrugModel();
            model.DrugEntity = new CTHDrugEntity();
            model.RouteList = DataHelper.GetDirectionSelectList<Route>();
            model.DoseUnitList = DataHelper.GetSelectList<CTHDoseUnitEntity>(CTHDoseUnitFields.ID, CTHDoseUnitFields.Name);
            model.DurationUnitList = DataHelper.GetDirectionSelectList<DurationUnit>();
            model.FormList = DataHelper.GetDirectionSelectList<Form>();
            model.PerList = DataHelper.GetDirectionSelectList<PerList>();
            model.SolutionList = DataHelper.GetSelectList<CTHSolutionEntity>(CTHSolutionFields.ID, CTHSolutionFields.Name);
            if (ID > 0)
            {
                model.DrugEntity = new CTHDrugEntity(ID);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugEntity);
                path.Add(CTHDrugEntity.PrefetchPathCTHDrugDayCollection, true);
                path.Add(CTHDrugEntity.PrefetchPathCTHDrugSymptomCollection, true)
                   .SubPath.Add(CTHDrugSymptomEntity.PrefetchPathCTHSymptomItem);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(model.DrugEntity, path);
            }
            CTHChemotherapyProtocolEntity protocol = new CTHChemotherapyProtocolEntity(ProtocolID);
            BL.DataBaseClassHelper.FillEntity(protocol, null);
            model.DrugEntity.ProtocolID = ProtocolID;
            model.CancerID = (int)protocol.CancerTypeID;
            return View(model);
        }
        //    public ActionResult OnPostUpload(List<IFormFile> files)
        //    {
        //        if (files != null && files.Count > 0)
        //        {
        //            string folderName = "Upload";
        //            string webRootPath = _hostingEnvironment.WebRootPath;
        //            string newPath = Path.Combine(webRootPath, folderName);
        //            if (!Directory.Exists(newPath))
        //            {
        //                Directory.CreateDirectory(newPath);
        //            }
        //            foreach (IFormFile item in files)
        //            {
        //                if (item.Length > 0)
        //                {
        //                    string fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
        //                    string fullPath = Path.Combine(newPath, fileName);
        //                    using (var stream = new FileStream(fullPath, FileMode.Create))
        //                    {
        //                        item.CopyTo(stream);
        //                    }
        //                }
        //            }
        //            return this.Content("Success");
        //        }
        //        return this.Content("Fail");
        //    }
        //}

        [SmartAuthorize(UserPermission.CancerType_EditCreateDrug)]
        [HttpPost]
        public async Task<ActionResult> EditCreateDrug(DrugModel model, List<int> Days, List<IFormFile> files)
        {
            if (model.DrugEntity.ID > 0)
            {
                RelationPredicateBucket filter = new RelationPredicateBucket(CTHDrugFields.ID == model.DrugEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(model.DrugEntity, filter, 0);
            }
            else
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.DrugEntity, true, false, 0);
            }

            if (files.Count > 0)
            {
                foreach (var items in files)
                {
                    string toReturn = await this._fileService.SaveFile(model.DrugEntity.ID, items);
                    CTHDrugAttachmentEntity drugAttachmentEntity = new CTHDrugAttachmentEntity()
                    {
                        Attachment = toReturn,
                        DrugID = model.DrugEntity.ID
                    };
                    SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(drugAttachmentEntity, true, false, 0);
                }
            }

            var drug = new CTHDrugEntity(model.DrugEntity.ID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugEntity);
            path.Add(CTHDrugEntity.PrefetchPathCTHDrugDayCollection, true);
            path.Add(CTHDrugEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(drug, path);
            var DrugDays = drug.CTHDrugDayCollection;
            foreach (var i in Days)
            {
                var check = false;
                foreach (var dd in drug.CTHDrugDayCollection)
                {
                    if (dd.Day == i)
                    {
                        var DrugDay = new CTHDrugDayEntity(dd.ID);
                        SStorm.CTH.BL.DataBaseClassHelper.FillEntity(DrugDay, null);
                        DrugDays.Remove(DrugDay);
                        check = true;
                        break;
                    }
                }
                if (check == false)
                {
                    CTHDrugDayEntity DrugDay = new CTHDrugDayEntity()
                    {
                        DrugID = model.DrugEntity.ID,
                        Day = i
                    };
                    SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(DrugDay, true, false, 0);
                    DrugDays.Remove(DrugDay);
                }
            }
            if (DrugDays.Count > 0)
            {
                foreach (var i in DrugDays)
                {
                    var item = new CTHDrugDayEntity(i.ID);
                    SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, null);
                    SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                }
            }
            ViewBag.cancerId = drug.CTHChemotherapyProtocolItem.CancerTypeID;
            AddSweetNotification("Success", "Data Saves Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("EditCreateDrug", new { ID = model.DrugEntity.ID, ProtocolID = drug.CTHChemotherapyProtocolItem.ID });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteDrug)]
        [HttpGet]
        public ActionResult DeleteDrug(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteDrug)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteDrug")]
        public ActionResult ConfirmDeleteDrug(int ItemID)
        {
            CTHDrugEntity item = new CTHDrugEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugEntity);
            path.Add(CTHDrugEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
            path.Add(CTHDrugEntity.PrefetchPathCTHCycleDrugCollection, true);
            path.Add(CTHDrugEntity.PrefetchPathCTHDrugAttachmentCollection, true);
            path.Add(CTHDrugEntity.PrefetchPathCTHDrugDayCollection, true);
            path.Add(CTHDrugEntity.PrefetchPathCTHDrugSymptomCollection, true);
            path.Add(CTHDrugEntity.PrefetchPathCTHPatientDrugCollection, true);
            BL.DataBaseClassHelper.FillEntity(item, path);
            int ID = item.ID;
            if (item.CTHCycleDrugCollection.Count == 0 && item.CTHDrugAttachmentCollection.Count == 0 && item.CTHDrugDayCollection.Count == 0 && item.CTHDrugSymptomCollection.Count == 0 && item.CTHPatientDrugCollection.Count == 0)
            {

                BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Success","Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error","You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);
            }
            return RedirectToAction("EditCreateChemotherapyProtocol", new { ID = ID });
        }
        #endregion

        #region DrugDay

        [SmartAuthorize(UserPermission.CancerType_EditCreateDrug)]
        [HttpGet]
        public IActionResult EditCreateDrugDay(int ID, int DrugID)
        {
            CTHDrugDayEntity cTHDrugDay = new CTHDrugDayEntity();
            if (ID > 0)
            {
                cTHDrugDay = new CTHDrugDayEntity(ID);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugDayEntity);
                path.Add(CTHDrugDayEntity.PrefetchPathCTHDrugItem, true);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(cTHDrugDay, path);
            }
            cTHDrugDay.DrugID = DrugID;
            return PartialView(cTHDrugDay);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateDrug)]
        [HttpPost]
        public IActionResult EditCreateDrugDay(CTHDrugDayEntity cTHDrugDay)
        {

            if (cTHDrugDay.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(cTHDrugDay, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHDrugDayFields.ID == cTHDrugDay.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(cTHDrugDay, filter, 0);
            }
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugDayEntity);
            path.Add(CTHDrugDayEntity.PrefetchPathCTHDrugItem, true)
                .SubPath.Add(CTHDrugEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
            BL.DataBaseClassHelper.FillEntity(cTHDrugDay, path);
            AddSweetNotification("Success","Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("EditCreateDrug", new { ID = cTHDrugDay.DrugID, ProtocolID = cTHDrugDay.CTHDrugItem.CTHChemotherapyProtocolItem.ID });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteDrug)]
        [HttpGet]
        public ActionResult DeleteDrugDay(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteDrug)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteDrugDay")]
        public ActionResult ConfirmDeleteDrugDay(int ItemID)
        {
            CTHDrugDayEntity item = new CTHDrugDayEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugDayEntity);
            path.Add(CTHDrugDayEntity.PrefetchPathCTHDrugItem, true)
                 .SubPath.Add(CTHDrugEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
            path.Add(CTHDrugDayEntity.PrefetchPathCTHPatientDrugCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            int ID = item.ID;
            int ProtocolID = (int)item.CTHDrugItem.CTHChemotherapyProtocolItem.ID;
            if (item.CTHPatientDrugCollection.Count == 0)
            {

                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Success","Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error","You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);
            }
            return RedirectToAction("EditCreateDrug", new { ID = ID, ProtocolID = ProtocolID });
        }
        #endregion

        #region Lab

        [SmartAuthorize(UserPermission.CancerType_EditCreateLab)]
        [HttpGet]
        public IActionResult EditCreateLab(int ID, int ProtocolID)
        {
            LabModel LabModel = new LabModel();
            LabModel.LabEntity = new CTHLabEntity();
            LabModel.LabEntity.ProtocolID = ProtocolID;
            if (ID > 0)
            {
                LabModel.LabEntity = new CTHLabEntity(ID);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabEntity);
                path.Add(CTHLabEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
                path.Add(CTHLabEntity.PrefetchPathCTHLabDetailCollection, true)
                  .SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabDetailConditionCollection, true)
                  .SubPath.Add(CTHLabDetailConditionEntity.PrefetchPathCTHOperatorItem, true);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(LabModel.LabEntity, path);
            }
            return View(LabModel);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateLab)]
        [HttpPost]
        public IActionResult EditCreateLab(LabModel Lab, bool LabEntity_IsMandatory)
        {
            Lab.LabEntity.IsMandatory = LabEntity_IsMandatory;
            Lab.LabEntity.IsIntial = false;
            if (Lab.LabEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(Lab.LabEntity, true, false, 0);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabEntity);
                path.Add(CTHLabEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
                BL.DataBaseClassHelper.FillEntity(Lab.LabEntity, path);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHLabFields.ID == Lab.LabEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(Lab.LabEntity, filter, 0);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabEntity);
                path.Add(CTHLabEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
                BL.DataBaseClassHelper.FillEntity(Lab.LabEntity, path);
            }

            AddSweetNotification("Success","Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("EditCreateLab", new { ID = Lab.LabEntity.ID, ProtocolID = Lab.LabEntity.CTHChemotherapyProtocolItem.ID });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteLab)]
        [HttpGet]
        public ActionResult DeleteLab(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteLab)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteLab")]
        public ActionResult ConfirmDeleteLab(int ItemID)
        {
            CTHLabEntity item = new CTHLabEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabEntity);
            path.Add(CTHLabEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
            path.Add(CTHLabEntity.PrefetchPathCTHLabDetailCollection, true)
                .SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabDetailConditionCollection, true);
            path.Add(CTHLabEntity.PrefetchPathCTHPatientIntialLabCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            int ID = item.CTHChemotherapyProtocolItem.ID;
            int CancerTypeID = (int)item.CTHChemotherapyProtocolItem.CancerTypeID;
            if (item.CTHLabDetailCollection.Count == 0 && item.CTHPatientIntialLabCollection.Count == 0)
            {
                //foreach (var LabDel in item.CTHLabDetailCollection)
                //{
                //    CTHLabDetailEntity labDetailEntity = new CTHLabDetailEntity(LabDel.ID);
                //    PrefetchPath2 path1 = new PrefetchPath2(EntityType.CTHLabDetailEntity);
                //    path1.Add(CTHLabDetailEntity.PrefetchPathCTHLabDetailConditionCollection, true);
                //    BL.DataBaseClassHelper.FillEntity(labDetailEntity, path1);
                //    if (labDetailEntity.CTHLabDetailConditionCollection.Count != 0)
                //    {
                //        foreach (var LabDelCond in LabDel.CTHLabDetailConditionCollection)
                //        {
                //            CTHLabDetailConditionEntity cTHLabDetailCondition = new CTHLabDetailConditionEntity(LabDelCond.ID);
                //            SStorm.CTH.BL.DataBaseClassHelper.Delete(cTHLabDetailCondition, 0);
                //        }
                //        SStorm.CTH.BL.DataBaseClassHelper.Delete(labDetailEntity, 0);
                //    }
                //    else
                //    {
                //        SStorm.CTH.BL.DataBaseClassHelper.Delete(labDetailEntity, 0);
                //    }
                //}
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Success", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "You Can't Delete This Data", Helper.NotificationHelper.NotificationType.error);
            }
            return RedirectToAction("EditCreateChemotherapyProtocol", new { ID = ID, CancerTypeID = CancerTypeID });
        }
        #endregion

        #region Lab Details

        [SmartAuthorize(UserPermission.CancerType_ViewProtocolLabs)]
        [HttpGet]
        public IActionResult GetLabDetails(int ID)
        {
            CTHLabEntity CTHLabEntity = new CTHLabEntity(ID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabEntity);
            path.Add(CTHLabEntity.PrefetchPathCTHLabDetailCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CTHLabEntity, path);
            return View(CTHLabEntity);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateLab)]
        [HttpGet]
        public IActionResult EditCreateLabDetail(int ID, int LabID)
        {
            CTHLabDetailEntity CTHLabDetailEntity = new CTHLabDetailEntity();
            if (ID > 0)
            {
                CTHLabDetailEntity = new CTHLabDetailEntity(ID);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabDetailEntity);
                path.Add(CTHLabDetailEntity.PrefetchPathCTHLabDetailConditionCollection, true)
                        .SubPath.Add(CTHLabDetailConditionEntity.PrefetchPathCTHOperatorItem, true);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CTHLabDetailEntity, path);
            }
            CTHLabDetailEntity.LabID = LabID;

            return PartialView(CTHLabDetailEntity);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateLab)]
        [HttpPost]
        public IActionResult EditCreateLabDetail(CTHLabDetailEntity CTHLabDetailEntity)
        {
            if (CTHLabDetailEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(CTHLabDetailEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHLabDetailFields.ID == CTHLabDetailEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(CTHLabDetailEntity, filter, 0);
            }
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabDetailEntity);
            path.Add(CTHLabDetailEntity.PrefetchPathCTHLabItem, true)
            .SubPath.Add(CTHLabEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
            BL.DataBaseClassHelper.FillEntity(CTHLabDetailEntity, path);
            AddSweetNotification("Success","Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("EditCreateLab", new { ID = CTHLabDetailEntity.LabID, ProtocolID = CTHLabDetailEntity.CTHLabItem.CTHChemotherapyProtocolItem.ID });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteLab)]
        [HttpGet]
        public ActionResult DeleteLabDetail(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteLab)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteLabDetail")]
        public ActionResult ConfirmDeleteLabDetail(int ItemID)
        {
            CTHLabDetailEntity item = new CTHLabDetailEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabDetailEntity);
            path.Add(CTHLabDetailEntity.PrefetchPathCTHLabDetailConditionCollection, true);
            path.Add(CTHLabDetailEntity.PrefetchPathCTHChemoLabCollection, true);
            path.Add(CTHLabDetailEntity.PrefetchPathCTHCycleLabCollection, true);
            path.Add(CTHLabDetailEntity.PrefetchPathCTHLabItem, true)
              .SubPath.Add(CTHLabEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
            BL.DataBaseClassHelper.FillEntity(item, path);
            int LabID = (int)item.LabID;
            int ProtocolID = item.CTHLabItem.CTHChemotherapyProtocolItem.ID;
            if (item.CTHLabDetailConditionCollection.Count == 0 && item.CTHChemoLabCollection.Count == 0
                && item.CTHCycleLabCollection.Count == 0)
            {
                //foreach (var LabDelCond in item.CTHLabDetailConditionCollection)
                //{
                //    CTHLabDetailConditionEntity cTHLabDetailCondition = new CTHLabDetailConditionEntity(LabDelCond.ID);
                //    SStorm.CTH.BL.DataBaseClassHelper.Delete(cTHLabDetailCondition, 0);
                //}
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Success", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "You Can't Delete This Data", Helper.NotificationHelper.NotificationType.error);
            }
            return RedirectToAction("EditCreateLab", new { ID = LabID, ProtocolID = ProtocolID });
        }

        #endregion

        #region Lab Detail Conditions

        [SmartAuthorize(UserPermission.CancerType_EditCreateLab)]
        [HttpGet]
        public IActionResult EditCreateLabDetailCondition(int ID, int LabDetailID)
        {
            LabDetailConditionModel LabDetailCondition = new LabDetailConditionModel();
            LabDetailCondition.LabDetailConditionEntity = new CTHLabDetailConditionEntity();
            LabDetailCondition.OpertorList = DataHelper.GetSelectList<CTHOperatorEntity>(CTHOperatorFields.ID, CTHOperatorFields.OpertorName);
            if (ID > 0)
            {
                LabDetailCondition.LabDetailConditionEntity = new CTHLabDetailConditionEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(LabDetailCondition.LabDetailConditionEntity, null);
            }
            LabDetailCondition.LabDetailConditionEntity.LabDetailID = LabDetailID;
            return PartialView(LabDetailCondition);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateLab)]
        [HttpPost]
        public IActionResult EditCreateLabDetailCondition(LabDetailConditionModel LabDetailCondition)
        {
            if (LabDetailCondition.LabDetailConditionEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(LabDetailCondition.LabDetailConditionEntity, true, false, 0);
                AddSweetNotification("Success","Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHLabDetailConditionFields.ID == LabDetailCondition.LabDetailConditionEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(LabDetailCondition.LabDetailConditionEntity, filter, 0);
                AddSweetNotification("Success","Data Updated Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabDetailConditionEntity);
            path.Add(CTHLabDetailConditionEntity.PrefetchPathCTHLabDetailItem, true)
            .SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabItem, true)
            .SubPath.Add(CTHLabEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
            BL.DataBaseClassHelper.FillEntity(LabDetailCondition.LabDetailConditionEntity, path);
            return RedirectToAction("EditCreateLab", new { ID = LabDetailCondition.LabDetailConditionEntity.CTHLabDetailItem.LabID, ProtocolID = LabDetailCondition.LabDetailConditionEntity.CTHLabDetailItem.CTHLabItem.CTHChemotherapyProtocolItem.ID });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteLab)]
        [HttpGet]
        public ActionResult DeleteLabDetailCondition(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteLab)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteLabDetailCondition")]
        public ActionResult ConfirmDeleteLabDetailCondition(int ItemID)
        {
            CTHLabDetailConditionEntity item = new CTHLabDetailConditionEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabDetailConditionEntity);
            path.Add(CTHLabDetailConditionEntity.PrefetchPathCTHLabDetailItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            int ID = (int)item.ID;
            int LabID = (int)item.CTHLabDetailItem.LabID;
            SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
            AddSweetNotification("Success","Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("EditCreateLabDetail", new { ID = ID, LabID = LabID });
        }
        #endregion

        #region ProtocolCycle

        [SmartAuthorize(UserPermission.CancerType_EditCreateCycle)]
        [HttpGet]
        public IActionResult EditCreateProtocolCycle(int ID, int protocolID)
        {
            ProtocolCycleModel model = new ProtocolCycleModel();
            model.EveryUnitList = DataHelper.GetDirectionSelectList<EveryUnit>();

            model.protocolCycleEntity = new CTHProtocolCycleEntity();
            model.protocolCycleEntity.ProtocolID = protocolID;
            model.ChemotherapyProtocolEntity = new CTHChemotherapyProtocolEntity(protocolID);
            BL.DataBaseClassHelper.FillEntity(model.ChemotherapyProtocolEntity,null);
            
            if (ID > 0)
            {
                model.protocolCycleEntity = new CTHProtocolCycleEntity(ID);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHProtocolCycleEntity);
                path.Add(CTHProtocolCycleEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
                path.Add(CTHProtocolCycleEntity.PrefetchPathCTHCycleDrugCollection, true).SubPath.Add(CTHCycleDrugEntity.PrefetchPathCTHDrugItem);
                var ProCyclPath = path.Add(CTHProtocolCycleEntity.PrefetchPathCTHCycleLabCollection, true);
                var CyclLabPath = ProCyclPath.SubPath.Add(CTHCycleLabEntity.PrefetchPathCTHLabDetailItem);
                CyclLabPath.SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabItem);
                CyclLabPath.SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabDetailConditionCollection);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(model.protocolCycleEntity, path);
            }
            return View(model);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateCycle)]
        [HttpPost]
        public IActionResult EditCreateProtocolCycle(ProtocolCycleModel protocolCycle)
        {
            
            //protocolCycle.protocolCycleEntity.RecyclingAfter =  protocolCycle.protocolCycleEntity.RecycleDate - DateTime.Now;
            EntityCollection<CTHProtocolCycleEntity> collection = new EntityCollection<CTHProtocolCycleEntity>();
            RelationPredicateBucket cyclefilter = new RelationPredicateBucket();
            cyclefilter.PredicateExpression.Add(CTHProtocolCycleFields.ProtocolID == protocolCycle.ChemotherapyProtocolEntity.ID);
            BL.DataBaseClassHelper.FillCollection(collection, cyclefilter);
            if (protocolCycle.protocolCycleEntity.ID == 0)
            {
                if (collection.Count() <= protocolCycle.ChemotherapyProtocolEntity.Days)
                {

                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(protocolCycle.protocolCycleEntity, true, false, 0);
                    AddSweetNotification("Success", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);

                }
                else
                {
                    AddSweetNotification("Error", "Cannot Insert More Records", Helper.NotificationHelper.NotificationType.error);

                }
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHProtocolCycleFields.ID == protocolCycle.protocolCycleEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(protocolCycle.protocolCycleEntity, filter, 0);
            AddSweetNotification("Success","Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            }

            return RedirectToAction("EditCreateProtocolCycle", new { ID= protocolCycle.protocolCycleEntity.ID , protocolID = protocolCycle.protocolCycleEntity.ID});
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteCycle)]
        [HttpGet]
        public ActionResult DeleteProtocolCycle(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id,
            });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteCycle)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteProtocolCycle")]
        public ActionResult ConfirmDeleteProtocolCycle(int ItemID)
        {
            CTHProtocolCycleEntity protocolCycleEntity = new CTHProtocolCycleEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHProtocolCycleEntity);
            path.Add(CTHProtocolCycleEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
            path.Add(CTHProtocolCycleEntity.PrefetchPathCTHCycleDrugCollection, true);
            path.Add(CTHProtocolCycleEntity.PrefetchPathCTHCycleLabCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(protocolCycleEntity, path);
            int ID = protocolCycleEntity.CTHChemotherapyProtocolItem.ID;
            if(protocolCycleEntity.CTHCycleDrugCollection.Count == 0 && protocolCycleEntity.CTHCycleLabCollection.Count == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(protocolCycleEntity, 0);
                AddSweetNotification("Success", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "You Can't Delete This Data", Helper.NotificationHelper.NotificationType.success);
            }

            return RedirectToAction("EditCreateChemotherapyProtocol", new { ID = ID,  });
        }
        #endregion

        #region CycleLab
        //[SmartAuthorize(UserPermission.CancerType_AssignLabToCycle)]
        //[HttpGet]
        //public IActionResult EditCreateCycleLab(int ID, int ProtocolCycleID)
        //{
        //    CycleLabModel cycleLabModel = new CycleLabModel();
        //    cycleLabModel.cycleLabEntity = new CTHCycleLabEntity();
        //    var protocolCycle = new CTHProtocolCycleEntity(ProtocolCycleID);
        //    PrefetchPath2 path2 = new PrefetchPath2(EntityType.CTHProtocolCycleEntity);
        //    path2.Add(CTHProtocolCycleEntity.PrefetchPathCTHCycleLabCollection, true)
        //        .SubPath.Add(CTHCycleLabEntity.PrefetchPathCTHLabDetailItem, true)
        //        .SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabItem, true);
        //    BL.DataBaseClassHelper.FillEntity(protocolCycle, path2);
        //    if (ID==0)
        //    {
        //        if (protocolCycle.CTHCycleLabCollection.Count != 0)
        //        {
        //            var cyclelabcoll = protocolCycle.CTHCycleLabCollection;
        //            EntityCollection<CTHLabEntity> collLab = new EntityCollection<CTHLabEntity>();
        //            EntityCollection<CTHLabDetailEntity> collLabDetails = new EntityCollection<CTHLabDetailEntity>();
        //            List<SelectList> ListOfLab = new List<SelectList>();
        //            foreach (var item in cyclelabcoll)
        //            {
        //                collLab.Add(item.CTHLabDetailItem.CTHLabItem);
        //            }
        //            List<CTHLabEntity> uniquecollLab = collLab.Distinct().ToList();
        //            foreach (var item in uniquecollLab)
        //            {
        //                RelationPredicateBucket filterlab = new RelationPredicateBucket(CTHLabFields.ID == item.ID);
        //                var lab = DataHelper.GetSelectList<CTHLabEntity>(CTHLabFields.ID, CTHLabFields.LabName, filterlab).ToList();
        //                cycleLabModel.LabList = cycleLabModel.LabList.Concat(lab).ToList();
        //            }
        //            cycleLabModel.LabDetailsList = null;
        //        }
        //    }
        //    else
        //    {
        //        cycleLabModel.cycleLabEntity = new CTHCycleLabEntity(ID);
        //        PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCycleLabEntity);
        //        path.Add(CTHCycleLabEntity.PrefetchPathCTHLabDetailItem, true);
        //        BL.DataBaseClassHelper.FillEntity(cycleLabModel.cycleLabEntity, path);
        //        int labid = (int)cycleLabModel.cycleLabEntity.CTHLabDetailItem.LabID;
        //        RelationPredicateBucket filter = new RelationPredicateBucket(CTHLabFields.ID == labid);
        //        cycleLabModel.LabListEdit = DataHelper.GetSelectList<CTHLabEntity>(CTHLabFields.ID, CTHLabFields.LabName, filter);
        //        RelationPredicateBucket Filter2 = new RelationPredicateBucket(CTHLabDetailFields.ID == cycleLabModel.cycleLabEntity.LabID);
        //        cycleLabModel.LabDetailsList = DataHelper.GetSelectList<CTHLabDetailEntity>(CTHLabDetailFields.ID, CTHLabDetailFields.LabDetailsName, Filter2);
        //    }
        //    cycleLabModel.cycleLabEntity.CycleID = ProtocolCycleID;
        //    return PartialView(cycleLabModel);
        //}
        [SmartAuthorize(UserPermission.CancerType_AssignLabToCycle)]
        [HttpGet]
        public IActionResult EditCreateCycleLab(int ID, int ProtocolCycleID , int ProtocolID)
        {
            CycleLabModel cycleLabModel = new CycleLabModel();
            cycleLabModel.cycleLabEntity = new CTHCycleLabEntity();
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHLabFields.ProtocolID == ProtocolID);
            cycleLabModel.LabList = DataHelper.GetSelectList<CTHLabEntity>(CTHLabFields.ID, CTHLabFields.LabName, filter);
            if (ID==0)
            {               
                cycleLabModel.LabDetailsList = null;
            }
            else
            {
                cycleLabModel.cycleLabEntity = new CTHCycleLabEntity(ID);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCycleLabEntity);
                path.Add(CTHCycleLabEntity.PrefetchPathCTHLabDetailItem, true);
                BL.DataBaseClassHelper.FillEntity(cycleLabModel.cycleLabEntity, path);
                RelationPredicateBucket Filter2 = new RelationPredicateBucket(CTHLabDetailFields.ID == cycleLabModel.cycleLabEntity.LabID);
                cycleLabModel.LabDetailsList = DataHelper.GetSelectList<CTHLabDetailEntity>(CTHLabDetailFields.ID, CTHLabDetailFields.LabDetailsName, Filter2);
            }
            cycleLabModel.cycleLabEntity.CycleID = ProtocolCycleID;
            return PartialView(cycleLabModel);
        }

        [SmartAuthorize(UserPermission.CancerType_AssignLabToCycle)]
        [HttpPost]
        public IActionResult EditCreateCycleLab(CycleLabModel cycleLab , int [] LabIDS)
        {
            var CycleID = cycleLab.cycleLabEntity.CycleID;
            if (cycleLab.cycleLabEntity.ID == 0)
            {
                var x = LabIDS.Length;
                foreach (var item in LabIDS)
                {
                    cycleLab.cycleLabEntity.LabID = item;
                    cycleLab.cycleLabEntity.CycleID = CycleID;
                    SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(cycleLab.cycleLabEntity, true, false, 0);
                    x= x- 1;
                    if (x!=0)
                    {
                        cycleLab.cycleLabEntity = new CTHCycleLabEntity();
                    }
                }
                PrefetchPath2 path2 = new PrefetchPath2(EntityType.CTHCycleLabEntity);
                path2.Add(CTHCycleLabEntity.PrefetchPathCTHProtocolCycleItem, true).SubPath.Add(CTHProtocolCycleEntity.PrefetchPathCTHChemotherapyProtocolItem);
                BL.DataBaseClassHelper.FillEntity(cycleLab.cycleLabEntity, path2);
            }  
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHCycleLabFields.ID == cycleLab.cycleLabEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(cycleLab.cycleLabEntity, filter, 0);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCycleLabEntity);
                path.Add(CTHCycleLabEntity.PrefetchPathCTHProtocolCycleItem, true).SubPath.Add(CTHProtocolCycleEntity.PrefetchPathCTHChemotherapyProtocolItem);
                BL.DataBaseClassHelper.FillEntity(cycleLab.cycleLabEntity, path);
            }

            AddSweetNotification("Success","Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("EditCreateProtocolCycle", new { ID = cycleLab.cycleLabEntity.CycleID, ProtocolID = cycleLab.cycleLabEntity.CTHProtocolCycleItem.CTHChemotherapyProtocolItem.ID });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteLabFromCycle)]
        [HttpGet]
        public ActionResult DeleteCycleLab(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id,
            });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteLabFromCycle)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteCycleLab")]
        public ActionResult ConfirmDeleteCycleLab(int ItemID)
        {

            CTHCycleLabEntity cycleLabEntity = new CTHCycleLabEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCycleLabEntity);
            path.Add(CTHCycleLabEntity.PrefetchPathCTHProtocolCycleItem, true).SubPath.Add(CTHProtocolCycleEntity.PrefetchPathCTHChemotherapyProtocolItem);
            path.Add(CTHCycleLabEntity.PrefetchPathCTHLabDetailItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(cycleLabEntity, path);
            int ProtocolID = (int)cycleLabEntity.CTHProtocolCycleItem.CTHChemotherapyProtocolItem.ID;
            int ID = (int)cycleLabEntity.CycleID;
            SStorm.CTH.BL.DataBaseClassHelper.Delete(cycleLabEntity, 0);
            AddSweetNotification("Success", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("EditCreateProtocolCycle", new { ID = ID, ProtocolID = ProtocolID });
        }

        public IActionResult GetLabDela(int ID)
        {
            RelationPredicateBucket Filter = new RelationPredicateBucket(CTHLabDetailFields.LabID == ID);
            var LabDet = DataHelper.GetSelectList<CTHLabDetailEntity>(CTHLabDetailFields.ID, CTHLabDetailFields.LabDetailsName , Filter);
            return Json(LabDet);
        }
        #endregion

        #region CycleDrug

        [SmartAuthorize(UserPermission.CancerType_AssignDrugToCycle)]
        [HttpGet]
        public IActionResult EditCreateCycleDrug(int ID, int ProtocolCycleID)
        {
            var protocolCycle = new CTHProtocolCycleEntity(ProtocolCycleID);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(protocolCycle, null);
            CycleDrugModel cycleDrugModel = new CycleDrugModel();
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(CTHDrugFields.ProtocolID == protocolCycle.ProtocolID);
            cycleDrugModel.cycleDrugEntity = new CTHCycleDrugEntity();
            EntityCollection<CTHCycleDrugEntity> CycleDrugCollection = new EntityCollection<CTHCycleDrugEntity>();
            RelationPredicateBucket cycDrugfilter = new RelationPredicateBucket(CTHCycleDrugFields.CycleID == ProtocolCycleID);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(CycleDrugCollection, cycDrugfilter, 0, null, null, 0, 0);
            if (ID == 0)
            {
                foreach (var item in CycleDrugCollection)
                {
                    filter.PredicateExpression.Add(CTHDrugFields.ID != item.DrugID);
                }
            }
            else
            {
                cycleDrugModel.cycleDrugEntity = new CTHCycleDrugEntity(ID);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCycleDrugEntity);
                path.Add(CTHCycleDrugEntity.PrefetchPathCTHProtocolCycleItem, true);
                path.Add(CTHCycleDrugEntity.PrefetchPathCTHDrugItem, true);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(cycleDrugModel.cycleDrugEntity, path);
                foreach (var item in CycleDrugCollection)
                {
                    if (item.DrugID != cycleDrugModel.cycleDrugEntity.DrugID)
                    {
                        filter.PredicateExpression.Add(CTHDrugFields.ID != item.DrugID);
                    }
                }
            }
            if (ID > 0)
            {
            }
            cycleDrugModel.DrugList = DataHelper.GetSelectList<CTHDrugEntity>(CTHDrugFields.ID, CTHDrugFields.Name, filter);
            cycleDrugModel.cycleDrugEntity.CycleID = ProtocolCycleID;
            return PartialView(cycleDrugModel);
        }

        [SmartAuthorize(UserPermission.CancerType_AssignDrugToCycle)]
        [HttpPost]
        public IActionResult EditCreateCycleDrug(CycleDrugModel cycleDrug)
        {
            if (cycleDrug.cycleDrugEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(cycleDrug.cycleDrugEntity, true, false, 0);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCycleDrugEntity);
                path.Add(CTHCycleDrugEntity.PrefetchPathCTHProtocolCycleItem, true).SubPath.Add(CTHProtocolCycleEntity.PrefetchPathCTHChemotherapyProtocolItem);
                BL.DataBaseClassHelper.FillEntity(cycleDrug.cycleDrugEntity, path);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHCycleDrugFields.ID == cycleDrug.cycleDrugEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(cycleDrug.cycleDrugEntity, filter, 0);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCycleDrugEntity);
                path.Add(CTHCycleDrugEntity.PrefetchPathCTHProtocolCycleItem, true).SubPath.Add(CTHProtocolCycleEntity.PrefetchPathCTHChemotherapyProtocolItem);
                BL.DataBaseClassHelper.FillEntity(cycleDrug.cycleDrugEntity, path);
            }

            AddSweetNotification("Success","Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("EditCreateProtocolCycle", new { ID = cycleDrug.cycleDrugEntity.CycleID, ProtocolID = cycleDrug.cycleDrugEntity.CTHProtocolCycleItem.CTHChemotherapyProtocolItem.ID });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteDrugFromCycle)]
        [HttpGet]
        public ActionResult DeleteCycleDrug(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id,
            });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteDrugFromCycle)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteCycleDrug")]
        public ActionResult ConfirmDeleteCycleDrug(int ItemID)
        {

            CTHCycleDrugEntity cycleDrugEntity = new CTHCycleDrugEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCycleDrugEntity);
            path.Add(CTHCycleDrugEntity.PrefetchPathCTHProtocolCycleItem, true).SubPath.Add(CTHProtocolCycleEntity.PrefetchPathCTHChemotherapyProtocolItem);
            path.Add(CTHCycleDrugEntity.PrefetchPathCTHDrugItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(cycleDrugEntity, path);
            int ProtocolID = (int)cycleDrugEntity.CTHProtocolCycleItem.CTHChemotherapyProtocolItem.ID;
            int ID = (int)cycleDrugEntity.CycleID;
            SStorm.CTH.BL.DataBaseClassHelper.Delete(cycleDrugEntity, 0);
            AddSweetNotification("Success", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("EditCreateProtocolCycle", new { ID = ID, ProtocolID = ProtocolID });
        }
        #endregion

        #region Drug Symptom

        [SmartAuthorize(UserPermission.CancerType_AssignSymptomToDrug)]
        [HttpGet]
        public IActionResult EditCreateSymptom(int ID, int DrugID, int ProtocolID)
        {
            DrugSymptomModel DrugSymptom = new DrugSymptomModel();
            RelationPredicateBucket filter = new RelationPredicateBucket();
            DrugSymptom.DrugSymptomEntity = new CTHDrugSymptomEntity();
            var DrugSymptoms = new EntityCollection<CTHDrugSymptomEntity>();
            RelationPredicateBucket DrugSymptomFilter = new RelationPredicateBucket(CTHDrugSymptomFields.DrugID == DrugID);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(DrugSymptoms, DrugSymptomFilter, 0, null, null, 0, 0);
            if (ID == 0)
            {
                foreach (var item in DrugSymptoms)
                {
                    filter.PredicateExpression.Add(CTHSymptomFields.ID != item.SymtomID);
                }
            }
            else
            {
                DrugSymptom.DrugSymptomEntity = new CTHDrugSymptomEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(DrugSymptom.DrugSymptomEntity, null);
                foreach (var item in DrugSymptoms)
                {
                    if (item.SymtomID != DrugSymptom.DrugSymptomEntity.SymtomID)
                    {
                        filter.PredicateExpression.Add(CTHSymptomFields.ID != item.SymtomID);
                    }
                }
            }
            RelationPredicateBucket f = new RelationPredicateBucket(CTHSymptomFields.IsDoseLimitingToxicity == true);
            DrugSymptom.SymptomList = DataHelper.GetSelectList<CTHSymptomEntity>(CTHSymptomFields.ID, CTHSymptomFields.Name, f);
            DrugSymptom.DrugSymptomEntity.DrugID = DrugID;
            DrugSymptom.ProtocolID = ProtocolID;
            return PartialView(DrugSymptom);
        }

        [SmartAuthorize(UserPermission.CancerType_AssignSymptomToDrug)]
        [HttpPost]
        public IActionResult EditCreateSymptom(DrugSymptomModel model)
        {
            if (model.DrugSymptomEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.DrugSymptomEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHDrugSymptomFields.ID == model.DrugSymptomEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(model.DrugSymptomEntity, filter, 0);
            }
            AddSweetNotification("Success","Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("EditCreateDrug", new { ID = model.DrugSymptomEntity.DrugID, ProtocolID = model.ProtocolID });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteSymptomFromDrug)]
        [HttpGet]
        public ActionResult DeleteSymptom(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteSymptomFromDrug)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteSymptom")]
        public ActionResult ConfirmDeleteSymptom(int ItemID)
        {
            CTHDrugSymptomEntity item = new CTHDrugSymptomEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugSymptomEntity);
            path.Add(CTHDrugSymptomEntity.PrefetchPathCTHDrugItem, true);
            BL.DataBaseClassHelper.FillEntity(item, path);
            int Drudid = (int)item.DrugID;
            int ProtocolID = (int)item.CTHDrugItem.ProtocolID;
            BL.DataBaseClassHelper.Delete(item, 0);
            AddSweetNotification("Success","Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("EditCreateDrug", new {ID = Drudid , ProtocolID= ProtocolID });
        }

        #endregion

        #region Premidication

        [SmartAuthorize(UserPermission.Premedication_EditCreate)]
        [HttpGet]
        public IActionResult AddNewPremidication()
        {
            PremedicationModel model = new PremedicationModel();
            model.PreMedicationEntity = new CTHPreMedicationEntity();
            model.EmetogenicList = DataHelper.GetDirectionSelectList<EmatogenicRisk>();
            return PartialView(model);
        }

        [SmartAuthorize(UserPermission.Premedication_EditCreate)]
        [HttpPost]
        public IActionResult AddNewPremidication(PremedicationModel model, int EmetogenicRisk)
        {
            SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.PreMedicationEntity, true, false, 0);
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHPreMedicationFields.EmetogenicID == EmetogenicRisk);
            var Premidications = DataHelper.GetSelectList<CTHPreMedicationEntity>(CTHPreMedicationFields.ID, CTHPreMedicationFields.Title, filter);
            return Json(Premidications);
        }
        #endregion

        #region DoseUnit

        [SmartAuthorize(UserPermission.DoseUnit_EditCreate)]
        [HttpGet]
        public IActionResult AddNewDoseUnit()
        {
            CTHDoseUnitEntity model = new CTHDoseUnitEntity();
            return PartialView(model);
        }

        [SmartAuthorize(UserPermission.DoseUnit_EditCreate)]
        [HttpPost]
        public IActionResult AddNewDoseUnit(CTHDoseUnitEntity model)
        {
            SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model, true, false, 0);
            var DoseUnits = DataHelper.GetSelectList<CTHDoseUnitEntity>(CTHDoseUnitFields.ID, CTHDoseUnitFields.Name, null);
            return Json(DoseUnits);
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

        [HttpGet]
        public IActionResult CancerTypeTree()
        {
            TreeViewNode nodes = new TreeViewNode();
            nodes.CancerTypeCollection = new EntityCollection<CTHCancerTypeEntity>();
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCancerTypeEntity);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHCancerTypeCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(nodes.CancerTypeCollection, null, 0, null, path, 0, 0);
            nodes.Seed = null;
            return PartialView(nodes);
        }

        [SmartAuthorize(UserPermission.Solution_EditCreate)]
        [HttpGet]
        public IActionResult AddNewSolution(int ID)
        {
            CTHSolutionEntity masterEntity = new CTHSolutionEntity();       
            return View(masterEntity);
        }

        [SmartAuthorize(UserPermission.Solution_EditCreate)]
        [HttpPost]
        public IActionResult AddNewSolution(CTHSolutionEntity masterEntity)
        {
             SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(masterEntity, true, false, 0);
             var SolutionList = DataHelper.GetSelectList<CTHSolutionEntity>(CTHSolutionFields.ID, CTHSolutionFields.Name);
             return Json(SolutionList);
        }

    }
}