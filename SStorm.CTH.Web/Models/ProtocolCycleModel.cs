using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class ProtocolCycleModel
    {
        public CTHChemotherapyProtocolEntity ChemotherapyProtocolEntity { get; set; }
        public CTHProtocolCycleEntity protocolCycleEntity { get; set; }
        public List<SelectListItem> EveryUnitList { get; set; }

        public SelectList ProtocolList { get; set; }
    }
}
