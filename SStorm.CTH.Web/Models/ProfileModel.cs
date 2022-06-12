using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class ProfileModel
    {
        public CTHDoctorEntity doctorEntity { get; set; }
        public CTHPatientEntity PatientEntity { get; set; }
        public int Type { get; set; }
    }
}
