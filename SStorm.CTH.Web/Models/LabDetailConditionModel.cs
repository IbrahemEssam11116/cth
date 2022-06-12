using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using SStorm.CTH.DAL.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class LabDetailConditionModel
    {
        public CTHLabDetailConditionEntity LabDetailConditionEntity { get; set; }
        public CTHLabDetailEntity LabDetailEntity { get; set; }
        public IEnumerable<SelectListItem> OpertorList { get; set; }
    }
}
