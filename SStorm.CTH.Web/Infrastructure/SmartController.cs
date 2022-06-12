using Microsoft.AspNetCore.Mvc;
using SStorm.CTH.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web
{
    public class SmartController : Controller
    {
        private readonly IClientNotification _notifier;

        public SmartController(IClientNotification notifier)
        {
            this._notifier = notifier;
        }

        #region Notifications

        protected virtual void AddToastNotify(string message, Helper.NotificationHelper.NotificationType type)
        {
            _notifier.AddToastNotification(message, type,
                                           new ToastNotificationOption
                                           {
                                               ProgressBar = true,
                                               PositionClass = "toast-bottom-right"
                                           });
        }

        protected virtual void AddToastNotify(string message, Helper.NotificationHelper.NotificationType type, ToastNotificationOption options)
        {
            _notifier.AddToastNotification(message, type, options);
        }

        protected virtual void AddSweetNotification(string title, string message, Helper.NotificationHelper.NotificationType notificationType)
        {
            _notifier.AddSweetNotification(title, message, notificationType);

        }

        #endregion

        //protected JsonResult GetJsonValidationErrors()
        //{
        //    var errorList = new List<JsonValidationError>();
        //    foreach (var key in ModelState.Keys)
        //    {
        //        ModelState modelState = null;
        //        if (ModelState.TryGetValue(key, out modelState))
        //        {
        //            foreach (var error in modelState.Errors)
        //            {
        //                errorList.Add(new JsonValidationError()
        //                {
        //                    Key = key,
        //                    Message = error.ErrorMessage
        //                });
        //            }
        //        }
        //    }

        //    var response = new JsonResponse(errorList);

        //    Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
        //    Response.StatusDescription = "Validation";
        //    return Json(response, "application/json", JsonRequestBehavior.DenyGet);
        //}

        #region Nested Classes

        protected class JsonResponse
        {
            public JsonResponse(IEnumerable<JsonValidationError> errors)
            {
                Errors = errors;
            }

            public IEnumerable<JsonValidationError> Errors { get; set; }

            public JsonResponse()
            {
                Errors = new List<JsonValidationError>();
            }
        }

        protected class JsonValidationError
        {
            public string Key { get; set; }
            public string Message { get; set; }
        }

        #endregion
    }
}
