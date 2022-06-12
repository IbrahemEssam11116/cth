using Microsoft.AspNetCore.Mvc.Rendering;
using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class LabModel
    {
        public CTHLabEntity LabEntity { get; set; }
        public CTHLabGroupLabEntity CTHLabGroupLabEntity { get; set; }
        public IEnumerable<SelectListItem> ProtocolList { get; set; }
        public int CancerTypeID { get; set; }
        public int ChProID { get; set; }
        public int CycleID { get; set; }
        public int Index { get; set; }
        public IEnumerable<SelectListItem> LabList { get; set; }
        public List<SelectListItem> labdetlist { get; set; }

        public LabModel()
        {
            LabList = new List<SelectListItem>();
            labdetlist = new List<SelectListItem>();
        }
    }

    public class LabDetailsModel
    {
        public CTHLabDetailEntity LabDetailEntity { get; set; }
        public IEnumerable<SelectListItem> LablList { get; set; }
        public int CycleID { get; set; }
        public int KimoID { get; set; }

        public int Index { get; set; }


    }

    public class LChemoLabModel
    {
        public CTHChemoLabEntity CTHChemoLabEntity { get; set; }
        public CTHKimoSurveyEntity KimoSurveyEntity { get; set; }

        public CTHLabEntity CTHLabEntity { get; set; }

        public string LabName { get; set; }

        public string LabDetailsName { get; set; }
        public int NextcycleID { get; set; }
        public int KimoID { get; set; }

        public int Index { get; set; }

        public List<SelectListItem> LabList { get; set; }
        public List<SelectListItem> labdetlist { get; set; }
        public LChemoLabModel()
        {
            LabList = new List<SelectListItem>();
            labdetlist = new List<SelectListItem>();
        }
    }

}
