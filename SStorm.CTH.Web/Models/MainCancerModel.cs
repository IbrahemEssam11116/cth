using Microsoft.AspNetCore.Http;
using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class MainCancerModel
    {
        public CTHMainCancerImageEntity mainCancerImageEntity { get; set; }
        public IFormFile Image { get; set; }
        public string Type { get; set; }
    }
}
