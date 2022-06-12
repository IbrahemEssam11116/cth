using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class PatientModel
    {
        public CTHPatientEntity PatientEntity { get; set; }
        public IFormFile NationalIDPhoto { get; set; }
        public IEnumerable<SelectListItem> PaymentTypeList { get; set; }
        public IEnumerable<SelectListItem>  DoctorList { get; set; }

        public int ClinicalDataID { get; set; }
    }
}
