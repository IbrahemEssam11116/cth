
using static SStorm.CTH.Web.Helper.NotificationHelper;

namespace SStorm.CTH.Web.Infrastructure
{
    public interface IClientNotification
    {
        void AddToastNotification(string message, NotificationType type, ToastNotificationOption options);
        void AddSweetNotification(string title, string detail, NotificationType type);
    }
}
