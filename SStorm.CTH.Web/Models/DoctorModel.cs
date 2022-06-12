using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class DoctorModel
    {
        public CTHDoctorEntity DoctorEntity { get; set; }
        public CTHUserEntity UserEntity { get; set; }

    }
}
