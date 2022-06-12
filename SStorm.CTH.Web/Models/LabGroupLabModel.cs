using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class LabGroupLabModel: SearchFacade<SStorm.CTH.DAL.EntityClasses.CTHLabGroupLabEntity>
    {
        public int LabGroupID { get; set; }
        public IEnumerable<SelectListItem> LabList { get; set; }
        public CTHLabGroupLabEntity labGroupLabEntity { get; set; }
    }
}
