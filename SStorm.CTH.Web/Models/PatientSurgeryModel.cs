using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class PatientSurgeryModel
    {
        public CTHPatientSurgeryEntity PatientSurgery { get; set; }
        public IEnumerable<SelectListItem> SurgeryTypeList { get; set; }

    }
}
