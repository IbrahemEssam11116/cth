using SStorm.CTH.DAL.EntityClasses;
using SStorm.CTH.DAL.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class TreeBrowserDisplayModel
    {
        public EntityCollection<CTHCancerTypeEntity> CancerTypeModel { get; set; }
        public TreeBrowserDisplayModel()
        {
            CancerTypeModel = new EntityCollection<CTHCancerTypeEntity>();
        }
    }
}
