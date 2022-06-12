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

	/// <summary>Entity class which represents the entity 'CTHPatientSymptom'.<br/><br/></summary>
	[Serializable]
	public partial class CTHPatientSymptomEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private EntityCollection<CTHNotificationEntity> _cTHNotificationCollection;
		private EntityCollection<CTHDoctorEntity> _cTHDoctorCollectionViaCTHNotification;
		private EntityCollection<CTHKimoSurveyEntity> _cTHKimoSurveyCollectionViaCTHNotification;
		private EntityCollection<CTHPatientEntity> _cTHPatientCollectionViaCTHNotification;
		private CTHKimoSurveyEntity _cTHKimoSurveyItem;
		private CTHPatientEntity _cTHPatientItem;
		private CTHSymptomEntity _cTHSymptomItem;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static CTHPatientSymptomEntityStaticMetaData _staticMetaData = new CTHPatientSymptomEntityStaticMetaData();
		private static CTHPatientSymptomRelations _relationsFactory = new CTHPatientSymptomRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CTHKimoSurveyItem</summary>
			public static readonly string CTHKimoSurveyItem = "CTHKimoSurveyItem";
			/// <summary>Member name CTHPatientItem</summary>
			public static readonly string CTHPatientItem = "CTHPatientItem";
			/// <summary>Member name CTHSymptomItem</summary>
			public static readonly string CTHSymptomItem = "CTHSymptomItem";
			/// <summary>Member name CTHNotificationCollection</summary>
			public static readonly string CTHNotificationCollection = "CTHNotificationCollection";
			/// <summary>Member name CTHDoctorCollectionViaCTHNotification</summary>
			public static readonly string CTHDoctorCollectionViaCTHNotification = "CTHDoctorCollectionViaCTHNotification";
			/// <summary>Member name CTHKimoSurveyCollectionViaCTHNotification</summary>
			public static readonly string CTHKimoSurveyCollectionViaCTHNotification = "CTHKimoSurveyCollectionViaCTHNotification";
			/// <summary>Member name CTHPatientCollectionViaCTHNotification</summary>
			public static readonly string CTHPatientCollectionViaCTHNotification = "CTHPatientCollectionViaCTHNotification";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class CTHPatientSymptomEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public CTHPatientSymptomEntityStaticMetaData()
			{
				SetEntityCoreInfo("CTHPatientSymptomEntity", InheritanceHierarchyType.None, false, (int)SStorm.CTH.DAL.EntityType.CTHPatientSymptomEntity, typeof(CTHPatientSymptomEntity), typeof(CTHPatientSymptomEntityFactory), false);
				AddNavigatorMetaData<CTHPatientSymptomEntity, EntityCollection<CTHNotificationEntity>>("CTHNotificationCollection", a => a._cTHNotificationCollection, (a, b) => a._cTHNotificationCollection = b, a => a.CTHNotificationCollection, () => new CTHPatientSymptomRelations().CTHNotificationEntityUsingPatientSymptomID, typeof(CTHNotificationEntity), (int)SStorm.CTH.DAL.EntityType.CTHNotificationEntity);
				AddNavigatorMetaData<CTHPatientSymptomEntity, CTHKimoSurveyEntity>("CTHKimoSurveyItem", "CTHPatientSymptomCollection", (a, b) => a._cTHKimoSurveyItem = b, a => a._cTHKimoSurveyItem, (a, b) => a.CTHKimoSurveyItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHPatientSymptomRelations.CTHKimoSurveyEntityUsingChemoIDStatic, ()=>new CTHPatientSymptomRelations().CTHKimoSurveyEntityUsingChemoID, null, new int[] { (int)CTHPatientSymptomFieldIndex.ChemoID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHKimoSurveyEntity);
				AddNavigatorMetaData<CTHPatientSymptomEntity, CTHPatientEntity>("CTHPatientItem", "CTHPatientSymptomCollection", (a, b) => a._cTHPatientItem = b, a => a._cTHPatientItem, (a, b) => a.CTHPatientItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHPatientSymptomRelations.CTHPatientEntityUsingPatientIDStatic, ()=>new CTHPatientSymptomRelations().CTHPatientEntityUsingPatientID, null, new int[] { (int)CTHPatientSymptomFieldIndex.PatientID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHPatientEntity);
				AddNavigatorMetaData<CTHPatientSymptomEntity, CTHSymptomEntity>("CTHSymptomItem", "CTHPatientSymptomCollection", (a, b) => a._cTHSymptomItem = b, a => a._cTHSymptomItem, (a, b) => a.CTHSymptomItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHPatientSymptomRelations.CTHSymptomEntityUsingSymptomIDStatic, ()=>new CTHPatientSymptomRelations().CTHSymptomEntityUsingSymptomID, null, new int[] { (int)CTHPatientSymptomFieldIndex.SymptomID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHSymptomEntity);
				AddNavigatorMetaData<CTHPatientSymptomEntity, EntityCollection<CTHDoctorEntity>>("CTHDoctorCollectionViaCTHNotification", a => a._cTHDoctorCollectionViaCTHNotification, (a, b) => a._cTHDoctorCollectionViaCTHNotification = b, a => a.CTHDoctorCollectionViaCTHNotification, () => new CTHPatientSymptomRelations().CTHNotificationEntityUsingPatientSymptomID, () => new CTHNotificationRelations().CTHDoctorEntityUsingDoctorID, "CTHPatientSymptomEntity__", "CTHNotification_", typeof(CTHDoctorEntity), (int)SStorm.CTH.DAL.EntityType.CTHDoctorEntity);
				AddNavigatorMetaData<CTHPatientSymptomEntity, EntityCollection<CTHKimoSurveyEntity>>("CTHKimoSurveyCollectionViaCTHNotification", a => a._cTHKimoSurveyCollectionViaCTHNotification, (a, b) => a._cTHKimoSurveyCollectionViaCTHNotification = b, a => a.CTHKimoSurveyCollectionViaCTHNotification, () => new CTHPatientSymptomRelations().CTHNotificationEntityUsingPatientSymptomID, () => new CTHNotificationRelations().CTHKimoSurveyEntityUsingKimoID, "CTHPatientSymptomEntity__", "CTHNotification_", typeof(CTHKimoSurveyEntity), (int)SStorm.CTH.DAL.EntityType.CTHKimoSurveyEntity);
				AddNavigatorMetaData<CTHPatientSymptomEntity, EntityCollection<CTHPatientEntity>>("CTHPatientCollectionViaCTHNotification", a => a._cTHPatientCollectionViaCTHNotification, (a, b) => a._cTHPatientCollectionViaCTHNotification = b, a => a.CTHPatientCollectionViaCTHNotification, () => new CTHPatientSymptomRelations().CTHNotificationEntityUsingPatientSymptomID, () => new CTHNotificationRelations().CTHPatientEntityUsingPatientID, "CTHPatientSymptomEntity__", "CTHNotification_", typeof(CTHPatientEntity), (int)SStorm.CTH.DAL.EntityType.CTHPatientEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static CTHPatientSymptomEntity()
		{
		}

		/// <summary> CTor</summary>
		public CTHPatientSymptomEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CTHPatientSymptomEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CTHPatientSymptomEntity</param>
		public CTHPatientSymptomEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHPatientSymptom which data should be fetched into this CTHPatientSymptom object</param>
		public CTHPatientSymptomEntity(System.Int32 iD) : this(iD, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHPatientSymptom which data should be fetched into this CTHPatientSymptom object</param>
		/// <param name="validator">The custom validator object for this CTHPatientSymptomEntity</param>
		public CTHPatientSymptomEntity(System.Int32 iD, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CTHPatientSymptomEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHNotification' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHNotificationCollection() { return CreateRelationInfoForNavigator("CTHNotificationCollection"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHDoctor' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHDoctorCollectionViaCTHNotification() { return CreateRelationInfoForNavigator("CTHDoctorCollectionViaCTHNotification"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHKimoSurvey' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHKimoSurveyCollectionViaCTHNotification() { return CreateRelationInfoForNavigator("CTHKimoSurveyCollectionViaCTHNotification"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHPatient' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHPatientCollectionViaCTHNotification() { return CreateRelationInfoForNavigator("CTHPatientCollectionViaCTHNotification"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHKimoSurvey' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHKimoSurveyItem() { return CreateRelationInfoForNavigator("CTHKimoSurveyItem"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHPatient' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHPatientItem() { return CreateRelationInfoForNavigator("CTHPatientItem"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHSymptom' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHSymptomItem() { return CreateRelationInfoForNavigator("CTHSymptomItem"); }
		
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
		/// <param name="validator">The validator object for this CTHPatientSymptomEntity</param>
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
		public static CTHPatientSymptomRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHNotification' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHNotificationCollection { get { return _staticMetaData.GetPrefetchPathElement("CTHNotificationCollection", CommonEntityBase.CreateEntityCollection<CTHNotificationEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHDoctor' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHDoctorCollectionViaCTHNotification { get { return _staticMetaData.GetPrefetchPathElement("CTHDoctorCollectionViaCTHNotification", CommonEntityBase.CreateEntityCollection<CTHDoctorEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHKimoSurvey' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHKimoSurveyCollectionViaCTHNotification { get { return _staticMetaData.GetPrefetchPathElement("CTHKimoSurveyCollectionViaCTHNotification", CommonEntityBase.CreateEntityCollection<CTHKimoSurveyEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHPatient' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHPatientCollectionViaCTHNotification { get { return _staticMetaData.GetPrefetchPathElement("CTHPatientCollectionViaCTHNotification", CommonEntityBase.CreateEntityCollection<CTHPatientEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHKimoSurvey' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHKimoSurveyItem { get { return _staticMetaData.GetPrefetchPathElement("CTHKimoSurveyItem", CommonEntityBase.CreateEntityCollection<CTHKimoSurveyEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHPatient' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHPatientItem { get { return _staticMetaData.GetPrefetchPathElement("CTHPatientItem", CommonEntityBase.CreateEntityCollection<CTHPatientEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHSymptom' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHSymptomItem { get { return _staticMetaData.GetPrefetchPathElement("CTHSymptomItem", CommonEntityBase.CreateEntityCollection<CTHSymptomEntity>()); } }

		/// <summary>The ArDoctorRecommendation property of the Entity CTHPatientSymptom<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHPatientSymptom"."ArDoctorRecommendation".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ArDoctorRecommendation
		{
			get { return (System.String)GetValue((int)CTHPatientSymptomFieldIndex.ArDoctorRecommendation, true); }
			set	{ SetValue((int)CTHPatientSymptomFieldIndex.ArDoctorRecommendation, value); }
		}

		/// <summary>The ChemoID property of the Entity CTHPatientSymptom<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHPatientSymptom"."ChemoID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ChemoID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHPatientSymptomFieldIndex.ChemoID, false); }
			set	{ SetValue((int)CTHPatientSymptomFieldIndex.ChemoID, value); }
		}

		/// <summary>The Date property of the Entity CTHPatientSymptom<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHPatientSymptom"."Date".<br/>Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> Date
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CTHPatientSymptomFieldIndex.Date, false); }
			set	{ SetValue((int)CTHPatientSymptomFieldIndex.Date, value); }
		}

		/// <summary>The EnDoctorRecommendation property of the Entity CTHPatientSymptom<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHPatientSymptom"."EnDoctorRecommendation".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String EnDoctorRecommendation
		{
			get { return (System.String)GetValue((int)CTHPatientSymptomFieldIndex.EnDoctorRecommendation, true); }
			set	{ SetValue((int)CTHPatientSymptomFieldIndex.EnDoctorRecommendation, value); }
		}

		/// <summary>The ID property of the Entity CTHPatientSymptom<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHPatientSymptom"."ID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)CTHPatientSymptomFieldIndex.ID, true); }
			set { SetValue((int)CTHPatientSymptomFieldIndex.ID, value); }		}

		/// <summary>The PatientID property of the Entity CTHPatientSymptom<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHPatientSymptom"."PatientID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> PatientID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHPatientSymptomFieldIndex.PatientID, false); }
			set	{ SetValue((int)CTHPatientSymptomFieldIndex.PatientID, value); }
		}

		/// <summary>The SymptomDurationAmount property of the Entity CTHPatientSymptom<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHPatientSymptom"."SymptomDurationAmount".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> SymptomDurationAmount
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHPatientSymptomFieldIndex.SymptomDurationAmount, false); }
			set	{ SetValue((int)CTHPatientSymptomFieldIndex.SymptomDurationAmount, value); }
		}

		/// <summary>The SymptomDurationUnit property of the Entity CTHPatientSymptom<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHPatientSymptom"."SymptomDurationUnit".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> SymptomDurationUnit
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHPatientSymptomFieldIndex.SymptomDurationUnit, false); }
			set	{ SetValue((int)CTHPatientSymptomFieldIndex.SymptomDurationUnit, value); }
		}

		/// <summary>The SymptomID property of the Entity CTHPatientSymptom<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHPatientSymptom"."SymptomID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> SymptomID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHPatientSymptomFieldIndex.SymptomID, false); }
			set	{ SetValue((int)CTHPatientSymptomFieldIndex.SymptomID, value); }
		}

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHNotificationEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHNotificationEntity))]
		public virtual EntityCollection<CTHNotificationEntity> CTHNotificationCollection { get { return GetOrCreateEntityCollection<CTHNotificationEntity, CTHNotificationEntityFactory>("CTHPatientSymptomItem", true, false, ref _cTHNotificationCollection); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHDoctorEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHDoctorEntity))]
		public virtual EntityCollection<CTHDoctorEntity> CTHDoctorCollectionViaCTHNotification { get { return GetOrCreateEntityCollection<CTHDoctorEntity, CTHDoctorEntityFactory>("CTHPatientSymptomCollectionViaCTHNotification", false, true, ref _cTHDoctorCollectionViaCTHNotification); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHKimoSurveyEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHKimoSurveyEntity))]
		public virtual EntityCollection<CTHKimoSurveyEntity> CTHKimoSurveyCollectionViaCTHNotification { get { return GetOrCreateEntityCollection<CTHKimoSurveyEntity, CTHKimoSurveyEntityFactory>("CTHPatientSymptomCollectionViaCTHNotification", false, true, ref _cTHKimoSurveyCollectionViaCTHNotification); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHPatientEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHPatientEntity))]
		public virtual EntityCollection<CTHPatientEntity> CTHPatientCollectionViaCTHNotification { get { return GetOrCreateEntityCollection<CTHPatientEntity, CTHPatientEntityFactory>("CTHPatientSymptomCollectionViaCTHNotification", false, true, ref _cTHPatientCollectionViaCTHNotification); } }

		/// <summary>Gets / sets related entity of type 'CTHKimoSurveyEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHKimoSurveyEntity CTHKimoSurveyItem
		{
			get { return _cTHKimoSurveyItem; }
			set { SetSingleRelatedEntityNavigator(value, "CTHKimoSurveyItem"); }
		}

		/// <summary>Gets / sets related entity of type 'CTHPatientEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHPatientEntity CTHPatientItem
		{
			get { return _cTHPatientItem; }
			set { SetSingleRelatedEntityNavigator(value, "CTHPatientItem"); }
		}

		/// <summary>Gets / sets related entity of type 'CTHSymptomEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHSymptomEntity CTHSymptomItem
		{
			get { return _cTHSymptomItem; }
			set { SetSingleRelatedEntityNavigator(value, "CTHSymptomItem"); }
		}
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace SStorm.CTH.DAL
{
	public enum CTHPatientSymptomFieldIndex
	{
		///<summary>ArDoctorRecommendation. </summary>
		ArDoctorRecommendation,
		///<summary>ChemoID. </summary>
		ChemoID,
		///<summary>Date. </summary>
		Date,
		///<summary>EnDoctorRecommendation. </summary>
		EnDoctorRecommendation,
		///<summary>ID. </summary>
		ID,
		///<summary>PatientID. </summary>
		PatientID,
		///<summary>SymptomDurationAmount. </summary>
		SymptomDurationAmount,
		///<summary>SymptomDurationUnit. </summary>
		SymptomDurationUnit,
		///<summary>SymptomID. </summary>
		SymptomID,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace SStorm.CTH.DAL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: CTHPatientSymptom. </summary>
	public partial class CTHPatientSymptomRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between CTHPatientSymptomEntity and CTHNotificationEntity over the 1:n relation they have, using the relation between the fields: CTHPatientSymptom.ID - CTHNotification.PatientSymptomID</summary>
		public virtual IEntityRelation CTHNotificationEntityUsingPatientSymptomID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "CTHNotificationCollection", true, new[] { CTHPatientSymptomFields.ID, CTHNotificationFields.PatientSymptomID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHPatientSymptomEntity and CTHKimoSurveyEntity over the m:1 relation they have, using the relation between the fields: CTHPatientSymptom.ChemoID - CTHKimoSurvey.ID</summary>
		public virtual IEntityRelation CTHKimoSurveyEntityUsingChemoID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHKimoSurveyItem", false, new[] { CTHKimoSurveyFields.ID, CTHPatientSymptomFields.ChemoID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHPatientSymptomEntity and CTHPatientEntity over the m:1 relation they have, using the relation between the fields: CTHPatientSymptom.PatientID - CTHPatient.ID</summary>
		public virtual IEntityRelation CTHPatientEntityUsingPatientID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHPatientItem", false, new[] { CTHPatientFields.ID, CTHPatientSymptomFields.PatientID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHPatientSymptomEntity and CTHSymptomEntity over the m:1 relation they have, using the relation between the fields: CTHPatientSymptom.SymptomID - CTHSymptom.ID</summary>
		public virtual IEntityRelation CTHSymptomEntityUsingSymptomID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHSymptomItem", false, new[] { CTHSymptomFields.ID, CTHPatientSymptomFields.SymptomID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCTHPatientSymptomRelations
	{
		internal static readonly IEntityRelation CTHNotificationEntityUsingPatientSymptomIDStatic = new CTHPatientSymptomRelations().CTHNotificationEntityUsingPatientSymptomID;
		internal static readonly IEntityRelation CTHKimoSurveyEntityUsingChemoIDStatic = new CTHPatientSymptomRelations().CTHKimoSurveyEntityUsingChemoID;
		internal static readonly IEntityRelation CTHPatientEntityUsingPatientIDStatic = new CTHPatientSymptomRelations().CTHPatientEntityUsingPatientID;
		internal static readonly IEntityRelation CTHSymptomEntityUsingSymptomIDStatic = new CTHPatientSymptomRelations().CTHSymptomEntityUsingSymptomID;

		/// <summary>CTor</summary>
		static StaticCTHPatientSymptomRelations() { }
	}
}