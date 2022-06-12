using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class PremedicationModel
    {
        public CTHPreMedicationEntity PreMedicationEntity { get; set; }
        public List<SelectListItem> EmetogenicList { get; set; }
    }
}
