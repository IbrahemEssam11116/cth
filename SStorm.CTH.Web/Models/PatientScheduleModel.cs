using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class PatientScheduleModel
    {
        public CTHPatientEntity patientEntity { get; set; }
        public DateTime Date { get; set; }
    }
}
