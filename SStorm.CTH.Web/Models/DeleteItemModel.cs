﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class DeleteItemModel
    {

        public int ItemID { get; set; }

        public string ActionName { get; set; }

        public string ControllerName { get; set; }

        /// <summary>
        /// Html container
        /// </summary>
        public string DataAjaxUpdate { get; set; }

        public string DataAjaxMethod { get; set; }
        public bool DataAjax { get; set; }
        public string DataAjaxSuccess { get; set; }

    }
}
