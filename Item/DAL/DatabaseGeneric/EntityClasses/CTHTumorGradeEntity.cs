//////////////////////////////////////////////////////////////
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

	/// <summary>Entity class which represents the entity 'CTHTumorGrade'.<br/><br/></summary>
	[Serializable]
	public partial class CTHTumorGradeEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private EntityCollection<CTHPatientClinicalDataEntity> _cTHPatientClinicalDataCollection;
		private EntityCollection<CTHCancerHistologicEntity> _cTHCancerHistologicCollectionViaCTHPatientClinicalData;
		private EntityCollection<CTHCancerMolecularEntity> _cTHCancerMolecularCollectionViaCTHPatientClinicalData;
		private EntityCollection<CTHCancerSideEntity> _cTHCancerSideCollectionViaCTHPatientClinicalData;
		private EntityCollection<CTHCancerTypeEntity> _cTHCancerTypeCollectionViaCTHPatientClinicalData;
		private EntityCollection<CTHPatientEntity> _cTHPatientCollectionViaCTHPatientClinicalData;
		private EntityCollection<CTHStagingEntity> _cTHStagingCollectionViaCTHPatientClinicalData;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static CTHTumorGradeEntityStaticMetaData _staticMetaData = new CTHTumorGradeEntityStaticMetaData();
		private static CTHTumorGradeRelations _relationsFactory = new CTHTumorGradeRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CTHPatientClinicalDataCollection</summary>
			public static readonly string CTHPatientClinicalDataCollection = "CTHPatientClinicalDataCollection";
			/// <summary>Member name CTHCancerHistologicCollectionViaCTHPatientClinicalData</summary>
			public static readonly string CTHCancerHistologicCollectionViaCTHPatientClinicalData = "CTHCancerHistologicCollectionViaCTHPatientClinicalData";
			/// <summary>Member name CTHCancerMolecularCollectionViaCTHPatientClinicalData</summary>
			public static readonly string CTHCancerMolecularCollectionViaCTHPatientClinicalData = "CTHCancerMolecularCollectionViaCTHPatientClinicalData";
			/// <summary>Member name CTHCancerSideCollectionViaCTHPatientClinicalData</summary>
			public static readonly string CTHCancerSideCollectionViaCTHPatientClinicalData = "CTHCancerSideCollectionViaCTHPatientClinicalData";
			/// <summary>Member name CTHCancerTypeCollectionViaCTHPatientClinicalData</summary>
			public static readonly string CTHCancerTypeCollectionViaCTHPatientClinicalData = "CTHCancerTypeCollectionViaCTHPatientClinicalData";
			/// <summary>Member name CTHPatientCollectionViaCTHPatientClinicalData</summary>
			public static readonly string CTHPatientCollectionViaCTHPatientClinicalData = "CTHPatientCollectionViaCTHPatientClinicalData";
			/// <summary>Member name CTHStagingCollectionViaCTHPatientClinicalData</summary>
			public static readonly string CTHStagingCollectionViaCTHPatientClinicalData = "CTHStagingCollectionViaCTHPatientClinicalData";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class CTHTumorGradeEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public CTHTumorGradeEntityStaticMetaData()
			{
				SetEntityCoreInfo("CTHTumorGradeEntity", InheritanceHierarchyType.None, false, (int)SStorm.CTH.DAL.EntityType.CTHTumorGradeEntity, typeof(CTHTumorGradeEntity), typeof(CTHTumorGradeEntityFactory), false);
				AddNavigatorMetaData<CTHTumorGradeEntity, EntityCollection<CTHPatientClinicalDataEntity>>("CTHPatientClinicalDataCollection", a => a._cTHPatientClinicalDataCollection, (a, b) => a._cTHPatientClinicalDataCollection = b, a => a.CTHPatientClinicalDataCollection, () => new CTHTumorGradeRelations().CTHPatientClinicalDataEntityUsingTumorGradeID, typeof(CTHPatientClinicalDataEntity), (int)SStorm.CTH.DAL.EntityType.CTHPatientClinicalDataEntity);
				AddNavigatorMetaData<CTHTumorGradeEntity, EntityCollection<CTHCancerHistologicEntity>>("CTHCancerHistologicCollectionViaCTHPatientClinicalData", a => a._cTHCancerHistologicCollectionViaCTHPatientClinicalData, (a, b) => a._cTHCancerHistologicCollectionViaCTHPatientClinicalData = b, a => a.CTHCancerHistologicCollectionViaCTHPatientClinicalData, () => new CTHTumorGradeRelations().CTHPatientClinicalDataEntityUsingTumorGradeID, () => new CTHPatientClinicalDataRelations().CTHCancerHistologicEntityUsingCancerHistologicalID, "CTHTumorGradeEntity__", "CTHPatientClinicalData_", typeof(CTHCancerHistologicEntity), (int)SStorm.CTH.DAL.EntityType.CTHCancerHistologicEntity);
				AddNavigatorMetaData<CTHTumorGradeEntity, EntityCollection<CTHCancerMolecularEntity>>("CTHCancerMolecularCollectionViaCTHPatientClinicalData", a => a._cTHCancerMolecularCollectionViaCTHPatientClinicalData, (a, b) => a._cTHCancerMolecularCollectionViaCTHPatientClinicalData = b, a => a.CTHCancerMolecularCollectionViaCTHPatientClinicalData, () => new CTHTumorGradeRelations().CTHPatientClinicalDataEntityUsingTumorGradeID, () => new CTHPatientClinicalDataRelations().CTHCancerMolecularEntityUsingCancerMolecularID, "CTHTumorGradeEntity__", "CTHPatientClinicalData_", typeof(CTHCancerMolecularEntity), (int)SStorm.CTH.DAL.EntityType.CTHCancerMolecularEntity);
				AddNavigatorMetaData<CTHTumorGradeEntity, EntityCollection<CTHCancerSideEntity>>("CTHCancerSideCollectionViaCTHPatientClinicalData", a => a._cTHCancerSideCollectionViaCTHPatientClinicalData, (a, b) => a._cTHCancerSideCollectionViaCTHPatientClinicalData = b, a => a.CTHCancerSideCollectionViaCTHPatientClinicalData, () => new CTHTumorGradeRelations().CTHPatientClinicalDataEntityUsingTumorGradeID, () => new CTHPatientClinicalDataRelations().CTHCancerSideEntityUsingCancerSideId, "CTHTumorGradeEntity__", "CTHPatientClinicalData_", typeof(CTHCancerSideEntity), (int)SStorm.CTH.DAL.EntityType.CTHCancerSideEntity);
				AddNavigatorMetaData<CTHTumorGradeEntity, EntityCollection<CTHCancerTypeEntity>>("CTHCancerTypeCollectionViaCTHPatientClinicalData", a => a._cTHCancerTypeCollectionViaCTHPatientClinicalData, (a, b) => a._cTHCancerTypeCollectionViaCTHPatientClinicalData = b, a => a.CTHCancerTypeCollectionViaCTHPatientClinicalData, () => new CTHTumorGradeRelations().CTHPatientClinicalDataEntityUsingTumorGradeID, () => new CTHPatientClinicalDataRelations().CTHCancerTypeEntityUsingCancerTypeID, "CTHTumorGradeEntity__", "CTHPatientClinicalData_", typeof(CTHCancerTypeEntity), (int)SStorm.CTH.DAL.EntityType.CTHCancerTypeEntity);
				AddNavigatorMetaData<CTHTumorGradeEntity, EntityCollection<CTHPatientEntity>>("CTHPatientCollectionViaCTHPatientClinicalData", a => a._cTHPatientCollectionViaCTHPatientClinicalData, (a, b) => a._cTHPatientCollectionViaCTHPatientClinicalData = b, a => a.CTHPatientCollectionViaCTHPatientClinicalData, () => new CTHTumorGradeRelations().CTHPatientClinicalDataEntityUsingTumorGradeID, () => new CTHPatientClinicalDataRelations().CTHPatientEntityUsingPatientID, "CTHTumorGradeEntity__", "CTHPatientClinicalData_", typeof(CTHPatientEntity), (int)SStorm.CTH.DAL.EntityType.CTHPatientEntity);
				AddNavigatorMetaData<CTHTumorGradeEntity, EntityCollection<CTHStagingEntity>>("CTHStagingCollectionViaCTHPatientClinicalData", a => a._cTHStagingCollectionViaCTHPatientClinicalData, (a, b) => a._cTHStagingCollectionViaCTHPatientClinicalData = b, a => a.CTHStagingCollectionViaCTHPatientClinicalData, () => new CTHTumorGradeRelations().CTHPatientClinicalDataEntityUsingTumorGradeID, () => new CTHPatientClinicalDataRelations().CTHStagingEntityUsingStageGradeID, "CTHTumorGradeEntity__", "CTHPatientClinicalData_", typeof(CTHStagingEntity), (int)SStorm.CTH.DAL.EntityType.CTHStagingEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static CTHTumorGradeEntity()
		{
		}

		/// <summary> CTor</summary>
		public CTHTumorGradeEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CTHTumorGradeEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CTHTumorGradeEntity</param>
		public CTHTumorGradeEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHTumorGrade which data should be fetched into this CTHTumorGrade object</param>
		public CTHTumorGradeEntity(System.Int32 iD) : this(iD, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHTumorGrade which data should be fetched into this CTHTumorGrade object</param>
		/// <param name="validator">The custom validator object for this CTHTumorGradeEntity</param>
		public CTHTumorGradeEntity(System.Int32 iD, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CTHTumorGradeEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHPatientClinicalData' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHPatientClinicalDataCollection() { return CreateRelationInfoForNavigator("CTHPatientClinicalDataCollection"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHCancerHistologic' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHCancerHistologicCollectionViaCTHPatientClinicalData() { return CreateRelationInfoForNavigator("CTHCancerHistologicCollectionViaCTHPatientClinicalData"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHCancerMolecular' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHCancerMolecularCollectionViaCTHPatientClinicalData() { return CreateRelationInfoForNavigator("CTHCancerMolecularCollectionViaCTHPatientClinicalData"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHCancerSide' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHCancerSideCollectionViaCTHPatientClinicalData() { return CreateRelationInfoForNavigator("CTHCancerSideCollectionViaCTHPatientClinicalData"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHCancerType' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHCancerTypeCollectionViaCTHPatientClinicalData() { return CreateRelationInfoForNavigator("CTHCancerTypeCollectionViaCTHPatientClinicalData"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHPatient' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHPatientCollectionViaCTHPatientClinicalData() { return CreateRelationInfoForNavigator("CTHPatientCollectionViaCTHPatientClinicalData"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHStaging' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHStagingCollectionViaCTHPatientClinicalData() { return CreateRelationInfoForNavigator("CTHStagingCollectionViaCTHPatientClinicalData"); }
		
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
		/// <param name="validator">The validator object for this CTHTumorGradeEntity</param>
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
		public static CTHTumorGradeRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHPatientClinicalData' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHPatientClinicalDataCollection { get { return _staticMetaData.GetPrefetchPathElement("CTHPatientClinicalDataCollection", CommonEntityBase.CreateEntityCollection<CTHPatientClinicalDataEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHCancerHistologic' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHCancerHistologicCollectionViaCTHPatientClinicalData { get { return _staticMetaData.GetPrefetchPathElement("CTHCancerHistologicCollectionViaCTHPatientClinicalData", CommonEntityBase.CreateEntityCollection<CTHCancerHistologicEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHCancerMolecular' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHCancerMolecularCollectionViaCTHPatientClinicalData { get { return _staticMetaData.GetPrefetchPathElement("CTHCancerMolecularCollectionViaCTHPatientClinicalData", CommonEntityBase.CreateEntityCollection<CTHCancerMolecularEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHCancerSide' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHCancerSideCollectionViaCTHPatientClinicalData { get { return _staticMetaData.GetPrefetchPathElement("CTHCancerSideCollectionViaCTHPatientClinicalData", CommonEntityBase.CreateEntityCollection<CTHCancerSideEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHCancerType' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHCancerTypeCollectionViaCTHPatientClinicalData { get { return _staticMetaData.GetPrefetchPathElement("CTHCancerTypeCollectionViaCTHPatientClinicalData", CommonEntityBase.CreateEntityCollection<CTHCancerTypeEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHPatient' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHPatientCollectionViaCTHPatientClinicalData { get { return _staticMetaData.GetPrefetchPathElement("CTHPatientCollectionViaCTHPatientClinicalData", CommonEntityBase.CreateEntityCollection<CTHPatientEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHStaging' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHStagingCollectionViaCTHPatientClinicalData { get { return _staticMetaData.GetPrefetchPathElement("CTHStagingCollectionViaCTHPatientClinicalData", CommonEntityBase.CreateEntityCollection<CTHStagingEntity>()); } }

		/// <summary>The Description property of the Entity CTHTumorGrade<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHTumorGrade"."Description".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)CTHTumorGradeFieldIndex.Description, true); }
			set	{ SetValue((int)CTHTumorGradeFieldIndex.Description, value); }
		}

		/// <summary>The ID property of the Entity CTHTumorGrade<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHTumorGrade"."ID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)CTHTumorGradeFieldIndex.ID, true); }
			set { SetValue((int)CTHTumorGradeFieldIndex.ID, value); }		}

		/// <summary>The TumorGrade property of the Entity CTHTumorGrade<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHTumorGrade"."TumorGrade".<br/>Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Double> TumorGrade
		{
			get { return (Nullable<System.Double>)GetValue((int)CTHTumorGradeFieldIndex.TumorGrade, false); }
			set	{ SetValue((int)CTHTumorGradeFieldIndex.TumorGrade, value); }
		}

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHPatientClinicalDataEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHPatientClinicalDataEntity))]
		public virtual EntityCollection<CTHPatientClinicalDataEntity> CTHPatientClinicalDataCollection { get { return GetOrCreateEntityCollection<CTHPatientClinicalDataEntity, CTHPatientClinicalDataEntityFactory>("CTHTumorGradeItem", true, false, ref _cTHPatientClinicalDataCollection); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHCancerHistologicEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHCancerHistologicEntity))]
		public virtual EntityCollection<CTHCancerHistologicEntity> CTHCancerHistologicCollectionViaCTHPatientClinicalData { get { return GetOrCreateEntityCollection<CTHCancerHistologicEntity, CTHCancerHistologicEntityFactory>("CTHTumorGradeCollectionViaCTHPatientClinicalData", false, true, ref _cTHCancerHistologicCollectionViaCTHPatientClinicalData); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHCancerMolecularEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHCancerMolecularEntity))]
		public virtual EntityCollection<CTHCancerMolecularEntity> CTHCancerMolecularCollectionViaCTHPatientClinicalData { get { return GetOrCreateEntityCollection<CTHCancerMolecularEntity, CTHCancerMolecularEntityFactory>("CTHTumorGradeCollectionViaCTHPatientClinicalData", false, true, ref _cTHCancerMolecularCollectionViaCTHPatientClinicalData); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHCancerSideEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHCancerSideEntity))]
		public virtual EntityCollection<CTHCancerSideEntity> CTHCancerSideCollectionViaCTHPatientClinicalData { get { return GetOrCreateEntityCollection<CTHCancerSideEntity, CTHCancerSideEntityFactory>("CTHTumorGradeCollectionViaCTHPatientClinicalData", false, true, ref _cTHCancerSideCollectionViaCTHPatientClinicalData); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHCancerTypeEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHCancerTypeEntity))]
		public virtual EntityCollection<CTHCancerTypeEntity> CTHCancerTypeCollectionViaCTHPatientClinicalData { get { return GetOrCreateEntityCollection<CTHCancerTypeEntity, CTHCancerTypeEntityFactory>("CTHTumorGradeCollectionViaCTHPatientClinicalData", false, true, ref _cTHCancerTypeCollectionViaCTHPatientClinicalData); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHPatientEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHPatientEntity))]
		public virtual EntityCollection<CTHPatientEntity> CTHPatientCollectionViaCTHPatientClinicalData { get { return GetOrCreateEntityCollection<CTHPatientEntity, CTHPatientEntityFactory>("CTHTumorGradeCollectionViaCTHPatientClinicalData", false, true, ref _cTHPatientCollectionViaCTHPatientClinicalData); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHStagingEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHStagingEntity))]
		public virtual EntityCollection<CTHStagingEntity> CTHStagingCollectionViaCTHPatientClinicalData { get { return GetOrCreateEntityCollection<CTHStagingEntity, CTHStagingEntityFactory>("CTHTumorGradeCollectionViaCTHPatientClinicalData", false, true, ref _cTHStagingCollectionViaCTHPatientClinicalData); } }
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace SStorm.CTH.DAL
{
	public enum CTHTumorGradeFieldIndex
	{
		///<summary>Description. </summary>
		Description,
		///<summary>ID. </summary>
		ID,
		///<summary>TumorGrade. </summary>
		TumorGrade,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace SStorm.CTH.DAL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: CTHTumorGrade. </summary>
	public partial class CTHTumorGradeRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between CTHTumorGradeEntity and CTHPatientClinicalDataEntity over the 1:n relation they have, using the relation between the fields: CTHTumorGrade.ID - CTHPatientClinicalData.TumorGradeID</summary>
		public virtual IEntityRelation CTHPatientClinicalDataEntityUsingTumorGradeID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "CTHPatientClinicalDataCollection", true, new[] { CTHTumorGradeFields.ID, CTHPatientClinicalDataFields.TumorGradeID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCTHTumorGradeRelations
	{
		internal static readonly IEntityRelation CTHPatientClinicalDataEntityUsingTumorGradeIDStatic = new CTHTumorGradeRelations().CTHPatientClinicalDataEntityUsingTumorGradeID;

		/// <summary>CTor</summary>
		static StaticCTHTumorGradeRelations() { }
	}
}
