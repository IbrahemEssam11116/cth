//using iTextSharp.text.pdf.qrcode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SStorm.CTH.DAL;
using SStorm.CTH.DAL.EntityClasses;
using SStorm.CTH.DAL.HelperClasses;
using SStorm.CTH.Web.Infrastructure;
using SStorm.CTH.Web.Models;
using X.PagedList;

namespace SStorm.CTH.Web.Controllers
{
    public class LabGroup_LabController : SmartController
    {
        public LabGroup_LabController(IClientNotification _clientNotification)
        : base(_clientNotification)
        {

        }

        [SmartAuthorize(UserPermission.LabGroup_Lab_View)]
        [HttpGet]
        public IActionResult Index(LabGroupLabModel model,int LabGroupID)
        {
            EntityCollection<CTHLabGroupLabEntity> Collection = new EntityCollection<CTHLabGroupLabEntity>();
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabGroupLabEntity);
            path.Add(CTHLabGroupLabEntity.PrefetchPathCTHLabGroupItem);
            path.Add(CTHLabGroupLabEntity.PrefetchPathCTHLabItem);
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(CTHLabGroupLabFields.LabGroupID == LabGroupID);
            if (!string.IsNullOrWhiteSpace(model.SearchString))
                filter.PredicateExpression.Add(CTHLabGroupLabFields.LabGroupID % $"%{model.SearchString}%");
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(Collection, filter, model.PageSize, null, path, model.Page, model.PageSize);
            var Count = BL.DataBaseClassHelper.GetCount(CTHLabGroupLabFields.ID, filter);
            model.DataPagedList = new StaticPagedList<CTHLabGroupLabEntity>(Collection, model.Page, model.PageSize, Count);
            return View(model);
        }

        [SmartAuthorize(UserPermission.LabGroup_Lab_EditCreate)]
        [HttpGet]
        public IActionResult EditCreate(int ID,int LabGroupID)
        {
            CTHLabGroupLabEntity entity = new CTHLabGroupLabEntity();
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHLabGroupLabEntity);
            path.Add(CTHLabGroupLabEntity.PrefetchPathCTHLabGroupItem);
            path.Add(CTHLabGroupLabEntity.PrefetchPathCTHLabItem);
            if (ID > 0)
            {
                entity = new CTHLabGroupLabEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(entity, path);
            }
            LabGroupLabModel model = new LabGroupLabModel();
            model.LabGroupID = LabGroupID;
            model.LabList = DataHelper.GetSelectList<CTHLabEntity>(CTHLabFields.ID, CTHLabFields.LabName);
            model.labGroupLabEntity = entity;

            return PartialView(model);
        }

        [SmartAuthorize(UserPermission.LabGroup_Lab_EditCreate)]
        [HttpPost]
        public IActionResult EditCreate(LabGroupLabModel model)
        {
                model.labGroupLabEntity.LabGroupID = model.LabGroupID;
            if (model.labGroupLabEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(model.labGroupLabEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHLabGroupLabFields.ID == model.labGroupLabEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(model.labGroupLabEntity, filter, 0);
            }
            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index",new { LabGroupID = model.LabGroupID });
        }

        [SmartAuthorize(UserPermission.LabGroup_Lab_Delete)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.LabGroup_Lab_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHLabGroupLabEntity masterEntity = new CTHLabGroupLabEntity(ItemID);
           
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(masterEntity, null);
            var LabGroupID = masterEntity.LabGroupID;
            try
            {

                SStorm.CTH.BL.DataBaseClassHelper.Delete(masterEntity, 0);
                AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            catch
            {
                AddSweetNotification("Error", "Error, You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);
            }
            return RedirectToAction("Index",new { LabGroupID = LabGroupID });
        }
    }
}