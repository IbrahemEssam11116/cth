using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SStorm.CTH.Web.Components
{

    [ViewComponent(Name = "SStorm.CTH.Web.Notify")]
    public class NotificationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Notification");
        }
    }
}