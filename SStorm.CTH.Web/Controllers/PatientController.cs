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
using System.IO;
using X.PagedList;

namespace SStorm.CTH.Web.Controllers
{
    public class PatientController : SmartController
    {
        private readonly IFileService _fileService;
        private readonly IUserService _userService;
        public PatientController(IClientNotification _clientNotification, IFileService _fileService, IUserService _userService)
         : base(_clientNotification)
        {
            this._fileService = _fileService;
            this._userService = _userService;

        }

        #region Patient
        [SmartAuthorize(UserPermission.Patient_View)]
        public IActionResult Index(SearchFacade<CTHPatientEntity> model)
        {
            EntityCollection<CTHPatientEntity> patientCollection = new EntityCollection<CTHPatientEntity>();
            EntityCollection<CTHDoctorEntity> doctorCollection = new EntityCollection<CTHDoctorEntity>();
            RelationPredicateBucket filter2 = new RelationPredicateBucket(CTHDoctorFields.UserID == _userService.GetCurrentUserID());
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(doctorCollection, filter2);

            RelationPredicateBucket filter = new RelationPredicateBucket();
            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHPatientFields.PatientNameE % $"%{model.SearchString}%");
            if (doctorCollection.Count != 0)
            {
                var doctorEntity = new CTHDoctorEntity();
                doctorEntity = doctorCollection.First();
                filter.PredicateExpression.Add(CTHPatientFields.DoctorID == doctorEntity.ID);

            }
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(patientCollection, filter, model.PageSize, null, null, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHPatientFields.ID, filter);

            model.DataPagedList = new StaticPagedList<CTHPatientEntity>(patientCollection, model.Page, model.PageSize, Count);
            return View(model);
        }


        [SmartAuthorize(UserPermission.Patient_EditCreate)]
        [HttpGet]
        public IActionResult EditCreate(int ID)
        {
            PatientModel patient = new PatientModel();
            patient.DoctorList = DataHelper.GetSelectList<CTHDoctorEntity>(CTHDoctorFields.ID, CTHDoctorFields.Name);

            patient.PaymentTypeList = DataHelper.GetSelectList<CTHPaymentTypeEntity>(CTHPaymentTypeFields.ID, CTHPaymentTypeFields.PaymentType);
            patient.PatientEntity = new CTHPatientEntity();
            patient.ClinicalDataID = 0;
            if (ID > 0)
            {
                patient.PatientEntity = new CTHPatientEntity(ID);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientEntity);
                path.Add(CTHPatientEntity.PrefetchPathCTHPaymentTypeItem, true);
                path.Add(CTHPatientEntity.PrefetchPathCTHUserItem, true);
                var patientAssessmentPath = path.Add(CTHPatientEntity.PrefetchPathCTHPatientAssessmentCollection, true);
                patientAssessmentPath.SubPath.Add(CTHPatientAssessmentEntity.PrefetchPathCTHTreatmentTypeItem,true);
                patientAssessmentPath.SubPath.Add(CTHPatientAssessmentEntity.PrefetchPathCTHTreatmentTypeItem1, true);
                /*
                 * in partial view refer to patient model -> patient surgery collection
                 * so this path is made.
                 */
                var pcd = path.Add(CTHPatientEntity.PrefetchPathCTHPatientClinicalDataCollection, true);
                pcd.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerSideItem, true);
                pcd.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHTumorGradeItem, true);
                pcd.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHStagingItem, true);
                var chemoPath = pcd.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHKimoSurveyCollection, true);
                var protocolPath = chemoPath.SubPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
                protocolPath.SubPath.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHDrugCollection, true)
                    .SubPath.Add(CTHDrugEntity.PrefetchPathCTHDoseUnitItem, true);


                chemoPath.SubPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHProtocolCycleItem, true);
                protocolPath.SubPath.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHProtocolCycleCollection, true);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(patient.PatientEntity, path);
                if (patient.PatientEntity.CTHPatientClinicalDataCollection.Count != 0)
                {
                    patient.ClinicalDataID = patient.PatientEntity.CTHPatientClinicalDataCollection.ToList()[0].ID;
                    if (patient.PatientEntity.CTHPatientClinicalDataCollection.First().CTHKimoSurveyCollection.Count > 0)
                    {
                        var lastChemo = patient.PatientEntity.CTHPatientClinicalDataCollection.First().CTHKimoSurveyCollection.Last();
                        if (((DateTime)lastChemo.Date).Date < DateTime.Now.Date)
                        {
                            CreateDynamicChemoSessions(patient.PatientEntity.CTHPatientClinicalDataCollection.First());
                            patient.PatientEntity = new CTHPatientEntity(ID);
                            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(patient.PatientEntity, path);
                        }
                    }
                }

            }

            return View(patient);
        }

        [SmartAuthorize(UserPermission.Patient_EditCreate)]
        [HttpPost]
        public async Task<IActionResult> EditCreate(PatientModel patient)
        {
            string toReturn = await this._fileService.SaveFile(patient.PatientEntity.ID, patient.NationalIDPhoto);
            patient.PatientEntity.NationalIDPhotoPath = toReturn;
            EntityCollection<CTHUserEntity> users = new EntityCollection<CTHUserEntity>();
            RelationPredicateBucket usersfilter = new RelationPredicateBucket();
            usersfilter.PredicateExpression.Add(CTHUserFields.UserName == patient.PatientEntity.CTHUserItem.UserName | CTHUserFields.Email == patient.PatientEntity.CTHUserItem.Email);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(users, usersfilter, 0, null, null, 0, 0);
            patient.PatientEntity.CTHUserItem.Password = Helper.TextEncryption.Encrypt(patient.PatientEntity.CTHUserItem.Password);
            if (patient.PatientEntity.ID == 0)
            {
                if (users.Count == 0)
                {
                    SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(patient.PatientEntity.CTHUserItem, true, false, 0);
                    patient.PatientEntity.UserID = patient.PatientEntity.CTHUserItem.ID;
                    SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(patient.PatientEntity, true, false, 0);
                }
                else
                {
                    AddSweetNotification("Error", "This username or email is already existing", Helper.NotificationHelper.NotificationType.error);
                    patient.DoctorList = DataHelper.GetSelectList<CTHDoctorEntity>(CTHDoctorFields.ID, CTHDoctorFields.Name);
                    patient.PaymentTypeList = DataHelper.GetSelectList<CTHPaymentTypeEntity>(CTHPaymentTypeFields.ID, CTHPaymentTypeFields.PaymentType);
                    return View(patient);
                }
            }
            else
            {
                var oldUser = new CTHUserEntity((int)patient.PatientEntity.UserID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(oldUser, null);
                users.Remove(oldUser);
                if (users.Count == 0)
                {
                    RelationPredicateBucket userFilter = new RelationPredicateBucket();
                    userFilter.PredicateExpression.Add(CTHUserFields.ID == (int)patient.PatientEntity.UserID);
                    SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(patient.PatientEntity.CTHUserItem, userFilter, 0);
                    RelationPredicateBucket filter = new RelationPredicateBucket();
                    filter.PredicateExpression.Add(CTHPatientFields.ID == patient.PatientEntity.ID);
                    SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(patient.PatientEntity, filter, 0);
                }
                else
                {
                    AddSweetNotification("Error", "This username or email is already existing", Helper.NotificationHelper.NotificationType.error);
                    patient.DoctorList = DataHelper.GetSelectList<CTHDoctorEntity>(CTHDoctorFields.ID, CTHDoctorFields.Name);
                    patient.PaymentTypeList = DataHelper.GetSelectList<CTHPaymentTypeEntity>(CTHPaymentTypeFields.ID, CTHPaymentTypeFields.PaymentType);
                    return View(patient);
                }
            }
            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("EditCreate", new { ID = patient.PatientEntity.ID });
        }


        [SmartAuthorize(UserPermission.Patient_Delete)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.Patient_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult  ConfirmDelete(int ItemID)
        {
            CTHPatientEntity patient = new CTHPatientEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientEntity);
            path.Add(CTHPatientEntity.PrefetchPathCTHPatientClinicalDataCollection, true);
            path.Add(CTHPatientEntity.PrefetchPathCTHNotificationCollection, true);
            path.Add(CTHPatientEntity.PrefetchPathCTHPatientSymptomCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(patient, path);

            if (patient.CTHPatientClinicalDataCollection.Count == 0 && patient.CTHPatientSymptomCollection.Count == 0)
            {
                foreach (var item in patient.CTHNotificationCollection)
                {
                    CTHNotificationEntity noti = new CTHNotificationEntity(item.ID);
                    SStorm.CTH.BL.DataBaseClassHelper.FillEntity(noti, null);
                    SStorm.CTH.BL.DataBaseClassHelper.Delete(noti, 0);
                }
                SStorm.CTH.BL.DataBaseClassHelper.Delete(patient, 0);
                AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "Can not remove this patient!!!", Helper.NotificationHelper.NotificationType.error);
            }

            return RedirectToAction("Index");
        }

        public ActionResult DownloadFile(int ID)
        {
            CTHPatientEntity fileEntity = new CTHPatientEntity(ID);
            CTH.BL.DataBaseClassHelper.FillEntity(fileEntity, null);

            if (fileEntity.IsNew)
            {
                AddSweetNotification("Error", "Failed to download attachment.", Helper.NotificationHelper.NotificationType.error);
                return Content("");
            }

            var file = _fileService.ReadFile(fileEntity.NationalIDPhotoPath);
            if (file == null || file.Length < 1)
                return Content("");

            return File(file, System.Net.Mime.MediaTypeNames.Application.Octet, Path.ChangeExtension(fileEntity.NationalIDPhotoPath, Path.GetExtension(fileEntity.NationalIDPhotoPath)));
        }

        #endregion

        #region Doctor

        [SmartAuthorize(UserPermission.Doctor_EditCreate)]
        [HttpGet]
        public IActionResult EditCreateDoctor()
        {
            DoctorModel model = new DoctorModel();
            return PartialView(model);
        }

        [SmartAuthorize(UserPermission.Doctor_EditCreate)]
        [HttpPost]
        public IActionResult EditCreateDoctor(DoctorModel model)
        {
            EntityCollection<CTHUserEntity> userCollection = new EntityCollection<CTHUserEntity>();
            RelationPredicateBucket userfilter = new RelationPredicateBucket(CTHUserFields.UserName == model.DoctorEntity.CTHUserItem.UserName | CTHUserFields.Email == model.DoctorEntity.CTHUserItem.Email);
            BL.DataBaseClassHelper.FillCollection(userCollection, userfilter, 0, null, null, 0, 0);
            var result = false;
            if (userCollection.Count == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.DoctorEntity.CTHUserItem, true, true, 0);
                model.DoctorEntity.UserID = model.DoctorEntity.CTHUserItem.ID;
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.DoctorEntity, true, true, 0);
                result = true;
            }
            if (result == true)
            {
                var Doctors = DataHelper.GetSelectList<CTHDoctorEntity>(CTHDoctorFields.ID, CTHDoctorFields.Name);
                return Json(Doctors);
            }
            else
            {
                return Json(0);
            }
        }
        #endregion

        #region Doctor Recommendation For Patient Symptoms
        public ActionResult GetAllSymptomsForPatient(int NotifID, int PatientSymptomID)
        {
            CTHPatientSymptomEntity patient = new CTHPatientSymptomEntity(PatientSymptomID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientSymptomEntity);
            path.Add(CTHPatientSymptomEntity.PrefetchPathCTHPatientItem, true);
            path.Add(CTHPatientSymptomEntity.PrefetchPathCTHSymptomItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(patient, path);
            ViewBag.NotifID = NotifID;
            return View(patient);
        }

        //[SmartAuthorize(UserPermission.Notificaion_EditCreatePatientSymptoms)]
        [HttpPost]
        public ActionResult EditCreatePatientSymptoms(CTHPatientSymptomEntity CTHPatientSymptomEntity, int NotifID)
        {
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHPatientSymptomFields.ID == CTHPatientSymptomEntity.ID);
            BL.DataBaseClassHelper.UpdateEntityDirectly(CTHPatientSymptomEntity, filter, 0);
            BL.DataBaseClassHelper.FillEntity(CTHPatientSymptomEntity, null);
            CTHNotificationEntity NotificationEntity = new CTHNotificationEntity(NotifID)
            {
                Seen = true
            };
            RelationPredicateBucket filterNotify = new RelationPredicateBucket(CTHNotificationFields.ID == NotifID);
            BL.DataBaseClassHelper.UpdateEntityDirectly(NotificationEntity, filterNotify, 0);
            return RedirectToAction("GetAllSymptomsForPatient", new { NotifID = NotifID, PatientSymptomID = CTHPatientSymptomEntity.ID });
        }
        #endregion

        #region Patient Follow Up (Patient Symptoms)

        [SmartAuthorize(UserPermission.Patient_ViewSymptoms)]
        public ActionResult GetPatientSymptoms(int patientID)
        {
            CTHPatientEntity patient = new CTHPatientEntity(patientID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientEntity);
            path.Add(CTHPatientEntity.PrefetchPathCTHPatientSymptomCollection, true)
                .SubPath.Add(CTHPatientSymptomEntity.PrefetchPathCTHSymptomItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(patient, path);
            return View(patient);
        }

        [SmartAuthorize(UserPermission.Patient_CreatePatientSymptom)]
        [HttpGet]
        public ActionResult CreatePatientSymptom(int patientID)
        {
            PatientSymptomModel model = new PatientSymptomModel();
            model.PatientSymptom = new CTHPatientSymptomEntity();
            model.Symptom = new CTHSymptomEntity();
            model.PatientSymptom.PatientID = patientID;
            model.IsNewSymptom = false;
            model.SymptomList = DataHelper.GetSelectList<CTHSymptomEntity>(CTHSymptomFields.ID, CTHSymptomFields.Name);
            model.DurationUnitList = DataHelper.GetDirectionSelectList<DurationUnit>();
            return PartialView(model);
        }

        [SmartAuthorize(UserPermission.Patient_CreatePatientSymptom)]
        [HttpPost]
        public ActionResult CreatePatientSymptom(PatientSymptomModel model)
        {
            if (model.IsNewSymptom == false)
            {
                model.PatientSymptom.Date = DateTime.Now;
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.PatientSymptom, true, false, 0);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientSymptomEntity);
                path.Add(CTHPatientSymptomEntity.PrefetchPathCTHPatientItem, true);
                path.Add(CTHPatientSymptomEntity.PrefetchPathCTHSymptomItem, true);
                BL.DataBaseClassHelper.FillEntity(model.PatientSymptom, path);

                CTHNotificationEntity NotificationEntity = new CTHNotificationEntity()
                {
                    PatientID = (int)model.PatientSymptom.PatientID,
                    PatientSymptomID = model.PatientSymptom.ID,
                    DoctorID = model.PatientSymptom.CTHPatientItem.DoctorID,
                    TypeID = (int)NotificationEntityType.PatientSymptom,
                    Message =
                   "Patient Name:" + model.PatientSymptom.CTHPatientItem.PatientNameE + "/" +
                   "Has Symptom:" + model.PatientSymptom.CTHSymptomItem.Name + "/" +
                   "His Grade Is :" + model.PatientSymptom.CTHSymptomItem.Grade,
                    NotificationDate = DateTime.Now
                };
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(NotificationEntity, true, false, 0);
            }
            else
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.Symptom, true, false, 0);
                CTHPatientSymptomEntity PatientSymptom = new CTHPatientSymptomEntity()
                {
                    PatientID = (int)model.PatientSymptom.PatientID,
                    SymptomID = model.Symptom.ID,
                    SymptomDurationAmount = model.PatientSymptom.SymptomDurationAmount,
                    SymptomDurationUnit = model.PatientSymptom.SymptomDurationUnit,
                    Date = DateTime.Now
                };
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(PatientSymptom, true, false, 0);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientSymptomEntity);
                path.Add(CTHPatientSymptomEntity.PrefetchPathCTHPatientItem, true);
                path.Add(CTHPatientSymptomEntity.PrefetchPathCTHSymptomItem, true);
                BL.DataBaseClassHelper.FillEntity(PatientSymptom, path);
                CTHNotificationEntity NotificationEntity = new CTHNotificationEntity()
                {
                    PatientID = (int)PatientSymptom.PatientID,
                    PatientSymptomID = PatientSymptom.ID,
                    DoctorID = PatientSymptom.CTHPatientItem.DoctorID,
                    TypeID = (int)NotificationEntityType.PatientSymptom,
                    Message =
                   "Patient Name:" + PatientSymptom.CTHPatientItem.PatientNameE + "/" +
                   "Has Symptom:" + PatientSymptom.CTHSymptomItem.Name + "/" +
                   "His Grade Is :" + PatientSymptom.CTHSymptomItem.Grade,
                    NotificationDate = DateTime.Now
                };
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(NotificationEntity, true, false, 0);
            }

            CTHPatientEntity Patient = new CTHPatientEntity((int)model.PatientSymptom.PatientID);
            PrefetchPath2 patientPath = new PrefetchPath2(EntityType.CTHPatientEntity);
            patientPath.Add(CTHPatientEntity.PrefetchPathCTHPatientSymptomCollection, true)
                .SubPath.Add(CTHPatientSymptomEntity.PrefetchPathCTHSymptomItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(Patient, patientPath);
            return PartialView("_ChemoSymptomView", Patient);
        }

        public ActionResult GetSymptomData(int ID)
        {
            CTHSymptomEntity symptom = new CTHSymptomEntity(ID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHSymptomEntity);
            path.Add(CTHSymptomEntity.PrefetchPathCTHSymptomDrugCollection, true)
                .SubPath.Add(CTHSymptomDrugEntity.PrefetchPathCTHDrugItem, true)
                    .SubPath.Add(CTHDrugEntity.PrefetchPathCTHDoseUnitItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(symptom, path);
            return PartialView("_SymptomData", symptom);
        }

        #endregion

        #region Patient Schedule
        [SmartAuthorize(UserPermission.Patient_ViewPatientSchedule)]
        public IActionResult PatientSchedule(int PatientID, string Date = "")
        {
            PatientScheduleModel model = new PatientScheduleModel();
            model.patientEntity = new CTHPatientEntity(PatientID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientEntity);
            var patientpath = path.Add(CTHPatientEntity.PrefetchPathCTHPatientClinicalDataCollection, true);
            var kimopath = patientpath.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHKimoSurveyCollection, true);
            var chemolabpath = kimopath.SubPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHChemoLabCollection, true);
            var labdetailpath = chemolabpath.SubPath.Add(CTHChemoLabEntity.PrefetchPathCTHLabDetailItem, true);
            labdetailpath.SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabItem,true);
            var drugpath = kimopath.SubPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHPatientDrugCollection, true);
            var drugdaypath = drugpath.SubPath.Add(CTHPatientDrugEntity.PrefetchPathCTHDrugDayItem, true);
            drugdaypath.SubPath.Add(CTHDrugDayEntity.PrefetchPathCTHDrugItem, true)
                .SubPath.Add(CTHDrugEntity.PrefetchPathCTHDoseUnitItem,true);
            BL.DataBaseClassHelper.FillEntity(model.patientEntity, path);
            if (Date != "")
            {
                var x = DateTime.Parse(Date).Date;
                var y = new DateTime(x.Year, x.Month, x.Day);
                model.Date = y.Date;
            }
            else
            {
                model.Date = DateTime.Now.Date;
            }
            return PartialView(model);
        }
        #endregion

        #region Patient Assessment
        [HttpGet]
        public ActionResult EditCreateAssessment(int ID, int PatientID)
        {
            AssessmentModel model = new AssessmentModel();
            model.assessmentEntity = new CTHPatientAssessmentEntity();
            model.assessmentEntity.PatientID = PatientID;
            if (ID > 0)
            {
                model.assessmentEntity = new CTHPatientAssessmentEntity(ID);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientAssessmentEntity);
                path.Add(CTHPatientAssessmentEntity.PrefetchPathCTHTreatmentTypeItem, true);
                path.Add(CTHPatientAssessmentEntity.PrefetchPathCTHTreatmentTypeItem1, true);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(model.assessmentEntity, path);
            }
            RelationPredicateBucket planFilter = new RelationPredicateBucket(CTHTreatmentTypeFields.WhatTreatment == 2);
            model.TreatmentPlanList = DataHelper.GetSelectList<CTHTreatmentTypeEntity>(CTHTreatmentTypeFields.ID, CTHTreatmentTypeFields.TreatmentType, planFilter);
            RelationPredicateBucket responseFilter = new RelationPredicateBucket(CTHTreatmentTypeFields.WhatTreatment == 3);
            model.TreatmentResponseList = DataHelper.GetSelectList<CTHTreatmentTypeEntity>(CTHTreatmentTypeFields.ID, CTHTreatmentTypeFields.TreatmentType, responseFilter);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditCreateAssessment(AssessmentModel model)
        {
            if(model.assessmentEntity.ID > 0) 
            {
                RelationPredicateBucket filter = new RelationPredicateBucket(CTHPatientAssessmentFields.ID == model.assessmentEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(model.assessmentEntity, filter, 0);
            }
            else
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.assessmentEntity, true, false, 0);
            }
            var patientModel = GetPatientModel((int)model.assessmentEntity.PatientID);
            return PartialView("_PatientAssessment", patientModel);
        }

        [HttpGet]
        public ActionResult DeleteAssessment(int ID)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = ID,
                ActionName = "DeleteAssessment",
                ControllerName = "Patient",
                DataAjaxMethod = "post",
                DataAjax = true,
                DataAjaxSuccess = "LoadPatientAssessmentForDelete"
            });
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteAssessment")]
        public ActionResult ConfirmDeleteAssessment(int ItemID)
        {
            CTHPatientAssessmentEntity item = new CTHPatientAssessmentEntity(ItemID);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, null);
            int PatientID = (int)item.PatientID;
            SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
            return Json(PatientID);
        }

        public ActionResult GetAssessments(int ID)
        {
            var patientModel = GetPatientModel(ID);
            return PartialView("_PatientAssessment", patientModel);
        }

        #endregion

        #region Helper methods
        public IActionResult AttachmentCollection(int DrugID)
        {
            CTHDrugEntity CTHDrugEntity = new CTHDrugEntity(DrugID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugEntity);
            path.Add(CTHDrugEntity.PrefetchPathCTHDrugAttachmentCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CTHDrugEntity, path);
            return PartialView(CTHDrugEntity);
        }

        public void CreateDynamicChemoSessions(CTHPatientClinicalDataEntity ClinicalData)
        {
            var LastSession = ClinicalData.CTHKimoSurveyCollection.Last();
            var LastDate = (DateTime)LastSession.Date;
            var CurrentDate = DateTime.Now;
            int reminder = (int)(CurrentDate - LastDate).TotalDays;
            for (var i = 0; i < reminder; i++)
            {
                var Date = LastDate.AddDays(1);
                var CycleDays = LastSession.CTHChemotherapyProtocolItem.Days;
                int Day = 1;
                int CycleNum = (int)LastSession.CTHProtocolCycleItem.Number;
                int CycleID = (int)LastSession.CycleID;
                if (CycleDays > LastSession.Days)
                {
                    Day = (int)LastSession.Days + 1;
                }
                else
                {
                    var protocolCycles = LastSession.CTHChemotherapyProtocolItem.CTHProtocolCycleCollection.Where(c => c.Number > CycleNum);
                    if (protocolCycles.Count() == 0)
                    {
                        var minCycleNum = (int)LastSession.CTHChemotherapyProtocolItem.CTHProtocolCycleCollection.Min(c => c.Number);
                        protocolCycles = LastSession.CTHChemotherapyProtocolItem.CTHProtocolCycleCollection.Where(c => c.Number == minCycleNum);
                    }

                    if (protocolCycles.Count() > 0)
                    {
                        var firstItem = protocolCycles.First();
                        CycleNum = (int)firstItem.Number;
                        CycleID = firstItem.ID;
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

                //Save Notification
                var savedChemoSession = new CTHKimoSurveyEntity(ChemoSession.ID);
                PrefetchPath2 savedChemoPath = new PrefetchPath2(EntityType.CTHKimoSurveyEntity);
                savedChemoPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
                savedChemoPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHProtocolCycleItem, true);
                savedChemoPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHPatientClinicalDataItem, true);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(savedChemoSession, savedChemoPath);
                var ProtocolCycleItem = savedChemoSession.CTHProtocolCycleItem;
                int KimoDay = (int)savedChemoSession.Days;
                int Days = (int)savedChemoSession.CTHChemotherapyProtocolItem.Days;
                int SubDay = Days - KimoDay;
                DateTime NotificationDate = ((DateTime)savedChemoSession.Date).AddDays(SubDay);
                CTHNotificationEntity NotificationEntity = new CTHNotificationEntity()
                {
                    KimoID = savedChemoSession.ID,
                    PatientID = savedChemoSession.CTHPatientClinicalDataItem.PatientID,
                    TypeID = (int)NotificationEntityType.KimoSurvey,
                    Message =
                           "Kimo cycle Number is:" + savedChemoSession.CTHProtocolCycleItem.Number + "_" +
                           "Is finshed in Date :" + NotificationDate,
                    NotificationDate = NotificationDate
                };
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(NotificationEntity, true, false, 0);

                //after save
                EntityCollection<CTHKimoSurveyEntity> collection = new EntityCollection<CTHKimoSurveyEntity>();
                RelationPredicateBucket ChemoFilter = new RelationPredicateBucket(CTHKimoSurveyFields.PatientClinicalDataID == ClinicalData.ID);
                PrefetchPath2 ChemoPath = new PrefetchPath2(EntityType.CTHKimoSurveyEntity);
                ChemoPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHSpecialCaseItem, true);
                ChemoPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHChemotherapyProtocolItem, true)
                    .SubPath.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHProtocolCycleCollection,true);
                ChemoPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHProtocolCycleItem, true)
                    .SubPath.Add(CTHProtocolCycleEntity.PrefetchPathCTHChemotherapyProtocolItem, true)
                        .SubPath.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHProtocolCycleCollection, true);
                SStorm.CTH.BL.DataBaseClassHelper.FillCollection(collection, ChemoFilter, 0, null, ChemoPath, 0, 0);
                LastSession = collection.Last();
                Date = (DateTime)LastSession.Date;
                LastDate = Date;
            }
        }

        public PatientModel GetPatientModel(int ID)
        {
            PatientModel model = new PatientModel();
            model.PatientEntity = new CTHPatientEntity(ID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientEntity);
            path.Add(CTHPatientEntity.PrefetchPathCTHPaymentTypeItem, true);
            path.Add(CTHPatientEntity.PrefetchPathCTHUserItem, true);
            var patientAssessmentPath = path.Add(CTHPatientEntity.PrefetchPathCTHPatientAssessmentCollection, true);
            patientAssessmentPath.SubPath.Add(CTHPatientAssessmentEntity.PrefetchPathCTHTreatmentTypeItem, true);
            patientAssessmentPath.SubPath.Add(CTHPatientAssessmentEntity.PrefetchPathCTHTreatmentTypeItem1, true);
            /*
             * in partial view refer to patient model -> patient surgery collection
             * so this path is made.
             */
            var pcd = path.Add(CTHPatientEntity.PrefetchPathCTHPatientClinicalDataCollection, true);
            pcd.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerSideItem, true);
            pcd.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHTumorGradeItem, true);
            pcd.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHStagingItem, true);
            var chemoPath = pcd.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHKimoSurveyCollection, true);
            var protocolPath = chemoPath.SubPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHChemotherapyProtocolItem, true);
            protocolPath.SubPath.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHDrugCollection, true)
                .SubPath.Add(CTHDrugEntity.PrefetchPathCTHDoseUnitItem, true);


            chemoPath.SubPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHProtocolCycleItem, true);
            protocolPath.SubPath.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHProtocolCycleCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(model.PatientEntity, path);
            return model;
        }
        #endregion

    }
}