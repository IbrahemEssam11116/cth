using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Models
{
    public class UserModel
    {
        public string UserName { get; set; }

        public string FullName { get; set; }


        public List<string> Roles { get; set; }
        public List<string> Permissions { get; set; }

        public UserModel()
        {
            Permissions = new List<string>();
        }
    }
}