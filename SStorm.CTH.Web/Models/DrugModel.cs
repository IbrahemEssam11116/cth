using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class DrugModel
    {
        public CTHDrugEntity DrugEntity { get; set; }
        public List<SelectListItem> RouteList { get; set; }

        public List<SelectListItem> PerList { get; set; }
        public SelectList DoseUnitList { get; set; }
        public List<SelectListItem> DurationUnitList { get; set; }
        public SelectList SolutionList { get; set; }
        public List<int> Days { get; set; }
        public int CancerID { get; set; }

        public int Index { get; set; }

        public int CycleID { get; set; }

        public int KimoID { get; set; }
        public List<SelectListItem> FormList { get; set; }

        public CTHPatientDrugEntity PatientDrugEntity { get; set; }
        public CTHDrugAttachmentEntity DrugAttachmentEntity { get; set; }
        public IFormFile file { get; set; }

        // to make add new dose unit
        public CTHDoseUnitEntity DoseUnitEntity { get; set; }
    }
}