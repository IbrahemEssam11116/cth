using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SStorm.CTH.DAL.EntityClasses;
using SStorm.CTH.DAL.HelperClasses;
using SStorm.CTH.BL.Helpers;
using SStorm.CTH.DAL;
using SStorm.CTH.Web.Models;
using SStorm.CTH.Web.Infrastructure;

namespace SStorm.CTH.Web.Controllers
{
    public class NotificationController : SmartController
    {
        private readonly IUserService _userService;
        public NotificationController(IClientNotification notifier, IUserService _userService) : base(notifier)
        {
            this._userService = _userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public EntityCollection<CTHNotificationEntity> GetNotification()
        {
            EntityCollection<CTHNotificationEntity> UserNotification = new EntityCollection<CTHNotificationEntity>();
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHNotificationEntity);
            path.Add(CTHNotificationEntity.PrefetchPathCTHDoctorItem, true)
                .SubPath.Add(CTHDoctorEntity.PrefetchPathCTHUserItem);
            path.Add(CTHNotificationEntity.PrefetchPathCTHPatientItem, true)
                 .SubPath.Add(CTHPatientEntity.PrefetchPathCTHUserItem);
            BL.DataBaseClassHelper.FillCollection(UserNotification, null, 0, null, path, 0, 0);
            EntityCollection<CTHNotificationEntity> CTHNotifications = new EntityCollection<CTHNotificationEntity>();
            foreach (var item in UserNotification)
            {
                DateTime DateTime = ((DateTime)item.NotificationDate);
                if (DateTime <= DateTime.Now)
                {
                    if (item.DoctorID == null && item.CTHPatientItem.CTHUserItem.ID == _userService.GetCurrentUserID())
                    {
                        item.NotificationDate = DateTime;
                        RelationPredicateBucket notiFilter = new RelationPredicateBucket(CTHNotificationFields.ID == item.ID);
                        CTHNotifications.Add(item);
                    }

                    if (item.DoctorID != null && item.CTHDoctorItem.CTHUserItem.ID == _userService.GetCurrentUserID())
                    {
                        item.NotificationDate = DateTime;
                        RelationPredicateBucket notiFilter = new RelationPredicateBucket(CTHNotificationFields.ID == item.ID);
                        CTHNotifications.Add(item);
                    }
                }
            }
            return CTHNotifications;
        }

        public ActionResult NotificationHeader()
        {
            var model = GetNotification();
            return PartialView(model);
        }

    }
}