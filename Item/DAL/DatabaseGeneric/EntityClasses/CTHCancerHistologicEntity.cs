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

	/// <summary>Entity class which represents the entity 'CTHCancerHistologic'.<br/><br/></summary>
	[Serializable]
	public partial class CTHCancerHistologicEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private EntityCollection<CTHCancerHistologicEntity> _cTHCancerHistologicCollection;
		private EntityCollection<CTHPatientClinicalDataEntity> _cTHPatientClinicalDataCollection;
		private EntityCollection<CTHCancerMolecularEntity> _cTHCancerMolecularCollectionViaCTHPatientClinicalData;
		private EntityCollection<CTHCancerSideEntity> _cTHCancerSideCollectionViaCTHPatientClinicalData;
		private EntityCollection<CTHCancerTypeEntity> _cTHCancerTypeCollectionViaCTHCancerHistologic;
		private EntityCollection<CTHCancerTypeEntity> _cTHCancerTypeCollectionViaCTHPatientClinicalData;
		private EntityCollection<CTHPatientEntity> _cTHPatientCollectionViaCTHPatientClinicalData;
		private EntityCollection<CTHStagingEntity> _cTHStagingCollectionViaCTHPatientClinicalData;
		private EntityCollection<CTHTumorGradeEntity> _cTHTumorGradeCollectionViaCTHPatientClinicalData;
		private CTHCancerHistologicEntity _cTHCancerHistologicItem;
		private CTHCancerTypeEntity _cTHCancerTypeItem;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static CTHCancerHistologicEntityStaticMetaData _staticMetaData = new CTHCancerHistologicEntityStaticMetaData();
		private static CTHCancerHistologicRelations _relationsFactory = new CTHCancerHistologicRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CTHCancerHistologicItem</summary>
			public static readonly string CTHCancerHistologicItem = "CTHCancerHistologicItem";
			/// <summary>Member name CTHCancerTypeItem</summary>
			public static readonly string CTHCancerTypeItem = "CTHCancerTypeItem";
			/// <summary>Member name CTHCancerHistologicCollection</summary>
			public static readonly string CTHCancerHistologicCollection = "CTHCancerHistologicCollection";
			/// <summary>Member name CTHPatientClinicalDataCollection</summary>
			public static readonly string CTHPatientClinicalDataCollection = "CTHPatientClinicalDataCollection";
			/// <summary>Member name CTHCancerMolecularCollectionViaCTHPatientClinicalData</summary>
			public static readonly string CTHCancerMolecularCollectionViaCTHPatientClinicalData = "CTHCancerMolecularCollectionViaCTHPatientClinicalData";
			/// <summary>Member name CTHCancerSideCollectionViaCTHPatientClinicalData</summary>
			public static readonly string CTHCancerSideCollectionViaCTHPatientClinicalData = "CTHCancerSideCollectionViaCTHPatientClinicalData";
			/// <summary>Member name CTHCancerTypeCollectionViaCTHCancerHistologic</summary>
			public static readonly string CTHCancerTypeCollectionViaCTHCancerHistologic = "CTHCancerTypeCollectionViaCTHCancerHistologic";
			/// <summary>Member name CTHCancerTypeCollectionViaCTHPatientClinicalData</summary>
			public static readonly string CTHCancerTypeCollectionViaCTHPatientClinicalData = "CTHCancerTypeCollectionViaCTHPatientClinicalData";
			/// <summary>Member name CTHPatientCollectionViaCTHPatientClinicalData</summary>
			public static readonly string CTHPatientCollectionViaCTHPatientClinicalData = "CTHPatientCollectionViaCTHPatientClinicalData";
			/// <summary>Member name CTHStagingCollectionViaCTHPatientClinicalData</summary>
			public static readonly string CTHStagingCollectionViaCTHPatientClinicalData = "CTHStagingCollectionViaCTHPatientClinicalData";
			/// <summary>Member name CTHTumorGradeCollectionViaCTHPatientClinicalData</summary>
			public static readonly string CTHTumorGradeCollectionViaCTHPatientClinicalData = "CTHTumorGradeCollectionViaCTHPatientClinicalData";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class CTHCancerHistologicEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public CTHCancerHistologicEntityStaticMetaData()
			{
				SetEntityCoreInfo("CTHCancerHistologicEntity", InheritanceHierarchyType.None, false, (int)SStorm.CTH.DAL.EntityType.CTHCancerHistologicEntity, typeof(CTHCancerHistologicEntity), typeof(CTHCancerHistologicEntityFactory), false);
				AddNavigatorMetaData<CTHCancerHistologicEntity, EntityCollection<CTHCancerHistologicEntity>>("CTHCancerHistologicCollection", a => a._cTHCancerHistologicCollection, (a, b) => a._cTHCancerHistologicCollection = b, a => a.CTHCancerHistologicCollection, () => new CTHCancerHistologicRelations().CTHCancerHistologicEntityUsingParentID, typeof(CTHCancerHistologicEntity), (int)SStorm.CTH.DAL.EntityType.CTHCancerHistologicEntity);
				AddNavigatorMetaData<CTHCancerHistologicEntity, EntityCollection<CTHPatientClinicalDataEntity>>("CTHPatientClinicalDataCollection", a => a._cTHPatientClinicalDataCollection, (a, b) => a._cTHPatientClinicalDataCollection = b, a => a.CTHPatientClinicalDataCollection, () => new CTHCancerHistologicRelations().CTHPatientClinicalDataEntityUsingCancerHistologicalID, typeof(CTHPatientClinicalDataEntity), (int)SStorm.CTH.DAL.EntityType.CTHPatientClinicalDataEntity);
				AddNavigatorMetaData<CTHCancerHistologicEntity, CTHCancerHistologicEntity>("CTHCancerHistologicItem", "CTHCancerHistologicCollection", (a, b) => a._cTHCancerHistologicItem = b, a => a._cTHCancerHistologicItem, (a, b) => a.CTHCancerHistologicItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHCancerHistologicRelations.CTHCancerHistologicEntityUsingIDParentIDStatic, ()=>new CTHCancerHistologicRelations().CTHCancerHistologicEntityUsingIDParentID, null, new int[] { (int)CTHCancerHistologicFieldIndex.ParentID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHCancerHistologicEntity);
				AddNavigatorMetaData<CTHCancerHistologicEntity, CTHCancerTypeEntity>("CTHCancerTypeItem", "CTHCancerHistologicCollection", (a, b) => a._cTHCancerTypeItem = b, a => a._cTHCancerTypeItem, (a, b) => a.CTHCancerTypeItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHCancerHistologicRelations.CTHCancerTypeEntityUsingCanerIDStatic, ()=>new CTHCancerHistologicRelations().CTHCancerTypeEntityUsingCanerID, null, new int[] { (int)CTHCancerHistologicFieldIndex.CanerID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHCancerTypeEntity);
				AddNavigatorMetaData<CTHCancerHistologicEntity, EntityCollection<CTHCancerMolecularEntity>>("CTHCancerMolecularCollectionViaCTHPatientClinicalData", a => a._cTHCancerMolecularCollectionViaCTHPatientClinicalData, (a, b) => a._cTHCancerMolecularCollectionViaCTHPatientClinicalData = b, a => a.CTHCancerMolecularCollectionViaCTHPatientClinicalData, () => new CTHCancerHistologicRelations().CTHPatientClinicalDataEntityUsingCancerHistologicalID, () => new CTHPatientClinicalDataRelations().CTHCancerMolecularEntityUsingCancerMolecularID, "CTHCancerHistologicEntity__", "CTHPatientClinicalData_", typeof(CTHCancerMolecularEntity), (int)SStorm.CTH.DAL.EntityType.CTHCancerMolecularEntity);
				AddNavigatorMetaData<CTHCancerHistologicEntity, EntityCollection<CTHCancerSideEntity>>("CTHCancerSideCollectionViaCTHPatientClinicalData", a => a._cTHCancerSideCollectionViaCTHPatientClinicalData, (a, b) => a._cTHCancerSideCollectionViaCTHPatientClinicalData = b, a => a.CTHCancerSideCollectionViaCTHPatientClinicalData, () => new CTHCancerHistologicRelations().CTHPatientClinicalDataEntityUsingCancerHistologicalID, () => new CTHPatientClinicalDataRelations().CTHCancerSideEntityUsingCancerSideId, "CTHCancerHistologicEntity__", "CTHPatientClinicalData_", typeof(CTHCancerSideEntity), (int)SStorm.CTH.DAL.EntityType.CTHCancerSideEntity);
				AddNavigatorMetaData<CTHCancerHistologicEntity, EntityCollection<CTHCancerTypeEntity>>("CTHCancerTypeCollectionViaCTHCancerHistologic", a => a._cTHCancerTypeCollectionViaCTHCancerHistologic, (a, b) => a._cTHCancerTypeCollectionViaCTHCancerHistologic = b, a => a.CTHCancerTypeCollectionViaCTHCancerHistologic, () => new CTHCancerHistologicRelations().CTHCancerHistologicEntityUsingParentID, () => new CTHCancerHistologicRelations().CTHCancerTypeEntityUsingCanerID, "CTHCancerHistologicEntity__", "CTHCancerHistologic_", typeof(CTHCancerTypeEntity), (int)SStorm.CTH.DAL.EntityType.CTHCancerTypeEntity);
				AddNavigatorMetaData<CTHCancerHistologicEntity, EntityCollection<CTHCancerTypeEntity>>("CTHCancerTypeCollectionViaCTHPatientClinicalData", a => a._cTHCancerTypeCollectionViaCTHPatientClinicalData, (a, b) => a._cTHCancerTypeCollectionViaCTHPatientClinicalData = b, a => a.CTHCancerTypeCollectionViaCTHPatientClinicalData, () => new CTHCancerHistologicRelations().CTHPatientClinicalDataEntityUsingCancerHistologicalID, () => new CTHPatientClinicalDataRelations().CTHCancerTypeEntityUsingCancerTypeID, "CTHCancerHistologicEntity__", "CTHPatientClinicalData_", typeof(CTHCancerTypeEntity), (int)SStorm.CTH.DAL.EntityType.CTHCancerTypeEntity);
				AddNavigatorMetaData<CTHCancerHistologicEntity, EntityCollection<CTHPatientEntity>>("CTHPatientCollectionViaCTHPatientClinicalData", a => a._cTHPatientCollectionViaCTHPatientClinicalData, (a, b) => a._cTHPatientCollectionViaCTHPatientClinicalData = b, a => a.CTHPatientCollectionViaCTHPatientClinicalData, () => new CTHCancerHistologicRelations().CTHPatientClinicalDataEntityUsingCancerHistologicalID, () => new CTHPatientClinicalDataRelations().CTHPatientEntityUsingPatientID, "CTHCancerHistologicEntity__", "CTHPatientClinicalData_", typeof(CTHPatientEntity), (int)SStorm.CTH.DAL.EntityType.CTHPatientEntity);
				AddNavigatorMetaData<CTHCancerHistologicEntity, EntityCollection<CTHStagingEntity>>("CTHStagingCollectionViaCTHPatientClinicalData", a => a._cTHStagingCollectionViaCTHPatientClinicalData, (a, b) => a._cTHStagingCollectionViaCTHPatientClinicalData = b, a => a.CTHStagingCollectionViaCTHPatientClinicalData, () => new CTHCancerHistologicRelations().CTHPatientClinicalDataEntityUsingCancerHistologicalID, () => new CTHPatientClinicalDataRelations().CTHStagingEntityUsingStageGradeID, "CTHCancerHistologicEntity__", "CTHPatientClinicalData_", typeof(CTHStagingEntity), (int)SStorm.CTH.DAL.EntityType.CTHStagingEntity);
				AddNavigatorMetaData<CTHCancerHistologicEntity, EntityCollection<CTHTumorGradeEntity>>("CTHTumorGradeCollectionViaCTHPatientClinicalData", a => a._cTHTumorGradeCollectionViaCTHPatientClinicalData, (a, b) => a._cTHTumorGradeCollectionViaCTHPatientClinicalData = b, a => a.CTHTumorGradeCollectionViaCTHPatientClinicalData, () => new CTHCancerHistologicRelations().CTHPatientClinicalDataEntityUsingCancerHistologicalID, () => new CTHPatientClinicalDataRelations().CTHTumorGradeEntityUsingTumorGradeID, "CTHCancerHistologicEntity__", "CTHPatientClinicalData_", typeof(CTHTumorGradeEntity), (int)SStorm.CTH.DAL.EntityType.CTHTumorGradeEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static CTHCancerHistologicEntity()
		{
		}

		/// <summary> CTor</summary>
		public CTHCancerHistologicEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CTHCancerHistologicEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CTHCancerHistologicEntity</param>
		public CTHCancerHistologicEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHCancerHistologic which data should be fetched into this CTHCancerHistologic object</param>
		public CTHCancerHistologicEntity(System.Int32 iD) : this(iD, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHCancerHistologic which data should be fetched into this CTHCancerHistologic object</param>
		/// <param name="validator">The custom validator object for this CTHCancerHistologicEntity</param>
		public CTHCancerHistologicEntity(System.Int32 iD, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CTHCancerHistologicEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHCancerHistologic' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHCancerHistologicCollection() { return CreateRelationInfoForNavigator("CTHCancerHistologicCollection"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHPatientClinicalData' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHPatientClinicalDataCollection() { return CreateRelationInfoForNavigator("CTHPatientClinicalDataCollection"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHCancerMolecular' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHCancerMolecularCollectionViaCTHPatientClinicalData() { return CreateRelationInfoForNavigator("CTHCancerMolecularCollectionViaCTHPatientClinicalData"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHCancerSide' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHCancerSideCollectionViaCTHPatientClinicalData() { return CreateRelationInfoForNavigator("CTHCancerSideCollectionViaCTHPatientClinicalData"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHCancerType' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHCancerTypeCollectionViaCTHCancerHistologic() { return CreateRelationInfoForNavigator("CTHCancerTypeCollectionViaCTHCancerHistologic"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHCancerType' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHCancerTypeCollectionViaCTHPatientClinicalData() { return CreateRelationInfoForNavigator("CTHCancerTypeCollectionViaCTHPatientClinicalData"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHPatient' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHPatientCollectionViaCTHPatientClinicalData() { return CreateRelationInfoForNavigator("CTHPatientCollectionViaCTHPatientClinicalData"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHStaging' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHStagingCollectionViaCTHPatientClinicalData() { return CreateRelationInfoForNavigator("CTHStagingCollectionViaCTHPatientClinicalData"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHTumorGrade' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHTumorGradeCollectionViaCTHPatientClinicalData() { return CreateRelationInfoForNavigator("CTHTumorGradeCollectionViaCTHPatientClinicalData"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHCancerHistologic' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHCancerHistologicItem() { return CreateRelationInfoForNavigator("CTHCancerHistologicItem"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHCancerType' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHCancerTypeItem() { return CreateRelationInfoForNavigator("CTHCancerTypeItem"); }
		
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
		/// <param name="validator">The validator object for this CTHCancerHistologicEntity</param>
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
		public static CTHCancerHistologicRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHCancerHistologic' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHCancerHistologicCollection { get { return _staticMetaData.GetPrefetchPathElement("CTHCancerHistologicCollection", CommonEntityBase.CreateEntityCollection<CTHCancerHistologicEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHPatientClinicalData' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHPatientClinicalDataCollection { get { return _staticMetaData.GetPrefetchPathElement("CTHPatientClinicalDataCollection", CommonEntityBase.CreateEntityCollection<CTHPatientClinicalDataEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHCancerMolecular' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHCancerMolecularCollectionViaCTHPatientClinicalData { get { return _staticMetaData.GetPrefetchPathElement("CTHCancerMolecularCollectionViaCTHPatientClinicalData", CommonEntityBase.CreateEntityCollection<CTHCancerMolecularEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHCancerSide' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHCancerSideCollectionViaCTHPatientClinicalData { get { return _staticMetaData.GetPrefetchPathElement("CTHCancerSideCollectionViaCTHPatientClinicalData", CommonEntityBase.CreateEntityCollection<CTHCancerSideEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHCancerType' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHCancerTypeCollectionViaCTHCancerHistologic { get { return _staticMetaData.GetPrefetchPathElement("CTHCancerTypeCollectionViaCTHCancerHistologic", CommonEntityBase.CreateEntityCollection<CTHCancerTypeEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHCancerType' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHCancerTypeCollectionViaCTHPatientClinicalData { get { return _staticMetaData.GetPrefetchPathElement("CTHCancerTypeCollectionViaCTHPatientClinicalData", CommonEntityBase.CreateEntityCollection<CTHCancerTypeEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHPatient' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHPatientCollectionViaCTHPatientClinicalData { get { return _staticMetaData.GetPrefetchPathElement("CTHPatientCollectionViaCTHPatientClinicalData", CommonEntityBase.CreateEntityCollection<CTHPatientEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHStaging' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHStagingCollectionViaCTHPatientClinicalData { get { return _staticMetaData.GetPrefetchPathElement("CTHStagingCollectionViaCTHPatientClinicalData", CommonEntityBase.CreateEntityCollection<CTHStagingEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHTumorGrade' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHTumorGradeCollectionViaCTHPatientClinicalData { get { return _staticMetaData.GetPrefetchPathElement("CTHTumorGradeCollectionViaCTHPatientClinicalData", CommonEntityBase.CreateEntityCollection<CTHTumorGradeEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHCancerHistologic' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHCancerHistologicItem { get { return _staticMetaData.GetPrefetchPathElement("CTHCancerHistologicItem", CommonEntityBase.CreateEntityCollection<CTHCancerHistologicEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHCancerType' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHCancerTypeItem { get { return _staticMetaData.GetPrefetchPathElement("CTHCancerTypeItem", CommonEntityBase.CreateEntityCollection<CTHCancerTypeEntity>()); } }

		/// <summary>The ArName property of the Entity CTHCancerHistologic<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHCancerHistologic"."ArName".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ArName
		{
			get { return (System.String)GetValue((int)CTHCancerHistologicFieldIndex.ArName, true); }
			set	{ SetValue((int)CTHCancerHistologicFieldIndex.ArName, value); }
		}

		/// <summary>The CanerID property of the Entity CTHCancerHistologic<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHCancerHistologic"."CanerID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> CanerID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHCancerHistologicFieldIndex.CanerID, false); }
			set	{ SetValue((int)CTHCancerHistologicFieldIndex.CanerID, value); }
		}

		/// <summary>The ID property of the Entity CTHCancerHistologic<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHCancerHistologic"."ID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)CTHCancerHistologicFieldIndex.ID, true); }
			set { SetValue((int)CTHCancerHistologicFieldIndex.ID, value); }		}

		/// <summary>The Name property of the Entity CTHCancerHistologic<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHCancerHistologic"."Name".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)CTHCancerHistologicFieldIndex.Name, true); }
			set	{ SetValue((int)CTHCancerHistologicFieldIndex.Name, value); }
		}

		/// <summary>The ParentID property of the Entity CTHCancerHistologic<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHCancerHistologic"."ParentID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ParentID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHCancerHistologicFieldIndex.ParentID, false); }
			set	{ SetValue((int)CTHCancerHistologicFieldIndex.ParentID, value); }
		}

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHCancerHistologicEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHCancerHistologicEntity))]
		public virtual EntityCollection<CTHCancerHistologicEntity> CTHCancerHistologicCollection { get { return GetOrCreateEntityCollection<CTHCancerHistologicEntity, CTHCancerHistologicEntityFactory>("CTHCancerHistologicItem", true, false, ref _cTHCancerHistologicCollection); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHPatientClinicalDataEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHPatientClinicalDataEntity))]
		public virtual EntityCollection<CTHPatientClinicalDataEntity> CTHPatientClinicalDataCollection { get { return GetOrCreateEntityCollection<CTHPatientClinicalDataEntity, CTHPatientClinicalDataEntityFactory>("CTHCancerHistologicItem", true, false, ref _cTHPatientClinicalDataCollection); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHCancerMolecularEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHCancerMolecularEntity))]
		public virtual EntityCollection<CTHCancerMolecularEntity> CTHCancerMolecularCollectionViaCTHPatientClinicalData { get { return GetOrCreateEntityCollection<CTHCancerMolecularEntity, CTHCancerMolecularEntityFactory>("CTHCancerHistologicCollectionViaCTHPatientClinicalData", false, true, ref _cTHCancerMolecularCollectionViaCTHPatientClinicalData); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHCancerSideEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHCancerSideEntity))]
		public virtual EntityCollection<CTHCancerSideEntity> CTHCancerSideCollectionViaCTHPatientClinicalData { get { return GetOrCreateEntityCollection<CTHCancerSideEntity, CTHCancerSideEntityFactory>("CTHCancerHistologicCollectionViaCTHPatientClinicalData", false, true, ref _cTHCancerSideCollectionViaCTHPatientClinicalData); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHCancerTypeEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHCancerTypeEntity))]
		public virtual EntityCollection<CTHCancerTypeEntity> CTHCancerTypeCollectionViaCTHCancerHistologic { get { return GetOrCreateEntityCollection<CTHCancerTypeEntity, CTHCancerTypeEntityFactory>("CTHCancerHistologicCollectionViaCTHCancerHistologic", false, true, ref _cTHCancerTypeCollectionViaCTHCancerHistologic); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHCancerTypeEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHCancerTypeEntity))]
		public virtual EntityCollection<CTHCancerTypeEntity> CTHCancerTypeCollectionViaCTHPatientClinicalData { get { return GetOrCreateEntityCollection<CTHCancerTypeEntity, CTHCancerTypeEntityFactory>("CTHCancerHistologicCollectionViaCTHPatientClinicalData", false, true, ref _cTHCancerTypeCollectionViaCTHPatientClinicalData); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHPatientEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHPatientEntity))]
		public virtual EntityCollection<CTHPatientEntity> CTHPatientCollectionViaCTHPatientClinicalData { get { return GetOrCreateEntityCollection<CTHPatientEntity, CTHPatientEntityFactory>("CTHCancerHistologicCollectionViaCTHPatientClinicalData", false, true, ref _cTHPatientCollectionViaCTHPatientClinicalData); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHStagingEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHStagingEntity))]
		public virtual EntityCollection<CTHStagingEntity> CTHStagingCollectionViaCTHPatientClinicalData { get { return GetOrCreateEntityCollection<CTHStagingEntity, CTHStagingEntityFactory>("CTHCancerHistologicCollectionViaCTHPatientClinicalData", false, true, ref _cTHStagingCollectionViaCTHPatientClinicalData); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHTumorGradeEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHTumorGradeEntity))]
		public virtual EntityCollection<CTHTumorGradeEntity> CTHTumorGradeCollectionViaCTHPatientClinicalData { get { return GetOrCreateEntityCollection<CTHTumorGradeEntity, CTHTumorGradeEntityFactory>("CTHCancerHistologicCollectionViaCTHPatientClinicalData", false, true, ref _cTHTumorGradeCollectionViaCTHPatientClinicalData); } }

		/// <summary>Gets / sets related entity of type 'CTHCancerHistologicEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHCancerHistologicEntity CTHCancerHistologicItem
		{
			get { return _cTHCancerHistologicItem; }
			set { SetSingleRelatedEntityNavigator(value, "CTHCancerHistologicItem"); }
		}

		/// <summary>Gets / sets related entity of type 'CTHCancerTypeEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHCancerTypeEntity CTHCancerTypeItem
		{
			get { return _cTHCancerTypeItem; }
			set { SetSingleRelatedEntityNavigator(value, "CTHCancerTypeItem"); }
		}
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace SStorm.CTH.DAL
{
	public enum CTHCancerHistologicFieldIndex
	{
		///<summary>ArName. </summary>
		ArName,
		///<summary>CanerID. </summary>
		CanerID,
		///<summary>ID. </summary>
		ID,
		///<summary>Name. </summary>
		Name,
		///<summary>ParentID. </summary>
		ParentID,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace SStorm.CTH.DAL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: CTHCancerHistologic. </summary>
	public partial class CTHCancerHistologicRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between CTHCancerHistologicEntity and CTHCancerHistologicEntity over the 1:n relation they have, using the relation between the fields: CTHCancerHistologic.ID - CTHCancerHistologic.ParentID</summary>
		public virtual IEntityRelation CTHCancerHistologicEntityUsingParentID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "CTHCancerHistologicCollection", true, new[] { CTHCancerHistologicFields.ID, CTHCancerHistologicFields.ParentID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHCancerHistologicEntity and CTHPatientClinicalDataEntity over the 1:n relation they have, using the relation between the fields: CTHCancerHistologic.ID - CTHPatientClinicalData.CancerHistologicalID</summary>
		public virtual IEntityRelation CTHPatientClinicalDataEntityUsingCancerHistologicalID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "CTHPatientClinicalDataCollection", true, new[] { CTHCancerHistologicFields.ID, CTHPatientClinicalDataFields.CancerHistologicalID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHCancerHistologicEntity and CTHCancerHistologicEntity over the m:1 relation they have, using the relation between the fields: CTHCancerHistologic.ParentID - CTHCancerHistologic.ID</summary>
		public virtual IEntityRelation CTHCancerHistologicEntityUsingIDParentID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHCancerHistologicItem", false, new[] { CTHCancerHistologicFields.ID, CTHCancerHistologicFields.ParentID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHCancerHistologicEntity and CTHCancerTypeEntity over the m:1 relation they have, using the relation between the fields: CTHCancerHistologic.CanerID - CTHCancerType.ID</summary>
		public virtual IEntityRelation CTHCancerTypeEntityUsingCanerID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHCancerTypeItem", false, new[] { CTHCancerTypeFields.ID, CTHCancerHistologicFields.CanerID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCTHCancerHistologicRelations
	{
		internal static readonly IEntityRelation CTHCancerHistologicEntityUsingParentIDStatic = new CTHCancerHistologicRelations().CTHCancerHistologicEntityUsingParentID;
		internal static readonly IEntityRelation CTHPatientClinicalDataEntityUsingCancerHistologicalIDStatic = new CTHCancerHistologicRelations().CTHPatientClinicalDataEntityUsingCancerHistologicalID;
		internal static readonly IEntityRelation CTHCancerHistologicEntityUsingIDParentIDStatic = new CTHCancerHistologicRelations().CTHCancerHistologicEntityUsingIDParentID;
		internal static readonly IEntityRelation CTHCancerTypeEntityUsingCanerIDStatic = new CTHCancerHistologicRelations().CTHCancerTypeEntityUsingCanerID;

		/// <summary>CTor</summary>
		static StaticCTHCancerHistologicRelations() { }
	}
}
