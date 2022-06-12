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
    public class CancerTypeController : SmartController
    {
        public CancerTypeController(IClientNotification _clientNotification)
          : base(_clientNotification)
        {

        }
        #region Cancer Type
        /////////////////////////////////*Get Cancer Type List*/////////////////////////////////

        [SmartAuthorize(UserPermission.CancerType_View)]
        public IActionResult Index()
        {
            TreeViewNode nodes = new TreeViewNode();

            nodes.CancerTypeCollection = new EntityCollection<CTHCancerTypeEntity>();
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCancerTypeEntity);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHCancerTypeCollection,true);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHSurgeryTypeCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(nodes.CancerTypeCollection, null, 0, null, path, 0, 0);
            nodes.Seed = null;
            return View(nodes);
        }

        [SmartAuthorize(UserPermission.CancerType_View)]
        public ActionResult CancerTypeList()
        {
            TreeViewNode nodes = new TreeViewNode();
            nodes.CancerTypeCollection = new EntityCollection<CTHCancerTypeEntity>();
            PrefetchPath2 Path = new PrefetchPath2(EntityType.CTHCancerTypeEntity);
            Path.Add(CTHCancerTypeEntity.PrefetchPathCTHCancerTypeCollection);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(nodes.CancerTypeCollection, null, 0, null, Path, 0, 0);
            nodes.Seed = null;
            return View(nodes);
        }

        /////////////////////////////////*Edit and Create Cancer Type*/////////////////////////////////

        [SmartAuthorize(UserPermission.CancerType_EditCreate)]
        [HttpGet]
        public IActionResult EditCreate(int ID,int ParentID)
        {
            CTHCancerTypeEntity cancerType = new CTHCancerTypeEntity();
            if (ID > 0)
            {
                cancerType = new CTHCancerTypeEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(cancerType, null);
            }
            if(ParentID != 0)
            {
                cancerType.ParentID = ParentID;
                cancerType.IsParent = false;
            }
            else
            {
                cancerType.IsParent = true;
            }
            
            return PartialView(cancerType);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreate)]

        [HttpPost]
        public IActionResult EditCreate(CTHCancerTypeEntity cancer)
        {
            if (cancer.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(cancer, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket(CTHCancerTypeFields.ID == cancer.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(cancer, filter, 0);
            }
            AddSweetNotification("Done", "Data Saved Successfully", Helper.NotificationHelper.NotificationType.success);
            return RedirectToAction("Index");
        }

        /////////////////////////////////*Delete Cancer Type*/////////////////////////////////

        [SmartAuthorize(UserPermission.CancerType_Delete)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id
            });
        }

        [SmartAuthorize(UserPermission.CancerType_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult ConfirmDelete(int ItemID)
        {
            CTHCancerTypeEntity item = new CTHCancerTypeEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCancerTypeEntity);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHCancerHistologicCollection,true);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHCancerMolecularCollection,true);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHCancerTypeCollection,true);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHChemotherapyProtocolCollection,true);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHPatientClinicalDataCollection,true);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHSurgeryTypeCollection,true);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHTNMStagingMatrixCollection,true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            if (item.CTHCancerHistologicCollection.Count()==0 && item.CTHCancerMolecularCollection.Count()==0 && item.CTHCancerTypeCollection.Count()==0 && item.CTHChemotherapyProtocolCollection.Count()==0 && item.CTHPatientClinicalDataCollection.Count()==0 && item.CTHSurgeryTypeCollection.Count()==0 && item.CTHTNMStagingMatrixCollection.Count() == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                AddSweetNotification("Done", "Data Deleted Successfully", Helper.NotificationHelper.NotificationType.success);
            }
            else
            {
                AddSweetNotification("Done", "You Cannot Delete this data", Helper.NotificationHelper.NotificationType.error);
            }
            return RedirectToAction("Index");
        }

        /////////////////////////////////*Get Cancer Details*/////////////////////////////////
        [HttpGet]
        public IActionResult GetCancerDetails(int ID)
        {
            TreeViewNode node = new TreeViewNode();
            node.CancerType = new CTHCancerTypeEntity(ID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCancerTypeEntity);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHCancerHistologicCollection,true);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHCancerMolecularCollection, true);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHChemotherapyProtocolCollection, true);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHSurgeryTypeCollection, true);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHStagingCollection,true);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHTNMStagingCollection,true);

            var StagingMatrixPath = path.Add(CTHCancerTypeEntity.PrefetchPathCTHTNMStagingMatrixCollection, true);
            StagingMatrixPath.SubPath.Add(CTHTNMStagingMatrixEntity.PrefetchPathCTHStagingItem, true);
            StagingMatrixPath.SubPath.Add(CTHTNMStagingMatrixEntity.PrefetchPathCTHTNMStagingItem, true);
            StagingMatrixPath.SubPath.Add(CTHTNMStagingMatrixEntity.PrefetchPathCTHTNMStagingItem1, true);
            StagingMatrixPath.SubPath.Add(CTHTNMStagingMatrixEntity.PrefetchPathCTHTNMStagingItem2, true);
            CTH.BL.DataBaseClassHelper.FillEntity(node.CancerType, path);

            

            node.HistologicCollection = new EntityCollection<CTHCancerHistologicEntity>();
            PrefetchPath2 Path = new PrefetchPath2(EntityType.CTHCancerHistologicEntity);
            Path.Add(CTHCancerHistologicEntity.PrefetchPathCTHCancerHistologicCollection);
            RelationPredicateBucket histologicalFilter = new RelationPredicateBucket(CTHCancerHistologicFields.CanerID == ID);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(node.HistologicCollection, histologicalFilter, 0, null, Path, 0, 0);

            node.MolecularCollection = new EntityCollection<CTHCancerMolecularEntity>();
            PrefetchPath2 Path2 = new PrefetchPath2(EntityType.CTHCancerMolecularEntity);
            Path.Add(CTHCancerMolecularEntity.PrefetchPathCTHCancerMolecularCollection);
            RelationPredicateBucket molecularFilter = new RelationPredicateBucket(CTHCancerMolecularFields.CanerID == ID);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(node.MolecularCollection, molecularFilter, 0, null, Path2, 0, 0);

            node.Seed = null;
            return PartialView("_CancerTypeDetails", node);
        }

        #endregion

        #region Surgery Type Details
        [SmartAuthorize(UserPermission.SurgeryType_EditCreate)]
        [HttpGet]
        public IActionResult EditCreateSurgeryType(int ID, int CancerTypeID)
        {
            CTHSurgeryTypeEntity surgeryType = new CTHSurgeryTypeEntity();
            if (ID > 0)
            {
                surgeryType = new CTHSurgeryTypeEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(surgeryType, null);
            }
            surgeryType.CancerTypeID = CancerTypeID;
            return PartialView(surgeryType);
        }

        [SmartAuthorize(UserPermission.SurgeryType_EditCreate)]
        [HttpPost]
        public IActionResult EditCreateSurgeryType(CTHSurgeryTypeEntity surgery)
        {
            if (surgery.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(surgery, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHSurgeryTypeFields.ID == surgery.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(surgery, filter, 0);
            }
            return Json(JsonReturnType.EditCreateSuccess);
        }

        [SmartAuthorize(UserPermission.SurgeryType_Delete)]
        [HttpGet]
        public ActionResult DeleteSurgeryType(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id,
                ControllerName = "CancerType",
                ActionName = "DeleteSurgeryType",
                DataAjax = true,
                DataAjaxMethod = "post",
                DataAjaxSuccess = "LoadSurgeryTypeList"
            });
        }

        [SmartAuthorize(UserPermission.SurgeryType_Delete)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteSurgeryType")]
        public ActionResult ConfirmDeleteSurgeryType(int ItemID)
        {
            CTHSurgeryTypeEntity item = new CTHSurgeryTypeEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHSurgeryTypeEntity);
            path.Add(CTHSurgeryTypeEntity.PrefetchPathCTHPatientSurgeryCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            if (item.CTHPatientSurgeryCollection.Count == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                return Json(JsonReturnType.DeleteSuccess);
            }
            else
            {
                return Json(JsonReturnType.DeleteFail);
            }
        }

        public ActionResult GetSurgeryType(int CancerTypeID)
        {
            TreeViewNode SurgeryType = new TreeViewNode();
            SurgeryType.CancerType = new CTHCancerTypeEntity(CancerTypeID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCancerTypeEntity);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHSurgeryTypeCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(SurgeryType.CancerType, path);

            SurgeryType.SurgeryTypeCollection = new EntityCollection<CTHSurgeryTypeEntity>();
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHSurgeryTypeFields.CancerTypeID == CancerTypeID);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(SurgeryType.SurgeryTypeCollection, filter, 0, null, null, 0, 0);
            SurgeryType.Seed = null;
            return PartialView("_SurgeryTypeDetails", SurgeryType);
        }
        #endregion
        
        #region TNM staging
        /////////////////////////////////*Assign TNM To Stage*/////////////////////////////////

        [SmartAuthorize(UserPermission.CancerType_AssignStageToTNM)]
        [HttpGet]
        public ActionResult AssignTNMToStage(int CancerTypeID,int ID)
        {

            TNMStagingModel TNMStaging = new TNMStagingModel();
            TNMStaging.TNMStaging = new CTHTNMStagingMatrixEntity();
            if(ID > 0)
            {
                TNMStaging.TNMStaging = new CTHTNMStagingMatrixEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(TNMStaging.TNMStaging, null);
            }
            RelationPredicateBucket filter1 = new RelationPredicateBucket(CTHTNMStagingFields.TNMTypeID == 1 );
            filter1.PredicateExpression.AddWithAnd(CTHTNMStagingFields.CancerTypeID == CancerTypeID);
            TNMStaging.TumorSizeList = DataHelper.GetStagingSelectList(CTHTNMStagingFields.ID, CTHTNMStagingFields.Name, CTHTNMStagingFields.Description, filter1);
            RelationPredicateBucket filter2 = new RelationPredicateBucket(CTHTNMStagingFields.TNMTypeID == 2);
            filter2.PredicateExpression.AddWithAnd(CTHTNMStagingFields.CancerTypeID == CancerTypeID);
            TNMStaging.LymphNodeList = DataHelper.GetStagingSelectList(CTHTNMStagingFields.ID, CTHTNMStagingFields.Name, CTHTNMStagingFields.Description, filter2);
            RelationPredicateBucket filter3 = new RelationPredicateBucket(CTHTNMStagingFields.TNMTypeID == 3);
            filter3.PredicateExpression.AddWithAnd(CTHTNMStagingFields.CancerTypeID == CancerTypeID);

            TNMStaging.DistantMetastasisList = DataHelper.GetStagingSelectList(CTHTNMStagingFields.ID, CTHTNMStagingFields.Name, CTHTNMStagingFields.Description, filter3);
            RelationPredicateBucket filter4 = new RelationPredicateBucket(CTHStagingFields.CancerTypeID == CancerTypeID);
            TNMStaging.StagingList = DataHelper.GetSelectList<CTHStagingEntity>(CTHStagingFields.ID, CTHStagingFields.Name,filter4);
            TNMStaging.TNMStaging.CancerTypeID = CancerTypeID;
            return PartialView(TNMStaging);
        }

        [SmartAuthorize(UserPermission.CancerType_AssignStageToTNM)]
        [HttpPost]
        public JsonResult AssignTNMToStage(TNMStagingModel TNMStagingModel)
        {
            EntityCollection<CTHTNMStagingMatrixEntity> StagingMatrixCollection = new EntityCollection<CTHTNMStagingMatrixEntity>();
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(CTHTNMStagingMatrixFields.StageID == TNMStagingModel.TNMStaging.StageID);
            filter.PredicateExpression.Add(CTHTNMStagingMatrixFields.TID == TNMStagingModel.TNMStaging.TID);
            filter.PredicateExpression.Add(CTHTNMStagingMatrixFields.MID == TNMStagingModel.TNMStaging.MID);
            filter.PredicateExpression.Add(CTHTNMStagingMatrixFields.NID == TNMStagingModel.TNMStaging.NID);
            filter.PredicateExpression.Add(CTHTNMStagingMatrixFields.CancerTypeID == TNMStagingModel.TNMStaging.CancerTypeID);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(StagingMatrixCollection, filter, 0, null, null,0, 0);
            if(StagingMatrixCollection.Count == 0)
            {
                if(TNMStagingModel.TNMStaging.ID == 0)
                {
                    SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(TNMStagingModel.TNMStaging, false, false, 0);
                }
                else
                {
                    RelationPredicateBucket filter2 = new RelationPredicateBucket(CTHTNMStagingMatrixFields.ID == TNMStagingModel.TNMStaging.ID);
                    SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(TNMStagingModel.TNMStaging, filter2, 0);
                }
                return Json(JsonReturnType.EditCreateSuccess);
            }
            else
            {
                return Json(JsonReturnType.EditCreateFail);
            }
         
        }

        /////////////////////////////////*Get TNM Staging Matrix*/////////////////////////////////

        [SmartAuthorize(UserPermission.CancerType_ViewStagingMatrix)]
        [HttpGet]
        public IActionResult GetStagingMatrix(int CancerTypeID)
        {
            TreeViewNode node = new TreeViewNode();
            node.CancerType = new CTHCancerTypeEntity(CancerTypeID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCancerTypeEntity);
            var matrixPath = path.Add(CTHCancerTypeEntity.PrefetchPathCTHTNMStagingMatrixCollection, true);
            matrixPath.SubPath.Add(CTHTNMStagingMatrixEntity.PrefetchPathCTHStagingItem, true);
            matrixPath.SubPath.Add(CTHTNMStagingMatrixEntity.PrefetchPathCTHTNMStagingItem, true);
            matrixPath.SubPath.Add(CTHTNMStagingMatrixEntity.PrefetchPathCTHTNMStagingItem1, true);
            matrixPath.SubPath.Add(CTHTNMStagingMatrixEntity.PrefetchPathCTHTNMStagingItem2, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(node.CancerType, path);
            return PartialView("_StagingMatrix", node);
        }

        /////////////////////////////////*Delete TNM Staging*/////////////////////////////////

        [SmartAuthorize(UserPermission.CancerType_DeleteTNMStaging)]
        public ActionResult DeleteStagingMatrix(int ID)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = ID,
                ControllerName = "CancerType",
                ActionName = "DeleteStagingMatrix",
                DataAjax = true,
                DataAjaxMethod = "post",
                DataAjaxSuccess = "RefreshStagingMatrix"
            });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteTNMStaging)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteStagingMatrix")]
        public ActionResult ConfirmDeleteStagingMatrix(int ItemID)
        {
            CTHTNMStagingMatrixEntity item = new CTHTNMStagingMatrixEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHTNMStagingMatrixEntity);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, null);
            SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
            return Json(JsonReturnType.DeleteSuccess);
        }

        #endregion

        #region Cancer Histological
        /////////////////////////////////*Edit and Create Cancer Histological*/////////////////////////////////
        [SmartAuthorize(UserPermission.CancerType_EditCreateHistologicalSubtype)]
        [HttpGet]
        public IActionResult EditCreateHistological(int ID,int CancerID, int ParentID)
        {
            CTHCancerHistologicEntity CTHCancerHistologicEntity = new CTHCancerHistologicEntity();
            if (ID > 0)
            {
                CTHCancerHistologicEntity = new CTHCancerHistologicEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CTHCancerHistologicEntity, null);
            }
            if (ParentID != 0)
            {
                CTHCancerHistologicEntity.ParentID = ParentID;
            }
            CTHCancerHistologicEntity.CanerID = CancerID;
            return PartialView(CTHCancerHistologicEntity);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateHistologicalSubtype)]
        [HttpPost]
        public IActionResult EditCreateHistological(CTHCancerHistologicEntity CTHCancerHistologicEntity)
        {
            if (CTHCancerHistologicEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(CTHCancerHistologicEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket(CTHCancerHistologicFields.ID == CTHCancerHistologicEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(CTHCancerHistologicEntity, filter, 0);
            }
            return Json(JsonReturnType.EditCreateSuccess);
        }

        /////////////////////////////////*Delete Cancer Histological*/////////////////////////////////
       
        [SmartAuthorize(UserPermission.CancerType_DeleteHistologicalSubtype)]
        [HttpGet]
        public ActionResult DeleteHistological(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id,
                ControllerName = "CancerType",
                ActionName = "DeleteHistological",
                DataAjax = true,
                DataAjaxMethod = "post",
                DataAjaxSuccess = "RefreshHistological"
            });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteHistologicalSubtype)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteHistological")]
        public ActionResult ConfirmDeleteHistological(int ItemID)
        {
            CTHCancerHistologicEntity item = new CTHCancerHistologicEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCancerHistologicEntity);
            path.Add(CTHCancerHistologicEntity.PrefetchPathCTHCancerHistologicCollection, true);
            path.Add(CTHCancerHistologicEntity.PrefetchPathCTHPatientClinicalDataCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            if(item.CTHCancerHistologicCollection.Count() == 0 && item.CTHPatientClinicalDataCollection.Count() == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                return Json(JsonReturnType.DeleteSuccess);
            }
            else
            {
                return Json(JsonReturnType.DeleteFail);

            }
        }

        /////////////////////////////////*Get Cancer Histological*/////////////////////////////////

        [SmartAuthorize(UserPermission.CancerType_ViewHistologicalSubtype)]
        public ActionResult GetCancerHistological(int CancerTypeID)
        {
            TreeViewNode CancerType = new TreeViewNode();
            CancerType.CancerType = new CTHCancerTypeEntity(CancerTypeID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCancerTypeEntity);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHCancerHistologicCollection,true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CancerType.CancerType, path);

            CancerType.HistologicCollection = new EntityCollection<CTHCancerHistologicEntity>();
            PrefetchPath2 Path = new PrefetchPath2(EntityType.CTHCancerHistologicEntity);
            Path.Add(CTHCancerHistologicEntity.PrefetchPathCTHCancerHistologicCollection);
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHCancerHistologicFields.CanerID == CancerTypeID);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(CancerType.HistologicCollection, filter, 0, null, Path, 0, 0);
            return PartialView("_Histological", CancerType);
        }
        #endregion

        #region Cancer Molecular
        /////////////////////////////////*Edit and Create Cancer Molecular*/////////////////////////////////

        [SmartAuthorize(UserPermission.CancerType_EditCreateMolecularSubtype)]
        [HttpGet]
        public IActionResult EditCreateMolecular(int ID, int CancerID, int ParentID)
        {
            CTHCancerMolecularEntity CTHCancerMolecularEntity = new CTHCancerMolecularEntity();
            if (ID > 0)
            {
                CTHCancerMolecularEntity = new CTHCancerMolecularEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CTHCancerMolecularEntity, null);
            }
            if (ParentID != 0)
            {
                CTHCancerMolecularEntity.ParentID = ParentID;
            }
            CTHCancerMolecularEntity.CanerID = CancerID;
            return PartialView(CTHCancerMolecularEntity);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateMolecularSubtype)]
        [HttpPost]
        public IActionResult EditCreateMolecular(CTHCancerMolecularEntity CTHCancerMolecularEntity)
        {
            if (CTHCancerMolecularEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(CTHCancerMolecularEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket(CTHCancerMolecularFields.ID == CTHCancerMolecularEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(CTHCancerMolecularEntity, filter, 0);
            }
            return Json(JsonReturnType.EditCreateSuccess);
        }

        /////////////////////////////////*Delete Cancer Molecular*/////////////////////////////////

        [SmartAuthorize(UserPermission.CancerType_DeleteMolecularSubtype)]
        [HttpGet]
        public ActionResult DeleteMolecular(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id,
                ControllerName = "CancerType",
                ActionName = "DeleteMolecular",
                DataAjax = true,
                DataAjaxMethod = "post",
                DataAjaxSuccess = "RefreshMolecular"
            });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteMolecularSubtype)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteMolecular")]
        public ActionResult ConfirmDeleteMolecular(int ItemID)
        {
            CTHCancerMolecularEntity item = new CTHCancerMolecularEntity(ItemID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCancerMolecularEntity);
            path.Add(CTHCancerMolecularEntity.PrefetchPathCTHCancerMolecularCollection, true);
            path.Add(CTHCancerMolecularEntity.PrefetchPathCTHPatientClinicalDataCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, path);
            if (item.CTHCancerMolecularCollection.Count() == 0 && item.CTHPatientClinicalDataCollection.Count() == 0) 
            {

                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                return Json(JsonReturnType.DeleteSuccess);
            }
            else
            {
                return Json(JsonReturnType.DeleteFail);

            }
        }

        /////////////////////////////////*Get Cancer Molecular*/////////////////////////////////
        
        [SmartAuthorize(UserPermission.CancerType_ViewMolecularSubtype)]
        public ActionResult GetCancerMolecular(int CancerTypeID)
        {
            TreeViewNode CancerType = new TreeViewNode();
            CancerType.CancerType = new CTHCancerTypeEntity(CancerTypeID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCancerTypeEntity);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHCancerMolecularCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CancerType.CancerType, path);

            CancerType.MolecularCollection = new EntityCollection<CTHCancerMolecularEntity>();
            PrefetchPath2 Path = new PrefetchPath2(EntityType.CTHCancerMolecularEntity);
            Path.Add(CTHCancerMolecularEntity.PrefetchPathCTHCancerMolecularCollection);
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHCancerMolecularFields.CanerID == CancerTypeID);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(CancerType.MolecularCollection, filter, 0, null, Path, 0, 0);
            CancerType.Seed = null;
            return PartialView("_Molecular", CancerType);
        }
        #endregion

        #region ChemotherapyProtocol 
        /////////////////////////////////*Edit and Create Cancer Histological*/////////////////////////////////

        [SmartAuthorize(UserPermission.CancerType_EditCreateProtocol)]
        [HttpGet]
        public IActionResult EditCreateChemotherapyProtocol(int ID, int CancerTypeID)
        {
            CTHChemotherapyProtocolEntity CTHChemotherapyProtocolEntity = new CTHChemotherapyProtocolEntity();
            if (ID > 0)
            {
                CTHChemotherapyProtocolEntity = new CTHChemotherapyProtocolEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CTHChemotherapyProtocolEntity, null);
            }        
            CTHChemotherapyProtocolEntity.CancerTypeID = CancerTypeID;
            return PartialView(CTHChemotherapyProtocolEntity);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateProtocol)]
        [HttpPost]
        public IActionResult EditCreateChemotherapyProtocol(CTHChemotherapyProtocolEntity CTHChemotherapyProtocolEntity)
        {
            if (CTHChemotherapyProtocolEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(CTHChemotherapyProtocolEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket(CTHChemotherapyProtocolFields.ID == CTHChemotherapyProtocolEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(CTHChemotherapyProtocolEntity, filter, 0);
            }
            return Json(JsonReturnType.EditCreateSuccess);
        }

        /////////////////////////////////*Delete Cancer Histological*/////////////////////////////////

        [SmartAuthorize(UserPermission.CancerType_DeleteProtocol)]
        [HttpGet]
        public ActionResult DeleteChemotherapyProtocol(int id)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = id,
                ControllerName = "CancerType",
                ActionName = "DeleteChemotherapyProtocol",
                DataAjax = true,
                DataAjaxMethod = "post",
                DataAjaxSuccess = "RefreshChemotherapyProtocol"
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
            if(item.CTHDrugCollection.Count() == 0 && item.CTHKimoSurveyCollection.Count() == 0 && item.CTHLabCollection.Count() == 0 && item.CTHProtocolCycleCollection.Count() == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
                return Json(JsonReturnType.DeleteSuccess);
            }
            else
            {
                return Json(JsonReturnType.DeleteFail);

            }
        }

        /////////////////////////////////*Get Cancer ChemotherapyProtocol*/////////////////////////////////

        [SmartAuthorize(UserPermission.CancerType_ViewCancerTypeProtocols)]
        public ActionResult GetChemotherapyProtocol(int CancerTypeID)
        {
            TreeViewNode CancerType = new TreeViewNode();
            CancerType.CancerType = new CTHCancerTypeEntity(CancerTypeID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCancerTypeEntity);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHChemotherapyProtocolCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CancerType.CancerType, path);
            return PartialView("_ChemotherapyProtocol", CancerType);
        }
        #endregion

        public IActionResult AttachmentCollection(int DrugID)
        {
            CTHDrugEntity CTHDrugEntity = new CTHDrugEntity(DrugID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHDrugEntity);
            path.Add(CTHDrugEntity.PrefetchPathCTHDrugAttachmentCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CTHDrugEntity, path);
            return PartialView(CTHDrugEntity);
        }

        /////////////////////////////////*Assign Cancer Stage*/////////////////////////////////
        [SmartAuthorize(UserPermission.CancerType_AssignStageToTNM)]
        [HttpGet]
        public ActionResult EditCreateStaging(int CancerTypeID, int ID)
        {

            CTHStagingEntity stagingEntity = new CTHStagingEntity();
            if (ID > 0)
            {
                stagingEntity = new CTHStagingEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(stagingEntity, null);
            }
            stagingEntity.CancerTypeID = CancerTypeID;
            return PartialView(stagingEntity);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateMolecularSubtype)]
        [HttpPost]
        public IActionResult EditCreateStaging(CTHStagingEntity stagingEntity)
        {
            if (stagingEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(stagingEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHStagingFields.ID == stagingEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(stagingEntity, filter, 0);
            }
            return Json(JsonReturnType.EditCreateSuccess);
        }

        [SmartAuthorize(UserPermission.CancerType_ViewStagingMatrix)]
        [HttpGet]
        public IActionResult GetStaging(int CancerTypeID)
        {
            TreeViewNode Staging = new TreeViewNode();
            Staging.CancerType = new CTHCancerTypeEntity(CancerTypeID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCancerTypeEntity);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHStagingCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(Staging.CancerType, path);

            RelationPredicateBucket filter = new RelationPredicateBucket(CTHStagingFields.CancerTypeID == CancerTypeID);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(Staging.CancerType.CTHStagingCollection, filter, 0, null, null, 0, 0);
            Staging.Seed = null;
            return PartialView("_Staging", Staging);
        }

        #region TNMStaging

        [SmartAuthorize(UserPermission.CancerType_ViewStagingMatrix)]
        [HttpGet]
        public IActionResult GetTNMStaging(int CancerTypeID)
        {
            TreeViewNode TNMStaging = new TreeViewNode();
            TNMStaging.CancerType = new CTHCancerTypeEntity(CancerTypeID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHCancerTypeEntity);
            path.Add(CTHCancerTypeEntity.PrefetchPathCTHTNMStagingCollection, true);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(TNMStaging.CancerType, path);

            RelationPredicateBucket filter = new RelationPredicateBucket(CTHStagingFields.CancerTypeID == CancerTypeID);
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(TNMStaging.CancerType.CTHTNMStagingCollection, filter, 0, null, null, 0, 0);
            TNMStaging.Seed = null;
            return PartialView("_Staging", TNMStaging);
        }


        [SmartAuthorize(UserPermission.CancerType_AssignStageToTNM)]
        [HttpGet]
        public ActionResult EditCreateTNM(int CancerTypeID, int ID,int Type)
        {
           
            CTHTNMStagingEntity CTHTNMStagingEntity = new CTHTNMStagingEntity();
            if (ID > 0)
            {
                CTHTNMStagingEntity = new CTHTNMStagingEntity(ID);
                SStorm.CTH.BL.DataBaseClassHelper.FillEntity(CTHTNMStagingEntity, null);
            }
            CTHTNMStagingEntity.CancerTypeID = CancerTypeID;
            CTHTNMStagingEntity.TNMTypeID = Type;
            return PartialView(CTHTNMStagingEntity);
        }

        [SmartAuthorize(UserPermission.CancerType_EditCreateMolecularSubtype)]
        [HttpPost]
        public IActionResult EditCreateTumerSize(CTHTNMStagingEntity cTHTNMStagingEntity)
        {
            if (cTHTNMStagingEntity.ID == 0)
            {
                SStorm.CTH.BL.DataBaseClassHelper.SaveEntity(cTHTNMStagingEntity, true, false, 0);
            }
            else
            {
                RelationPredicateBucket filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CTHTNMStagingFields.ID == cTHTNMStagingEntity.ID);
                SStorm.CTH.BL.DataBaseClassHelper.UpdateEntityDirectly(cTHTNMStagingEntity, filter, 0);
            }
            return Json(JsonReturnType.EditCreateSuccess);
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteTNMStaging)]
        public ActionResult DeleteTNMStaging(int ID)
        {
            return PartialView("DeleteItem", new DeleteItemModel
            {
                ItemID = ID,
                ControllerName = "CancerType",
                ActionName = "DeleteTNMStaging",
                DataAjax = true,
                DataAjaxMethod = "post",
                DataAjaxSuccess = "RefreshTNMStaging"
            });
        }

        [SmartAuthorize(UserPermission.CancerType_DeleteTNMStaging)]
        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteTNMStaging")]
        public ActionResult ConfirmDeleteTNMStaging(int ItemID)
        {
            CTHTNMStagingEntity item = new CTHTNMStagingEntity(ItemID);
            SStorm.CTH.BL.DataBaseClassHelper.FillEntity(item, null);
            SStorm.CTH.BL.DataBaseClassHelper.Delete(item, 0);
            return Json(JsonReturnType.DeleteSuccess);
        }
        #endregion

    }
}