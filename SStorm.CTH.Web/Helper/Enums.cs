using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web
{

    public enum UserPermission
    {
        //1-Maintenence

        //////////////////3

        //1.1-Surgery Type
        SurgeryType_View = 1,
        SurgeryType_EditCreate = 2,
        SurgeryType_Delete = 3,

        //////////////////3

        //1.2-Treatment Type
        TreatmentType_View = 4,
        TreatmentType_EditCreate = 5,
        TreatmentType_Delete = 6,

        //////////////////12

        //1.3-TNM Staging 
        TNMStaging_ViewStaging = 7,
        TNMStaging_EditCreateStaging = 8,
        TNMStaging_DeleteStaging = 9,
        TNMStaging_ViewTumorSize = 10,
        TNMStaging_EditCreateTumorSize = 11,
        TNMStaging_DeleteTumorSize = 12,
        TNMStaging_ViewLymphNode = 13,
        TNMStaging_EditCreateLymphNode = 14,
        TNMStaging_DeleteLymphNode = 15,
        TNMStaging_ViewDistantMetastasis = 16,
        TNMStaging_EditCreateDistantMetastasis = 17,
        TNMStaging_DeleteDistantMetastasis = 18,

        //////////////////3

        //1.4-Imaging
        Imaging_View = 19,
        Imaging_EditCreate = 20,
        Imaging_Delete = 21,

        //////////////////3

        //1.5-Pathology Report
        PathologyReport_View = 22,
        PathologyReport_EditCreate = 23,
        PathologyReport_Delete = 24,

        //////////////////6

        //1.6-Special Case
        SpecialCase_View = 25,
        SpecialCase_EditCreate = 26,
        SpecialCase_Delete = 27,
        SpecialCase_ViewParts = 28,
        SpecialCase_EditCreatePart = 29,
        SpecialCase_DeletePart = 30,

        //////////////////3

        //1.7-Intial Lab
        IntialLab_View = 31,
        IntialLab_EditCreate = 32,
        IntialLab_Delete = 33,

        //////////////////3

        //1.8-Premedication
        Premedication_View = 34,
        Premedication_EditCreate = 35,
        Premedication_Delete = 36,

        //////////////////3

        //1.9-Solution
        Solution_View = 37,
        Solution_EditCreate = 38,
        Solution_Delete = 39,

        //////////////////3

        //1.10-Dose Unit
        DoseUnit_View = 40,
        DoseUnit_EditCreate = 41,
        DoseUnit_Delete = 42,

        //////////////////3

        //1.11-Symptom
        Symptom_View = 43,
        Symptom_EditCreate = 44,
        Symptom_Delete = 45,

        //////////////////33

        //1.12-Cancer Type
        CancerType_View = 46,
        CancerType_EditCreate = 47,
        CancerType_Delete = 48,
        CancerType_ViewHistologicalSubtype = 49,
        CancerType_EditCreateHistologicalSubtype = 50,
        CancerType_DeleteHistologicalSubtype = 51,
        CancerType_ViewMolecularSubtype = 52,
        CancerType_EditCreateMolecularSubtype = 53,
        CancerType_DeleteMolecularSubtype = 54,
        CancerType_ViewStagingMatrix = 55,
        CancerType_AssignStageToTNM = 56,
        CancerType_DeleteTNMStaging = 57,
        CancerType_ViewCancerTypeProtocols = 58,
        CancerType_EditCreateProtocol = 59,
        CancerType_DeleteProtocol = 60,
        CancerType_ViewProtocolDrugs = 61,
        CancerType_EditCreateDrug = 62,
        CancerType_DeleteDrug = 63,
        CancerType_ViewDrugSymptoms = 64,
        CancerType_AssignSymptomToDrug = 65,
        CancerType_DeleteSymptomFromDrug = 66,
        CancerType_ViewProtocolLabs = 67,
        CancerType_EditCreateLab = 68,
        CancerType_DeleteLab = 69,
        CancerType_ViewProtocolCycles = 70,
        CancerType_EditCreateCycle = 71,
        CancerType_DeleteCycle = 72,
        CancerType_ViewCycleDrugs = 73,
        CancerType_AssignDrugToCycle = 74,
        CancerType_DeleteDrugFromCycle = 75,
        CancerType_ViewCycleLabs = 76,
        CancerType_AssignLabToCycle = 77,
        CancerType_DeleteLabFromCycle = 78,

        //-------------------------------19

        //2-Patient
        Patient_View = 79,
        Patient_EditCreate = 80,
        Patient_Delete = 81,
        Patient_Diagnosis = 82,
        Patient_ViewPatientInvestigations = 83,
        Patient_PerformInvestigation = 84,
        Patient_DeleteInvestigation = 85,
        Patient_ViewPatientSurgeries = 86,
        Patient_PerformSurgery = 87,
        Patient_DeleteSurgery = 88,
        Patient_ViewPatientChemoSurveySessions = 89,
        Patient_EditCreateChemo = 90,
        Patient_DeleteChemo = 91,
        Patient_ChemoDischargeNote = 92,
        Patient_ChemoPrintOutSheet = 93,
        Patient_ViewPatientSchedule = 94,
        Patient_ViewSymptoms = 95,
        Patient_CreatePatientSymptom = 96,
        Patient_DoctorRecommendationForPatientSymptom = 97,

        //-------------------------------3
        //3-User
        User_View = 98,
        User_EditCreate = 99,
        User_Delete = 100,
        //-------------------------------3
        //4-Doctor
        Doctor_View = 101,
        Doctor_EditCreate = 102,
        Doctor_Delete = 103,
        //-------------------------------9
        //5-Role
        Role_View = 104,
        Role_EditCreate = 105,
        Role_Delete = 106,
        Role_ViewUsers = 107,
        Role_AssignPermissionsToRole = 108,
        Role_DeletePermissionsFromRole = 109,
        Role_AssignUserToRole = 110,
        Role_DeleteUserFromRole = 111,
        Role_ViewPermissions = 112,
        //-------------------------------

        //TumorGrade
        TumorGrade_View = 113,
        TumorGrade_EditCreate = 114,
        TumorGrade_Delete = 115,

        //LabGroup
        LabGroup_View = 116,
        LabGroup_EditCreate = 117,
        LabGroup_Delete = 118,

        LabGroup_Lab_View = 119,
        LabGroup_Lab_EditCreate = 120,
        LabGroup_Lab_Delete = 121,
    }

    public enum NotificationEntityType
    {
        PatientSymptom = 1,
        ChemoLab = 2,
        PatientDrug = 3,
        KimoSurvey=4,
    }
    public enum JsonReturnType
    {
        EditCreateSuccess = 1,
        EditCreateFail = 2,
        DeleteSuccess = 3,
        DeleteFail = 4
    }
    public enum EmatogenicRisk
    {
        High = 1,
        Low = 2,
        Moderate = 3,
        MiniMal = 4
    }
    public enum Route
    {
        Iv = 1,
        Po = 2,
        Sc = 3,
        Im = 4
    }
    //public enum DoseUnit
    //{
    //    BodyWieght = 1,
    //    AdjustBodyWieght = 2,
    //    BodySurfaceArea = 3
    //}
    public enum DurationUnit
    {
        Minutes = 1,
        Hours = 2,
        Days = 3,
        Weeks = 4
    }

    public enum Grade
    {
        one = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }

    public enum EveryUnit
    {
        Days = 1,
        Weeks = 2
    }
    public enum Form
    {
        Tablets = 1,
        Caps = 2
    }

    public enum PerList
    {
        BodySurfaceArea = 1,
        AdjustBodyWieght = 2,
        LeanBodyWeight = 3,
        CRCL = 4,
    }
   
}




