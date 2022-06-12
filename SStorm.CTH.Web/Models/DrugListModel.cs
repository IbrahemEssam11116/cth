using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class DrugListModel
    {
        public int ID { get; set; }
        public string DrugName { get; set; }
        public decimal DrugDose { get; set; }
        public int DrugDoseUnit { get; set; }
        public int DrugDosePer { get; set; }
        public SelectList DrugDoseUnitList { get; set; }
        public List<SelectListItem> DrugDosePerList { get; set; }
        public decimal DoseModification { get; set; }
        public int RouteID { get; set; }
        public List<SelectListItem> RouteList { get; set; }
        public DateTime Date { get; set; }
    }
}
