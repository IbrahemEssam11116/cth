﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.6.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using SStorm.CTH.DAL.HelperClasses;
using SStorm.CTH.DAL.FactoryClasses;
using SStorm.CTH.DAL.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SStorm.CTH.DAL.EntityClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>Entity class which represents the entity 'CTHTreatmentType'.<br/><br/></summary>
	[Serializable]
	public partial class CTHTreatmentTypeEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private EntityCollection<CTHKimoSurveyEntity> _cTHKimoSurveyCollection;
		private EntityCollection<CTHPatientAssessmentEntity> _cTHPatientAssessmentCollection;
		private EntityCollection<CTHPatientAssessmentEntity> _cTHPatientAssessmentCollection1;
		private EntityCollection<CTHChemotherapyProtocolEntity> _cTHChemotherapyProtocolCollectionViaCTHKimoSurvey;
		private EntityCollection<CTHPatientEntity> _cTHPatientCollectionViaCTHPatientAssessment;
		private EntityCollection<CTHPatientEntity> _cTHPatientCollectionViaCTHPatientAssessment1;
		private EntityCollection<CTHPatientClinicalDataEntity> _cTHPatientClinicalDataCollectionViaCTHKimoSurvey;
		private EntityCollection<CTHProtocolCycleEntity> _cTHProtocolCycleCollectionViaCTHKimoSurvey;
		private EntityCollection<CTHSpecialCaseEntity> _cTHSpecialCaseCollectionViaCTHKimoSurvey;
		private EntityCollection<CTHSpecialCasePartEntity> _cTHSpecialCasePartCollectionViaCTHKimoSurvey;
		private EntityCollection<CTHTreatmentTypeEntity> _cTHTreatmentTypeCollectionViaCTHPatientAssessment;
		private EntityCollection<CTHTreatmentTypeEntity> _cTHTreatmentTypeCollectionViaCTHPatientAssessment_;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static CTHTreatmentTypeEntityStaticMetaData _staticMetaData = new CTHTreatmentTypeEntityStaticMetaData();
		private static CTHTreatmentTypeRelations _relationsFactory = new CTHTreatmentTypeRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CTHKimoSurveyCollection</summary>
			public static readonly string CTHKimoSurveyCollection = "CTHKimoSurveyCollection";
			/// <summary>Member name CTHPatientAssessmentCollection</summary>
			public static readonly string CTHPatientAssessmentCollection = "CTHPatientAssessmentCollection";
			/// <summary>Member name CTHPatientAssessmentCollection1</summary>
			public static readonly string CTHPatientAssessmentCollection1 = "CTHPatientAssessmentCollection1";
			/// <summary>Member name CTHChemotherapyProtocolCollectionViaCTHKimoSurvey</summary>
			public static readonly string CTHChemotherapyProtocolCollectionViaCTHKimoSurvey = "CTHChemotherapyProtocolCollectionViaCTHKimoSurvey";
			/// <summary>Member name CTHPatientCollectionViaCTHPatientAssessment</summary>
			public static readonly string CTHPatientCollectionViaCTHPatientAssessment = "CTHPatientCollectionViaCTHPatientAssessment";
			/// <summary>Member name CTHPatientCollectionViaCTHPatientAssessment1</summary>
			public static readonly string CTHPatientCollectionViaCTHPatientAssessment1 = "CTHPatientCollectionViaCTHPatientAssessment1";
			/// <summary>Member name CTHPatientClinicalDataCollectionViaCTHKimoSurvey</summary>
			public static readonly string CTHPatientClinicalDataCollectionViaCTHKimoSurvey = "CTHPatientClinicalDataCollectionViaCTHKimoSurvey";
			/// <summary>Member name CTHProtocolCycleCollectionViaCTHKimoSurvey</summary>
			public static readonly string CTHProtocolCycleCollectionViaCTHKimoSurvey = "CTHProtocolCycleCollectionViaCTHKimoSurvey";
			/// <summary>Member name CTHSpecialCaseCollectionViaCTHKimoSurvey</summary>
			public static readonly string CTHSpecialCaseCollectionViaCTHKimoSurvey = "CTHSpecialCaseCollectionViaCTHKimoSurvey";
			/// <summary>Member name CTHSpecialCasePartCollectionViaCTHKimoSurvey</summary>
			public static readonly string CTHSpecialCasePartCollectionViaCTHKimoSurvey = "CTHSpecialCasePartCollectionViaCTHKimoSurvey";
			/// <summary>Member name CTHTreatmentTypeCollectionViaCTHPatientAssessment</summary>
			public static readonly string CTHTreatmentTypeCollectionViaCTHPatientAssessment = "CTHTreatmentTypeCollectionViaCTHPatientAssessment";
			/// <summary>Member name CTHTreatmentTypeCollectionViaCTHPatientAssessment_</summary>
			public static readonly string CTHTreatmentTypeCollectionViaCTHPatientAssessment_ = "CTHTreatmentTypeCollectionViaCTHPatientAssessment_";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class CTHTreatmentTypeEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public CTHTreatmentTypeEntityStaticMetaData()
			{
				SetEntityCoreInfo("CTHTreatmentTypeEntity", InheritanceHierarchyType.None, false, (int)SStorm.CTH.DAL.EntityType.CTHTreatmentTypeEntity, typeof(CTHTreatmentTypeEntity), typeof(CTHTreatmentTypeEntityFactory), false);
				AddNavigatorMetaData<CTHTreatmentTypeEntity, EntityCollection<CTHKimoSurveyEntity>>("CTHKimoSurveyCollection", a => a._cTHKimoSurveyCollection, (a, b) => a._cTHKimoSurveyCollection = b, a => a.CTHKimoSurveyCollection, () => new CTHTreatmentTypeRelations().CTHKimoSurveyEntityUsingTreatementTypeID, typeof(CTHKimoSurveyEntity), (int)SStorm.CTH.DAL.EntityType.CTHKimoSurveyEntity);
				AddNavigatorMetaData<CTHTreatmentTypeEntity, EntityCollection<CTHPatientAssessmentEntity>>("CTHPatientAssessmentCollection", a => a._cTHPatientAssessmentCollection, (a, b) => a._cTHPatientAssessmentCollection = b, a => a.CTHPatientAssessmentCollection, () => new CTHTreatmentTypeRelations().CTHPatientAssessmentEntityUsingTreatmentPlanID, typeof(CTHPatientAssessmentEntity), (int)SStorm.CTH.DAL.EntityType.CTHPatientAssessmentEntity);
				AddNavigatorMetaData<CTHTreatmentTypeEntity, EntityCollection<CTHPatientAssessmentEntity>>("CTHPatientAssessmentCollection1", a => a._cTHPatientAssessmentCollection1, (a, b) => a._cTHPatientAssessmentCollection1 = b, a => a.CTHPatientAssessmentCollection1, () => new CTHTreatmentTypeRelations().CTHPatientAssessmentEntityUsingTreatmentResponseID, typeof(CTHPatientAssessmentEntity), (int)SStorm.CTH.DAL.EntityType.CTHPatientAssessmentEntity);
				AddNavigatorMetaData<CTHTreatmentTypeEntity, EntityCollection<CTHChemotherapyProtocolEntity>>("CTHChemotherapyProtocolCollectionViaCTHKimoSurvey", a => a._cTHChemotherapyProtocolCollectionViaCTHKimoSurvey, (a, b) => a._cTHChemotherapyProtocolCollectionViaCTHKimoSurvey = b, a => a.CTHChemotherapyProtocolCollectionViaCTHKimoSurvey, () => new CTHTreatmentTypeRelations().CTHKimoSurveyEntityUsingTreatementTypeID, () => new CTHKimoSurveyRelations().CTHChemotherapyProtocolEntityUsingProtocolID, "CTHTreatmentTypeEntity__", "CTHKimoSurvey_", typeof(CTHChemotherapyProtocolEntity), (int)SStorm.CTH.DAL.EntityType.CTHChemotherapyProtocolEntity);
				AddNavigatorMetaData<CTHTreatmentTypeEntity, EntityCollection<CTHPatientEntity>>("CTHPatientCollectionViaCTHPatientAssessment", a => a._cTHPatientCollectionViaCTHPatientAssessment, (a, b) => a._cTHPatientCollectionViaCTHPatientAssessment = b, a => a.CTHPatientCollectionViaCTHPatientAssessment, () => new CTHTreatmentTypeRelations().CTHPatientAssessmentEntityUsingTreatmentPlanID, () => new CTHPatientAssessmentRelations().CTHPatientEntityUsingPatientID, "CTHTreatmentTypeEntity__", "CTHPatientAssessment_", typeof(CTHPatientEntity), (int)SStorm.CTH.DAL.EntityType.CTHPatientEntity);
				AddNavigatorMetaData<CTHTreatmentTypeEntity, EntityCollection<CTHPatientEntity>>("CTHPatientCollectionViaCTHPatientAssessment1", a => a._cTHPatientCollectionViaCTHPatientAssessment1, (a, b) => a._cTHPatientCollectionViaCTHPatientAssessment1 = b, a => a.CTHPatientCollectionViaCTHPatientAssessment1, () => new CTHTreatmentTypeRelations().CTHPatientAssessmentEntityUsingTreatmentResponseID, () => new CTHPatientAssessmentRelations().CTHPatientEntityUsingPatientID, "CTHTreatmentTypeEntity__", "CTHPatientAssessment_", typeof(CTHPatientEntity), (int)SStorm.CTH.DAL.EntityType.CTHPatientEntity);
				AddNavigatorMetaData<CTHTreatmentTypeEntity, EntityCollection<CTHPatientClinicalDataEntity>>("CTHPatientClinicalDataCollectionViaCTHKimoSurvey", a => a._cTHPatientClinicalDataCollectionViaCTHKimoSurvey, (a, b) => a._cTHPatientClinicalDataCollectionViaCTHKimoSurvey = b, a => a.CTHPatientClinicalDataCollectionViaCTHKimoSurvey, () => new CTHTreatmentTypeRelations().CTHKimoSurveyEntityUsingTreatementTypeID, () => new CTHKimoSurveyRelations().CTHPatientClinicalDataEntityUsingPatientClinicalDataID, "CTHTreatmentTypeEntity__", "CTHKimoSurvey_", typeof(CTHPatientClinicalDataEntity), (int)SStorm.CTH.DAL.EntityType.CTHPatientClinicalDataEntity);
				AddNavigatorMetaData<CTHTreatmentTypeEntity, EntityCollection<CTHProtocolCycleEntity>>("CTHProtocolCycleCollectionViaCTHKimoSurvey", a => a._cTHProtocolCycleCollectionViaCTHKimoSurvey, (a, b) => a._cTHProtocolCycleCollectionViaCTHKimoSurvey = b, a => a.CTHProtocolCycleCollectionViaCTHKimoSurvey, () => new CTHTreatmentTypeRelations().CTHKimoSurveyEntityUsingTreatementTypeID, () => new CTHKimoSurveyRelations().CTHProtocolCycleEntityUsingCycleID, "CTHTreatmentTypeEntity__", "CTHKimoSurvey_", typeof(CTHProtocolCycleEntity), (int)SStorm.CTH.DAL.EntityType.CTHProtocolCycleEntity);
				AddNavigatorMetaData<CTHTreatmentTypeEntity, EntityCollection<CTHSpecialCaseEntity>>("CTHSpecialCaseCollectionViaCTHKimoSurvey", a => a._cTHSpecialCaseCollectionViaCTHKimoSurvey, (a, b) => a._cTHSpecialCaseCollectionViaCTHKimoSurvey = b, a => a.CTHSpecialCaseCollectionViaCTHKimoSurvey, () => new CTHTreatmentTypeRelations().CTHKimoSurveyEntityUsingTreatementTypeID, () => new CTHKimoSurveyRelations().CTHSpecialCaseEntityUsingSpecialCaseID, "CTHTreatmentTypeEntity__", "CTHKimoSurvey_", typeof(CTHSpecialCaseEntity), (int)SStorm.CTH.DAL.EntityType.CTHSpecialCaseEntity);
				AddNavigatorMetaData<CTHTreatmentTypeEntity, EntityCollection<CTHSpecialCasePartEntity>>("CTHSpecialCasePartCollectionViaCTHKimoSurvey", a => a._cTHSpecialCasePartCollectionViaCTHKimoSurvey, (a, b) => a._cTHSpecialCasePartCollectionViaCTHKimoSurvey = b, a => a.CTHSpecialCasePartCollectionViaCTHKimoSurvey, () => new CTHTreatmentTypeRelations().CTHKimoSurveyEntityUsingTreatementTypeID, () => new CTHKimoSurveyRelations().CTHSpecialCasePartEntityUsingSpecialCasePartID, "CTHTreatmentTypeEntity__", "CTHKimoSurvey_", typeof(CTHSpecialCasePartEntity), (int)SStorm.CTH.DAL.EntityType.CTHSpecialCasePartEntity);
				AddNavigatorMetaData<CTHTreatmentTypeEntity, EntityCollection<CTHTreatmentTypeEntity>>("CTHTreatmentTypeCollectionViaCTHPatientAssessment", a => a._cTHTreatmentTypeCollectionViaCTHPatientAssessment, (a, b) => a._cTHTreatmentTypeCollectionViaCTHPatientAssessment = b, a => a.CTHTreatmentTypeCollectionViaCTHPatientAssessment, () => new CTHTreatmentTypeRelations().CTHPatientAssessmentEntityUsingTreatmentPlanID, () => new CTHPatientAssessmentRelations().CTHTreatmentTypeEntityUsingTreatmentResponseID, "CTHTreatmentTypeEntity__", "CTHPatientAssessment_", typeof(CTHTreatmentTypeEntity), (int)SStorm.CTH.DAL.EntityType.CTHTreatmentTypeEntity);
				AddNavigatorMetaData<CTHTreatmentTypeEntity, EntityCollection<CTHTreatmentTypeEntity>>("CTHTreatmentTypeCollectionViaCTHPatientAssessment_", a => a._cTHTreatmentTypeCollectionViaCTHPatientAssessment_, (a, b) => a._cTHTreatmentTypeCollectionViaCTHPatientAssessment_ = b, a => a.CTHTreatmentTypeCollectionViaCTHPatientAssessment_, () => new CTHTreatmentTypeRelations().CTHPatientAssessmentEntityUsingTreatmentPlanID, () => new CTHPatientAssessmentRelations().CTHTreatmentTypeEntityUsingTreatmentResponseID, "CTHTreatmentTypeEntity__", "CTHPatientAssessment_", typeof(CTHTreatmentTypeEntity), (int)SStorm.CTH.DAL.EntityType.CTHTreatmentTypeEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static CTHTreatmentTypeEntity()
		{
		}

		/// <summary> CTor</summary>
		public CTHTreatmentTypeEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CTHTreatmentTypeEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CTHTreatmentTypeEntity</param>
		public CTHTreatmentTypeEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHTreatmentType which data should be fetched into this CTHTreatmentType object</param>
		public CTHTreatmentTypeEntity(System.Int32 iD) : this(iD, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHTreatmentType which data should be fetched into this CTHTreatmentType object</param>
		/// <param name="validator">The custom validator object for this CTHTreatmentTypeEntity</param>
		public CTHTreatmentTypeEntity(System.Int32 iD, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CTHTreatmentTypeEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHKimoSurvey' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHKimoSurveyCollection() { return CreateRelationInfoForNavigator("CTHKimoSurveyCollection"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHPatientAssessment' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHPatientAssessmentCollection() { return CreateRelationInfoForNavigator("CTHPatientAssessmentCollection"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHPatientAssessment' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHPatientAssessmentCollection1() { return CreateRelationInfoForNavigator("CTHPatientAssessmentCollection1"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHChemotherapyProtocol' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHChemotherapyProtocolCollectionViaCTHKimoSurvey() { return CreateRelationInfoForNavigator("CTHChemotherapyProtocolCollectionViaCTHKimoSurvey"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHPatient' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHPatientCollectionViaCTHPatientAssessment() { return CreateRelationInfoForNavigator("CTHPatientCollectionViaCTHPatientAssessment"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHPatient' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHPatientCollectionViaCTHPatientAssessment1() { return CreateRelationInfoForNavigator("CTHPatientCollectionViaCTHPatientAssessment1"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHPatientClinicalData' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHPatientClinicalDataCollectionViaCTHKimoSurvey() { return CreateRelationInfoForNavigator("CTHPatientClinicalDataCollectionViaCTHKimoSurvey"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHProtocolCycle' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHProtocolCycleCollectionViaCTHKimoSurvey() { return CreateRelationInfoForNavigator("CTHProtocolCycleCollectionViaCTHKimoSurvey"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHSpecialCase' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHSpecialCaseCollectionViaCTHKimoSurvey() { return CreateRelationInfoForNavigator("CTHSpecialCaseCollectionViaCTHKimoSurvey"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHSpecialCasePart' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHSpecialCasePartCollectionViaCTHKimoSurvey() { return CreateRelationInfoForNavigator("CTHSpecialCasePartCollectionViaCTHKimoSurvey"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHTreatmentType' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHTreatmentTypeCollectionViaCTHPatientAssessment() { return CreateRelationInfoForNavigator("CTHTreatmentTypeCollectionViaCTHPatientAssessment"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHTreatmentType' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHTreatmentTypeCollectionViaCTHPatientAssessment_() { return CreateRelationInfoForNavigator("CTHTreatmentTypeCollectionViaCTHPatientAssessment_"); }
		
		/// <inheritdoc/>
		protected override EntityStaticMetaDataBase GetEntityStaticMetaData() {	return _staticMetaData; }

		/// <summary>Initializes the class members</summary>
		private void InitClassMembers()
		{
			PerformDependencyInjection();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitClassMembersComplete();
		}

		/// <summary>Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CTHTreatmentTypeEntity</param>
		/// <param name="fields">Fields of this entity</param>
		private void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			this.Fields = fields ?? CreateFields();
			this.Validator = validator;
			InitClassMembers();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END


			OnInitialized();
		}

		/// <summary>The relations object holding all relations of this entity with other entity classes.</summary>
		public static CTHTreatmentTypeRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHKimoSurvey' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHKimoSurveyCollection { get { return _staticMetaData.GetPrefetchPathElement("CTHKimoSurveyCollection", CommonEntityBase.CreateEntityCollection<CTHKimoSurveyEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHPatientAssessment' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHPatientAssessmentCollection { get { return _staticMetaData.GetPrefetchPathElement("CTHPatientAssessmentCollection", CommonEntityBase.CreateEntityCollection<CTHPatientAssessmentEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHPatientAssessment' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHPatientAssessmentCollection1 { get { return _staticMetaData.GetPrefetchPathElement("CTHPatientAssessmentCollection1", CommonEntityBase.CreateEntityCollection<CTHPatientAssessmentEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHChemotherapyProtocol' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHChemotherapyProtocolCollectionViaCTHKimoSurvey { get { return _staticMetaData.GetPrefetchPathElement("CTHChemotherapyProtocolCollectionViaCTHKimoSurvey", CommonEntityBase.CreateEntityCollection<CTHChemotherapyProtocolEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHPatient' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHPatientCollectionViaCTHPatientAssessment { get { return _staticMetaData.GetPrefetchPathElement("CTHPatientCollectionViaCTHPatientAssessment", CommonEntityBase.CreateEntityCollection<CTHPatientEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHPatient' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHPatientCollectionViaCTHPatientAssessment1 { get { return _staticMetaData.GetPrefetchPathElement("CTHPatientCollectionViaCTHPatientAssessment1", CommonEntityBase.CreateEntityCollection<CTHPatientEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHPatientClinicalData' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHPatientClinicalDataCollectionViaCTHKimoSurvey { get { return _staticMetaData.GetPrefetchPathElement("CTHPatientClinicalDataCollectionViaCTHKimoSurvey", CommonEntityBase.CreateEntityCollection<CTHPatientClinicalDataEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHProtocolCycle' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHProtocolCycleCollectionViaCTHKimoSurvey { get { return _staticMetaData.GetPrefetchPathElement("CTHProtocolCycleCollectionViaCTHKimoSurvey", CommonEntityBase.CreateEntityCollection<CTHProtocolCycleEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHSpecialCase' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHSpecialCaseCollectionViaCTHKimoSurvey { get { return _staticMetaData.GetPrefetchPathElement("CTHSpecialCaseCollectionViaCTHKimoSurvey", CommonEntityBase.CreateEntityCollection<CTHSpecialCaseEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHSpecialCasePart' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHSpecialCasePartCollectionViaCTHKimoSurvey { get { return _staticMetaData.GetPrefetchPathElement("CTHSpecialCasePartCollectionViaCTHKimoSurvey", CommonEntityBase.CreateEntityCollection<CTHSpecialCasePartEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHTreatmentType' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHTreatmentTypeCollectionViaCTHPatientAssessment { get { return _staticMetaData.GetPrefetchPathElement("CTHTreatmentTypeCollectionViaCTHPatientAssessment", CommonEntityBase.CreateEntityCollection<CTHTreatmentTypeEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHTreatmentType' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHTreatmentTypeCollectionViaCTHPatientAssessment_ { get { return _staticMetaData.GetPrefetchPathElement("CTHTreatmentTypeCollectionViaCTHPatientAssessment_", CommonEntityBase.CreateEntityCollection<CTHTreatmentTypeEntity>()); } }

		/// <summary>The ArTreatmentType property of the Entity CTHTreatmentType<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHTreatmentType"."ArTreatmentType".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ArTreatmentType
		{
			get { return (System.String)GetValue((int)CTHTreatmentTypeFieldIndex.ArTreatmentType, true); }
			set	{ SetValue((int)CTHTreatmentTypeFieldIndex.ArTreatmentType, value); }
		}

		/// <summary>The ID property of the Entity CTHTreatmentType<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHTreatmentType"."ID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)CTHTreatmentTypeFieldIndex.ID, true); }
			set { SetValue((int)CTHTreatmentTypeFieldIndex.ID, value); }		}

		/// <summary>The TreatmentType property of the Entity CTHTreatmentType<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHTreatmentType"."TreatmentType".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String TreatmentType
		{
			get { return (System.String)GetValue((int)CTHTreatmentTypeFieldIndex.TreatmentType, true); }
			set	{ SetValue((int)CTHTreatmentTypeFieldIndex.TreatmentType, value); }
		}

		/// <summary>The WhatTreatment property of the Entity CTHTreatmentType<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHTreatmentType"."WhatTreatment".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> WhatTreatment
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHTreatmentTypeFieldIndex.WhatTreatment, false); }
			set	{ SetValue((int)CTHTreatmentTypeFieldIndex.WhatTreatment, value); }
		}

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHKimoSurveyEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHKimoSurveyEntity))]
		public virtual EntityCollection<CTHKimoSurveyEntity> CTHKimoSurveyCollection { get { return GetOrCreateEntityCollection<CTHKimoSurveyEntity, CTHKimoSurveyEntityFactory>("CTHTreatmentTypeItem", true, false, ref _cTHKimoSurveyCollection); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHPatientAssessmentEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHPatientAssessmentEntity))]
		public virtual EntityCollection<CTHPatientAssessmentEntity> CTHPatientAssessmentCollection { get { return GetOrCreateEntityCollection<CTHPatientAssessmentEntity, CTHPatientAssessmentEntityFactory>("CTHTreatmentTypeItem", true, false, ref _cTHPatientAssessmentCollection); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHPatientAssessmentEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHPatientAssessmentEntity))]
		public virtual EntityCollection<CTHPatientAssessmentEntity> CTHPatientAssessmentCollection1 { get { return GetOrCreateEntityCollection<CTHPatientAssessmentEntity, CTHPatientAssessmentEntityFactory>("CTHTreatmentTypeItem1", true, false, ref _cTHPatientAssessmentCollection1); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHChemotherapyProtocolEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHChemotherapyProtocolEntity))]
		public virtual EntityCollection<CTHChemotherapyProtocolEntity> CTHChemotherapyProtocolCollectionViaCTHKimoSurvey { get { return GetOrCreateEntityCollection<CTHChemotherapyProtocolEntity, CTHChemotherapyProtocolEntityFactory>("CTHTreatmentTypeCollectionViaCTHKimoSurvey", false, true, ref _cTHChemotherapyProtocolCollectionViaCTHKimoSurvey); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHPatientEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHPatientEntity))]
		public virtual EntityCollection<CTHPatientEntity> CTHPatientCollectionViaCTHPatientAssessment { get { return GetOrCreateEntityCollection<CTHPatientEntity, CTHPatientEntityFactory>("CTHTreatmentTypeCollectionViaCTHPatientAssessment", false, true, ref _cTHPatientCollectionViaCTHPatientAssessment); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHPatientEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHPatientEntity))]
		public virtual EntityCollection<CTHPatientEntity> CTHPatientCollectionViaCTHPatientAssessment1 { get { return GetOrCreateEntityCollection<CTHPatientEntity, CTHPatientEntityFactory>("CTHTreatmentTypeCollectionViaCTHPatientAssessment1", false, true, ref _cTHPatientCollectionViaCTHPatientAssessment1); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHPatientClinicalDataEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHPatientClinicalDataEntity))]
		public virtual EntityCollection<CTHPatientClinicalDataEntity> CTHPatientClinicalDataCollectionViaCTHKimoSurvey { get { return GetOrCreateEntityCollection<CTHPatientClinicalDataEntity, CTHPatientClinicalDataEntityFactory>("CTHTreatmentTypeCollectionViaCTHKimoSurvey", false, true, ref _cTHPatientClinicalDataCollectionViaCTHKimoSurvey); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHProtocolCycleEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHProtocolCycleEntity))]
		public virtual EntityCollection<CTHProtocolCycleEntity> CTHProtocolCycleCollectionViaCTHKimoSurvey { get { return GetOrCreateEntityCollection<CTHProtocolCycleEntity, CTHProtocolCycleEntityFactory>("CTHTreatmentTypeCollectionViaCTHKimoSurvey", false, true, ref _cTHProtocolCycleCollectionViaCTHKimoSurvey); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHSpecialCaseEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHSpecialCaseEntity))]
		public virtual EntityCollection<CTHSpecialCaseEntity> CTHSpecialCaseCollectionViaCTHKimoSurvey { get { return GetOrCreateEntityCollection<CTHSpecialCaseEntity, CTHSpecialCaseEntityFactory>("CTHTreatmentTypeCollectionViaCTHKimoSurvey", false, true, ref _cTHSpecialCaseCollectionViaCTHKimoSurvey); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHSpecialCasePartEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHSpecialCasePartEntity))]
		public virtual EntityCollection<CTHSpecialCasePartEntity> CTHSpecialCasePartCollectionViaCTHKimoSurvey { get { return GetOrCreateEntityCollection<CTHSpecialCasePartEntity, CTHSpecialCasePartEntityFactory>("CTHTreatmentTypeCollectionViaCTHKimoSurvey", false, true, ref _cTHSpecialCasePartCollectionViaCTHKimoSurvey); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHTreatmentTypeEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHTreatmentTypeEntity))]
		public virtual EntityCollection<CTHTreatmentTypeEntity> CTHTreatmentTypeCollectionViaCTHPatientAssessment { get { return GetOrCreateEntityCollection<CTHTreatmentTypeEntity, CTHTreatmentTypeEntityFactory>("CTHTreatmentTypeCollectionViaCTHPatientAssessment_", false, true, ref _cTHTreatmentTypeCollectionViaCTHPatientAssessment); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHTreatmentTypeEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHTreatmentTypeEntity))]
		public virtual EntityCollection<CTHTreatmentTypeEntity> CTHTreatmentTypeCollectionViaCTHPatientAssessment_ { get { return GetOrCreateEntityCollection<CTHTreatmentTypeEntity, CTHTreatmentTypeEntityFactory>("CTHTreatmentTypeCollectionViaCTHPatientAssessment", false, true, ref _cTHTreatmentTypeCollectionViaCTHPatientAssessment_); } }
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace SStorm.CTH.DAL
{
	public enum CTHTreatmentTypeFieldIndex
	{
		///<summary>ArTreatmentType. </summary>
		ArTreatmentType,
		///<summary>ID. </summary>
		ID,
		///<summary>TreatmentType. </summary>
		TreatmentType,
		///<summary>WhatTreatment. </summary>
		WhatTreatment,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace SStorm.CTH.DAL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: CTHTreatmentType. </summary>
	public partial class CTHTreatmentTypeRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between CTHTreatmentTypeEntity and CTHKimoSurveyEntity over the 1:n relation they have, using the relation between the fields: CTHTreatmentType.ID - CTHKimoSurvey.TreatementTypeID</summary>
		public virtual IEntityRelation CTHKimoSurveyEntityUsingTreatementTypeID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "CTHKimoSurveyCollection", true, new[] { CTHTreatmentTypeFields.ID, CTHKimoSurveyFields.TreatementTypeID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHTreatmentTypeEntity and CTHPatientAssessmentEntity over the 1:n relation they have, using the relation between the fields: CTHTreatmentType.ID - CTHPatientAssessment.TreatmentPlanID</summary>
		public virtual IEntityRelation CTHPatientAssessmentEntityUsingTreatmentPlanID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "CTHPatientAssessmentCollection", true, new[] { CTHTreatmentTypeFields.ID, CTHPatientAssessmentFields.TreatmentPlanID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHTreatmentTypeEntity and CTHPatientAssessmentEntity over the 1:n relation they have, using the relation between the fields: CTHTreatmentType.ID - CTHPatientAssessment.TreatmentResponseID</summary>
		public virtual IEntityRelation CTHPatientAssessmentEntityUsingTreatmentResponseID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "CTHPatientAssessmentCollection1", true, new[] { CTHTreatmentTypeFields.ID, CTHPatientAssessmentFields.TreatmentResponseID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCTHTreatmentTypeRelations
	{
		internal static readonly IEntityRelation CTHKimoSurveyEntityUsingTreatementTypeIDStatic = new CTHTreatmentTypeRelations().CTHKimoSurveyEntityUsingTreatementTypeID;
		internal static readonly IEntityRelation CTHPatientAssessmentEntityUsingTreatmentPlanIDStatic = new CTHTreatmentTypeRelations().CTHPatientAssessmentEntityUsingTreatmentPlanID;
		internal static readonly IEntityRelation CTHPatientAssessmentEntityUsingTreatmentResponseIDStatic = new CTHTreatmentTypeRelations().CTHPatientAssessmentEntityUsingTreatmentResponseID;

		/// <summary>CTor</summary>
		static StaticCTHTreatmentTypeRelations() { }
	}
}
