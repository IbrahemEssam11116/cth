using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class CycleLabModel
    {
        public CTHLabDetailEntity labDetailEntity { get; set; }
        public CTHProtocolCycleEntity protocolCycleEntity { get; set; }
        public CTHCycleLabEntity cycleLabEntity { get; set; }
        public SelectList CycleList { get; set; }

        public SelectList LabListEdit { get; set; }
        public IEnumerable<SelectListItem> LabList { get; set; }
        public SelectList LabDetailsList { get; set; }

  

    }
}
