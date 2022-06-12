using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using SStorm.CTH.DAL.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class TNMStagingModel
    {
        public CTHTNMStagingMatrixEntity TNMStaging { get; set; }
        public CTHStagingEntity stagingEntity { get; set; }
        public IEnumerable<SelectListItem> TumorSizeList { get; set; }
        public IEnumerable<SelectListItem> LymphNodeList { get; set; }
        public IEnumerable<SelectListItem> DistantMetastasisList { get; set; }
        public IEnumerable<SelectListItem> StagingList { get; set; }
        public EntityCollection<CTHTNMStagingEntity> TNMStagingCollection{ get; set; }
        public EntityCollection<CTHStagingEntity> StagingCollection { get; set; }
    }
}
