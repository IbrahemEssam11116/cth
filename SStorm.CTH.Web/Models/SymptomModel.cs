using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class SymptomModel
    {
        public CTHSymptomEntity SymptomEntity { get; set; }
        public CTHSymptomDrugEntity SymptomDrugEntity { get; set; }

        public List<SelectListItem> GradeList { get; set; }
        public SelectList DrugList { get; set; }

    }
}
