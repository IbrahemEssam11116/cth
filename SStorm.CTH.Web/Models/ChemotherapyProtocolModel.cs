using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class ChemotherapyProtocolModel
    {
        public CTHChemotherapyProtocolEntity ChemotherapyProtocolEntity { get; set; }
        public List<SelectListItem> EmatogenicRiskList { get; set; }
        public IEnumerable<SelectListItem> PreMedicationList { get; set; }
        public IEnumerable<SelectListItem> CancerTypeList { get; set; }

        public int ID { get; set; }

        //to make add new premidication
        public CTHPreMedicationEntity PreMedicationEntity { get; set; }
    }
}
