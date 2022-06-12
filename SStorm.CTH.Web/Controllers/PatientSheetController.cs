using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SStorm.CTH.DAL.EntityClasses;
using SStorm.CTH.DAL.HelperClasses;
using SStorm.CTH.BL.Helpers;
using Microsoft.AspNetCore.Mvc;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SStorm.CTH.DAL;
using SStorm.CTH.Web.Infrastructure;

namespace SStorm.CTH.Web.Controllers
{
    public class PatientSheetController : SmartController
    {
        public PatientSheetController(IClientNotification notifier) : base(notifier)
        {
        }

        public IActionResult PatientSheet(int PatientID)
        {
            CTHPatientEntity patientEntity = new CTHPatientEntity(PatientID);
            PrefetchPath2 path = new PrefetchPath2(EntityType.CTHPatientEntity);
            var patientpath = path.Add(CTHPatientEntity.PrefetchPathCTHPatientClinicalDataCollection, true);
               var kimopath = patientpath.SubPath.Add(CTHPatientClinicalDataEntity.PrefetchPathCTHKimoSurveyCollection, true);
               var labpath = kimopath.SubPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHChemoLabCollection, true);
                    labpath.SubPath.Add(CTHChemoLabEntity.PrefetchPathCTHLabDetailItem, true);

               var drugpath = kimopath.SubPath.Add(CTHKimoSurveyEntity.PrefetchPathCTHPatientDrugCollection, true);
                  var drugdaypath = drugpath.SubPath.Add(CTHPatientDrugEntity.PrefetchPathCTHDrugDayItem, true);
                        drugdaypath.SubPath.Add(CTHDrugDayEntity.PrefetchPathCTHDrugItem,true);
            BL.DataBaseClassHelper.FillEntity(patientEntity, path);
            return View(patientEntity);
        }
    }
}