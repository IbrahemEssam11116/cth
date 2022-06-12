using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class LabListModel
    {
        public int ID { get; set; }
        public string  LabName { get; set; }
        public string LabDetailName { get; set; }
        public string TextResult { get; set; }
        public IFormFile AttachmentResultToUpload { get; set; }
        public string AttachmentResultToDownload { get; set; }
        public DateTime Date { get; set; }
    }
}
