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
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace SStorm.CTH.Web.Controllers
{

    public class PatientClinicalDataController : SmartController
    {
        private readonly IFileService _fileService;
        private readonly IFileService _fileService2;

        public PatientClinicalDataController(IClientNotification _clientNotification, IFileService _fileService, IFileService _fileService2)
         : base(_clientNotification)
        {
            this._fileService = _fileService;
            this._fileService2 = _fileService2;

        }



        /////////////////////////////////*Get Patient Clinical Data List*/////////////////////////////////
        //public IActionResult Index(int PatientID)
        //{
        //    EntityCollection<CTHPatientClinicalDataEntity> patientClinicalDataCollection = new EntityCollection<CTHPatientClinicalDataEntity>();
        //    RelationPredicateBucket filter = new RelationPredicateBucket(CTHPatientClinicalDataFields.PatientID == PatientID);
        //    PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientClinicalDataEntity);
        //    path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerTypeItem, true);
        //    path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerSideItem, true);
        //    path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHTumorGradeItem, true);
        //    path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHStageItem, true);
        //    path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHTreatmentTypeItem, true);
        //    path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHSurgeryTypeItem, true);
        //    SStorm.CTH.BL.DataBaseClassHelper.FillCollection(patientClinicalDataCollection, filter, 0, null, path, 0, 0);
        //    return View(patientClinicalDataCollection);
        //}

        #region Clinical Data

        [SmartAuthorize(UserPermission.Patient_Diagnosis)]
        [HttpGet]
        public IActionResult EditCreate(int ID, int PatientID)
        {
            PatientClinicalDataModel patientClinicalData = new PatientClinicalDataModel();
            patientClinicalData.CancerTypeList = DataHelper.GetSelectList<CTHCancerTypeEntity>(CTHCancerTypeFields.ID, CTHCancerTypeFields.TypeName);
            patientClinicalData.CancerSideList = DataHelper.GetSelectList<CTHCancerSideEntity>(CTHCancerSideFields.ID, CTHCancerSideFields.Side);
            patientClinicalData.TumorGradeList = DataHelper.GetSelectList<CTHTumorGradeEntity>(CTHTumorGradeFields.ID, CTHTumorGradeFields.TumorGrade);
            patientClinicalData.SurgeryTypeList = DataHelper.GetSelectList<CTHSurgeryTypeEntity>(CTHSurgeryTypeFields.ID, CTHSurgeryTypeFields.SurgeryType);
            
            patientClinicalData.HistologicalSubTypeCancerList = null;
            patientClinicalData.MolecularSubTypeList = null;

            RelationPredicateBucket filter1 = new RelationPredicateBucket(CTHTNMStagingFields.TNMTypeID == 1);
            patientClinicalData.TumorSizeList = DataHelper.GetStagingSelectList(CTHTNMStagingFields.ID, CTHTNMStagingFields.Name, CTHTNMStagingFields.Description, filter1);

            RelationPredicateBucket filter2 = new RelationPredicateBucket(CTHTNMStagingFields.TNMTypeID == 2);
            patientClinicalData.LymphNodeList = DataHelper.GetStagingSelectList(CTHTNMStagingFields.ID, CTHTNMStagingFields.Name, CTHTNMStagingFields.Description, filter2);

            RelationPredicateBucket filter3 = new RelationPredicateBucket(CTHTNMStagingFields.TNMTypeID == 3);
            patientClinicalData.DistantMetastasisList = DataHelper.GetStagingSelectList(CTHTNMStagingFields.ID, CTHTNMStagingFields.Name, CTHTNMStagingFields.Description, filter3);

            patientClinicalData.PatientClinicalData = new CTHPatientClinicalDataEntity();
            patientClinicalData.PatientClinicalData.PatientID = PatientID;

            if (ID > 0)
            {
                patientClinicalData.PatientClinicalData = new CTHPatientClinicalDataEntity(ID);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientClinicalDataEntity);
                path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerSideItem, true);
                path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHTumorGradeItem, true);
                path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHStagingItem, true);
                path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHPatientSurgeryCollection, true)
                    .SubPath.Add(CTHPatientSurgeryEntity.PrefetchPathCTHSurgeryTypeItem, true);

                path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHPatientIntialLabCollection, true)
                .SubPath.Add(CTHPatientIntialLabEntity.PrefetchPathCTHLabItem, true);
                path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHPatientPathologyReportCollection, true)
                 .SubPath.Add(CTHPatientPathologyReportEntity.PrefetchPathCTHPathologyReportTypeItem, true);
                path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHPatientImagingCollection, true)
                 .SubPath.Add(CTHPatientImagingEntity.PrefetchPathCTHImagingItem, true);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(patientClinicalData.PatientClinicalData, path);
                RelationPredicateBucket histologicalFilter = new RelationPredicateBucket(CTHCancerHistologicFields.CanerID == patientClinicalData.PatientClinicalData.CancerTypeID);
                RelationPredicateBucket molecularFilter = new RelationPredicateBucket(CTHCancerMolecularFields.CanerID == patientClinicalData.PatientClinicalData.CancerTypeID);
                patientClinicalData.HistologicalSubTypeCancerList = DataHelper.GetSelectList<CTHCancerHistologicEntity>(CTHCancerHistologicFields.ID, CTHCancerHistologicFields.Name, histologicalFilter);
                patientClinicalData.MolecularSubTypeList = DataHelper.GetSelectList<CTHCancerMolecularEntity>(CTHCancerMolecularFields.ID, CTHCancerMolecularFields.Name, molecularFilter);

            }

            return PartialView(patientClinicalData);
        }

        [SmartAuthorize(UserPermission.Patient_Diagnosis)]
        [HttpPost]
        public IActionResult EditCreate(PatientClinicalDataModel PatientClncData)
        {
            PatientClncData.PatientClinicalData.DataDate = DateTime.Now;
            if (PatientClncData.PatientClinicalData.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(PatientClncData.PatientClinicalData, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHPatientClinicalDataFields.ID == PatientClncData.PatientClinicalData.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(PatientClncData.PatientClinicalData, filter, 0);
            }
            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("EditCreate", "Patient", new { ID = PatientClncData.PatientClinicalData.PatientID });
        }

        [SmartAuthorize(UserPermission.Patient_Diagnosis)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.Patient_Diagnosis)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHPatientClinicalDataEntity item = new CTHPatientClinicalDataEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientClinicalDataEntity);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHKimoSurveyCollection, true);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHPatientImagingCollection, true);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHPatientIntialLabCollection, true);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHPatientPathologyReportCollection, true);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHPatientSurgeryCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            int PatientID = (int)item.PatientID;
            if (item.CTHKimoSurveyCollection.Count == 0 && item.CTHPatientImagingCollection.Count == 0 && item.CTHPatientIntialLabCollection.Count == 0 && item.CTHPatientSurgeryCollection.Count == 0 && item.CTHPatientPathologyReportCollection.Count == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "Error, You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);
            }
            return RedirectToAction("EditCreate", "Patient", new { ID = PatientID });
        }

        [HttpGet]
        public JsonResult GetList(int SelectedID, int NumOfListToPush)
        {
            IEnumerable<SelectListItem> myList = null;

            //if(NumOfListToPush == 1)
            //{
            //    RelationPredicateBucket filter = new RelationPredicateBucket(CTHCancerSubTypeFields.CancerTypeID == SelectedID);
            //    myList = DataHelper.GetSelectList<CTHCancerSubTypeEntity>(CTHCancerSubTypeFields.ID, CTHCancerSubTypeFields.TypeName,filter);
            //}
            //else if(NumOfListToPush == 2)
            //{
            //    RelationPredicateBucket filter = new RelationPredicateBucket(CTHCancerSubSubTypeFields.CancerSubTypeID == SelectedID);
            //    myList = DataHelper.GetSelectList<CTHCancerSubSubTypeEntity>(CTHCancerSubSubTypeFields.ID, CTHCancerSubSubTypeFields.TypeName, filter);
            //}
            //else if (NumOfListToPush == 3)
            //{
            //    RelationPredicateBucket filter = new RelationPredicateBucket(CTHCancerSubSubSubTypeFields.CancerSubSubTypeID == SelectedID);
            //    myList = DataHelper.GetSelectList<CTHCancerSubSubSubTypeEntity>(CTHCancerSubSubSubTypeFields.ID, CTHCancerSubSubSubTypeFields.TypeName, filter);
            //}
            //else if (NumOfListToPush == 4)
            //{
            //    RelationPredicateBucket filter = new RelationPredicateBucket(CTHMolecularSubSubTypeCancerFields.MolecularSubTypeCancerID == SelectedID);
            //    myList = DataHelper.GetSelectList<CTHMolecularSubSubTypeCancerEntity>(CTHMolecularSubSubTypeCancerFields.ID, CTHMolecularSubSubTypeCancerFields.Name, filter);
            //}
            //else
            //{
            //    RelationPredicateBucket filter = new RelationPredicateBucket(CTHHistologicSubSubTypeCancerFields.HistologicSubTypeCancerID == SelectedID);
            //    myList = DataHelper.GetSelectList<CTHHistologicSubSubTypeCancerEntity>(CTHHistologicSubSubTypeCancerFields.ID, CTHHistologicSubSubTypeCancerFields.Name, filter);
            //}
            return Json(myList);
        }

        [HttpGet]
        public JsonResult CalculateStage(int T, int N, int M)
        {
            EntityCollection<CTHTNMStagingMatrixEntity> Staging = new EntityCollection<CTHTNMStagingMatrixEntity>();
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHTNMStagingMatrixEntity);
            path.Add(CTHTNMStagingMatrixEntity.PrefetchPathCTHStagingItem, true, CTHStagingFields.ID, CTHStagingFields.Name);
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(CTHTNMStagingMatrixFields.TID == T);
            filter.PredicateExpression.Add(CTHTNMStagingMatrixFields.NID == N);
            filter.PredicateExpression.Add(CTHTNMStagingMatrixFields.MID == M);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(Staging, filter, 0, null, path, 0, 0);
            int stageID = 0;
            string stageName = "";
            foreach (var i in Staging)
            {
                stageID = i.CTHStagingItem.ID;
                stageName = i.CTHStagingItem.Name;
            }


            return Json(new { responseName = stageName, responseID = stageID });
        }

        [HttpGet]
        public ActionResult CancerTypeList()
        {
            TreeViewNode nodes = new TreeViewNode();
            nodes.CancerTypeCollection = new EntityCollection<CTHCancerTypeEntity>();
            PrefetchPath2 Path = new PrefetchPath2(EntityType.CTHCancerTypeEntity);
            Path.Add(CTHCancerTypeEntity.PrefetchPathCTHCancerTypeCollection);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(nodes.CancerTypeCollection, null, 0, null, Path, 0, 0);
            nodes.Seed = null;
            return PartialView(nodes);
        }


        [HttpGet]
        public IActionResult AddNewTumorGrade()
        {
            CTHTumorGradeEntity TumorGrade = new CTHTumorGradeEntity();
            return PartialView(TumorGrade);
        }

        // [SmartAuthorize(UserPermission.Imaging_EditCreate)]
        [HttpPost]
        public IActionResult AddNewTumorGrade(CTHTumorGradeEntity Tumor)
        {
            SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(Tumor, true, false, 0);
            var TumorGradeList = DataHelper.GetSelectList<CTHTumorGradeEntity>(CTHTumorGradeFields.ID, CTHTumorGradeFields.TumorGrade);
            return Json(TumorGradeList);
        }
        #endregion


        #region Patient Surgery

        [SmartAuthorize(UserPermission.Patient_PerformSurgery)]
        [HttpGet]
        public IActionResult EditCreateSurgery(int ID, int PatientClinicalDataID)
        {
            PatientClinicalDataModel patientSurgery = new PatientClinicalDataModel();
            patientSurgery.PatientSurgery = new CTHPatientSurgeryEntity();
            patientSurgery.SurgeryTypeList = DataHelper.GetSelectList<CTHSurgeryTypeEntity>(CTHSurgeryTypeFields.ID, CTHSurgeryTypeFields.SurgeryType);
            patientSurgery.PatientClinicalData = new CTHPatientClinicalDataEntity(PatientClinicalDataID);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(patientSurgery.PatientClinicalData, null);

            if (ID > 0)
            {
                patientSurgery.PatientSurgery = new CTHPatientSurgeryEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(patientSurgery.PatientSurgery, null);
            }

            patientSurgery.PatientSurgery.PatientClinicalDataID = PatientClinicalDataID;
            return View(patientSurgery);
        }

        [SmartAuthorize(UserPermission.Patient_PerformSurgery)]
        [HttpPost]
        public ActionResult EditCreateSurgery(PatientClinicalDataModel PatientClinicalDataModel)
        {
            if (PatientClinicalDataModel.PatientSurgery.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(PatientClinicalDataModel.PatientSurgery, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHPatientSurgeryFields.ID == PatientClinicalDataModel.PatientSurgery.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(PatientClinicalDataModel.PatientSurgery, filter, 0);
            }
            //AddSweetNotification("Done","Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            //return RedirectToAction("EditCreate", "Patient", new { ID = PatientClinicalDataModel.PatientClinicalData.PatientID });
            int PatientDataID = (int)PatientClinicalDataModel.PatientSurgery.PatientClinicalDataID;
            return GetSurgeryList(PatientDataID);
        }


        [SmartAuthorize(UserPermission.Patient_DeleteSurgery)]
        [HttpGet]
        public ActionResult DeleteSurgery(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id,
                ActionName = "DeleteSurgery",
                ControllerName = "PatientClinicalData",
                DataAjaxMethod = "post",
                DataAjax = true,
                DataAjaxSuccess = "LoadSurgeryList"
            });
        }

        [SmartAuthorize(UserPermission.Patient_DeleteSurgery)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteSurgery")]
        public ActionResult ConfirmDeleteSurgery(int ItemID)
        {
            CTHPatientSurgeryEntity item = new CTHPatientSurgeryEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientSurgeryEntity);
            path.Add(CTHPatientSurgeryEntity.PrefetchPathCTHPatientClinicalDataItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            int PatientDataID = (int)item.CTHPatientClinicalDataItem.ID;
            int PatientID = (int)item.CTHPatientClinicalDataItem.PatientID;
            SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
            return Json(JsonReturnType.DeleteSuccess);
        }

        [SmartAuthorize(UserPermission.Patient_ViewPatientSurgeries)]
        [HttpGet]
        public ActionResult GetSurgeryList(int PatientClinicalDataID)
        {
            PatientClinicalDataModel patientClinicalData = new PatientClinicalDataModel();
            patientClinicalData.PatientClinicalData = new CTHPatientClinicalDataEntity(PatientClinicalDataID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientClinicalDataEntity);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHPatientSurgeryCollection, true)
            .SubPath.Add(CTHPatientSurgeryEntity.PrefetchPathCTHSurgeryTypeItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(patientClinicalData.PatientClinicalData, path);
            return PartialView("_PatientSurgeryList", patientClinicalData);
        }

        #endregion


        #region Patien Lab

        [SmartAuthorize(UserPermission.Patient_ViewPatientInvestigations)]
        [HttpGet]
        public IActionResult GETLabList(int PatientClinicalDataID)
        {
            PatientClinicalDataModel patientClinicalData = new PatientClinicalDataModel();
            patientClinicalData.PatientClinicalData = new CTHPatientClinicalDataEntity(PatientClinicalDataID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientClinicalDataEntity);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHPatientIntialLabCollection, true)
            .SubPath.Add(CTHPatientIntialLabEntity.PrefetchPathCTHLabItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(patientClinicalData.PatientClinicalData, path);
            return PartialView("_PatientLab", patientClinicalData);
        }

        [SmartAuthorize(UserPermission.Patient_PerformInvestigation)]
        [HttpGet]
        public IActionResult EditCreatePatientLab(int ID, int PatientClinicalDataID)
        {
            PatientClinicalDataModel patientlab = new PatientClinicalDataModel();
            patientlab.PatientLabEntity = new CTHPatientIntialLabEntity();
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHLabFields.IsIntial == true);
            patientlab.LabList = DataHelper.GetSelectList<CTHLabEntity>(CTHLabFields.ID, CTHLabFields.LabName, filter);
            //patientlab.LabDetalisList = null;
            patientlab.PatientClinicalData = new CTHPatientClinicalDataEntity(PatientClinicalDataID);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(patientlab.PatientClinicalData, null);

            if (ID > 0)
            {
                patientlab.PatientLabEntity = new CTHPatientIntialLabEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(patientlab.PatientLabEntity, null);
            }

            patientlab.PatientLabEntity.PatientClinicalDataID = PatientClinicalDataID;
            return PartialView(patientlab);
        }

        [SmartAuthorize(UserPermission.Patient_PerformInvestigation)]
        [HttpPost]
        public async Task<IActionResult> EditCreatePatientLab(PatientClinicalDataModel PatientClinicalDataModel)
        {
            //string toReturn = await this._fileService.SaveFile(PatientClinicalDataModel.PatientLabEntity.ID, PatientClinicalDataModel.Image);
            //PatientClinicalDataModel.PatientLabEntity.PatientLabFile = toReturn;

            string toReturn2 = await this._fileService2.SaveFile(PatientClinicalDataModel.PatientLabEntity.ID, PatientClinicalDataModel.LabAttachmentResult);
            PatientClinicalDataModel.PatientLabEntity.AttachmentResult = toReturn2;
            if (PatientClinicalDataModel.PatientLabEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(PatientClinicalDataModel.PatientLabEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHPatientIntialLabFields.ID == PatientClinicalDataModel.PatientLabEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(PatientClinicalDataModel.PatientLabEntity, filter, 0);
            }
            int PatientClinicalDataID = (int)PatientClinicalDataModel.PatientLabEntity.PatientClinicalDataID;
            return GETLabList(PatientClinicalDataID);
        }

        [SmartAuthorize(UserPermission.Patient_DeleteInvestigation)]
        [HttpGet]
        public ActionResult DeletePatientLab(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id,
                ActionName = "DeletePatientLab",
                ControllerName = "PatientClinicalData",
                DataAjaxMethod = "post",
                DataAjax = true,
                DataAjaxSuccess = "LoadLab"
            });
        }

        [SmartAuthorize(UserPermission.Patient_DeleteInvestigation)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeletePatientLab")]
        public ActionResult ConfirmDeletePatientLab(int ItemID)
        {
            CTHPatientIntialLabEntity item = new CTHPatientIntialLabEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientIntialLabEntity);
            path.Add(CTHPatientIntialLabEntity.PrefetchPathCTHPatientClinicalDataItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            int PatientID = (int)item.CTHPatientClinicalDataItem.PatientID;
            SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
            return Json(JsonReturnType.DeleteSuccess);
        }

        [HttpGet]
        public JsonResult GetLabDetailList(int SelectedID)
        {
            IEnumerable<SelectListItem> myList = null;
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHLabDetailFields.LabID == SelectedID);
            myList = DataHelper.GetSelectList<CTHLabDetailEntity>(CTHLabDetailFields.ID, CTHLabDetailFields.LabDetailsName, filter);
            return Json(myList);
        }
        #endregion


        #region Patient Imaging

        [SmartAuthorize(UserPermission.Patient_ViewPatientInvestigations)]
        [HttpGet]
        public IActionResult GETPatientImagingList(int PatientClinicalDataID)
        {
            PatientClinicalDataModel patientClinicalDataImaging = new PatientClinicalDataModel();
            patientClinicalDataImaging.PatientClinicalData = new CTHPatientClinicalDataEntity(PatientClinicalDataID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientClinicalDataEntity);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHPatientImagingCollection, true)
                .SubPath.Add(CTHPatientImagingEntity.PrefetchPathCTHImagingItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(patientClinicalDataImaging.PatientClinicalData, path);
            return PartialView("_PatientImaging", patientClinicalDataImaging);
        }

        [SmartAuthorize(UserPermission.Patient_PerformInvestigation)]
        [HttpGet]
        public IActionResult EditCreateImaging(int ID, int PatientClinicalDataID)
        {
            PatientClinicalDataModel patientSurgery = new PatientClinicalDataModel();
            patientSurgery.PatientImagingEntity = new CTHPatientImagingEntity();
            patientSurgery.ImagingTypeList = DataHelper.GetSelectList<CTHImagingEntity>(CTHImagingFields.ID, CTHImagingFields.ImageName);
            patientSurgery.PatientClinicalData = new CTHPatientClinicalDataEntity(PatientClinicalDataID);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(patientSurgery.PatientClinicalData, null);

            if (ID > 0)
            {
                patientSurgery.PatientImagingEntity = new CTHPatientImagingEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(patientSurgery.PatientImagingEntity, null);
            }

            patientSurgery.PatientImagingEntity.PatientClinicalDataID = PatientClinicalDataID;
            return PartialView(patientSurgery);
        }

        [SmartAuthorize(UserPermission.Patient_PerformInvestigation)]
        [HttpPost]
        public async Task<IActionResult> EditCreateImaging(PatientClinicalDataModel PatientClinicalDataModel)
        {
            //string toReturn = await this._fileService.SaveFile(PatientClinicalDataModel.PatientImagingEntity.ID, PatientClinicalDataModel.Image);
            //PatientClinicalDataModel.PatientImagingEntity.Image = toReturn;
            string toReturn2 = await this._fileService.SaveFile(PatientClinicalDataModel.PatientImagingEntity.ID, PatientClinicalDataModel.ImageAttachmentResult);
            PatientClinicalDataModel.PatientImagingEntity.AttachmentResult = toReturn2;
            if (PatientClinicalDataModel.PatientImagingEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(PatientClinicalDataModel.PatientImagingEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHPatientImagingFields.ID == PatientClinicalDataModel.PatientImagingEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(PatientClinicalDataModel.PatientImagingEntity, filter, 0);
            }
            int PatientClinicalDataID = (int)PatientClinicalDataModel.PatientImagingEntity.PatientClinicalDataID;
            return GETPatientImagingList(PatientClinicalDataID);
        }

        [SmartAuthorize(UserPermission.Patient_DeleteInvestigation)]
        [HttpGet]
        public ActionResult DeleteImaging(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id,
                ActionName = "DeleteImaging",
                ControllerName = "PatientClinicalData",
                DataAjaxMethod = "post",
                DataAjax = true,
                DataAjaxSuccess = "LoadImaging"
            });
        }

        [SmartAuthorize(UserPermission.Patient_DeleteInvestigation)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteImaging")]
        public ActionResult ConfirmDeleteImaging(int ItemID)
        {
            CTHPatientImagingEntity item = new CTHPatientImagingEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientImagingEntity);
            path.Add(CTHPatientImagingEntity.PrefetchPathCTHPatientClinicalDataItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            int PatientID = (int)item.CTHPatientClinicalDataItem.PatientID;
            SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
            return Json(JsonReturnType.DeleteSuccess);
        }

        public ActionResult DownloadFileImaging(int ID)
        {
            CTHPatientImagingEntity fileEntity = new CTHPatientImagingEntity(ID);
            CTH.BL.DataBaseClassHelper.FillEntity(fileEntity, null);

            if (fileEntity.IsNew)
            {
                AddSweetNotification("Error", "Failed to download attachment.", Helper.NotificationHelper.NotificationType.error);
                return Content("");
            }

            var file = _fileService.ReadFile(fileEntity.Image);
            if (file == null || file.Length < 1)
                return Content("");

            return File(file, System.Net.Mime.MediaTypeNames.Application.Octet, Path.ChangeExtension(fileEntity.Image, Path.GetExtension(fileEntity.Image)));
        }

        #endregion


        #region Patien Pathology Report

        [SmartAuthorize(UserPermission.Patient_ViewPatientInvestigations)]
        [HttpGet]
        public IActionResult GETPathologyReportList(int PatientClinicalDataID)
        {
            PatientClinicalDataModel patientClinicalDataReport = new PatientClinicalDataModel();
            patientClinicalDataReport.PatientClinicalData = new CTHPatientClinicalDataEntity(PatientClinicalDataID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientClinicalDataEntity);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHPatientPathologyReportCollection, true)
                .SubPath.Add(CTHPatientPathologyReportEntity.PrefetchPathCTHPathologyReportTypeItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(patientClinicalDataReport.PatientClinicalData, path);
            return PartialView("_PatientPathologyReport", patientClinicalDataReport);
        }

        [SmartAuthorize(UserPermission.Patient_PerformInvestigation)]
        [HttpGet]
        public IActionResult EditCreatePathologyReport(int ID, int PatientClinicalDataID)
        {
            PatientClinicalDataModel patientSurgery = new PatientClinicalDataModel();
            patientSurgery.PathologyReportEntity = new CTHPatientPathologyReportEntity();
            patientSurgery.ReportTypeList = DataHelper.GetSelectList<CTHPathologyReportTypeEntity>(CTHPathologyReportTypeFields.ID, CTHPathologyReportTypeFields.Name);
            patientSurgery.PatientClinicalData = new CTHPatientClinicalDataEntity(PatientClinicalDataID);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(patientSurgery.PatientClinicalData, null);

            if (ID > 0)
            {
                patientSurgery.PathologyReportEntity = new CTHPatientPathologyReportEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(patientSurgery.PathologyReportEntity, null);
            }

            patientSurgery.PathologyReportEntity.PatienClinicalDataID = PatientClinicalDataID;
            return PartialView(patientSurgery);
        }

        [SmartAuthorize(UserPermission.Patient_PerformInvestigation)]
        [HttpPost]
        public async Task<IActionResult> EditCreatePathologyReport(PatientClinicalDataModel PatientClinicalDataModel)
        {
            string toReturn = await this._fileService.SaveFile(PatientClinicalDataModel.PathologyReportEntity.ID, PatientClinicalDataModel.Image);
            PatientClinicalDataModel.PathologyReportEntity.Report = toReturn;
            if (PatientClinicalDataModel.PathologyReportEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(PatientClinicalDataModel.PathologyReportEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHPatientPathologyReportFields.ID == PatientClinicalDataModel.PathologyReportEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(PatientClinicalDataModel.PathologyReportEntity, filter, 0);
            }
            int PatientClinicalDataID = (int)PatientClinicalDataModel.PathologyReportEntity.PatienClinicalDataID;
            return GETPathologyReportList(PatientClinicalDataID);
        }

        [SmartAuthorize(UserPermission.Patient_DeleteInvestigation)]
        [HttpGet]
        public ActionResult DeletePathologyReport(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id,
                ActionName = "DeletePathologyReport",
                ControllerName = "PatientClinicalData",
                DataAjaxMethod = "post",
                DataAjax = true,
                DataAjaxSuccess = "LoadPathologyReport"
            });

        }

        [SmartAuthorize(UserPermission.Patient_DeleteInvestigation)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeletePathologyReport")]
        public ActionResult ConfirmDeletePathologyReport(int ItemID)
        {
            CTHPatientPathologyReportEntity item = new CTHPatientPathologyReportEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientPathologyReportEntity);
            path.Add(CTHPatientPathologyReportEntity.PrefetchPathCTHPatientClinicalDataItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            int PatientID = (int)item.CTHPatientClinicalDataItem.PatientID;
            SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
            return Json(JsonReturnType.DeleteSuccess);
        }

        public ActionResult DownloadFilePathologyReport(int ID)
        {
            CTHPatientPathologyReportEntity fileEntity = new CTHPatientPathologyReportEntity(ID);
            CTH.BL.DataBaseClassHelper.FillEntity(fileEntity, null);

            if (fileEntity.IsNew)
            {
                AddSweetNotification("Error", "Failed to download attachment.", Helper.NotificationHelper.NotificationType.error);
                return Content("");
            }

            var file = _fileService.ReadFile(fileEntity.Report);
            if (file == null || file.Length < 1)
                return Content("");

            return File(file, System.Net.Mime.MediaTypeNames.Application.Octet, Path.ChangeExtension(fileEntity.Report, Path.GetExtension(fileEntity.Report)));
        }
        #endregion


        #region KimoSurvey

        [SmartAuthorize(UserPermission.Patient_ViewPatientChemoSurveySessions)]

        public ActionResult GetKimoSurvey(int ID)
        {
            CTHPatientClinicalDataEntity ClinicalData = new CTHPatientClinicalDataEntity(ID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientClinicalDataEntity);

            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHPatientItem, true);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerTypeItem, true);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerHistologicItem, true);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerMolecularItem, true);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerSideItem, true);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHStagingItem, true);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHTumorGradeItem, true);

            var KimoPath = path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHKimoSurveyCollection, true);
            KimoPath.SubPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
            KimoPath.SubPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHSpecialCaseItem, true);
            KimoPath.SubPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHSpecialCasePartItem, true);
            KimoPath.SubPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHProtocolCycleItem, true)
                .SubPath.Add(CTHProtocolCycleEntity.PrefetchPathCTHChemotherapyProtocolItem, true)
                    .SubPath.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHProtocolCycleCollection, true);

            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(ClinicalData, path);
            if (ClinicalData.CTHKimoSurveyCollection.Count == 0)
            {
                return RedirectToAction("EditCreateKimoSurvey", new { ID = 0, DataID = ClinicalData.ID });
            }
            else
            {
                var LastSession = ClinicalData.CTHKimoSurveyCollection.Last();
                var LastDate = (DateTime)LastSession.Date;
                var CurrentDate = DateTime.Now;
                int reminder = (int)(CurrentDate - LastDate).TotalDays;
                for (var i = 0; i < reminder; i++)
                {
                    var Date = LastDate.AddDays(1);
                    var CycleDays = LastSession.CTHProtocolCycleItem.Every;
                    int Day = 1;
                    int CycleNum = (int)LastSession.CTHProtocolCycleItem.Number;
                    int CycleID = (int)LastSession.CycleID;
                    if (LastSession.CTHProtocolCycleItem.EveryUnit == 2)
                    {
                        CycleDays = LastSession.CTHProtocolCycleItem.Every * 7;
                    }
                    if (CycleDays > LastSession.Days)
                    {
                        Day = (int)LastSession.Days + 1;
                    }
                    else
                    {
                        var protocolCycles = LastSession.CTHProtocolCycleItem.CTHChemotherapyProtocolItem.CTHProtocolCycleCollection.Where(c => c.Number > CycleNum);
                        if (protocolCycles.Count() == 0)
                        {
                            var minCycleNum = (int)LastSession.CTHProtocolCycleItem.CTHChemotherapyProtocolItem.CTHProtocolCycleCollection.Min(c => c.Number);
                            protocolCycles = LastSession.CTHProtocolCycleItem.CTHChemotherapyProtocolItem.CTHProtocolCycleCollection.Where(c => c.Number == minCycleNum);
                        }

                        if (protocolCycles.Count() > 0)
                        {
                            var firstItem = protocolCycles.First();
                            CycleNum = (int)firstItem.Number;
                            CycleID = firstItem.ID;
                        }
                        else
                        {

                        }

                    }

                    CTHKimoSurveyEntity ChemoSession = new CTHKimoSurveyEntity()
                    {
                        PatientClinicalDataID = LastSession.PatientClinicalDataID,
                        ProtocolID = LastSession.ProtocolID,
                        Weight = LastSession.Weight,
                        Height = LastSession.Height,
                        SerumCreatinine = LastSession.SerumCreatinine,
                        BodyMassIndex = LastSession.BodyMassIndex,
                        BodySurfaceArea = LastSession.BodySurfaceArea,
                        AdjustBodyWeight = LastSession.AdjustBodyWeight,
                        LeanBodyWeight = LastSession.LeanBodyWeight,
                        CRCL = LastSession.CRCL,
                        IsSpecialCase = LastSession.IsSpecialCase,
                        SpecialCaseID = LastSession.SpecialCaseID,
                        SpecialCasePartID = LastSession.SpecialCasePartID,
                        TreatementTypeID = LastSession.TreatementTypeID,
                        Date = Date,
                        CycleID = CycleID,
                        CycleNum = CycleNum,
                        Days = Day
                    };
                    SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(ChemoSession, true, false, 0);

                    //after save
                    EntityCollection<CTHKimoSurveyEntity> collection = new EntityCollection<CTHKimoSurveyEntity>();
                    RelationPredicateBucket ChemoFilter = new RelationPredicateBucket(CTHKimoSurveyFields.PatientClinicalDataID == ClinicalData.ID);
                    PrefetchPath2 ChemoPath = new PrefetchPath2(EntityType.CTHKimoSurveyEntity);
                    ChemoPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHSpecialCaseItem, true);
                    ChemoPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
                    ChemoPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHProtocolCycleItem, true)
                        .SubPath.Add(CTHProtocolCycleEntity.PrefetchPathCTHChemotherapyProtocolItem, true)
                            .SubPath.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHProtocolCycleCollection, true);
                    SStorm.CTH.BL.DataBaseClassHelper.FillCollection(collection, ChemoFilter, 0, null, ChemoPath, 0, 0);
                    LastSession = collection.Last();
                    Date = (DateTime)LastSession.Date;
                    LastDate = Date;
                }
                ClinicalData = new CTHPatientClinicalDataEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(ClinicalData, path);
                return View(ClinicalData);
            }

        }

        [SmartAuthorize(UserPermission.Patient_DeleteChemo)]
        [HttpGet]
        public ActionResult DeleteKimoSurvey(int ID)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = ID,
            });
        }

        [SmartAuthorize(UserPermission.Patient_DeleteChemo)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteKimoSurvey")]
        public ActionResult ConfirmDeleteKimoSurvey(int ItemID)
        {
            CTHKimoSurveyEntity item = new CTHKimoSurveyEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHKimoSurveyEntity);
            path.Add(CTHKimoSurveyEntity.PrefetchPathCTHPatientDrugCollection, true);
            path.Add(CTHKimoSurveyEntity.PrefetchPathCTHChemoLabCollection, true);
            path.Add(CTHKimoSurveyEntity.PrefetchPathCTHPatientClinicalDataItem, true);
            path.Add(CTHKimoSurveyEntity.PrefetchPathCTHNotificationCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            int DataID = (int)item.PatientClinicalDataID;
            int PatientID = (int)item.CTHPatientClinicalDataItem.PatientID;

            if (item.CTHPatientDrugCollection.Count == 0 && item.CTHChemoLabCollection.Count == 0)
            {
                foreach (var i in item.CTHNotificationCollection)
                {
                    SStorm.CTH.BL.DataBaseClassHelper.Delete(i, 0);
                }
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);
            }


            return RedirectToAction("EditCreate", "Patient", new { ID = PatientID });
        }

        [SmartAuthorize(UserPermission.Patient_EditCreateChemo)]
        [HttpGet]
        public ActionResult EditCreateKimoSurvey(int ID, int DataID)
        {
            KimoSurveyModel KimoSurveyModel = new KimoSurveyModel();
            KimoSurveyModel.KimoSurveyEntity = new CTHKimoSurveyEntity();

            KimoSurveyModel.SpecialCaseList = DataHelper.GetSelectList<CTHSpecialCaseEntity>(CTHSpecialCaseFields.ID, CTHSpecialCaseFields.CaseName);
            RelationPredicateBucket f = new RelationPredicateBucket(CTHTreatmentTypeFields.WhatTreatment == 2);
            KimoSurveyModel.TreatementList = DataHelper.GetSelectList<CTHTreatmentTypeEntity>(CTHTreatmentTypeFields.ID, CTHTreatmentTypeFields.TreatmentType, f);
            KimoSurveyModel.SpecialCasePartList = null;
            KimoSurveyModel.ProtocolCycleList = null;
            KimoSurveyModel.KimoSurveyEntity.Date = DateTime.Now;

            if (ID > 0)
            {
                KimoSurveyModel.KimoSurveyEntity = new CTHKimoSurveyEntity(ID);
                PrefetchPath2 path1 = new PrefetchPath2(EntityType.CTHKimoSurveyEntity);
                path1.Add(CTHKimoSurveyEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
                path1.Add(CTHKimoSurveyEntity.PrefetchPathCTHPatientDrugCollection, true)
                    .SubPath.Add(CTHPatientDrugEntity.PrefetchPathCTHDrugDayItem, true)
                        .SubPath.Add(CTHDrugDayEntity.PrefetchPathCTHDrugItem, true)
                            .SubPath.Add(CTHDrugEntity.PrefetchPathCTHDoseUnitItem, true);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(KimoSurveyModel.KimoSurveyEntity, path1);
                KimoSurveyModel.ChemoDrugs = GetCycleDrug(ID, (int)KimoSurveyModel.KimoSurveyEntity.CycleID, (int)KimoSurveyModel.KimoSurveyEntity.Days);
                KimoSurveyModel.ChemoLabs = GetCycleLab(ID, (int)KimoSurveyModel.KimoSurveyEntity.CycleID);
                if (KimoSurveyModel.KimoSurveyEntity.IsSpecialCase == true)
                {
                    CTHSpecialCaseEntity specialCaseEntity = new CTHSpecialCaseEntity((int)KimoSurveyModel.KimoSurveyEntity.SpecialCaseID);
                    SStorm.CTH.BL.DataBaseClassHelper.FillEntity(specialCaseEntity, null);
                    if (specialCaseEntity.HasParts == true)
                    {
                        RelationPredicateBucket Casefilter = new RelationPredicateBucket(CTHSpecialCasePartFields.CaseID == ID);
                        KimoSurveyModel.SpecialCasePartList = DataHelper.GetSelectList<CTHSpecialCasePartEntity>(CTHSpecialCasePartFields.ID, CTHSpecialCasePartFields.PartName, Casefilter);
                    }
                }
                RelationPredicateBucket Cyclefilter = new RelationPredicateBucket(CTHProtocolCycleFields.ProtocolID == KimoSurveyModel.KimoSurveyEntity.ProtocolID);
                KimoSurveyModel.ProtocolCycleList = DataHelper.GetSelectList<CTHProtocolCycleEntity>(CTHProtocolCycleFields.ID, CTHProtocolCycleFields.Number, Cyclefilter);

            }


            KimoSurveyModel.PatientClinicalDataEntity = new CTHPatientClinicalDataEntity(DataID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientClinicalDataEntity);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHPatientItem, true);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerTypeItem, true);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerHistologicItem, true);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerMolecularItem, true);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerSideItem, true);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHStagingItem, true);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHTumorGradeItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(KimoSurveyModel.PatientClinicalDataEntity, path);

            RelationPredicateBucket filter = new RelationPredicateBucket(CTHChemotherapyProtocolFields.CancerTypeID == KimoSurveyModel.PatientClinicalDataEntity.CancerTypeID);
            KimoSurveyModel.ProtocolList = DataHelper.GetSelectList<CTHChemotherapyProtocolEntity>(CTHChemotherapyProtocolFields.ID, CTHChemotherapyProtocolFields.ProtocolName, filter);



            KimoSurveyModel.KimoSurveyEntity.PatientClinicalDataID = DataID;
            return View(KimoSurveyModel);
        }

        [SmartAuthorize(UserPermission.Patient_EditCreateChemo)]
        [HttpPost]
        public ActionResult EditCreateKimoSurvey(KimoSurveyModel kimoSurveyModel, bool KimoSurveyEntity_IsSpecialCase)
        {
            kimoSurveyModel.KimoSurveyEntity.PatientClinicalDataID = kimoSurveyModel.PatientClinicalDataEntity.ID;
            kimoSurveyModel.KimoSurveyEntity.IsSpecialCase = KimoSurveyEntity_IsSpecialCase;
            if (kimoSurveyModel.KimoSurveyEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(kimoSurveyModel.KimoSurveyEntity, true, false, 0);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHKimoSurveyEntity);
                path.Add(CTHKimoSurveyEntity.PrefetchPathCTHPatientClinicalDataItem, true);
                path.Add(CTHKimoSurveyEntity.PrefetchPathCTHProtocolCycleItem, true);
                path.Add(CTHKimoSurveyEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
                BL.DataBaseClassHelper.FillEntity(kimoSurveyModel.KimoSurveyEntity, path);
                var ProtocolCycleItem = kimoSurveyModel.KimoSurveyEntity.CTHProtocolCycleItem;
                int KimoDays = (int)kimoSurveyModel.KimoSurveyEntity.Days;
                int Days = (int)kimoSurveyModel.KimoSurveyEntity.CTHChemotherapyProtocolItem.Days;
                int SubDay = Days - KimoDays;
                DateTime NotificationDate = ((DateTime)kimoSurveyModel.KimoSurveyEntity.Date).AddDays(SubDay);
                CTHNotificationEntity NotificationEntity = new CTHNotificationEntity()
                {
                    KimoID = kimoSurveyModel.KimoSurveyEntity.ID,
                    PatientID = kimoSurveyModel.KimoSurveyEntity.CTHPatientClinicalDataItem.PatientID,
                    TypeID = (int)NotificationEntityType.KimoSurvey,
                    Message =
                           "Kimo cycle Number is:" + kimoSurveyModel.KimoSurveyEntity.CTHProtocolCycleItem.Number + "_" +
                           "Is finshed in Date :" + NotificationDate,
                    NotificationDate = NotificationDate
                };
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(NotificationEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket(CTHKimoSurveyFields.ID == kimoSurveyModel.KimoSurveyEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(kimoSurveyModel.KimoSurveyEntity, filter, 0);
                
                int KimoID = kimoSurveyModel.KimoSurveyEntity.ID;
                int KimoDay = (int)kimoSurveyModel.KimoSurveyEntity.Days;
                EditCreateChemoDrugList(kimoSurveyModel.ChemoDrugs, KimoID, KimoDay);
                var x = EditCreateChemoLabList(kimoSurveyModel.ChemoLabs, KimoID);
            }

            

            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("EditCreateKimoSurvey", new { ID = kimoSurveyModel.KimoSurveyEntity.ID, DataID = kimoSurveyModel.PatientClinicalDataEntity.ID });
        }


        public void EditCreateChemoDrugList(List<DrugListModel> ChemoDrugs, int KimoID, int KimoDay)
        {
            if (ChemoDrugs.Count != 0)
            {

                for (var i = 0; i < ChemoDrugs.Count; i++)
                {
                    CTHDrugEntity Drug = new CTHDrugEntity(ChemoDrugs[i].ID);
                    PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugEntity);
                    path.Add(CTHDrugEntity.PrefetchPathCTHDrugDayCollection, true);
                    SStorm.CTH.BL.DataBaseClassHelper.FillEntity(Drug, path);
                    int DrugDayID = Drug.CTHDrugDayCollection.FirstOrDefault(c => c.Day == KimoDay).ID;
                    //float DosePercentage = DosePercentageList[i];
                    EntityCollection<CTHPatientDrugEntity> PatienDrugs = new EntityCollection<CTHPatientDrugEntity>();
                    RelationPredicateBucket filter = new RelationPredicateBucket(CTHPatientDrugFields.KimoID == KimoID & CTHPatientDrugFields.DrugDayID == DrugDayID);
                    SStorm.CTH.BL.DataBaseClassHelper.FillCollection(PatienDrugs, filter, 0, null, null, 0, 0);
                    if (PatienDrugs.Count == 0)
                    {
                        CTHPatientDrugEntity patientDrug = new CTHPatientDrugEntity()
                        {
                            DrugID = ChemoDrugs[i].ID,
                            DrugDayID = DrugDayID,
                            KimoID = KimoID,
                            Dose = (double)ChemoDrugs[i].DrugDose,
                            DoseUnit = ChemoDrugs[i].DrugDoseUnit,
                            DosePer = ChemoDrugs[i].DrugDosePer,
                            DoseModification = (double)ChemoDrugs[i].DoseModification,
                            RouteID = ChemoDrugs[i].RouteID,
                            IsNew = true,
                            Date = DateTime.Now
                        };
                        SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(patientDrug, true, false, 0);
                    }
                    else
                    {
                        CTHPatientDrugEntity PatientDrug = PatienDrugs.FirstOrDefault();
                        PatientDrug.DrugID = ChemoDrugs[i].ID;
                        PatientDrug.DrugDayID = DrugDayID;
                        PatientDrug.KimoID = KimoID;
                        PatientDrug.Dose = (double)ChemoDrugs[i].DrugDose;
                        PatientDrug.DoseUnit = ChemoDrugs[i].DrugDoseUnit;
                        PatientDrug.DosePer = ChemoDrugs[i].DrugDosePer;
                        PatientDrug.DoseModification = (double)ChemoDrugs[i].DoseModification;
                        PatientDrug.RouteID = ChemoDrugs[i].RouteID;
                        PatientDrug.IsNew = false;
                        PatientDrug.Date = DateTime.Now;
                        RelationPredicateBucket PatientDrugFilter = new RelationPredicateBucket(CTHPatientDrugFields.ID == PatientDrug.ID);
                        SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(PatientDrug, PatientDrugFilter, 0);
                    }

                }
            }

        }

        public async Task<bool> EditCreateChemoLabList(List<LabListModel> ChemoLabs, int ChemoID)
        {
            foreach (var item in ChemoLabs)
            {
                EntityCollection<CTHChemoLabEntity> labs = new EntityCollection<CTHChemoLabEntity>();
                RelationPredicateBucket labFilter = new RelationPredicateBucket();
                labFilter.PredicateExpression.Add(CTHChemoLabFields.ChemoID == ChemoID);
                labFilter.PredicateExpression.Add(CTHChemoLabFields.LabDetailsID == item.ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillCollection(labs, labFilter, 0, null, null, 0, 0);
                string toReturn = await this._fileService.SaveFile(item.ID, item.AttachmentResultToUpload);
                if (labs.Count == 0)
                {
                    CTHChemoLabEntity lab = new CTHChemoLabEntity()
                    {
                        ChemoID = ChemoID,
                        LabDetailsID = item.ID,
                        Date = item.Date,
                        TextResult = item.TextResult,
                        AttachmentResult = toReturn
                    };
                    SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(lab, true, false, 0);
                }
                else
                {
                    var oldlab = labs.First();
                    if (toReturn == "")
                    {
                        toReturn = oldlab.AttachmentResult;
                    }
                    oldlab.Date = item.Date;
                    oldlab.TextResult = item.TextResult;
                    oldlab.AttachmentResult = toReturn;
                    RelationPredicateBucket filter = new RelationPredicateBucket(CTHChemoLabFields.ID == oldlab.ID);
                    SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(oldlab, filter, 0);
                }
            }
            return true;
        }

        [HttpGet]
        public ActionResult GetSpecialCaseParts(int ID)
        {
            CTHSpecialCaseEntity specialCaseEntity = new CTHSpecialCaseEntity(ID);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(specialCaseEntity, null);
            IEnumerable<SelectListItem> CaseParts = null;
            if (specialCaseEntity.HasParts == true)
            {
                RelationPredicateBucket filter = new RelationPredicateBucket(CTHSpecialCasePartFields.CaseID == ID);
                CaseParts = DataHelper.GetSelectList<CTHSpecialCasePartEntity>(CTHSpecialCasePartFields.ID, CTHSpecialCasePartFields.PartName, filter);
            }
            var caseHasParts = specialCaseEntity.HasParts;
            return Json(CaseParts);
        }

        [HttpGet]
        public ActionResult GetProtocol(int ID, int PatientDataID)
        {
            CTHChemotherapyProtocolEntity protocolEntity = new CTHChemotherapyProtocolEntity(ID);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(protocolEntity, null);
            CTHPatientClinicalDataEntity PatientData = new CTHPatientClinicalDataEntity(PatientDataID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientClinicalDataEntity);
            path.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHKimoSurveyCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(PatientData, path);
            var Day = 0;
            var Cycle = 0;
            if (PatientData.CTHKimoSurveyCollection.Count > 0)
            {
                var LastSession = PatientData.CTHKimoSurveyCollection.LastOrDefault();
                if (LastSession.ProtocolID != ID)
                {
                    Day = 1;
                    Cycle = 1;
                }
            }
            List<int> result = new List<int>();
            result.Add((int)protocolEntity.Days);
            result.Add(Day);
            result.Add(Cycle);
            return Json(result);
        }

        [HttpGet]
        public ActionResult GetDrugList(int ChemoID, int CycleID, int Day)
        {
            var Drugs = GetCycleDrug(ChemoID, CycleID, Day);
            return PartialView("_Druglist", Drugs);
        }

        [HttpGet]
        public List<DrugListModel> GetCycleDrug(int ChemoID, int CycleID, int Day)
        {
            List<DrugListModel> Drugs = new List<DrugListModel>();
            var chemo = new CTHKimoSurveyEntity();
            if (ChemoID != 0)
            {
                chemo = new CTHKimoSurveyEntity(ChemoID);
                PrefetchPath2 path1 = new PrefetchPath2(EntityType.CTHKimoSurveyEntity);
                var patientDrugPath = path1.Add(CTHKimoSurveyEntity.PrefetchPathCTHPatientDrugCollection, true);
                var drugDayPath = patientDrugPath.SubPath.Add(CTHPatientDrugEntity.PrefetchPathCTHDrugDayItem, true);
                var drugPath1 = drugDayPath.SubPath.Add(CTHDrugDayEntity.PrefetchPathCTHDrugItem, true);
                drugPath1.SubPath.Add(CTHDrugEntity.PrefetchPathCTHCycleDrugCollection, true);
                drugPath1.SubPath.Add(CTHDrugEntity.PrefetchPathCTHDoseUnitItem, true);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(chemo, path1);


                if (chemo.CycleID == CycleID)
                {
                    foreach (var item in chemo.CTHPatientDrugCollection)
                    {
                        var check = false;
                        if (item.CTHDrugDayItem != null)
                        {
                            if (item.CTHDrugDayItem.CTHDrugItem != null)
                            {
                                foreach (var i in item.CTHDrugDayItem.CTHDrugItem.CTHCycleDrugCollection)
                                {
                                    if (i.CycleID == CycleID && item.CTHDrugDayItem.Day == Day)
                                    {
                                        check = true;
                                    }
                                }
                            }
                        }

                        if (check == true)
                        {
                            DrugListModel drug = new DrugListModel()
                            {
                                ID = (int)item.DrugID,
                                DrugName = item.CTHDrugDayItem.CTHDrugItem.Name,
                                DrugDose = (decimal)item.Dose,
                                DoseModification = (decimal)item.DoseModification,
                                DrugDosePer = (int)item.DosePer,
                                RouteID = (int)item.RouteID,
                                RouteList = DataHelper.GetDirectionSelectList<Route>(),
                                DrugDoseUnit = (int)item.DoseUnit,
                                DrugDosePerList = DataHelper.GetDirectionSelectList<PerList>(),
                                DrugDoseUnitList = DataHelper.GetSelectList<CTHDoseUnitEntity>(CTHDoseUnitFields.ID, CTHDoseUnitFields.Name, null),
                            };
                            if(ChemoID != 0)
                            {
                                drug.Date = ((DateTime)chemo.Date).Date;
                            }
                            Drugs.Add(drug);
                        }

                    }
                }
            }

            CTHProtocolCycleEntity cycle = new CTHProtocolCycleEntity(CycleID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHProtocolCycleEntity);
            var cycleDrugPath = path.Add(CTHProtocolCycleEntity.PrefetchPathCTHCycleDrugCollection, true);
            var drugPath = cycleDrugPath.SubPath.Add(CTHCycleDrugEntity.PrefetchPathCTHDrugItem, true);
            drugPath.SubPath.Add(CTHDrugEntity.PrefetchPathCTHDrugDayCollection, true);
            drugPath.SubPath.Add(CTHDrugEntity.PrefetchPathCTHDoseUnitItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(cycle, path);

            foreach (var cycledrug in cycle.CTHCycleDrugCollection)
            {
                if (cycledrug.CTHDrugItem != null)
                {
                    foreach (var drugday in cycledrug.CTHDrugItem.CTHDrugDayCollection)
                    {
                        if (drugday.Day == Day)
                        {
                            DrugListModel drug = new DrugListModel()
                            {
                                ID = (int)cycledrug.DrugID,
                                DrugName = cycledrug.CTHDrugItem.Name,
                                DrugDose = (decimal)cycledrug.CTHDrugItem.Dose,
                                DrugDosePer = (int)cycledrug.CTHDrugItem.DosePerID,
                                RouteID = (int)cycledrug.CTHDrugItem.RouteID,
                                RouteList = DataHelper.GetDirectionSelectList<Route>(),
                                DrugDoseUnit = (int)cycledrug.CTHDrugItem.DoseUnitID,
                                DrugDosePerList = DataHelper.GetDirectionSelectList<PerList>(),
                                DrugDoseUnitList = DataHelper.GetSelectList<CTHDoseUnitEntity>(CTHDoseUnitFields.ID, CTHDoseUnitFields.Name, null)
                            };
                            if (ChemoID != 0)
                            {
                                //BodySurfaceArea = 1
                                if (drug.DrugDosePer == 1)
                                {
                                    drug.DoseModification = (decimal)chemo.BodySurfaceArea * drug.DrugDose;
                                }
                                //AdjustBodyWieght = 2
                                else if (drug.DrugDosePer == 2)
                                {
                                    drug.DoseModification = (decimal)chemo.AdjustBodyWeight * drug.DrugDose;
                                }
                                //LeanBodyWeight = 3
                                else if (drug.DrugDosePer == 3)
                                {
                                    drug.DoseModification = (decimal)chemo.LeanBodyWeight * drug.DrugDose;
                                }
                                //CRCL = 4
                                else
                                {
                                    drug.DoseModification = (decimal)chemo.CRCL * drug.DrugDose;
                                }
                                drug.Date = ((DateTime)chemo.Date).Date;
                            }
                            if (Drugs.Where(c => c.ID == drug.ID).Count() == 0)
                            {
                                Drugs.Add(drug);
                            }
                        }
                    }
                }
            }

            return Drugs;
        }


        [HttpGet]
        public ActionResult GetCycleLabList(int ChemoID, int CycleID)
        {
            var Labs = GetCycleLab(ChemoID, CycleID);
            return PartialView("_LabList", Labs);
        }

        [HttpGet]
        public List<LabListModel> GetCycleLab(int ChemoID, int CycleID)
        {
            List<LabListModel> Labs = new List<LabListModel>();
            var chemo = new CTHKimoSurveyEntity();
            if (ChemoID != 0)
            {
                chemo = new CTHKimoSurveyEntity(ChemoID);
                PrefetchPath2 path1 = new PrefetchPath2(EntityType.CTHKimoSurveyEntity);
                path1.Add(CTHKimoSurveyEntity.PrefetchPathCTHChemoLabCollection, true)
                    .SubPath.Add(CTHChemoLabEntity.PrefetchPathCTHLabDetailItem, true)
                        .SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabItem, true);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(chemo, path1);

                if (chemo.CycleID == CycleID)
                {
                    foreach (var item in chemo.CTHChemoLabCollection)
                    {
                        LabListModel lab = new LabListModel()
                        {
                            ID = (int)item.LabDetailsID,
                            LabName = item.CTHLabDetailItem.CTHLabItem.LabName,
                            LabDetailName = item.CTHLabDetailItem.LabDetailsName,
                            TextResult = item.TextResult,
                            AttachmentResultToDownload = item.AttachmentResult,
                            Date = ((DateTime)item.Date).Date
                        };
                        Labs.Add(lab);
                    }
                }
            }

            CTHProtocolCycleEntity cycle = new CTHProtocolCycleEntity(CycleID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHProtocolCycleEntity);
            path.Add(CTHProtocolCycleEntity.PrefetchPathCTHCycleLabCollection, true)
                .SubPath.Add(CTHCycleLabEntity.PrefetchPathCTHLabDetailItem, true)
                    .SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(cycle, path);

            foreach (var item in cycle.CTHCycleLabCollection)
            {
                LabListModel lab = new LabListModel()
                {
                    ID = (int)item.LabID,
                    LabName = item.CTHLabDetailItem.CTHLabItem.LabName,
                    LabDetailName = item.CTHLabDetailItem.LabDetailsName,
                    TextResult = "",
                    AttachmentResultToDownload = "",
                    Date = DateTime.Now
                };
                if (ChemoID != 0)
                {
                    lab.Date = ((DateTime)chemo.Date).Date;
                }
                if (Labs.Where(c => c.ID == lab.ID).Count() == 0)
                {
                    Labs.Add(lab);
                }
            }


            return Labs;
        }

        [HttpGet]
        public ActionResult GetCalculations(double height, double weight, double SerumCreatinine, int PatientID)
        {
            CTHPatientEntity patientEntity = new CTHPatientEntity(PatientID);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(patientEntity, null);
            double TBW = weight;
            double HeightInMeter = height / 100;
            //if female
            double Factor = 45.4;
            double A = 1.07;
            double B = 0.0148;

            //for male
            if (patientEntity.PatientGender.Equals("Male"))
            {
                Factor = 49.9;
                A = 1.1;
                B = 0.0128;
            }
            double IBW = Factor + (0.89 * (height - 152.4));
            double AdjustBodyWeight = IBW + (0.4 * (TBW - IBW));
            //double BSA = (Math.Pow(TBW, 0.435)) * (Math.Pow(height, 0.725)) * 0.007184;
            double BSA = Math.Sqrt((height * weight) / 3600);
            double BMI = TBW / (Math.Pow(HeightInMeter, 2.00));
            double LBW = (A * TBW) - (B * BMI * TBW);
            double CRCL = ((140 - (int)patientEntity.PatientAge) * LBW) / (SerumCreatinine * 72);
            if (patientEntity.PatientGender.Equals("Female"))
            {
                CRCL *= 0.85;
            }
            List<double> details = new List<double>();
            details.Add(((float)BMI));
            details.Add((float)BSA);
            details.Add((float)AdjustBodyWeight);
            details.Add((float)LBW);
            details.Add(CRCL);
            return Json(details);
        }

        public ActionResult GetProtocolCycle(int ProtocolID)
        {
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHProtocolCycleFields.ProtocolID == ProtocolID);
            var CycleList = DataHelper.GetSelectList<CTHProtocolCycleEntity>(CTHProtocolCycleFields.ID, CTHProtocolCycleFields.Number, filter);
            return Json(CycleList);
        }

        public ActionResult GetChemoDay(int CycleID, int ChemoID)
        {
            var day = 1;
            if (ChemoID > 0)
            {
                EntityCollection<CTHKimoSurveyEntity> collection = new EntityCollection<CTHKimoSurveyEntity>();
                RelationPredicateBucket filter = new RelationPredicateBucket(CTHKimoSurveyFields.CycleID == CycleID);
                SStorm.CTH.BL.DataBaseClassHelper.FillCollection(collection, filter, 0, null, null, 0, 0);

            }
            return Json(day);
        }

        [HttpGet]
        public IActionResult AddNewTreatmentPlan()
        {
            CTHTreatmentTypeEntity treatementType = new CTHTreatmentTypeEntity();
            return PartialView(treatementType);
        }

        [HttpPost]
        public IActionResult AddNewTreatmentPlan(CTHTreatmentTypeEntity treatement)
        {
            treatement.WhatTreatment = 2;
            SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(treatement, true, false, 0);
            RelationPredicateBucket f = new RelationPredicateBucket(CTHTreatmentTypeFields.WhatTreatment == 2);
            var TreatementList = DataHelper.GetSelectList<CTHTreatmentTypeEntity>(CTHTreatmentTypeFields.ID, CTHTreatmentTypeFields.TreatmentType, f);
            return Json(TreatementList);
        }
        [HttpGet]
        public IActionResult AddNewProtocol(int CancerID)
        {
            ChemotherapyProtocolModel ProtocolModel = new ChemotherapyProtocolModel();
            ProtocolModel.ChemotherapyProtocolEntity = new CTHChemotherapyProtocolEntity();
            ProtocolModel.PreMedicationList = null;
            ProtocolModel.EmatogenicRiskList = DataHelper.GetDirectionSelectList<EmatogenicRisk>();
            ProtocolModel.CancerTypeList = DataHelper.GetSelectList<CTHCancerTypeEntity>(CTHCancerTypeFields.ID, CTHCancerTypeFields.TypeName);
            ViewBag.CancerID = CancerID;
            return PartialView(ProtocolModel);
        }
        [HttpPost]
        public IActionResult AddNewProtocol(ChemotherapyProtocolModel ProtocolModel, int CancerID)
        {
            SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(ProtocolModel.ChemotherapyProtocolEntity, true, false, 0);
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHChemotherapyProtocolFields.CancerTypeID == CancerID);
            var ChemotherapyProtocol = DataHelper.GetSelectList<CTHChemotherapyProtocolEntity>(CTHChemotherapyProtocolFields.ID, CTHChemotherapyProtocolFields.ProtocolName, filter);
            return Json(ChemotherapyProtocol);
        }
        [HttpGet]
        public IActionResult AddNewSpecialCase()
        {
            CTHSpecialCaseEntity SpecialCaseName = new CTHSpecialCaseEntity();
            return PartialView(SpecialCaseName);
        }

        [HttpPost]
        public IActionResult AddNewSpecialCase(CTHSpecialCaseEntity SpecialCase)
        {
            if (SpecialCase.HasParts == null)
                SpecialCase.HasParts = false;
            BL.DataBaseClassHelper.SaveEntity(SpecialCase, true, false, 0);
            var SpecialCaselist = DataHelper.GetSelectList<CTHSpecialCaseEntity>(CTHSpecialCaseFields.ID, CTHSpecialCaseFields.CaseName);
            return Json(SpecialCaselist);
        }

        [HttpGet]
        public IActionResult AddNewSpecialCasePart(int ID)
        {
            CTHSpecialCasePartEntity CTHSpecialCasePartEntity = new CTHSpecialCasePartEntity();
            CTHSpecialCasePartEntity.CaseID = ID;
            return PartialView(CTHSpecialCasePartEntity);
        }

        [HttpPost]
        public IActionResult AddNewSpecialCasePart(CTHSpecialCasePartEntity SpecialCasePartEntity)
        {
            BL.DataBaseClassHelper.SaveEntity(SpecialCasePartEntity, true, false, 0);
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHSpecialCasePartFields.CaseID == SpecialCasePartEntity.CaseID);
            var SpecialCasePartlist = DataHelper.GetSelectList<CTHSpecialCasePartEntity>(CTHSpecialCasePartFields.ID, CTHSpecialCasePartFields.PartName, filter);
            return Json(SpecialCasePartlist);
        }


        [HttpGet]
        public IActionResult AddNewCycle(int CancerID)
        {
            ProtocolCycleModel model = new ProtocolCycleModel();
            model.protocolCycleEntity = new CTHProtocolCycleEntity();
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHChemotherapyProtocolFields.CancerTypeID == CancerID);
            model.ProtocolList = DataHelper.GetSelectList<CTHChemotherapyProtocolEntity>(CTHChemotherapyProtocolFields.ID, CTHChemotherapyProtocolFields.ProtocolName,filter);
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult AddNewCycle(ProtocolCycleModel model)
        {
            BL.DataBaseClassHelper.SaveEntity(model.protocolCycleEntity, true, false, 0);
            var protocolCyclelist = DataHelper.GetSelectList<CTHProtocolCycleEntity>(CTHProtocolCycleFields.ID, CTHProtocolCycleFields.Number);
            return Json(protocolCyclelist);
        }
        #endregion

        #region Surgery

        [SmartAuthorize(UserPermission.SurgeryType_EditCreate)]
        [HttpGet]
        public IActionResult EditCreateSurgeryType(int ID)
        {
            CTHSurgeryTypeEntity surgeryType = new CTHSurgeryTypeEntity();
            if (ID > 0)
            {
                surgeryType = new CTHSurgeryTypeEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(surgeryType, null);
            }

            return PartialView(surgeryType);
        }

        [SmartAuthorize(UserPermission.SurgeryType_EditCreate)]
        [HttpPost]
        public IActionResult EditCreateSurgeryType(CTHSurgeryTypeEntity surgery)
        {
            if (surgery.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(surgery, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHSurgeryTypeFields.ID == surgery.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(surgery, filter, 0);
            }
            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            var SurgeryTypeList = DataHelper.GetSelectList<CTHSurgeryTypeEntity>(CTHSurgeryTypeFields.ID, CTHSurgeryTypeFields.SurgeryType);
            return Json(SurgeryTypeList);
        }

        #endregion

        #region CancerType

        [SmartAuthorize(UserPermission.CancerType_EditCreate)]
        [HttpGet]
        public IActionResult AddNewCancerType()
        {
            PatientClinicalDataModel model = new PatientClinicalDataModel();
            model.CancerTypeEntity = new CTHCancerTypeEntity();
            RelationPredicateBucket Filter = new RelationPredicateBucket();
            Filter.PredicateExpression.Add(CTHCancerTypeFields.IsParent == true);
            model.CancerList = DataHelper.GetSelectList<CTHCancerTypeEntity>(CTHCancerTypeFields.ID, CTHCancerTypeFields.TypeName, Filter);
            return PartialView(model);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreate)]
        [HttpPost]
        public IActionResult AddNewCancerType(PatientClinicalDataModel model)
        {
            SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.CancerTypeEntity, true, false, 0);
            RelationPredicateBucket Filter = new RelationPredicateBucket();
            var CancerTypes = DataHelper.GetSelectList<CTHCancerTypeEntity>(CTHCancerTypeFields.ID, CTHCancerTypeFields.TypeName);
            return Json(CancerTypes);
        }
        #endregion

        #region Histological

        [SmartAuthorize(UserPermission.CancerType_EditCreateHistologicalSubtype)]
        [HttpGet]
        public IActionResult AddNewHistological(int CancerID)
        {
            PatientClinicalDataModel model = new PatientClinicalDataModel();
            model.CancerHistologicEntity = new CTHCancerHistologicEntity();
            model.CancerList = DataHelper.GetSelectList<CTHCancerTypeEntity>(CTHCancerTypeFields.ID, CTHCancerTypeFields.TypeName);
            RelationPredicateBucket Filter = new RelationPredicateBucket();
            model.HistologicalList = null;
            ViewBag.CancerID = CancerID;
            return PartialView(model);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateHistologicalSubtype)]
        [HttpPost]
        public IActionResult AddNewHistological(PatientClinicalDataModel model, int CancerID)
        {
            SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.CancerHistologicEntity, true, false, 0);
            SelectList hostilogical = null;
            if (CancerID > 0)
            {
                RelationPredicateBucket Filter = new RelationPredicateBucket(CTHCancerHistologicFields.CanerID == CancerID);
                hostilogical = DataHelper.GetSelectList<CTHCancerHistologicEntity>(CTHCancerHistologicFields.ID, CTHCancerHistologicFields.Name, Filter);
            }
            return Json(hostilogical);
        }
        public JsonResult GetHistologicalList(int ID)
        {
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHCancerHistologicFields.CanerID == ID);
            int? pid = null;
            filter.PredicateExpression.Add(CTHCancerHistologicFields.ParentID == pid);
            var HistologicalList = DataHelper.GetSelectList<CTHCancerHistologicEntity>(CTHCancerHistologicFields.ID, CTHCancerHistologicFields.Name, filter);
            return Json(HistologicalList);
        }
        #endregion

        #region Molecular

        [SmartAuthorize(UserPermission.CancerType_EditCreateMolecularSubtype)]
        [HttpGet]
        public IActionResult AddNewMolecular(int CancerID)
        {
            PatientClinicalDataModel model = new PatientClinicalDataModel();
            model.CancerMolecularEntity = new CTHCancerMolecularEntity();
            model.CancerList = DataHelper.GetSelectList<CTHCancerTypeEntity>(CTHCancerTypeFields.ID, CTHCancerTypeFields.TypeName);
            RelationPredicateBucket Filter = new RelationPredicateBucket();
            model.MelocularList = null;
            ViewBag.CancerID = CancerID;
            return PartialView(model);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateMolecularSubtype)]
        [HttpPost]
        public IActionResult AddNewMolecular(PatientClinicalDataModel model, int CancerID)
        {
            SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.CancerMolecularEntity, true, false, 0);
            SelectList Molecular = null;
            if(CancerID > 0)
            {
                RelationPredicateBucket Filter = new RelationPredicateBucket(CTHCancerMolecularFields.CanerID == CancerID);
                Molecular = DataHelper.GetSelectList<CTHCancerMolecularEntity>(CTHCancerMolecularFields.ID, CTHCancerMolecularFields.Name, Filter);
            }
           
            return Json(Molecular);
        }
        public JsonResult GetMolecularList(int ID)
        {
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHCancerMolecularFields.CanerID == ID);
            int? pid = null;
            filter.PredicateExpression.Add(CTHCancerMolecularFields.ParentID == pid);
            var molcularList = DataHelper.GetSelectList<CTHCancerMolecularEntity>(CTHCancerMolecularFields.ID, CTHCancerMolecularFields.Name, filter);
            return Json(molcularList);
        }
        #endregion

        public ActionResult DownloadFile(string path)
        {
            var file = _fileService.ReadFile(path);
            if (file == null || file.Length < 1)
                return Content("");

            return File(file, System.Net.Mime.MediaTypeNames.Application.Octet, Path.ChangeExtension(path, Path.GetExtension(path)));
        }

        public IActionResult AttachmentCollection(int DrugID)
        {
            CTHDrugEntity CTHDrugEntity = new CTHDrugEntity(DrugID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugEntity);
            path.Add(CTHDrugEntity.PrefetchPathCTHDrugAttachmentCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CTHDrugEntity, path);
            return PartialView(CTHDrugEntity);
        }

        public JsonResult GethistologicalListComp(int ID)
        {
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHCancerHistologicFields.CanerID == ID);
            var HistList = DataHelper.GetSelectList<CTHCancerHistologicEntity>(CTHCancerHistologicFields.ID, CTHCancerHistologicFields.Name, filter);
            return Json(HistList);
        }
        public JsonResult GetmolecularListComp(int ID)
        {
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHCancerMolecularFields.CanerID == ID);
            var HistList = DataHelper.GetSelectList<CTHCancerMolecularEntity>(CTHCancerMolecularFields.ID, CTHCancerMolecularFields.Name, filter);
            return Json(HistList);
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

        [HttpGet]
        public IActionResult HistologicalTree(int ID)
        {
            TreeViewNode node = new TreeViewNode();
            node.CancerType = new CTHCancerTypeEntity(ID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCancerTypeEntity);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHCancerHistologicCollection, true);
            CTH.BL.DataBaseClassHelper.FillEntity(node.CancerType, path);
            node.HistologicCollection = node.CancerType.CTHCancerHistologicCollection;
            node.Seed = null;
            return PartialView(node);
        }
        [HttpGet]
        public IActionResult MolecularTree(int ID)
        {
            TreeViewNode node = new TreeViewNode();
            node.CancerType = new CTHCancerTypeEntity(ID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCancerTypeEntity);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHCancerMolecularCollection, true);
            CTH.BL.DataBaseClassHelper.FillEntity(node.CancerType, path);
            node.MolecularCollection = node.CancerType.CTHCancerMolecularCollection;
            node.Seed = null;
            return PartialView(node);
        }
    }

}