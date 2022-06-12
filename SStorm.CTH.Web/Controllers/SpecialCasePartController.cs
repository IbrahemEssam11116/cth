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
    public class SpecialCasePartController : SmartController
    {
        public SpecialCasePartController(IClientNotification _clientNotification)
           : base(_clientNotification)
        {

        }
        [SmartAuthorize(UserPermission.SpecialCase_ViewParts)]
        [HttpGet]
        public IActionResult Index(int ID)
        {
            CTHSpecialCaseEntity CTHSpecialCaseEntity = new CTHSpecialCaseEntity(ID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHSpecialCaseEntity);
            path.Add(CTHSpecialCaseEntity.PrefetchPathCTHSpecialCasePartCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CTHSpecialCaseEntity, path);
            return View(CTHSpecialCaseEntity);
        }

        [SmartAuthorize(UserPermission.SpecialCase_EditCreatePart)]
        [HttpGet]
        public IActionResult EditCreate(int ID, int CaseID)
        {
            CTHSpecialCasePartEntity Part = new CTHSpecialCasePartEntity();
            if (ID > 0)
            {
                Part = new CTHSpecialCasePartEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(Part, null);
            }
            Part.CaseID = CaseID;

            return PartialView(Part);
        }

        [SmartAuthorize(UserPermission.SpecialCase_EditCreatePart)]
        [HttpPost]
        public IActionResult EditCreate(CTHSpecialCasePartEntity Part)
        {
            if (Part.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(Part, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHSpecialCasePartFields.ID == Part.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(Part, filter, 0);
            }
            AddSweetNotification("Done","Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index" , new { ID = Part.CaseID});
        }


        [SmartAuthorize(UserPermission.SpecialCase_DeletePart)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.SpecialCase_DeletePart)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHSpecialCasePartEntity item = new CTHSpecialCasePartEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHSpecialCasePartEntity);
            path.Add(CTHSpecialCasePartEntity.PrefetchPathCTHKimoSurveyCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            int CaseID = (int)item.CaseID;
            if (item.CTHKimoSurveyCollection.Count == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Done","You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);
            }

            return RedirectToAction("Index", new {ID = CaseID });
        }

    }
}