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
    public class ChemotherapyProtocolController : SmartController
    {
        public ChemotherapyProtocolController(IClientNotification _clientNotification)
         : base(_clientNotification)
        {

        }
        #region ChemotherapyProtocol 

        [SmartAuthorize(UserPermission.CancerType_ViewCancerTypeProtocols)]
        public ActionResult Index()
        {
            EntityCollection<CTHChemotherapyProtocolEntity> ChemotherapyProtocolCollection = new EntityCollection<CTHChemotherapyProtocolEntity>();
            BL.DataBaseClassHelper.FillCollection(ChemotherapyProtocolCollection, null, 0, null, null, 0, 0);
            return View(ChemotherapyProtocolCollection);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateProtocol)]
        [HttpGet]
        public IActionResult EditCreateChemotherapyProtocol(int ID)
        {
            ChemotherapyProtocolModel model = new ChemotherapyProtocolModel();
            model.ChemotherapyProtocolEntity = new CTHChemotherapyProtocolEntity();
            model.CancerTypeList = DataHelper.GetSelectList<CTHChemotherapyProtocolEntity>(CTHChemotherapyProtocolFields.ID, CTHChemotherapyProtocolFields.ProtocolName);
            if (ID > 0)
            {
                model.ChemotherapyProtocolEntity = new CTHChemotherapyProtocolEntity(ID);
                BL.DataBaseClassHelper.FillEntity(model.ChemotherapyProtocolEntity, null);
            }
            return View(model);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateProtocol)]
        [HttpPost]
        public IActionResult EditCreateChemotherapyProtocol(ChemotherapyProtocolModel model)
        {
            if (model.ChemotherapyProtocolEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.ChemotherapyProtocolEntity, true, false, 0);
                AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket(CTHChemotherapyProtocolFields.ID == model.ChemotherapyProtocolEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(model.ChemotherapyProtocolEntity, filter, 0);
                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHChemotherapyProtocolEntity);
                path.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHDrugCollection, true);
                path.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHLabCollection, true);
                path.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHProtocolCycleCollection, true);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(model.ChemotherapyProtocolEntity, path);
                AddSweetNotification("Done", "Data Updated Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            return View("EditCreateChemotherapyProtocol" ,new { ID= model.ChemotherapyProtocolEntity.ID});
        }


        [SmartAuthorize(UserPermission.CancerType_DeleteProtocol)]
        [HttpGet]
        public ActionResult DeleteChemotherapyProtocol(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id,
            });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteProtocol)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteChemotherapyProtocol")]
        public ActionResult ConfirmDeleteChemotherapyProtocol(int ItemID)
        {
            CTHChemotherapyProtocolEntity item = new CTHChemotherapyProtocolEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHChemotherapyProtocolEntity);
            path.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHDrugCollection, true);
            path.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHLabCollection, true);
            path.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHProtocolCycleCollection, true);
            path.Add(CTHChemotherapyProtocolEntity.PrefetchPathCTHKimoSurveyCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            if (item.CTHDrugCollection.Count() == 0 && item.CTHKimoSurveyCollection.Count() == 0 && item.CTHLabCollection.Count() == 0 && item.CTHProtocolCycleCollection.Count() == 0)
            {
                BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Error", "You cannot delete this item", Helper.NotificationHelper.NotificationType.error);
            }
            return View("Index");
        }



        #endregion

    }
}