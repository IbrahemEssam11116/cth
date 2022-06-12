using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class AssessmentModel
    {
        public CTHPatientAssessmentEntity assessmentEntity { get; set; }
        public SelectList TreatmentPlanList { get; set; }
        public SelectList TreatmentResponseList { get; set; }
    }
}
