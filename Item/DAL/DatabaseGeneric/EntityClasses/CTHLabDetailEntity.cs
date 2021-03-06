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

	/// <summary>Entity class which represents the entity 'CTHLabDetail'.<br/><br/></summary>
	[Serializable]
	public partial class CTHLabDetailEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private EntityCollection<CTHChemoLabEntity> _cTHChemoLabCollection;
		private EntityCollection<CTHCycleLabEntity> _cTHCycleLabCollection;
		private EntityCollection<CTHLabDetailConditionEntity> _cTHLabDetailConditionCollection;
		private EntityCollection<CTHKimoSurveyEntity> _cTHKimoSurveyCollectionViaCTHChemoLab;
		private EntityCollection<CTHOperatorEntity> _cTHOperatorCollectionViaCTHLabDetailCondition;
		private EntityCollection<CTHProtocolCycleEntity> _cTHProtocolCycleCollectionViaCTHCycleLab;
		private CTHLabEntity _cTHLabItem;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static CTHLabDetailEntityStaticMetaData _staticMetaData = new CTHLabDetailEntityStaticMetaData();
		private static CTHLabDetailRelations _relationsFactory = new CTHLabDetailRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CTHLabItem</summary>
			public static readonly string CTHLabItem = "CTHLabItem";
			/// <summary>Member name CTHChemoLabCollection</summary>
			public static readonly string CTHChemoLabCollection = "CTHChemoLabCollection";
			/// <summary>Member name CTHCycleLabCollection</summary>
			public static readonly string CTHCycleLabCollection = "CTHCycleLabCollection";
			/// <summary>Member name CTHLabDetailConditionCollection</summary>
			public static readonly string CTHLabDetailConditionCollection = "CTHLabDetailConditionCollection";
			/// <summary>Member name CTHKimoSurveyCollectionViaCTHChemoLab</summary>
			public static readonly string CTHKimoSurveyCollectionViaCTHChemoLab = "CTHKimoSurveyCollectionViaCTHChemoLab";
			/// <summary>Member name CTHOperatorCollectionViaCTHLabDetailCondition</summary>
			public static readonly string CTHOperatorCollectionViaCTHLabDetailCondition = "CTHOperatorCollectionViaCTHLabDetailCondition";
			/// <summary>Member name CTHProtocolCycleCollectionViaCTHCycleLab</summary>
			public static readonly string CTHProtocolCycleCollectionViaCTHCycleLab = "CTHProtocolCycleCollectionViaCTHCycleLab";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class CTHLabDetailEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public CTHLabDetailEntityStaticMetaData()
			{
				SetEntityCoreInfo("CTHLabDetailEntity", InheritanceHierarchyType.None, false, (int)SStorm.CTH.DAL.EntityType.CTHLabDetailEntity, typeof(CTHLabDetailEntity), typeof(CTHLabDetailEntityFactory), false);
				AddNavigatorMetaData<CTHLabDetailEntity, EntityCollection<CTHChemoLabEntity>>("CTHChemoLabCollection", a => a._cTHChemoLabCollection, (a, b) => a._cTHChemoLabCollection = b, a => a.CTHChemoLabCollection, () => new CTHLabDetailRelations().CTHChemoLabEntityUsingLabDetailsID, typeof(CTHChemoLabEntity), (int)SStorm.CTH.DAL.EntityType.CTHChemoLabEntity);
				AddNavigatorMetaData<CTHLabDetailEntity, EntityCollection<CTHCycleLabEntity>>("CTHCycleLabCollection", a => a._cTHCycleLabCollection, (a, b) => a._cTHCycleLabCollection = b, a => a.CTHCycleLabCollection, () => new CTHLabDetailRelations().CTHCycleLabEntityUsingLabID, typeof(CTHCycleLabEntity), (int)SStorm.CTH.DAL.EntityType.CTHCycleLabEntity);
				AddNavigatorMetaData<CTHLabDetailEntity, EntityCollection<CTHLabDetailConditionEntity>>("CTHLabDetailConditionCollection", a => a._cTHLabDetailConditionCollection, (a, b) => a._cTHLabDetailConditionCollection = b, a => a.CTHLabDetailConditionCollection, () => new CTHLabDetailRelations().CTHLabDetailConditionEntityUsingLabDetailID, typeof(CTHLabDetailConditionEntity), (int)SStorm.CTH.DAL.EntityType.CTHLabDetailConditionEntity);
				AddNavigatorMetaData<CTHLabDetailEntity, CTHLabEntity>("CTHLabItem", "CTHLabDetailCollection", (a, b) => a._cTHLabItem = b, a => a._cTHLabItem, (a, b) => a.CTHLabItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHLabDetailRelations.CTHLabEntityUsingLabIDStatic, ()=>new CTHLabDetailRelations().CTHLabEntityUsingLabID, null, new int[] { (int)CTHLabDetailFieldIndex.LabID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHLabEntity);
				AddNavigatorMetaData<CTHLabDetailEntity, EntityCollection<CTHKimoSurveyEntity>>("CTHKimoSurveyCollectionViaCTHChemoLab", a => a._cTHKimoSurveyCollectionViaCTHChemoLab, (a, b) => a._cTHKimoSurveyCollectionViaCTHChemoLab = b, a => a.CTHKimoSurveyCollectionViaCTHChemoLab, () => new CTHLabDetailRelations().CTHChemoLabEntityUsingLabDetailsID, () => new CTHChemoLabRelations().CTHKimoSurveyEntityUsingChemoID, "CTHLabDetailEntity__", "CTHChemoLab_", typeof(CTHKimoSurveyEntity), (int)SStorm.CTH.DAL.EntityType.CTHKimoSurveyEntity);
				AddNavigatorMetaData<CTHLabDetailEntity, EntityCollection<CTHOperatorEntity>>("CTHOperatorCollectionViaCTHLabDetailCondition", a => a._cTHOperatorCollectionViaCTHLabDetailCondition, (a, b) => a._cTHOperatorCollectionViaCTHLabDetailCondition = b, a => a.CTHOperatorCollectionViaCTHLabDetailCondition, () => new CTHLabDetailRelations().CTHLabDetailConditionEntityUsingLabDetailID, () => new CTHLabDetailConditionRelations().CTHOperatorEntityUsingOpertorID, "CTHLabDetailEntity__", "CTHLabDetailCondition_", typeof(CTHOperatorEntity), (int)SStorm.CTH.DAL.EntityType.CTHOperatorEntity);
				AddNavigatorMetaData<CTHLabDetailEntity, EntityCollection<CTHProtocolCycleEntity>>("CTHProtocolCycleCollectionViaCTHCycleLab", a => a._cTHProtocolCycleCollectionViaCTHCycleLab, (a, b) => a._cTHProtocolCycleCollectionViaCTHCycleLab = b, a => a.CTHProtocolCycleCollectionViaCTHCycleLab, () => new CTHLabDetailRelations().CTHCycleLabEntityUsingLabID, () => new CTHCycleLabRelations().CTHProtocolCycleEntityUsingCycleID, "CTHLabDetailEntity__", "CTHCycleLab_", typeof(CTHProtocolCycleEntity), (int)SStorm.CTH.DAL.EntityType.CTHProtocolCycleEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static CTHLabDetailEntity()
		{
		}

		/// <summary> CTor</summary>
		public CTHLabDetailEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CTHLabDetailEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CTHLabDetailEntity</param>
		public CTHLabDetailEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHLabDetail which data should be fetched into this CTHLabDetail object</param>
		public CTHLabDetailEntity(System.Int32 iD) : this(iD, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHLabDetail which data should be fetched into this CTHLabDetail object</param>
		/// <param name="validator">The custom validator object for this CTHLabDetailEntity</param>
		public CTHLabDetailEntity(System.Int32 iD, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CTHLabDetailEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHChemoLab' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHChemoLabCollection() { return CreateRelationInfoForNavigator("CTHChemoLabCollection"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHCycleLab' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHCycleLabCollection() { return CreateRelationInfoForNavigator("CTHCycleLabCollection"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHLabDetailCondition' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHLabDetailConditionCollection() { return CreateRelationInfoForNavigator("CTHLabDetailConditionCollection"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHKimoSurvey' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHKimoSurveyCollectionViaCTHChemoLab() { return CreateRelationInfoForNavigator("CTHKimoSurveyCollectionViaCTHChemoLab"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHOperator' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHOperatorCollectionViaCTHLabDetailCondition() { return CreateRelationInfoForNavigator("CTHOperatorCollectionViaCTHLabDetailCondition"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHProtocolCycle' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHProtocolCycleCollectionViaCTHCycleLab() { return CreateRelationInfoForNavigator("CTHProtocolCycleCollectionViaCTHCycleLab"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHLab' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHLabItem() { return CreateRelationInfoForNavigator("CTHLabItem"); }
		
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
		/// <param name="validator">The validator object for this CTHLabDetailEntity</param>
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
		public static CTHLabDetailRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHChemoLab' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHChemoLabCollection { get { return _staticMetaData.GetPrefetchPathElement("CTHChemoLabCollection", CommonEntityBase.CreateEntityCollection<CTHChemoLabEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHCycleLab' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHCycleLabCollection { get { return _staticMetaData.GetPrefetchPathElement("CTHCycleLabCollection", CommonEntityBase.CreateEntityCollection<CTHCycleLabEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHLabDetailCondition' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHLabDetailConditionCollection { get { return _staticMetaData.GetPrefetchPathElement("CTHLabDetailConditionCollection", CommonEntityBase.CreateEntityCollection<CTHLabDetailConditionEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHKimoSurvey' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHKimoSurveyCollectionViaCTHChemoLab { get { return _staticMetaData.GetPrefetchPathElement("CTHKimoSurveyCollectionViaCTHChemoLab", CommonEntityBase.CreateEntityCollection<CTHKimoSurveyEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHOperator' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHOperatorCollectionViaCTHLabDetailCondition { get { return _staticMetaData.GetPrefetchPathElement("CTHOperatorCollectionViaCTHLabDetailCondition", CommonEntityBase.CreateEntityCollection<CTHOperatorEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHProtocolCycle' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHProtocolCycleCollectionViaCTHCycleLab { get { return _staticMetaData.GetPrefetchPathElement("CTHProtocolCycleCollectionViaCTHCycleLab", CommonEntityBase.CreateEntityCollection<CTHProtocolCycleEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHLab' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHLabItem { get { return _staticMetaData.GetPrefetchPathElement("CTHLabItem", CommonEntityBase.CreateEntityCollection<CTHLabEntity>()); } }

		/// <summary>The ArLabDetailsName property of the Entity CTHLabDetail<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHLabDetail"."ArLabDetailsName".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ArLabDetailsName
		{
			get { return (System.String)GetValue((int)CTHLabDetailFieldIndex.ArLabDetailsName, true); }
			set	{ SetValue((int)CTHLabDetailFieldIndex.ArLabDetailsName, value); }
		}

		/// <summary>The ArRemarks property of the Entity CTHLabDetail<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHLabDetail"."ArRemarks".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ArRemarks
		{
			get { return (System.String)GetValue((int)CTHLabDetailFieldIndex.ArRemarks, true); }
			set	{ SetValue((int)CTHLabDetailFieldIndex.ArRemarks, value); }
		}

		/// <summary>The ID property of the Entity CTHLabDetail<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHLabDetail"."ID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)CTHLabDetailFieldIndex.ID, true); }
			set { SetValue((int)CTHLabDetailFieldIndex.ID, value); }		}

		/// <summary>The LabDetailsName property of the Entity CTHLabDetail<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHLabDetail"."LabDetailsName".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String LabDetailsName
		{
			get { return (System.String)GetValue((int)CTHLabDetailFieldIndex.LabDetailsName, true); }
			set	{ SetValue((int)CTHLabDetailFieldIndex.LabDetailsName, value); }
		}

		/// <summary>The LabID property of the Entity CTHLabDetail<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHLabDetail"."LabID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> LabID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHLabDetailFieldIndex.LabID, false); }
			set	{ SetValue((int)CTHLabDetailFieldIndex.LabID, value); }
		}

		/// <summary>The Remarks property of the Entity CTHLabDetail<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHLabDetail"."Remarks".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Remarks
		{
			get { return (System.String)GetValue((int)CTHLabDetailFieldIndex.Remarks, true); }
			set	{ SetValue((int)CTHLabDetailFieldIndex.Remarks, value); }
		}

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHChemoLabEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHChemoLabEntity))]
		public virtual EntityCollection<CTHChemoLabEntity> CTHChemoLabCollection { get { return GetOrCreateEntityCollection<CTHChemoLabEntity, CTHChemoLabEntityFactory>("CTHLabDetailItem", true, false, ref _cTHChemoLabCollection); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHCycleLabEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHCycleLabEntity))]
		public virtual EntityCollection<CTHCycleLabEntity> CTHCycleLabCollection { get { return GetOrCreateEntityCollection<CTHCycleLabEntity, CTHCycleLabEntityFactory>("CTHLabDetailItem", true, false, ref _cTHCycleLabCollection); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHLabDetailConditionEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHLabDetailConditionEntity))]
		public virtual EntityCollection<CTHLabDetailConditionEntity> CTHLabDetailConditionCollection { get { return GetOrCreateEntityCollection<CTHLabDetailConditionEntity, CTHLabDetailConditionEntityFactory>("CTHLabDetailItem", true, false, ref _cTHLabDetailConditionCollection); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHKimoSurveyEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHKimoSurveyEntity))]
		public virtual EntityCollection<CTHKimoSurveyEntity> CTHKimoSurveyCollectionViaCTHChemoLab { get { return GetOrCreateEntityCollection<CTHKimoSurveyEntity, CTHKimoSurveyEntityFactory>("CTHLabDetailCollectionViaCTHChemoLab", false, true, ref _cTHKimoSurveyCollectionViaCTHChemoLab); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHOperatorEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHOperatorEntity))]
		public virtual EntityCollection<CTHOperatorEntity> CTHOperatorCollectionViaCTHLabDetailCondition { get { return GetOrCreateEntityCollection<CTHOperatorEntity, CTHOperatorEntityFactory>("CTHLabDetailCollectionViaCTHLabDetailCondition", false, true, ref _cTHOperatorCollectionViaCTHLabDetailCondition); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHProtocolCycleEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHProtocolCycleEntity))]
		public virtual EntityCollection<CTHProtocolCycleEntity> CTHProtocolCycleCollectionViaCTHCycleLab { get { return GetOrCreateEntityCollection<CTHProtocolCycleEntity, CTHProtocolCycleEntityFactory>("CTHLabDetailCollectionViaCTHCycleLab", false, true, ref _cTHProtocolCycleCollectionViaCTHCycleLab); } }

		/// <summary>Gets / sets related entity of type 'CTHLabEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHLabEntity CTHLabItem
		{
			get { return _cTHLabItem; }
			set { SetSingleRelatedEntityNavigator(value, "CTHLabItem"); }
		}
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace SStorm.CTH.DAL
{
	public enum CTHLabDetailFieldIndex
	{
		///<summary>ArLabDetailsName. </summary>
		ArLabDetailsName,
		///<summary>ArRemarks. </summary>
		ArRemarks,
		///<summary>ID. </summary>
		ID,
		///<summary>LabDetailsName. </summary>
		LabDetailsName,
		///<summary>LabID. </summary>
		LabID,
		///<summary>Remarks. </summary>
		Remarks,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace SStorm.CTH.DAL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: CTHLabDetail. </summary>
	public partial class CTHLabDetailRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between CTHLabDetailEntity and CTHChemoLabEntity over the 1:n relation they have, using the relation between the fields: CTHLabDetail.ID - CTHChemoLab.LabDetailsID</summary>
		public virtual IEntityRelation CTHChemoLabEntityUsingLabDetailsID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "CTHChemoLabCollection", true, new[] { CTHLabDetailFields.ID, CTHChemoLabFields.LabDetailsID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHLabDetailEntity and CTHCycleLabEntity over the 1:n relation they have, using the relation between the fields: CTHLabDetail.ID - CTHCycleLab.LabID</summary>
		public virtual IEntityRelation CTHCycleLabEntityUsingLabID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "CTHCycleLabCollection", true, new[] { CTHLabDetailFields.ID, CTHCycleLabFields.LabID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHLabDetailEntity and CTHLabDetailConditionEntity over the 1:n relation they have, using the relation between the fields: CTHLabDetail.ID - CTHLabDetailCondition.LabDetailID</summary>
		public virtual IEntityRelation CTHLabDetailConditionEntityUsingLabDetailID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "CTHLabDetailConditionCollection", true, new[] { CTHLabDetailFields.ID, CTHLabDetailConditionFields.LabDetailID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHLabDetailEntity and CTHLabEntity over the m:1 relation they have, using the relation between the fields: CTHLabDetail.LabID - CTHLab.ID</summary>
		public virtual IEntityRelation CTHLabEntityUsingLabID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHLabItem", false, new[] { CTHLabFields.ID, CTHLabDetailFields.LabID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCTHLabDetailRelations
	{
		internal static readonly IEntityRelation CTHChemoLabEntityUsingLabDetailsIDStatic = new CTHLabDetailRelations().CTHChemoLabEntityUsingLabDetailsID;
		internal static readonly IEntityRelation CTHCycleLabEntityUsingLabIDStatic = new CTHLabDetailRelations().CTHCycleLabEntityUsingLabID;
		internal static readonly IEntityRelation CTHLabDetailConditionEntityUsingLabDetailIDStatic = new CTHLabDetailRelations().CTHLabDetailConditionEntityUsingLabDetailID;
		internal static readonly IEntityRelation CTHLabEntityUsingLabIDStatic = new CTHLabDetailRelations().CTHLabEntityUsingLabID;

		/// <summary>CTor</summary>
		static StaticCTHLabDetailRelations() { }
	}
}
