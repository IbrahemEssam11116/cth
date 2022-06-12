using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using SStorm.CTH.DAL.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class KimoSurveyModel
    {
        public CTHKimoSurveyEntity KimoSurveyEntity { get; set; }
        public CTHPatientClinicalDataEntity PatientClinicalDataEntity { get; set; }
        public IEnumerable<SelectListItem> ProtocolList { get; set; }
        public SelectList ProtocolCycleList { get; set; }
        public IEnumerable<SelectListItem> SpecialCaseList { get; set; }
        public IEnumerable<SelectListItem> SpecialCasePartList { get; set; }
        public IEnumerable<SelectListItem> TreatementList { get; set; }

        public List<SelectListItem> LabDetailsList { get; set; }

        public List<SelectListItem> LabList { get; set; }
        public List<SelectListItem> DrugList { get; set; }
        public int NextcycleNumber { get; set; }
        public int NextcycleID { get; set; }
        public int cyclenum { get; set; }
        public CTHChemoLabEntity ChemoLabEntity { get; set; }
        public CTHPatientDrugEntity PatientDrugEntity { get; set; }

        public CTHDrugEntity DrugEntity { get; set; }
        public CTHLabDetailEntity cTHLabDetailEntity { get; set; }

        public List<CTHLabEntity> uniquecollLab { get; set; }

        public List<CTHDrugEntity> uniquecollDrug { get; set; }

        public IEnumerable<IGrouping<int?,CTHDrugEntity>> GroupByuniquecollDrug { get; set; }

        //protocole cycle entity
        public CTHProtocolCycleEntity ProtocolCycleEntity { get; set; }
        public KimoSurveyModel()
        {
            LabList = new List<SelectListItem>();
            LabDetailsList = new List<SelectListItem>();
            DrugList = new List<SelectListItem>();
            uniquecollLab = new List<CTHLabEntity>();
            uniquecollDrug = new List<CTHDrugEntity>();

        }

        public List<DrugListModel> ChemoDrugs { get; set; }
        public List<LabListModel> ChemoLabs { get; set; }
    }
}
