using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class PatientSymptomModel
    {
        public bool IsNewSymptom { get; set; }
        public SelectList SymptomList { get; set; }
        public List<SelectListItem> DurationUnitList { get; set; }
        public CTHPatientSymptomEntity PatientSymptom { get; set; }
        public CTHSymptomEntity Symptom { get; set; }
    }
}
