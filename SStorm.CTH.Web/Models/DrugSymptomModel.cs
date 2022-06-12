using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class DrugSymptomModel
    {
        public CTHDrugSymptomEntity DrugSymptomEntity { get; set; }
        public SelectList SymptomList { get; set; }
        public int ProtocolID { get; set; }
    }
}
