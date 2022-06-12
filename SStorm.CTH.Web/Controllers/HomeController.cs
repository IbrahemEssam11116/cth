using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SStorm.CTH.DAL.EntityClasses;
using SStorm.CTH.DAL.HelperClasses;
using SStorm.CTH.Web.Infrastructure;
using SStorm.CTH.Web.Models;

namespace SStorm.CTH.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileService _fileService;
        public HomeController(ILogger<HomeController> logger, IFileService fileService)
        {
            _logger = logger;
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public ActionResult MainCancerType()
        {
            CTHMainCancerImageEntity mainCancerImageEntity = new CTHMainCancerImageEntity();
            EntityCollection<CTHMainCancerImageEntity> collection = new EntityCollection<CTHMainCancerImageEntity>();
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(collection, null, 0, null, null, 0, 0);
            if(collection.Count > 0)
            {
                var id = collection.First().ID;
                mainCancerImageEntity = new CTHMainCancerImageEntity(id);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(mainCancerImageEntity, null);
                if (!string.IsNullOrWhiteSpace(mainCancerImageEntity.SolidTumorImage))
                {
                    var fileBytes = this._fileService.ReadFile(mainCancerImageEntity.SolidTumorImage);
                    if (fileBytes != null)
                    {
                        var Base64String = Convert.ToBase64String(fileBytes);
                        mainCancerImageEntity.SolidTumorImage = string.Format("data:SolidTumorImage/jpeg;base64,{0}", Base64String);
                    }
                }
                if (!string.IsNullOrWhiteSpace(mainCancerImageEntity.HematologicTumorImage))
                {
                    var fileBytes = this._fileService.ReadFile(mainCancerImageEntity.HematologicTumorImage);
                    if (fileBytes != null)
                    {
                        var Base64String = Convert.ToBase64String(fileBytes);
                        mainCancerImageEntity.HematologicTumorImage = string.Format("data:HematologicTumorImage/jpeg;base64,{0}", Base64String);
                    }
                }
            }
            return View(mainCancerImageEntity);
        }

        [HttpGet]
        public ActionResult ChangeMainCancerImage(int ID, string Type)
        {
            MainCancerModel model = new MainCancerModel();
            model.mainCancerImageEntity = new CTHMainCancerImageEntity();
            model.mainCancerImageEntity.ImageNum = 0;
            if (ID > 0)
            {
                model.mainCancerImageEntity = new CTHMainCancerImageEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(model.mainCancerImageEntity, null);
                model.mainCancerImageEntity.ImageNum += 1;
            }
            model.Type = Type;
            return PartialView(model);
        }

        [HttpPost]
        public async Task<ActionResult> ChangeMainCancerImage(MainCancerModel model)
        {
            if(model.Type == "Solid")
            {
                model.mainCancerImageEntity.SolidTumorImage = await this._fileService.SaveFile((int)model.mainCancerImageEntity.ImageNum,  model.Image);
            }
            else
            {
                model.mainCancerImageEntity.HematologicTumorImage = await this._fileService.SaveFile((int)model.mainCancerImageEntity.ImageNum, model.Image);
            }
            if(model.mainCancerImageEntity.ID > 0)
            {
                RelationPredicateBucket filter = new RelationPredicateBucket(CTHMainCancerImageFields.ID == model.mainCancerImageEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(model.mainCancerImageEntity, filter, 0);
            }
            else
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.mainCancerImageEntity, true, false, 0);
            }
            return RedirectToAction("MainCancerType");
        }
        public ActionResult DownloadFile(string path)
        {
            var file = _fileService.ReadFile(path);
            if (file == null || file.Length < 1)
                return Content("");

            return File(file, System.Net.Mime.MediaTypeNames.Application.Octet, Path.ChangeExtension(path, Path.GetExtension(path)));
        }
        public bool SeeNotify(int ID)
        {
            CTHNotificationEntity noti = new CTHNotificationEntity(ID);
            BL.DataBaseClassHelper.FillEntity(noti, null);
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHNotificationFields.ID == ID);
            noti.Seen = true;
            BL.DataBaseClassHelper.UpdateEntityDirectly(noti, filter, 0);
            return true;
        }
    }
}
