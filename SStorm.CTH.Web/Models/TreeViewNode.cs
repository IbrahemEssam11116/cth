using SStorm.CTH.DAL.EntityClasses;
using SStorm.CTH.DAL.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class TreeViewNode
    {
        public EntityCollection<CTHCancerTypeEntity> CancerTypeCollection { get; set; }
        public int? Seed { get; set; }
        public CTHCancerTypeEntity CancerType { get; set; }
        public EntityCollection<CTHCancerHistologicEntity> HistologicCollection { get; set; }
        public EntityCollection<CTHCancerMolecularEntity> MolecularCollection { get; set; }
        public EntityCollection<CTHStagingEntity> StagingCollection { get; set; }
        public EntityCollection<CTHSurgeryTypeEntity> SurgeryTypeCollection { get; set; }
    }

}
