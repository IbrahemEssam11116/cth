using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class CycleDrugModel
    {
        public CTHCycleDrugEntity cycleDrugEntity { get; set; }
        public CTHProtocolCycleEntity protocolCycleEntity { get; set; }
        public CTHDrugEntity drugEntity { get; set; }
        public SelectList CycleList { get; set; }

        public SelectList DrugList { get; set; }

    }
}
