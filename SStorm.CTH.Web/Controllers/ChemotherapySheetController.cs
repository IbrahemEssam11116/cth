using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SStorm.CTH.DAL;
using SStorm.CTH.DAL.EntityClasses;
using SStorm.CTH.DAL.HelperClasses;
using SStorm.CTH.BL.Helpers;
using SStorm.CTH.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.IO;
using SStorm.CTH.Web.Infrastructure;
using Microsoft.AspNetCore.Hosting;

namespace SStorm.CTH.Web.Controllers
{
    public class ChemotherapySheetController : SmartController
    {
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _env;
        public ChemotherapySheetController(IClientNotification notifier, IFileService _fileService, IWebHostEnvironment _env) : base(notifier)
        {
            this._env = _env;
            this._fileService = _fileService;
        }
        [SmartAuthorize(UserPermission.Patient_ChemoPrintOutSheet)]
        public IActionResult PrintOutSheet(int ID)
        {
            var model = GetModel(ID);
            return View(model);
        }

        public KimoSurveyModel GetModel(int ID)
        {
            KimoSurveyModel model = new KimoSurveyModel();
            model.KimoSurveyEntity = new CTHKimoSurveyEntity(ID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHKimoSurveyEntity);
            var paitentpath = path.Add(CTHKimoSurveyEntity.PrefetchPathCTHPatientClinicalDataItem, true);
            paitentpath.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHPatientItem, true);
            paitentpath.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerHistologicItem, true);
            paitentpath.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerMolecularItem, true);
            paitentpath.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerTypeItem, true);
            paitentpath.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHCancerSideItem, true);
            paitentpath.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHStagingItem, true);
            paitentpath.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHTumorGradeItem, true);
            path.Add(CTHKimoSurveyEntity.PrefetchPathCTHChemotherapyProtocolItem, true)
                .SubPath.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHPreMedicationItem, true);
            path.Add(CTHKimoSurveyEntity.PrefetchPathCTHChemoLabCollection, true)
                .SubPath.Add(CTHChemoLabEntity.PrefetchPathCTHLabDetailItem, true)
                .SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabItem, true)
                .SubPath.Add(CTHLabEntity.PrefetchPathCTHLabDetailCollection, true)
                .SubPath.Add(CTHLabDetailEntity.PrefetchPathCTHLabDetailConditionCollection, true);
            var DrugPath = path.Add(CTHKimoSurveyEntity.PrefetchPathCTHPatientDrugCollection, true);
            var pathd2=   DrugPath.SubPath.Add(CTHPatientDrugEntity.PrefetchPathCTHDrugItem, true);
            pathd2.SubPath.Add(CTHDrugEntity.PrefetchPathCTHDoseUnitItem, true);
            pathd2.SubPath.Add(CTHDrugEntity.PrefetchPathCTHSolutionItem, true);
            path.Add(CTHKimoSurveyEntity.PrefetchPathCTHProtocolCycleItem, true);
            BL.DataBaseClassHelper.FillEntity(model.KimoSurveyEntity, path);
            EntityCollection<CTHDrugEntity> CTHDrugColl = new EntityCollection<CTHDrugEntity>();
            if (model.KimoSurveyEntity.CTHPatientDrugCollection.Count != 0)
            {
                foreach (var item in model.KimoSurveyEntity.CTHPatientDrugCollection)
                {
                    if (item.CTHDrugItem!=null)
                    {
                        CTHDrugColl.Add(item.CTHDrugItem);
                    }
                }
                model.uniquecollDrug = CTHDrugColl.Distinct().ToList();
                model.GroupByuniquecollDrug = model.uniquecollDrug.GroupBy(s => s.RouteID);
            }
            model.cyclenum = (int)model.KimoSurveyEntity.CTHProtocolCycleItem.Number;         
            return model;
        }

        public ActionResult PrintOutSheetPDF(int ID,string lang)
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
                dtProtocolData.Columns.Add("Cycle");
                dtProtocolData.Columns.Add("Day");
                dtProtocolData.Columns.Add("Body Surface Area");
                dtProtocolData.Columns.Add("Emetogenic Risk");
                dtProtocolData.Columns.Add("Growth Factor");
                dtProtocolData.Columns.Add("Antimicrobial");
                dtProtocolData.Columns.Add("Premedication");
                DataRow drProtocolData = dtProtocolData.NewRow();
                drProtocolData[0] = Model.KimoSurveyEntity.CTHChemotherapyProtocolItem.ProtocolName;
                drProtocolData[1] = Model.KimoSurveyEntity.CycleNum.ToString();
                drProtocolData[2] = Model.KimoSurveyEntity.Days.ToString();
                drProtocolData[3] = Model.KimoSurveyEntity.BodySurfaceArea;
                drProtocolData[4] = Enum.GetName(typeof(EmatogenicRisk), Model.KimoSurveyEntity.CTHChemotherapyProtocolItem.EmetodenicRiskID);
                drProtocolData[5] = Model.KimoSurveyEntity.CTHChemotherapyProtocolItem.IsGrowthFactor;
                drProtocolData[6] = Model.KimoSurveyEntity.CTHChemotherapyProtocolItem.IsAntimicrobial;
                drProtocolData[7] = Model.KimoSurveyEntity.CTHChemotherapyProtocolItem.CTHPreMedicationItem.Title;
                dtProtocolData.Rows.Add(drProtocolData);

                DataTable dtPatientLabs = new DataTable();
                dtPatientLabs.Columns.Add("Lab Category");
                dtPatientLabs.Columns.Add("Lab Item");
                dtPatientLabs.Columns.Add("Date");
                
                foreach (var item in Model.KimoSurveyEntity.CTHChemoLabCollection)
                {
                    DataRow drPatientLab = dtPatientLabs.NewRow();
                    drPatientLab[0] = item.CTHLabDetailItem.CTHLabItem.LabName;
                    drPatientLab[1] = item.CTHLabDetailItem.LabDetailsName;
                    drPatientLab[2] = item.Date.ToString();
                    dtPatientLabs.Rows.Add(drPatientLab);
                }


                DataTable dtPatientDrugs = new DataTable();
                dtPatientDrugs.Columns.Add("Route");
                dtPatientDrugs.Columns.Add("Name");
                dtPatientDrugs.Columns.Add("Dose/unit");
                dtPatientDrugs.Columns.Add("Duration/unit");
                dtPatientDrugs.Columns.Add("Every/unit");
                dtPatientDrugs.Columns.Add("Amout/Solution");
                dtPatientDrugs.Columns.Add("Final Concentration");
                dtPatientDrugs.Columns.Add("Amount/Form");
                dtPatientDrugs.Columns.Add("Administration Notes");
                dtPatientDrugs.Columns.Add("Time Of Administration");

                if(Model.KimoSurveyEntity.CTHPatientDrugCollection.Where(c => c.CTHDrugItem.RouteID == (int)Route.Iv).Count() > 0)
                {
                    DataRow dr1PatientDrug = dtPatientDrugs.NewRow();
                    dr1PatientDrug[0] = "IV";
                    dr1PatientDrug[1] = " ";
                    dr1PatientDrug[2] = " ";
                    dr1PatientDrug[3] = " ";
                    dr1PatientDrug[4] = " ";
                    dr1PatientDrug[5] = " ";
                    dr1PatientDrug[6] = " ";
                    dr1PatientDrug[7] = " ";
                    dr1PatientDrug[8] = " ";
                    dr1PatientDrug[9] = " ";
                    dtPatientDrugs.Rows.Add(dr1PatientDrug);
                }
                var count = 0;
                foreach (var item in Model.KimoSurveyEntity.CTHPatientDrugCollection.Where(c => c.CTHDrugItem.RouteID == (int)Route.Iv))
                {
                    DataRow dr2PatientDrug = dtPatientDrugs.NewRow();
                    dr2PatientDrug[count] = " ";
                    count++;
                    dr2PatientDrug[count] = item.CTHDrugItem.Name;
                    count++;
                    dr2PatientDrug[count] = item.CTHDrugItem.Dose + " " + item.CTHDrugItem.CTHDoseUnitItem.Name;
                    count++;
                    dr2PatientDrug[count] = item.CTHDrugItem.Duration + " " + Enum.GetName(typeof(DurationUnit), item.CTHDrugItem.DurationUnitID);
                    count++;
                    dr2PatientDrug[count] = item.CTHDrugItem.Every + " " + Enum.GetName(typeof(DurationUnit), item.CTHDrugItem.EveryUnitID);
                    count++;
                    dr2PatientDrug[count] = item.CTHDrugItem.SolutionAmount + " " + item.CTHDrugItem.CTHSolutionItem.Name;
                    count++;
                    dr2PatientDrug[count] = item.CTHDrugItem.FinalConcentration;
                    count++;
                    dr2PatientDrug[count] = " ";
                    count++;
                    dr2PatientDrug[count] = " ";
                    count++;
                    dr2PatientDrug[count] = " ";
                    count = 0;
                    dtPatientDrugs.Rows.Add(dr2PatientDrug);
                }

                if(Model.KimoSurveyEntity.CTHPatientDrugCollection.Where(c => c.CTHDrugItem.RouteID == (int)Route.Po).Count() > 0)
                {
                    DataRow dr3PatientDrug = dtPatientDrugs.NewRow();
                    dr3PatientDrug[0] = "PO";
                    dr3PatientDrug[1] = " ";
                    dr3PatientDrug[2] = " ";
                    dr3PatientDrug[3] = " ";
                    dr3PatientDrug[4] = " ";
                    dr3PatientDrug[5] = " ";
                    dr3PatientDrug[6] = " ";
                    dr3PatientDrug[7] = " ";
                    dr3PatientDrug[8] = " ";
                    dr3PatientDrug[9] = " ";
                    dtPatientDrugs.Rows.Add(dr3PatientDrug);
                }
                count = 0;
                foreach (var item in Model.KimoSurveyEntity.CTHPatientDrugCollection.Where(c => c.CTHDrugItem.RouteID == (int)Route.Po))
                {
                    DataRow dr4PatientDrug = dtPatientDrugs.NewRow();
                    dr4PatientDrug[count] = " ";
                    count++;
                    dr4PatientDrug[count] = item.CTHDrugItem.Name;
                    count++;
                    dr4PatientDrug[count] = item.CTHDrugItem.Dose + " " + item.CTHDrugItem.CTHDoseUnitItem.Name;
                    count++;
                    dr4PatientDrug[count] = item.CTHDrugItem.Duration + " " + Enum.GetName(typeof(DurationUnit), item.CTHDrugItem.DurationUnitID);
                    count++;
                    dr4PatientDrug[count] = item.CTHDrugItem.Every + " " + Enum.GetName(typeof(DurationUnit), item.CTHDrugItem.EveryUnitID);
                    count++;
                    dr4PatientDrug[count] = " ";
                    count++;
                    dr4PatientDrug[count] = " ";
                    count++;
                    dr4PatientDrug[count] = item.CTHDrugItem.FormAmount + " " + Enum.GetName(typeof(Form), item.CTHDrugItem.FormID);
                    count++;
                    dr4PatientDrug[count] = item.CTHDrugItem.SpecialAdminstrationNotes;
                    count++;
                    dr4PatientDrug[count] = " ";
                    count = 0;
                    dtPatientDrugs.Rows.Add(dr4PatientDrug);
                }

                if (Model.KimoSurveyEntity.CTHPatientDrugCollection.Where(c => c.CTHDrugItem.RouteID == (int)Route.Sc).Count() > 0)
                {
                    DataRow dr5PatientDrug = dtPatientDrugs.NewRow();
                    dr5PatientDrug[0] = "SC";
                    dr5PatientDrug[1] = " ";
                    dr5PatientDrug[2] = " ";
                    dr5PatientDrug[3] = " ";
                    dr5PatientDrug[4] = " ";
                    dr5PatientDrug[5] = " ";
                    dr5PatientDrug[6] = " ";
                    dr5PatientDrug[7] = " ";
                    dr5PatientDrug[8] = " ";
                    dr5PatientDrug[9] = " ";
                    dtPatientDrugs.Rows.Add(dr5PatientDrug);
                }
                count = 0;
                foreach (var item in Model.KimoSurveyEntity.CTHPatientDrugCollection.Where(c => c.CTHDrugItem.RouteID == (int)Route.Sc))
                {
                    DataRow dr6PatientDrug = dtPatientDrugs.NewRow();
                    dr6PatientDrug[count] = " ";
                    count++;
                    dr6PatientDrug[count] = item.CTHDrugItem.Name;
                    count++;
                    dr6PatientDrug[count] = item.CTHDrugItem.Dose + " " + item.CTHDrugItem.CTHDoseUnitItem.Name;
                    count++;
                    dr6PatientDrug[count] = item.CTHDrugItem.Duration + " " + Enum.GetName(typeof(DurationUnit), item.CTHDrugItem.DurationUnitID);
                    count++;
                    dr6PatientDrug[count] = item.CTHDrugItem.Every + " " + Enum.GetName(typeof(DurationUnit), item.CTHDrugItem.EveryUnitID);
                    count++;
                    dr6PatientDrug[count] = " ";
                    count++;
                    dr6PatientDrug[count] = " ";
                    count++;
                    dr6PatientDrug[count] = " ";
                    count++;
                    dr6PatientDrug[count] = " ";
                    count++;
                    dr6PatientDrug[count] = " ";
                    count = 0;
                    dtPatientDrugs.Rows.Add(dr6PatientDrug);
                }

                if (Model.KimoSurveyEntity.CTHPatientDrugCollection.Where(c => c.CTHDrugItem.RouteID == (int)Route.Im).Count() > 0)
                {
                    DataRow dr7PatientDrug = dtPatientDrugs.NewRow();
                    dr7PatientDrug[0] = "IM";
                    dr7PatientDrug[1] = " ";
                    dr7PatientDrug[2] = " ";
                    dr7PatientDrug[3] = " ";
                    dr7PatientDrug[4] = " ";
                    dr7PatientDrug[5] = " ";
                    dr7PatientDrug[6] = " ";
                    dr7PatientDrug[7] = " ";
                    dr7PatientDrug[8] = " ";
                    dr7PatientDrug[9] = " ";
                    dtPatientDrugs.Rows.Add(dr7PatientDrug);
                }
                count = 0;
                foreach (var item in Model.KimoSurveyEntity.CTHPatientDrugCollection.Where(c => c.CTHDrugItem.RouteID == (int)Route.Im))
                {
                    DataRow dr8PatientDrug = dtPatientDrugs.NewRow();
                    dr8PatientDrug[count] = " ";
                    count++;
                    dr8PatientDrug[count] = item.CTHDrugItem.Name;
                    count++;
                    dr8PatientDrug[count] = item.CTHDrugItem.Dose + " " + item.CTHDrugItem.CTHDoseUnitItem.Name;
                    count++;
                    dr8PatientDrug[count] = item.CTHDrugItem.Duration + " " + Enum.GetName(typeof(DurationUnit), item.CTHDrugItem.DurationUnitID);
                    count++;
                    dr8PatientDrug[count] = item.CTHDrugItem.Every + " " + Enum.GetName(typeof(DurationUnit), item.CTHDrugItem.EveryUnitID);
                    count++;
                    dr8PatientDrug[count] = item.CTHDrugItem.SolutionAmount + " " + item.CTHDrugItem.CTHSolutionItem.Name;
                    count++;
                    dr8PatientDrug[count] = " ";
                    count++;
                    dr8PatientDrug[count] = " ";
                    count++;
                    dr8PatientDrug[count] = " ";
                    count++;
                    dr8PatientDrug[count] = item.CTHDrugItem.TimeOfAdminstration.ToString();
                    count = 0;
                    dtPatientDrugs.Rows.Add(dr8PatientDrug);
                }

                DataTable Table1 = new DataTable();
                Table1.Columns.Add("Paient Data and Clinical Data");
                DataTable Table2 = new DataTable();
                Table2.Columns.Add("Protocol");
                DataTable Table3 = new DataTable();
                Table3.Columns.Add("Investigations");
                DataTable Table4 = new DataTable();
                Table4.Columns.Add("Premedication");
                Tables.Add(Table1);
                Tables.Add(dtPatientData);
                Tables.Add(dtDiagnosis);
                Tables.Add(Table2);
                Tables.Add(dtProtocolData);
                Tables.Add(Table3);
                Tables.Add(dtPatientLabs);
                Tables.Add(Table4);
                Tables.Add(dtPatientDrugs);
                Header = "Print Out Sheet";
            }
            else
            {
                DataTable dtPatientData = new DataTable();
                dtPatientData.Columns.Add("الأسم");
                dtPatientData.Columns.Add("رقم السجل الطبي");
                dtPatientData.Columns.Add("تاريخ الميلاد");
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
                dtProtocolData.Columns.Add("اليوم");
                dtProtocolData.Columns.Add("مساحة سطح الجسم");
                dtProtocolData.Columns.Add("خطر خلقي");
                dtProtocolData.Columns.Add("عامل النمو");
                dtProtocolData.Columns.Add("مضاد للميكروبات");
                dtProtocolData.Columns.Add("مخدر");
                DataRow drProtocolData = dtProtocolData.NewRow();
                drProtocolData[0] = Model.KimoSurveyEntity.CTHChemotherapyProtocolItem.ArProtocolName;
                drProtocolData[1] = Model.KimoSurveyEntity.CycleNum.ToString();
                drProtocolData[2] = Model.KimoSurveyEntity.Days.ToString();
                drProtocolData[3] = Model.KimoSurveyEntity.BodySurfaceArea;
                drProtocolData[4] = Enum.GetName(typeof(EmatogenicRisk), Model.KimoSurveyEntity.CTHChemotherapyProtocolItem.EmetodenicRiskID);
                drProtocolData[5] = Model.KimoSurveyEntity.CTHChemotherapyProtocolItem.IsGrowthFactor;
                drProtocolData[6] = Model.KimoSurveyEntity.CTHChemotherapyProtocolItem.IsAntimicrobial;
                drProtocolData[7] = Model.KimoSurveyEntity.CTHChemotherapyProtocolItem.CTHPreMedicationItem.ArTitle;
                dtProtocolData.Rows.Add(drProtocolData);

                DataTable dtPatientLabs = new DataTable();
                dtPatientLabs.Columns.Add("التحليل الرئيسيي");
                dtPatientLabs.Columns.Add("التحليل الفرعي");
                dtPatientLabs.Columns.Add("التاريخ");

                foreach (var item in Model.KimoSurveyEntity.CTHChemoLabCollection)
                {
                    DataRow drPatientLab = dtPatientLabs.NewRow();
                    drPatientLab[0] = item.CTHLabDetailItem.CTHLabItem.ArLabName;
                    drPatientLab[1] = item.CTHLabDetailItem.ArLabDetailsName;
                    drPatientLab[2] = item.Date.ToString();
                    dtPatientLabs.Rows.Add(drPatientLab);
                }

                DataTable dtPatientDrugs = new DataTable();
                dtPatientDrugs.Columns.Add("المسار");
                dtPatientDrugs.Columns.Add("الأسم");
                dtPatientDrugs.Columns.Add("الجرعة/الوحدة");
                dtPatientDrugs.Columns.Add("المدة الزمنية/الوحدة");
                dtPatientDrugs.Columns.Add("كل/الوحدة");
                dtPatientDrugs.Columns.Add("الكمية/المحلول");
                dtPatientDrugs.Columns.Add("التركيز النهائي");
                dtPatientDrugs.Columns.Add("الكمية/الشكل");
                dtPatientDrugs.Columns.Add("ملاحظات إدارية");
                dtPatientDrugs.Columns.Add("التوقيت الإداري");
                if (Model.KimoSurveyEntity.CTHPatientDrugCollection.Where(c => c.RouteID == (int)Route.Iv).Count() > 0)
                {
                    DataRow dr1PatientDrug = dtPatientDrugs.NewRow();
                    dr1PatientDrug[0] = "IV";
                    dr1PatientDrug[1] = " ";
                    dr1PatientDrug[2] = " ";
                    dr1PatientDrug[3] = " ";
                    dr1PatientDrug[4] = " ";
                    dr1PatientDrug[5] = " ";
                    dr1PatientDrug[6] = " ";
                    dr1PatientDrug[7] = " ";
                    dr1PatientDrug[8] = " ";
                    dr1PatientDrug[9] = " ";
                    dtPatientDrugs.Rows.Add(dr1PatientDrug);
                }
                var count = 0;
                foreach (var item in Model.KimoSurveyEntity.CTHPatientDrugCollection.Where(c => c.CTHDrugItem.RouteID == (int)Route.Iv))
                {
                    DataRow dr2PatientDrug = dtPatientDrugs.NewRow();
                    dr2PatientDrug[count] = " ";
                    count++;
                    dr2PatientDrug[count] = item.CTHDrugItem.ArName;
                    count++;
                    dr2PatientDrug[count] = item.CTHDrugItem.Dose + " " + item.CTHDrugItem.CTHDoseUnitItem.ArName;
                    count++;
                    dr2PatientDrug[count] = item.CTHDrugItem.Duration + " " + Enum.GetName(typeof(DurationUnit), item.CTHDrugItem.DurationUnitID);
                    count++;
                    dr2PatientDrug[count] = item.CTHDrugItem.Every + " " + Enum.GetName(typeof(DurationUnit), item.CTHDrugItem.EveryUnitID);
                    count++;
                    dr2PatientDrug[count] = item.CTHDrugItem.SolutionAmount + " " + item.CTHDrugItem.CTHSolutionItem.ArName;
                    count++;
                    dr2PatientDrug[count] = item.CTHDrugItem.ArFinalConcentration;
                    count++;
                    dr2PatientDrug[count] = " ";
                    count++;
                    dr2PatientDrug[count] = " ";
                    count++;
                    dr2PatientDrug[count] = " ";
                    count = 0;
                    dtPatientDrugs.Rows.Add(dr2PatientDrug);
                }

                if (Model.KimoSurveyEntity.CTHPatientDrugCollection.Where(c => c.RouteID == (int)Route.Po).Count() > 0)
                {
                    DataRow dr3PatientDrug = dtPatientDrugs.NewRow();
                    dr3PatientDrug[0] = "PO";
                    dr3PatientDrug[1] = " ";
                    dr3PatientDrug[2] = " ";
                    dr3PatientDrug[3] = " ";
                    dr3PatientDrug[4] = " ";
                    dr3PatientDrug[5] = " ";
                    dr3PatientDrug[6] = " ";
                    dr3PatientDrug[7] = " ";
                    dr3PatientDrug[8] = " ";
                    dr3PatientDrug[9] = " ";
                    dtPatientDrugs.Rows.Add(dr3PatientDrug);
                }
                count = 0;
                foreach (var item in Model.KimoSurveyEntity.CTHPatientDrugCollection
                    .Where(c => c.CTHDrugItem.RouteID == (int)Route.Po))
                {
                    DataRow dr4PatientDrug = dtPatientDrugs.NewRow();
                    dr4PatientDrug[count] = " ";
                    count++;
                    dr4PatientDrug[count] = item.CTHDrugItem.ArName;
                    count++;
                    dr4PatientDrug[count] = item.CTHDrugItem.Dose + " " + item.CTHDrugItem.CTHDoseUnitItem.ArName;
                    count++;
                    dr4PatientDrug[count] = item.CTHDrugItem.Duration + " " + Enum.GetName(typeof(DurationUnit), item.CTHDrugItem.DurationUnitID);
                    count++;
                    dr4PatientDrug[count] = item.CTHDrugItem.Every + " " + Enum.GetName(typeof(DurationUnit), item.CTHDrugItem.EveryUnitID);
                    count++;
                    dr4PatientDrug[count] = " ";
                    count++;
                    dr4PatientDrug[count] = " ";
                    count++;
                    dr4PatientDrug[count] = item.CTHDrugItem.FormAmount + " " + Enum.GetName(typeof(Form), item.CTHDrugItem.FormID);
                    count++;
                    dr4PatientDrug[count] = item.CTHDrugItem.ArSpecialAdminstrationNotes;
                    count++;
                    dr4PatientDrug[count] = " ";
                    count = 0;
                    dtPatientDrugs.Rows.Add(dr4PatientDrug);
                }

                if (Model.KimoSurveyEntity.CTHPatientDrugCollection.Where(c => c.RouteID == (int)Route.Sc).Count() > 0)
                {
                    DataRow dr5PatientDrug = dtPatientDrugs.NewRow();
                    dr5PatientDrug[0] = "SC";
                    dr5PatientDrug[1] = " ";
                    dr5PatientDrug[2] = " ";
                    dr5PatientDrug[3] = " ";
                    dr5PatientDrug[4] = " ";
                    dr5PatientDrug[5] = " ";
                    dr5PatientDrug[6] = " ";
                    dr5PatientDrug[7] = " ";
                    dr5PatientDrug[8] = " ";
                    dr5PatientDrug[9] = " ";
                    dtPatientDrugs.Rows.Add(dr5PatientDrug);
                }
                count = 0;
                foreach (var item in Model.KimoSurveyEntity.CTHPatientDrugCollection
                    .Where(c => c.CTHDrugItem.RouteID == (int)Route.Sc))
                {
                    DataRow dr6PatientDrug = dtPatientDrugs.NewRow();
                    dr6PatientDrug[count] = " ";
                    count++;
                    dr6PatientDrug[count] = item.CTHDrugItem.ArName;
                    count++;
                    dr6PatientDrug[count] = item.CTHDrugItem.Dose + " " + item.CTHDrugItem.CTHDoseUnitItem.ArName;
                    count++;
                    dr6PatientDrug[count] = item.CTHDrugItem.Duration + " " + Enum.GetName(typeof(DurationUnit), item.CTHDrugItem.DurationUnitID);
                    count++;
                    dr6PatientDrug[count] = item.CTHDrugItem.Every + " " + Enum.GetName(typeof(DurationUnit), item.CTHDrugItem.EveryUnitID);
                    count++;
                    dr6PatientDrug[count] = " ";
                    count++;
                    dr6PatientDrug[count] = " ";
                    count++;
                    dr6PatientDrug[count] = " ";
                    count++;
                    dr6PatientDrug[count] = " ";
                    count++;
                    dr6PatientDrug[count] = " ";
                    count = 0;
                    dtPatientDrugs.Rows.Add(dr6PatientDrug);
                }

                if (Model.KimoSurveyEntity.CTHPatientDrugCollection.Where(c => c.RouteID == (int)Route.Im).Count() > 0)
                {
                    DataRow dr7PatientDrug = dtPatientDrugs.NewRow();
                    dr7PatientDrug[0] = "IM";
                    dr7PatientDrug[1] = " ";
                    dr7PatientDrug[2] = " ";
                    dr7PatientDrug[3] = " ";
                    dr7PatientDrug[4] = " ";
                    dr7PatientDrug[5] = " ";
                    dr7PatientDrug[6] = " ";
                    dr7PatientDrug[7] = " ";
                    dr7PatientDrug[8] = " ";
                    dr7PatientDrug[9] = " ";
                    dtPatientDrugs.Rows.Add(dr7PatientDrug);
                }
                count = 0;
                foreach (var item in Model.KimoSurveyEntity.CTHPatientDrugCollection
                    .Where(c => c.CTHDrugItem.RouteID == (int)Route.Im))
                {
                    DataRow dr8PatientDrug = dtPatientDrugs.NewRow();
                    dr8PatientDrug[count] = " ";
                    count++;
                    dr8PatientDrug[count] = item.CTHDrugItem.ArName;
                    count++;
                    dr8PatientDrug[count] = item.CTHDrugItem.Dose + " " + item.CTHDrugItem.CTHDoseUnitItem.ArName;
                    count++;
                    dr8PatientDrug[count] = item.CTHDrugItem.Duration + " " + Enum.GetName(typeof(DurationUnit), item.CTHDrugItem.DurationUnitID);
                    count++;
                    dr8PatientDrug[count] = item.CTHDrugItem.Every + " " + Enum.GetName(typeof(DurationUnit), item.CTHDrugItem.EveryUnitID);
                    count++;
                    dr8PatientDrug[count] = item.CTHDrugItem.SolutionAmount + " " + item.CTHDrugItem.CTHSolutionItem.ArName;
                    count++;
                    dr8PatientDrug[count] = " ";
                    count++;
                    dr8PatientDrug[count] = " ";
                    count++;
                    dr8PatientDrug[count] = " ";
                    count++;
                    dr8PatientDrug[count] = item.CTHDrugItem.ArTimeOfAdminstration.ToString();
                    count = 0;
                    dtPatientDrugs.Rows.Add(dr8PatientDrug);
                }

                DataTable Table1 = new DataTable();
                Table1.Columns.Add("بيانات المريض و السجل المرضي");
                DataTable Table2 = new DataTable();
                Table2.Columns.Add("البروتوكول");
                DataTable Table3 = new DataTable();
                Table3.Columns.Add("الإستقصاء");
                DataTable Table4 = new DataTable();
                Table4.Columns.Add("مخدر");
                Tables.Add(Table1);
                Tables.Add(dtPatientData);
                Tables.Add(dtDiagnosis);
                Tables.Add(Table2);
                Tables.Add(dtProtocolData);
                Tables.Add(Table3);
                Tables.Add(dtPatientLabs);
                Tables.Add(Table4);
                Tables.Add(dtPatientDrugs);
                Header = "إطبع الورقة";
            }
            return DownloadAsPDF(Tables, Model.KimoSurveyEntity.ID, Header);
        }

        public ActionResult DownloadAsPDF(List<DataTable> dataTable, int ChemoID, string Header)
        {
            var webRoot = _env.WebRootPath;
            var TempFolder = System.IO.Path.Combine(webRoot, "TempFiles", Guid.NewGuid().ToString("N"));
            if (!Directory.Exists(TempFolder))
                Directory.CreateDirectory(TempFolder);
            var fileTosave = System.IO.Path.ChangeExtension(System.IO.Path.Combine(TempFolder,"Print Out Sheet #" + ChemoID), "pdf");
            DataHelper.ExportToPdf(dataTable, fileTosave, Header);
            var file = _fileService.ReadFile(fileTosave);
            System.IO.Directory.Delete(TempFolder, true);
            if (file == null || file.Length < 1)
                return Content("");
            return File(file, System.Net.Mime.MediaTypeNames.Application.Octet, Path.ChangeExtension(Guid.NewGuid().ToString("N"), Path.GetExtension(fileTosave)));
        }

    }

}