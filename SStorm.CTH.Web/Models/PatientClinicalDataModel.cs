using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class PatientClinicalDataModel
    {
        public CTHPatientClinicalDataEntity PatientClinicalData { get; set; }
        public IEnumerable<SelectListItem> CancerTypeList { get; set; }
        public IEnumerable<SelectListItem> CancerSideList { get; set; }
        public IEnumerable<SelectListItem> TumorGradeList { get; set; }
        public IEnumerable<SelectListItem> SurgeryTypeList { get; set; }
        public CTHPatientSurgeryEntity PatientSurgery { get; set; }
        public IEnumerable<SelectListItem> HistologicalSubTypeCancerList { get; set; }
        public IEnumerable<SelectListItem> MolecularSubTypeList { get; set; }
        public IEnumerable<SelectListItem> TumorSizeList { get; set; }
        public IEnumerable<SelectListItem> LymphNodeList { get; set; }
        public IEnumerable<SelectListItem> DistantMetastasisList { get; set; }

        public CTHPatientImagingEntity PatientImagingEntity { get; set; }
        public IEnumerable<SelectListItem> ImagingTypeList { get; set; }

        public CTHPatientIntialLabEntity PatientLabEntity { get; set; }
        public IEnumerable<SelectListItem> LabList { get; set; }
        public IEnumerable<SelectListItem> LabDetalisList { get; set; }


        public CTHPatientPathologyReportEntity PathologyReportEntity { get; set; }
        public IEnumerable<SelectListItem> ReportTypeList { get; set; }

        public IFormFile Image { get; set; }
        public IFormFile LabAttachmentResult { get; set; }
        public IFormFile ImageAttachmentResult { get; set; }

        public CTHCancerTypeEntity CancerTypeEntity { get; set; }
        public CTHCancerMolecularEntity CancerMolecularEntity { get; set; }
        public CTHCancerHistologicEntity CancerHistologicEntity { get; set; }
        public SelectList CancerList { get; set; }
        public SelectList MelocularList { get; set; }
        public SelectList HistologicalList { get; set; }


    }
}
