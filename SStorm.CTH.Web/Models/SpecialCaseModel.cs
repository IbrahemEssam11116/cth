using SStorm.CTH.DAL.HelperClasses;
using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class SpecialCaseModel
    {
        public EntityCollection<CTHSpecialCaseEntity> SpecialCaseCollection { get; set; }
        public EntityCollection<CTHSpecialCasePartEntity> SpecialCasePartCollection { get; set; }

        public CTHSpecialCaseEntity SpecialCaseEntity { get; set; }
        public CTHSpecialCasePartEntity SpecialCasePartEntity { get; set; }
    }
}
