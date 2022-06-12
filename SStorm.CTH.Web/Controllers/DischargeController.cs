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
using System.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace SStorm.CTH.Web.Controllers
{
    public class DischargeController : SmartController
    {
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _env;
        public DischargeController(IClientNotification notifier, IFileService _fileService, IWebHostEnvironment _env) : base(notifier)
        {
            this._env = _env;
            this._fileService = _fileService;
        }

        #region 
        [SmartAuthorize(UserPermission.Patient_ChemoDischargeNote)]
        [HttpGet]
        public IActionResult DischargeNote(int ID)
        {
            var model = GetModel(ID);
            return View(model);
        }

        public KimoSurveyModel GetModel(int ID)
        {
            KimoSurveyModel model = new KimoSurveyModel();
            model.cTHLabDetailEntity = new CTHLabDetailEntity();
            model.cTHLabDetailEntity.CTHChemoLabCollection.AddNew();
            model.DrugEntity = new CTHDrugEntity();
            model.DrugEntity.CTHPatientDrugCollection.AddNew();

            model.KimoSurveyEntity = new CTHKimoSurveyEntity(ID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHKimoSurveyEntity);
            path.Add(CTHKimoSurveyEntity.PrefetchPathCTHChemoLabCollection, true)
                .SubPath.Add(CTHChemoLabEntity.PrefetchPathCTHLabDetailItem, true)
                .SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabItem, true);
            var pa = path.Add(CTHKimoSurveyEntity.PrefetchPathCTHPatientDrugCollection, true);
            var p = pa.SubPath.Add(CTHPatientDrugEntity.PrefetchPathCTHDrugItem, true);
            p.SubPath.Add(CTHDrugEntity.PrefetchPathCTHDrugDayCollection, true);
            p.SubPath.Add(CTHDrugEntity.PrefetchPathCTHDoseUnitItem, true);


            var paitentpath = path.Add(CTHKimoSurveyEntity.PrefetchPathCTHPatientClinicalDataItem, true);
            paitentpath.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHPatientItem, true);
            paitentpath.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerHistologicItem, true);
            paitentpath.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerMolecularItem, true);
            paitentpath.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerTypeItem, true);
            paitentpath.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerSideItem, true);
            paitentpath.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHStagingItem, true);
            paitentpath.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHTumorGradeItem, true);
            path.Add(CTHKimoSurveyEntity.PrefetchPathCTHChemotherapyProtocolItem, true);

            var ProtocolcyclePath = path.Add(CTHKimoSurveyEntity.PrefetchPathCTHProtocolCycleItem, true);
            ProtocolcyclePath.SubPath.Add(CTHProtocolCycleEntity.PrefetchPathCTHCycleLabCollection, true)
                .SubPath.Add(CTHCycleLabEntity.PrefetchPathCTHLabDetailItem, true);
            BL.DataBaseClassHelper.FillEntity(model.KimoSurveyEntity, path);

            var firstidPro = model.KimoSurveyEntity.CTHProtocolCycleItem.ID;

            EntityCollection<CTHProtocolCycleEntity> collProtocolCycle = new EntityCollection<CTHProtocolCycleEntity>();
            PrefetchPath2 path2 = new PrefetchPath2(EntityType.CTHProtocolCycleEntity);
            path2.Add(CTHProtocolCycleEntity.PrefetchPathCTHCycleLabCollection, true)
                .SubPath.Add(CTHCycleLabEntity.PrefetchPathCTHLabDetailItem, true)
                .SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabItem, true);
            path2.Add(CTHProtocolCycleEntity.PrefetchPathCTHCycleDrugCollection, true)
                .SubPath.Add(CTHCycleDrugEntity.PrefetchPathCTHDrugItem, true);

            RelationPredicateBucket filter = new RelationPredicateBucket(CTHProtocolCycleFields.ProtocolID == model.KimoSurveyEntity.ProtocolID);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(collProtocolCycle, filter, 0, null, path2, 0, 0);

            if (collProtocolCycle.Count != 0)
            {
                if (collProtocolCycle.Where(c => c.Number > model.KimoSurveyEntity.CycleNum).Count() != 0)
                {
                    var nextcyclenum = collProtocolCycle.Where(c => c.Number > model.KimoSurveyEntity.CycleNum).Min(c => c.Number);
                    var NextcollProtocolCycle = collProtocolCycle.Where(c => c.Number == nextcyclenum).First();
                    model.NextcycleNumber = (int)NextcollProtocolCycle.Number;
                    model.NextcycleID = (int)NextcollProtocolCycle.ID;

                    if (NextcollProtocolCycle.CTHCycleLabCollection.Count != 0)
                    {
                        var cyclelabcoll = NextcollProtocolCycle.CTHCycleLabCollection;
                        EntityCollection<CTHLabEntity> collLab = new EntityCollection<CTHLabEntity>();
                        EntityCollection<CTHLabDetailEntity> collLabDetails = new EntityCollection<CTHLabDetailEntity>();
                        List<SelectList> ListOfLab = new List<SelectList>();
                        foreach (var item in cyclelabcoll)
                        {
                            collLab.Add(item.CTHLabDetailItem.CTHLabItem);
                            collLabDetails.Add(item.CTHLabDetailItem);
                        }
                        List<CTHLabDetailEntity> uniquecollLabDetails = collLabDetails.Distinct().ToList();
                        foreach (var item in uniquecollLabDetails)
                        {
                            RelationPredicateBucket filterlabDetails = new RelationPredicateBucket(CTHLabDetailFields.ID == item.ID);
                            var labDetails = DataHelper.GetSelectList<CTHLabDetailEntity>(CTHLabDetailFields.ID, CTHLabDetailFields.LabDetailsName, filterlabDetails).ToList();
                            model.LabDetailsList = model.LabDetailsList.Concat(labDetails).ToList();
                        }
                        List<CTHLabEntity> uniquecollLab = collLab.Distinct().ToList();
                        foreach (var item in uniquecollLab)
                        {
                            RelationPredicateBucket filterlab = new RelationPredicateBucket(CTHLabFields.ID == item.ID);
                            var lab = DataHelper.GetSelectList<CTHLabEntity>(CTHLabFields.ID, CTHLabFields.LabName, filterlab).ToList();
                            model.LabList = model.LabList.Concat(lab).ToList();
                        }
                    }
                    else
                    {
                        model.LabList = null;
                        model.LabDetailsList = null;
                    }
                    if (NextcollProtocolCycle.CTHCycleDrugCollection.Count != 0)
                    {
                        var CycleDrugCollection = NextcollProtocolCycle.CTHCycleDrugCollection;
                        EntityCollection<CTHDrugEntity> CTHDrugColl = new EntityCollection<CTHDrugEntity>();
                        List<SelectList> ListOfDrud = new List<SelectList>();
                        foreach (var item in CycleDrugCollection)
                        {
                            CTHDrugColl.Add(item.CTHDrugItem);
                        }

                        List<CTHDrugEntity> uniquecCTHDrugColl = CTHDrugColl.Distinct().ToList();
                        foreach (var item in uniquecCTHDrugColl)
                        {
                            RelationPredicateBucket filterDrud = new RelationPredicateBucket(CTHDrugFields.ID == item.ID);
                            var drug = DataHelper.GetSelectList<CTHDrugEntity>(CTHDrugFields.ID, CTHDrugFields.Name, filterDrud);
                            model.DrugList = model.DrugList.Concat(drug).ToList();
                        }
                    }
                    else
                    {
                        model.DrugList = null;
                    }
                }
                else
                {
                    var nextcyclenum = collProtocolCycle.Min(c => c.Number);
                    var NextcollProtocolCycle = collProtocolCycle.Where(c => c.Number == nextcyclenum).First();
                    model.NextcycleNumber = (int)NextcollProtocolCycle.Number;
                    model.NextcycleID = (int)NextcollProtocolCycle.ID;

                    if (NextcollProtocolCycle.CTHCycleLabCollection.Count != 0)
                    {
                        var cyclelabcoll = NextcollProtocolCycle.CTHCycleLabCollection;
                        EntityCollection<CTHLabEntity> collLab = new EntityCollection<CTHLabEntity>();
                        EntityCollection<CTHLabDetailEntity> collLabDetails = new EntityCollection<CTHLabDetailEntity>();
                        List<SelectList> ListOfLab = new List<SelectList>();
                        foreach (var item in cyclelabcoll)
                        {
                            collLab.Add(item.CTHLabDetailItem.CTHLabItem);
                            collLabDetails.Add(item.CTHLabDetailItem);
                        }
                        List<CTHLabDetailEntity> uniquecollLabDetails = collLabDetails.Distinct().ToList();
                        foreach (var item in uniquecollLabDetails)
                        {
                            RelationPredicateBucket filterlabDetails = new RelationPredicateBucket(CTHLabDetailFields.ID == item.ID);
                            var labDetails = DataHelper.GetSelectList<CTHLabDetailEntity>(CTHLabDetailFields.ID, CTHLabDetailFields.LabDetailsName, filterlabDetails).ToList();
                            model.LabDetailsList = model.LabDetailsList.Concat(labDetails).ToList();
                        }
                        List<CTHLabEntity> uniquecollLab = collLab.Distinct().ToList();
                        foreach (var item in uniquecollLab)
                        {
                            RelationPredicateBucket filterlab = new RelationPredicateBucket(CTHLabFields.ID == item.ID);
                            var lab = DataHelper.GetSelectList<CTHLabEntity>(CTHLabFields.ID, CTHLabFields.LabName, filterlab).ToList();
                            model.LabList = model.LabList.Concat(lab).ToList();
                        }
                    }
                    else
                    {
                        model.LabList = null;
                        model.LabDetailsList = null;
                    }
                    if (NextcollProtocolCycle.CTHCycleDrugCollection.Count != 0)
                    {
                        var CycleDrugCollection = NextcollProtocolCycle.CTHCycleDrugCollection;
                        EntityCollection<CTHDrugEntity> CTHDrugColl = new EntityCollection<CTHDrugEntity>();
                        List<SelectList> ListOfDrud = new List<SelectList>();
                        foreach (var item in CycleDrugCollection)
                        {
                            CTHDrugColl.Add(item.CTHDrugItem);
                        }

                        List<CTHDrugEntity> uniquecCTHDrugColl = CTHDrugColl.Distinct().ToList();
                        foreach (var item in uniquecCTHDrugColl)
                        {
                            RelationPredicateBucket filterDrud = new RelationPredicateBucket(CTHDrugFields.ID == item.ID);
                            var drug = DataHelper.GetSelectList<CTHDrugEntity>(CTHDrugFields.ID, CTHDrugFields.Name, filterDrud);
                            model.DrugList = model.DrugList.Concat(drug).ToList();
                        }
                    }
                    else
                    {
                        model.DrugList = null;
                    }
                }
            }
            else
            {
                model.LabList = null;
                model.DrugList = null;
                model.LabDetailsList = null;
            }
            return model;
        }

        [SmartAuthorize(UserPermission.Patient_ChemoDischargeNote)]
        [HttpPost]
        public IActionResult DischargeNote(KimoSurveyModel model)
        {
            CTHKimoSurveyEntity CTHKimoSurveyEntity = new CTHKimoSurveyEntity(model.KimoSurveyEntity.ID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHKimoSurveyEntity);
            path.Add(CTHKimoSurveyEntity.PrefetchPathCTHChemoLabCollection, true);
            path.Add(CTHKimoSurveyEntity.PrefetchPathCTHPatientDrugCollection, true);
            BL.DataBaseClassHelper.FillEntity(CTHKimoSurveyEntity, path);
            int countlab = model.KimoSurveyEntity.CTHChemoLabCollection.Count;
            int countdrug = model.KimoSurveyEntity.CTHPatientDrugCollection.Count;

            if (countlab > 0)
            {
                foreach (var item in model.KimoSurveyEntity.CTHChemoLabCollection)
                {
                    if (item.ID == 0)
                    {
                        CTHChemoLabEntity cTHChemoLabEntity = new CTHChemoLabEntity
                        {
                            ChemoID = item.ChemoID,
                            LabDetailsID = item.LabDetailsID,
                            Date = item.Date,
                        };
                        // CTHChemoLabCollection.Add(cTHChemoLabEntity);
                        SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(cTHChemoLabEntity, true, false, 0);
                        PrefetchPath2 pathChemo = new PrefetchPath2(EntityType.CTHChemoLabEntity);
                        pathChemo.Add(CTHChemoLabEntity.PrefetchPathCTHLabDetailItem, true)
                            .SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabItem, true);
                        pathChemo.Add(CTHChemoLabEntity.PrefetchPathCTHKimoSurveyItem, true)
                            .SubPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHPatientClinicalDataItem, true);
                        BL.DataBaseClassHelper.FillEntity(cTHChemoLabEntity, pathChemo);

                        CTHNotificationEntity NotificationEntity = new CTHNotificationEntity()
                        {
                            PatientID = cTHChemoLabEntity.CTHKimoSurveyItem.CTHPatientClinicalDataItem.PatientID,
                            TypeID = (int)NotificationEntityType.ChemoLab,
                            Message =
                            "Lab Name:" + cTHChemoLabEntity.CTHLabDetailItem.CTHLabItem.LabName + "_" +
                            "Date Is :" + cTHChemoLabEntity.Date,
                            NotificationDate = (DateTime)cTHChemoLabEntity.Date
                        };
                        SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(NotificationEntity, true, false, 0);
                    }
                }
            }

            if (countdrug > 0)
            {
                foreach (var item in model.KimoSurveyEntity.CTHPatientDrugCollection)
                {
                    if (item.ID == 0)
                    {
                        CTHPatientDrugEntity PatientDrugEntity = new CTHPatientDrugEntity
                        {
                            KimoID = item.KimoID,
                            DoseModification = item.DoseModification,
                            IsNew = item.IsNew,
                            DrugID = item.DrugID,
                            Date = item.Date,
                        };
                        SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(PatientDrugEntity, true, false, 0);
                        PrefetchPath2 pathDr = new PrefetchPath2(EntityType.CTHPatientDrugEntity);
                        pathDr.Add(CTHPatientDrugEntity.PrefetchPathCTHDrugItem, true);
                        pathDr.Add(CTHPatientDrugEntity.PrefetchPathCTHKimoSurveyItem, true)
                            .SubPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHPatientClinicalDataItem, true);
                        BL.DataBaseClassHelper.FillEntity(PatientDrugEntity, pathDr);
                        CTHNotificationEntity NotificationEntity = new CTHNotificationEntity()
                        {
                            PatientID = PatientDrugEntity.CTHKimoSurveyItem.CTHPatientClinicalDataItem.PatientID,
                            TypeID = (int)NotificationEntityType.PatientDrug,
                            Message =
                            "Drug Name :" + PatientDrugEntity.CTHDrugItem.Name + "_" +
                            "Date Is :" + PatientDrugEntity.Date,
                            NotificationDate = (DateTime)PatientDrugEntity.Date
                        };
                        SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(NotificationEntity, true, false, 0);
                    }
                }

            }

            return RedirectToAction("DischargeNote", new { ID = CTHKimoSurveyEntity.ID });
        }

        public JsonResult GetLabDetails(int ID)
        {
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHLabDetailFields.LabID == ID);
            var LabdetList = DataHelper.GetSelectList<CTHLabDetailEntity>(CTHLabDetailFields.ID, CTHLabDetailFields.LabDetailsName, filter);
            return Json(LabdetList);
        }
        public IActionResult GetDrugData(int ID, int Index, int KimoID, DateTime druDatevalue)
        {
            DrugModel model = new DrugModel { Index = Index };
            RelationPredicateBucket filter = new RelationPredicateBucket();
            model.DrugEntity = new CTHDrugEntity(ID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugEntity);
            path.Add(CTHDrugEntity.PrefetchPathCTHDoseUnitItem, true);
            path.Add(CTHDrugEntity.PrefetchPathCTHDrugDayCollection, true);
            BL.DataBaseClassHelper.FillEntity(model.DrugEntity, path);
            model.PatientDrugEntity = new CTHPatientDrugEntity();
            model.PatientDrugEntity.ID = 0;
            model.PatientDrugEntity.KimoID = KimoID;
            model.PatientDrugEntity.Date = druDatevalue;
            model.PatientDrugEntity.IsNew = true;
            return PartialView("_DrugRow", model);
        }

        public IActionResult GetLabRow(int LabID, int LabDID, int Index, int KimoID, DateTime LabDatevalue)
        {
            LChemoLabModel model = new LChemoLabModel { Index = Index };
            RelationPredicateBucket filter = new RelationPredicateBucket();
            model.CTHLabEntity = new CTHLabEntity(LabID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabEntity);
            path.Add(CTHLabEntity.PrefetchPathCTHLabDetailCollection, true);
            BL.DataBaseClassHelper.FillEntity(model.CTHLabEntity, path);
            model.LabName = model.CTHLabEntity.LabName;
            model.CTHChemoLabEntity = new CTHChemoLabEntity();

            foreach (var item in model.CTHLabEntity.CTHLabDetailCollection)
            {
                if (item.ID == LabDID)
                {
                    model.LabDetailsName = item.LabDetailsName;
                    model.CTHChemoLabEntity.LabDetailsID = item.ID;
                    break;
                }
            }
            model.CTHChemoLabEntity.ID = 0;
            model.CTHChemoLabEntity.ChemoID = KimoID;
            model.CTHChemoLabEntity.Date = LabDatevalue;
            return PartialView("_LabRow", model);
        }

        [SmartAuthorize(UserPermission.Patient_ChemoDischargeNote)]
        [HttpGet]
        public ActionResult ConfirmDeletePatientDrug(int ID)
        {
            CTHPatientDrugEntity CTHPatientDrugEntity = new CTHPatientDrugEntity(ID);
            PrefetchPath2 path2 = new PrefetchPath2(EntityType.CTHPatientDrugEntity);
            path2.Add(CTHPatientDrugEntity.PrefetchPathCTHKimoSurveyItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CTHPatientDrugEntity, path2);
            int kimoid = (int)CTHPatientDrugEntity.CTHKimoSurveyItem.ID;
            BL.DataBaseClassHelper.Delete(CTHPatientDrugEntity, 0);
            AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            KimoSurveyModel model = new KimoSurveyModel();
            model.KimoSurveyEntity = new CTHKimoSurveyEntity(kimoid);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHKimoSurveyEntity);
            var pa = path.Add(CTHKimoSurveyEntity.PrefetchPathCTHPatientDrugCollection, true);
            var p = pa.SubPath.Add(CTHPatientDrugEntity.PrefetchPathCTHDrugItem, true);
            p.SubPath.Add(CTHDrugEntity.PrefetchPathCTHDrugDayCollection, true);
            p.SubPath.Add(CTHDrugEntity.PrefetchPathCTHDoseUnitItem, true);
            BL.DataBaseClassHelper.FillEntity(model.KimoSurveyEntity, path);
            return PartialView("_PatientDrugCollection", model);
        }

        [SmartAuthorize(UserPermission.Patient_ChemoDischargeNote)]
        [HttpGet]
        public ActionResult ConfirmDeleteChemoLab(int ID)
        {
            CTHChemoLabEntity CTHChemoLabEntitydelete = new CTHChemoLabEntity(ID);
            PrefetchPath2 path2 = new PrefetchPath2(EntityType.CTHChemoLabEntity);
            path2.Add(CTHChemoLabEntity.PrefetchPathCTHKimoSurveyItem, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CTHChemoLabEntitydelete, path2);
            int kimoid = (int)CTHChemoLabEntitydelete.CTHKimoSurveyItem.ID;
            BL.DataBaseClassHelper.Delete(CTHChemoLabEntitydelete, 0);
            return Json(kimoid);
        }
        public ActionResult ChemoLabList(int kimoid)
        {
            KimoSurveyModel model = new KimoSurveyModel();
            model.KimoSurveyEntity = new CTHKimoSurveyEntity(kimoid);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHKimoSurveyEntity);
            path.Add(CTHKimoSurveyEntity.PrefetchPathCTHChemoLabCollection, true)
                .SubPath.Add(CTHChemoLabEntity.PrefetchPathCTHLabDetailItem, true)
                .SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabItem, true);
            BL.DataBaseClassHelper.FillEntity(model.KimoSurveyEntity, path);
            return PartialView("_ChemoLabCollection", model);
        }

        #endregion

        #region lab

        [SmartAuthorize(UserPermission.Patient_ChemoDischargeNote)]
        [HttpGet]
        public IActionResult AddNewLab(int KimoID, int ProtocolID, int CycleID)
        {
            LabModel model = new LabModel();
            model.LabEntity = new CTHLabEntity();
            model.LabEntity.ProtocolID = ProtocolID;
            model.ChProID = KimoID;
            model.CycleID = CycleID;
            return PartialView(model);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateLab)]
        [HttpPost]
        public IActionResult AddNewLab(LabModel model, bool LabEntity_IsMandatory, int ChProID, int CycleID)
        {
            model.LabEntity.IsMandatory = LabEntity_IsMandatory;
            SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.LabEntity, true, false, 0);

            CTHKimoSurveyEntity KimoSurveyEntity = new CTHKimoSurveyEntity(ChProID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHKimoSurveyEntity);
            var ProtocolcyclePath = path.Add(CTHKimoSurveyEntity.PrefetchPathCTHProtocolCycleItem, true);
            BL.DataBaseClassHelper.FillEntity(KimoSurveyEntity, path);
            var firstidPro = KimoSurveyEntity.CTHProtocolCycleItem.ID;
            EntityCollection<CTHProtocolCycleEntity> collProtocolCycle = new EntityCollection<CTHProtocolCycleEntity>();
            PrefetchPath2 path2 = new PrefetchPath2(EntityType.CTHProtocolCycleEntity);
            path2.Add(CTHProtocolCycleEntity.PrefetchPathCTHCycleLabCollection, true)
                .SubPath.Add(CTHCycleLabEntity.PrefetchPathCTHLabDetailItem, true)
                .SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabItem, true);
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHProtocolCycleFields.ProtocolID == KimoSurveyEntity.ProtocolID);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(collProtocolCycle, filter, 0, null, path2, 0, 0);
            List<SelectListItem> LabList = new List<SelectListItem>();

            if (collProtocolCycle.Count != 0)
            {
                var cyclelabcoll = collProtocolCycle.Where(c => c.Number > KimoSurveyEntity.CycleNum).First().CTHCycleLabCollection;
                EntityCollection<CTHLabEntity> collLab = new EntityCollection<CTHLabEntity>();
                List<SelectList> ListOfLab = new List<SelectList>();
                foreach (var item in cyclelabcoll)
                {
                    collLab.Add(item.CTHLabDetailItem.CTHLabItem);
                }
                List<CTHLabEntity> uniquecollLab = collLab.Distinct().ToList();

                foreach (var item in uniquecollLab)
                {
                    RelationPredicateBucket filterlab = new RelationPredicateBucket(CTHLabFields.ID == item.ID);
                    var lab = DataHelper.GetSelectList<CTHLabEntity>(CTHLabFields.ID, CTHLabFields.LabName, filterlab).ToList();
                    LabList = LabList.Concat(lab).ToList();
                }
            }

            return Json(LabList);
        }

        public IActionResult RefreshLab(int KimoID)
        {
            CTHKimoSurveyEntity KimoSurveyEntity = new CTHKimoSurveyEntity(KimoID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHKimoSurveyEntity);
            var ProtocolcyclePath = path.Add(CTHKimoSurveyEntity.PrefetchPathCTHProtocolCycleItem, true);
            BL.DataBaseClassHelper.FillEntity(KimoSurveyEntity, path);
            var firstidPro = KimoSurveyEntity.CTHProtocolCycleItem.ID;
            EntityCollection<CTHProtocolCycleEntity> collProtocolCycle = new EntityCollection<CTHProtocolCycleEntity>();
            PrefetchPath2 path2 = new PrefetchPath2(EntityType.CTHProtocolCycleEntity);
            path2.Add(CTHProtocolCycleEntity.PrefetchPathCTHCycleLabCollection, true)
                .SubPath.Add(CTHCycleLabEntity.PrefetchPathCTHLabDetailItem, true)
                .SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabItem, true);
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHProtocolCycleFields.ProtocolID == KimoSurveyEntity.ProtocolID);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(collProtocolCycle, filter, 0, null, path2, 0, 0);
            List<SelectListItem> LabList = new List<SelectListItem>();
            if (collProtocolCycle.Count != 0)
            {
                var cyclelabcoll = collProtocolCycle.Where(c => c.ID > firstidPro).FirstOrDefault().CTHCycleLabCollection;
                EntityCollection<CTHLabEntity> collLab = new EntityCollection<CTHLabEntity>();
                List<SelectList> ListOfLab = new List<SelectList>();
                foreach (var item in cyclelabcoll)
                {
                    collLab.Add(item.CTHLabDetailItem.CTHLabItem);
                }
                List<CTHLabEntity> uniquecollLab = collLab.Distinct().ToList();

                foreach (var item in uniquecollLab)
                {
                    RelationPredicateBucket filterlab = new RelationPredicateBucket(CTHLabFields.ID == item.ID);
                    var lab = DataHelper.GetSelectList<CTHLabEntity>(CTHLabFields.ID, CTHLabFields.LabName, filterlab).ToList();
                    LabList = LabList.Concat(lab).ToList();
                }
            }

            return Json(LabList);
        }
        #endregion

        #region labDetails

        [SmartAuthorize(UserPermission.CancerType_EditCreateLab)]
        [HttpGet]
        public IActionResult AddNewLabDetails(int KimoID, int CycleID)
        {
            LabDetailsModel model = new LabDetailsModel();
            model.LabDetailEntity = new CTHLabDetailEntity();
            model.LablList = DataHelper.GetSelectList<CTHLabEntity>(CTHLabFields.ID, CTHLabFields.LabName, null);
            model.CycleID = CycleID;
            model.KimoID = KimoID;
            return PartialView(model);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateLab)]
        [HttpPost]
        public IActionResult AddNewLabDetails(LabDetailsModel model, int CycleID, int KimoID)
        {
            SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.LabDetailEntity, true, false, 0);
            CTHCycleLabEntity CycleLabEntity = new CTHCycleLabEntity
            {
                LabID = model.LabDetailEntity.ID,
                CycleID = CycleID
            };
            SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(CycleLabEntity, true, false, 0);

            /////////////////////filter list//////////////////////////////////////////
            CTHKimoSurveyEntity KimoSurveyEntity = new CTHKimoSurveyEntity(KimoID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHKimoSurveyEntity);
            path.Add(CTHKimoSurveyEntity.PrefetchPathCTHProtocolCycleItem, true);
            BL.DataBaseClassHelper.FillEntity(KimoSurveyEntity, path);
            var firstidPro = KimoSurveyEntity.CTHProtocolCycleItem.ID;
            EntityCollection<CTHProtocolCycleEntity> collProtocolCycle = new EntityCollection<CTHProtocolCycleEntity>();
            PrefetchPath2 path2 = new PrefetchPath2(EntityType.CTHProtocolCycleEntity);
            path2.Add(CTHProtocolCycleEntity.PrefetchPathCTHCycleLabCollection, true)
                .SubPath.Add(CTHCycleLabEntity.PrefetchPathCTHLabDetailItem, true)
                .SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabItem, true);
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHProtocolCycleFields.ProtocolID == KimoSurveyEntity.ProtocolID);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(collProtocolCycle, filter, 0, null, path2, 0, 0);
            List<SelectListItem> LabList = new List<SelectListItem>();
            if (collProtocolCycle.Count != 0)
            {
                var cyclelabcoll = collProtocolCycle.Where(c => c.Number > KimoSurveyEntity.CycleNum).First().CTHCycleLabCollection;
                EntityCollection<CTHLabDetailEntity> collLab = new EntityCollection<CTHLabDetailEntity>();
                foreach (var item in cyclelabcoll)
                {
                    collLab.Add(item.CTHLabDetailItem);
                }
                List<CTHLabDetailEntity> uniquecollLab = collLab.Distinct().ToList();
                foreach (var item in collLab)
                {
                    RelationPredicateBucket filterlab = new RelationPredicateBucket(CTHLabDetailFields.ID == item.ID);
                    var LabDetails = DataHelper.GetSelectList<CTHLabDetailEntity>(CTHLabDetailFields.ID, CTHLabDetailFields.LabDetailsName, filterlab);
                    LabList = LabList.Concat(LabDetails).ToList();
                }
            }

            ///////////////////////////////////////////////////////////////////////////
            return Json(LabList);
        }
        #endregion

        #region Drug

        [SmartAuthorize(UserPermission.CancerType_EditCreateDrug)]
        [HttpGet]
        public IActionResult AddNewDrug(int ProtocolID, int CancerID, int KimoID, int CycleID)
        {
            DrugModel model = new DrugModel();
            model.DrugEntity = new CTHDrugEntity();
            model.RouteList = DataHelper.GetDirectionSelectList<Route>();
            model.DoseUnitList = DataHelper.GetSelectList<CTHDoseUnitEntity>(CTHDoseUnitFields.ID, CTHDoseUnitFields.Name);
            model.DurationUnitList = DataHelper.GetDirectionSelectList<DurationUnit>();
            model.SolutionList = DataHelper.GetSelectList<CTHSolutionEntity>(CTHSolutionFields.ID, CTHSolutionFields.Name);
            model.DrugEntity.ProtocolID = ProtocolID;
            model.CancerID = CancerID;
            model.CycleID = CycleID;
            model.KimoID = KimoID;
            return PartialView(model);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateDrug)]
        [HttpPost]
        public IActionResult AddNewDrug(DrugModel model, List<int> Days, int CycleID, int KimoID)
        {
            SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.DrugEntity, true, false, 0);
            var drug = new CTHDrugEntity(model.DrugEntity.ID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugEntity);
            path.Add(CTHDrugEntity.PrefetchPathCTHDrugDayCollection, true);
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

            CTHCycleDrugEntity cTHCycleDrug = new CTHCycleDrugEntity
            {
                DrugID = model.DrugEntity.ID,
                CycleID = CycleID
            };
            SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(cTHCycleDrug, true, false, 0);

            /////////////////////filter list//////////////////////////////////////////
            CTHKimoSurveyEntity KimoSurveyEntity = new CTHKimoSurveyEntity(KimoID);
            PrefetchPath2 pathchem = new PrefetchPath2(EntityType.CTHKimoSurveyEntity);
            pathchem.Add(CTHKimoSurveyEntity.PrefetchPathCTHProtocolCycleItem, true);
            BL.DataBaseClassHelper.FillEntity(KimoSurveyEntity, pathchem);
            var firstidPro = KimoSurveyEntity.CTHProtocolCycleItem.ID;
            EntityCollection<CTHProtocolCycleEntity> collProtocolCycle = new EntityCollection<CTHProtocolCycleEntity>();
            PrefetchPath2 path2 = new PrefetchPath2(EntityType.CTHProtocolCycleEntity);
            path2.Add(CTHProtocolCycleEntity.PrefetchPathCTHCycleDrugCollection, true)
                .SubPath.Add(CTHCycleDrugEntity.PrefetchPathCTHDrugItem, true);
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHProtocolCycleFields.ProtocolID == KimoSurveyEntity.ProtocolID);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(collProtocolCycle, filter, 0, null, path2, 0, 0);
            List<SelectListItem> DrugList = new List<SelectListItem>();

            if (collProtocolCycle.Count != 0)
            {
                var CycleDrugCollection = collProtocolCycle.Where(c => c.Number > KimoSurveyEntity.CycleNum).First().CTHCycleDrugCollection;
                EntityCollection<CTHDrugEntity> CTHDrugColl = new EntityCollection<CTHDrugEntity>();
                foreach (var item in CycleDrugCollection)
                {
                    CTHDrugColl.Add(item.CTHDrugItem);
                }
                List<CTHDrugEntity> uniquecCTHDrugColl = CTHDrugColl.Distinct().ToList();
                foreach (var item in CTHDrugColl)
                {
                    RelationPredicateBucket filterDrud = new RelationPredicateBucket(CTHDrugFields.ID == item.ID);
                    var druges = DataHelper.GetSelectList<CTHDrugEntity>(CTHDrugFields.ID, CTHDrugFields.Name, filterDrud);
                    DrugList = DrugList.Concat(druges).ToList();
                }
            }
            ///////////////////////////////////////////////////////////////////////////
            return Json(DrugList);
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


        public ActionResult DischargeNotePDF(int ID, string lang)
        {
            var Model = GetModel(ID);
            List<DataTable> Tables = new List<DataTable>();
            string Header;
            if (lang == "en")
            {
                DataTable dtPatientData = new DataTable();
                dtPatientData.Columns.Add("Name");
                dtPatientData.Columns.Add("MRN");
                dtPatientData.Columns.Add("Date");
                DataRow drPatientData = dtPatientData.NewRow();
                drPatientData[0] = Model.KimoSurveyEntity.CTHPatientClinicalDataItem.CTHPatientItem.PatientNameE;
                drPatientData[1] = Model.KimoSurveyEntity.CTHPatientClinicalDataItem.CTHPatientItem.PatientNumber.ToString();
                drPatientData[2] = DateTime.Now.ToString();
                dtPatientData.Rows.Add(drPatientData);

                DataTable dtDiagnosis = new DataTable();
                dtDiagnosis.Columns.Add("Type");
                dtDiagnosis.Columns.Add("Side");
                dtDiagnosis.Columns.Add("Histological Subtype");
                dtDiagnosis.Columns.Add("Molecular Subtype");
                dtDiagnosis.Columns.Add("Grade");
                dtDiagnosis.Columns.Add("Stage");
                DataRow drDiagnosis = dtDiagnosis.NewRow();
                drDiagnosis[0] = Model.KimoSurveyEntity.CTHPatientClinicalDataItem.CTHCancerTypeItem.TypeName;
                drDiagnosis[1] = Model.KimoSurveyEntity.CTHPatientClinicalDataItem.CTHCancerSideItem.Side;
                drDiagnosis[2] = Model.KimoSurveyEntity.CTHPatientClinicalDataItem.CTHCancerHistologicItem.Name;
                drDiagnosis[3] = Model.KimoSurveyEntity.CTHPatientClinicalDataItem.CTHCancerMolecularItem.Name;
                drDiagnosis[4] = Model.KimoSurveyEntity.CTHPatientClinicalDataItem.CTHTumorGradeItem.TumorGrade;
                drDiagnosis[5] = Model.KimoSurveyEntity.CTHPatientClinicalDataItem.CTHStagingItem.Name;
                dtDiagnosis.Rows.Add(drDiagnosis);

                DataTable dtProtocolData = new DataTable();
                dtProtocolData.Columns.Add("Protocol");
                dtProtocolData.Columns.Add("Cycle Number");
                DataRow drProtocolData = dtProtocolData.NewRow();
                drProtocolData[0] = Model.KimoSurveyEntity.CTHChemotherapyProtocolItem.ProtocolName;
                drProtocolData[1] = Model.NextcycleNumber.ToString();
                dtProtocolData.Rows.Add(drProtocolData);

                DataTable dtPatientLabs = new DataTable();
                dtPatientLabs.Columns.Add("Lab Type");
                dtPatientLabs.Columns.Add("Lab Subtype");
                dtPatientLabs.Columns.Add("Date");

                foreach (var item in Model.KimoSurveyEntity.CTHChemoLabCollection)
                {
                    DataRow drPatientLab = dtPatientLabs.NewRow();
                    drPatientLab[0] = item.CTHLabDetailItem.CTHLabItem.LabName;
                    drPatientLab[1] = item.CTHLabDetailItem.LabDetailsName;
                    drPatientLab[2] = item.Date;
                    dtPatientLabs.Rows.Add(drPatientLab);
                }

                DataTable dtPatientDrugs = new DataTable();
                dtPatientDrugs.Columns.Add("Name");
                dtPatientDrugs.Columns.Add("Dose");
                dtPatientDrugs.Columns.Add("Duration");
                dtPatientDrugs.Columns.Add("Every");
                dtPatientDrugs.Columns.Add("Route");
                dtPatientDrugs.Columns.Add("Days");
                dtPatientDrugs.Columns.Add("Date");
                foreach (var item in Model.KimoSurveyEntity.CTHPatientDrugCollection)
                {
                    DataRow drPatientDrug = dtPatientDrugs.NewRow();
                    drPatientDrug[0] = item.CTHDrugItem.Name;
                    drPatientDrug[1] = item.CTHDrugItem.Dose + " " + item.CTHDrugItem.CTHDoseUnitItem.Name;
                    drPatientDrug[2] = item.CTHDrugItem.Duration +
                     " " + Enum.GetName(typeof(DurationUnit), item.CTHDrugItem.DurationUnitID);
                    drPatientDrug[3] = item.CTHDrugItem.Every +
                    " " + Enum.GetName(typeof(EveryUnit), item.CTHDrugItem.EveryUnitID);
                    drPatientDrug[4] = Enum.GetName(typeof(Route), item.CTHDrugItem.RouteID);
                    var Days = "";
                    var x = 0;
                    foreach (var item2 in item.CTHDrugItem.CTHDrugDayCollection)
                    {
                        Days += item2.Day;
                        x++;
                        if (item.CTHDrugItem.CTHDrugDayCollection.Count - 1 >= x)
                        {
                            Days += ", ";
                        }
                    }
                    drPatientDrug[5] = Days;
                    drPatientDrug[6] = item.Date;
                    dtPatientDrugs.Rows.Add(drPatientDrug);
                }

                DataTable Table1 = new DataTable();
                Table1.Columns.Add("Paient Data and Clinical Data");
                DataTable Table2 = new DataTable();
                Table2.Columns.Add("Protocol");
                DataTable Table3 = new DataTable();
                Table3.Columns.Add("Required Investigations");
                DataTable Table4 = new DataTable();
                Table4.Columns.Add("Take Home Medications");

                //List<DataTable> Tables = new List<DataTable>();
                Tables.Add(Table1);
                Tables.Add(dtPatientData);
                Tables.Add(dtDiagnosis);
                Tables.Add(Table2);
                Tables.Add(dtProtocolData);
                Tables.Add(Table3);
                Tables.Add(dtPatientLabs);
                Tables.Add(Table4);
                Tables.Add(dtPatientDrugs);
                Header = "Discharge Note";
            }
            else
            {
                DataTable dtPatientData = new DataTable();
                dtPatientData.Columns.Add("الأسم");
                dtPatientData.Columns.Add("رقم التسجيل الطبي");
                dtPatientData.Columns.Add("التاريخ");
                DataRow drPatientData = dtPatientData.NewRow();
                drPatientData[0] = Model.KimoSurveyEntity.CTHPatientClinicalDataItem.CTHPatientItem.PatientNameA;
                drPatientData[1] = Model.KimoSurveyEntity.CTHPatientClinicalDataItem.CTHPatientItem.PatientNumber.ToString();
                drPatientData[2] = DateTime.Now.ToString();
                dtPatientData.Rows.Add(drPatientData);

                DataTable dtDiagnosis = new DataTable();
                dtDiagnosis.Columns.Add("نوع السرطان");
                dtDiagnosis.Columns.Add("الآثار الجانبيه");
                dtDiagnosis.Columns.Add("النوع الفرعي للسرطان النسيجي");
                dtDiagnosis.Columns.Add("النوع الفرعي للسرطان الجزيئي");
                dtDiagnosis.Columns.Add("الدرجة");
                dtDiagnosis.Columns.Add("المرحلة");
                DataRow drDiagnosis = dtDiagnosis.NewRow();
                drDiagnosis[0] = Model.KimoSurveyEntity.CTHPatientClinicalDataItem.CTHCancerTypeItem.ArTypeName;
                drDiagnosis[1] = Model.KimoSurveyEntity.CTHPatientClinicalDataItem.CTHCancerSideItem.ArSide;
                drDiagnosis[2] = Model.KimoSurveyEntity.CTHPatientClinicalDataItem.CTHCancerHistologicItem.ArName;
                drDiagnosis[3] = Model.KimoSurveyEntity.CTHPatientClinicalDataItem.CTHCancerMolecularItem.ArName;
                drDiagnosis[4] = Model.KimoSurveyEntity.CTHPatientClinicalDataItem.CTHTumorGradeItem.TumorGrade;
                drDiagnosis[5] = Model.KimoSurveyEntity.CTHPatientClinicalDataItem.CTHStagingItem.ArName;
                dtDiagnosis.Rows.Add(drDiagnosis);

                DataTable dtProtocolData = new DataTable();
                dtProtocolData.Columns.Add("البروتوكول");
                dtProtocolData.Columns.Add("رقم الدورة");
                DataRow drProtocolData = dtProtocolData.NewRow();
                drProtocolData[0] = Model.KimoSurveyEntity.CTHChemotherapyProtocolItem.ArProtocolName;
                drProtocolData[1] = Model.NextcycleNumber.ToString();
                dtProtocolData.Rows.Add(drProtocolData);

                DataTable dtPatientLabs = new DataTable();
                dtPatientLabs.Columns.Add("نوع التحليل");
                dtPatientLabs.Columns.Add("نوع التحليل الفرعي");
                dtPatientLabs.Columns.Add("التاريخ");

                foreach (var item in Model.KimoSurveyEntity.CTHChemoLabCollection)
                {
                    DataRow drPatientLab = dtPatientLabs.NewRow();
                    drPatientLab[0] = item.CTHLabDetailItem.CTHLabItem.ArLabName;
                    drPatientLab[1] = item.CTHLabDetailItem.ArLabDetailsName;
                    drPatientLab[2] = item.Date;
                    dtPatientLabs.Rows.Add(drPatientLab);
                }

                DataTable dtPatientDrugs = new DataTable();
                dtPatientDrugs.Columns.Add("الأسم");
                dtPatientDrugs.Columns.Add("الجرعة");
                dtPatientDrugs.Columns.Add("المدة الزمنية");
                dtPatientDrugs.Columns.Add("كل");
                dtPatientDrugs.Columns.Add("المسار");
                dtPatientDrugs.Columns.Add("الايام");
                dtPatientDrugs.Columns.Add("التاريخ");
                foreach (var item in Model.KimoSurveyEntity.CTHPatientDrugCollection)
                {
                    DataRow drPatientDrug = dtPatientDrugs.NewRow();
                    drPatientDrug[0] = item.CTHDrugItem.ArName;
                    drPatientDrug[1] = item.CTHDrugItem.Dose + " " + item.CTHDrugItem.CTHDoseUnitItem.ArName;
                    drPatientDrug[2] = item.CTHDrugItem.Duration +
                     " " + Enum.GetName(typeof(DurationUnit), item.CTHDrugItem.DurationUnitID);
                    drPatientDrug[3] = item.CTHDrugItem.Every +
                    " " + Enum.GetName(typeof(EveryUnit), item.CTHDrugItem.EveryUnitID);
                    drPatientDrug[4] = Enum.GetName(typeof(Route), item.CTHDrugItem.RouteID);
                    var Days = "";
                    var x = 0;
                    foreach (var item2 in item.CTHDrugItem.CTHDrugDayCollection)
                    {
                        Days += item2.Day;
                        x++;
                        if (item.CTHDrugItem.CTHDrugDayCollection.Count - 1 >= x)
                        {
                            Days += ", ";
                        }
                    }
                    drPatientDrug[5] = Days;
                    drPatientDrug[6] = item.Date;
                    dtPatientDrugs.Rows.Add(drPatientDrug);
                }

                DataTable Table1 = new DataTable();
                Table1.Columns.Add("بيانات المريض و السجل المرضي");
                DataTable Table2 = new DataTable();
                Table2.Columns.Add("البروتوكول");
                DataTable Table3 = new DataTable();
                Table3.Columns.Add("الإستقصاء اللازم");
                DataTable Table4 = new DataTable();
                Table4.Columns.Add("تناول الأدوية المنزلية");

                //List<DataTable> Tables = new List<DataTable>();
                Tables.Add(Table1);
                Tables.Add(dtPatientData);
                Tables.Add(dtDiagnosis);
                Tables.Add(Table2);
                Tables.Add(dtProtocolData);
                Tables.Add(Table3);
                Tables.Add(dtPatientLabs);
                Tables.Add(Table4);
                Tables.Add(dtPatientDrugs);
                Header = "ملاحظه التفريغ للبيانات";
            }
            return DownloadAsPDF(Tables, ID, Header);
        }

        public ActionResult DownloadAsPDF(List<DataTable> dataTable, int ChemoID, string Header)
        {
            var webRoot = _env.WebRootPath;
            var TempFolder = System.IO.Path.Combine(webRoot, "TempFiles", Guid.NewGuid().ToString("N"));
            if (!Directory.Exists(TempFolder))
                Directory.CreateDirectory(TempFolder);
            var fileTosave = System.IO.Path.ChangeExtension(System.IO.Path.Combine(TempFolder, "Discharge Note #" + ChemoID), "pdf");
            DataHelper.ExportToPdf(dataTable, fileTosave, Header);
            var file = _fileService.ReadFile(fileTosave);
            System.IO.Directory.Delete(TempFolder, true);
            if (file == null || file.Length < 1)
                return Content("");
            return File(file, System.Net.Mime.MediaTypeNames.Application.Octet, Path.ChangeExtension(Guid.NewGuid().ToString("N"), Path.GetExtension(fileTosave)));
        }
    }
}