using SStorm.CTH.DAL.EntityClasses;
using SStorm.CTH.DAL.HelperClasses;
using SStorm.CTH.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Infrastructure
{
    public interface IUserService
    {

        Task<UserModel> GetAllowedUser(string userName, string password);
        int GetCurrentUserID();
        //EntityCollection<CTHNotificationEntity> GetNotification();
        ProfileModel profile();
    }
}
