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

	/// <summary>Entity class which represents the entity 'CTHSurgeryType'.<br/><br/></summary>
	[Serializable]
	public partial class CTHSurgeryTypeEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private EntityCollection<CTHPatientSurgeryEntity> _cTHPatientSurgeryCollection;
		private EntityCollection<CTHPatientClinicalDataEntity> _cTHPatientClinicalDataCollectionViaCTHPatientSurgery;
		private CTHCancerTypeEntity _cTHCancerTypeItem;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static CTHSurgeryTypeEntityStaticMetaData _staticMetaData = new CTHSurgeryTypeEntityStaticMetaData();
		private static CTHSurgeryTypeRelations _relationsFactory = new CTHSurgeryTypeRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CTHCancerTypeItem</summary>
			public static readonly string CTHCancerTypeItem = "CTHCancerTypeItem";
			/// <summary>Member name CTHPatientSurgeryCollection</summary>
			public static readonly string CTHPatientSurgeryCollection = "CTHPatientSurgeryCollection";
			/// <summary>Member name CTHPatientClinicalDataCollectionViaCTHPatientSurgery</summary>
			public static readonly string CTHPatientClinicalDataCollectionViaCTHPatientSurgery = "CTHPatientClinicalDataCollectionViaCTHPatientSurgery";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class CTHSurgeryTypeEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public CTHSurgeryTypeEntityStaticMetaData()
			{
				SetEntityCoreInfo("CTHSurgeryTypeEntity", InheritanceHierarchyType.None, false, (int)SStorm.CTH.DAL.EntityType.CTHSurgeryTypeEntity, typeof(CTHSurgeryTypeEntity), typeof(CTHSurgeryTypeEntityFactory), false);
				AddNavigatorMetaData<CTHSurgeryTypeEntity, EntityCollection<CTHPatientSurgeryEntity>>("CTHPatientSurgeryCollection", a => a._cTHPatientSurgeryCollection, (a, b) => a._cTHPatientSurgeryCollection = b, a => a.CTHPatientSurgeryCollection, () => new CTHSurgeryTypeRelations().CTHPatientSurgeryEntityUsingSurgeryTypeId, typeof(CTHPatientSurgeryEntity), (int)SStorm.CTH.DAL.EntityType.CTHPatientSurgeryEntity);
				AddNavigatorMetaData<CTHSurgeryTypeEntity, CTHCancerTypeEntity>("CTHCancerTypeItem", "CTHSurgeryTypeCollection", (a, b) => a._cTHCancerTypeItem = b, a => a._cTHCancerTypeItem, (a, b) => a.CTHCancerTypeItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHSurgeryTypeRelations.CTHCancerTypeEntityUsingCancerTypeIDStatic, ()=>new CTHSurgeryTypeRelations().CTHCancerTypeEntityUsingCancerTypeID, null, new int[] { (int)CTHSurgeryTypeFieldIndex.CancerTypeID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHCancerTypeEntity);
				AddNavigatorMetaData<CTHSurgeryTypeEntity, EntityCollection<CTHPatientClinicalDataEntity>>("CTHPatientClinicalDataCollectionViaCTHPatientSurgery", a => a._cTHPatientClinicalDataCollectionViaCTHPatientSurgery, (a, b) => a._cTHPatientClinicalDataCollectionViaCTHPatientSurgery = b, a => a.CTHPatientClinicalDataCollectionViaCTHPatientSurgery, () => new CTHSurgeryTypeRelations().CTHPatientSurgeryEntityUsingSurgeryTypeId, () => new CTHPatientSurgeryRelations().CTHPatientClinicalDataEntityUsingPatientClinicalDataID, "CTHSurgeryTypeEntity__", "CTHPatientSurgery_", typeof(CTHPatientClinicalDataEntity), (int)SStorm.CTH.DAL.EntityType.CTHPatientClinicalDataEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static CTHSurgeryTypeEntity()
		{
		}

		/// <summary> CTor</summary>
		public CTHSurgeryTypeEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CTHSurgeryTypeEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CTHSurgeryTypeEntity</param>
		public CTHSurgeryTypeEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHSurgeryType which data should be fetched into this CTHSurgeryType object</param>
		public CTHSurgeryTypeEntity(System.Int32 iD) : this(iD, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHSurgeryType which data should be fetched into this CTHSurgeryType object</param>
		/// <param name="validator">The custom validator object for this CTHSurgeryTypeEntity</param>
		public CTHSurgeryTypeEntity(System.Int32 iD, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CTHSurgeryTypeEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHPatientSurgery' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHPatientSurgeryCollection() { return CreateRelationInfoForNavigator("CTHPatientSurgeryCollection"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHPatientClinicalData' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHPatientClinicalDataCollectionViaCTHPatientSurgery() { return CreateRelationInfoForNavigator("CTHPatientClinicalDataCollectionViaCTHPatientSurgery"); }

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
		/// <param name="validator">The validator object for this CTHSurgeryTypeEntity</param>
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
		public static CTHSurgeryTypeRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHPatientSurgery' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHPatientSurgeryCollection { get { return _staticMetaData.GetPrefetchPathElement("CTHPatientSurgeryCollection", CommonEntityBase.CreateEntityCollection<CTHPatientSurgeryEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHPatientClinicalData' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHPatientClinicalDataCollectionViaCTHPatientSurgery { get { return _staticMetaData.GetPrefetchPathElement("CTHPatientClinicalDataCollectionViaCTHPatientSurgery", CommonEntityBase.CreateEntityCollection<CTHPatientClinicalDataEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHCancerType' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHCancerTypeItem { get { return _staticMetaData.GetPrefetchPathElement("CTHCancerTypeItem", CommonEntityBase.CreateEntityCollection<CTHCancerTypeEntity>()); } }

		/// <summary>The ArSurgeryType property of the Entity CTHSurgeryType<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHSurgeryType"."ArSurgeryType".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ArSurgeryType
		{
			get { return (System.String)GetValue((int)CTHSurgeryTypeFieldIndex.ArSurgeryType, true); }
			set	{ SetValue((int)CTHSurgeryTypeFieldIndex.ArSurgeryType, value); }
		}

		/// <summary>The CancerTypeID property of the Entity CTHSurgeryType<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHSurgeryType"."CancerTypeID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> CancerTypeID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHSurgeryTypeFieldIndex.CancerTypeID, false); }
			set	{ SetValue((int)CTHSurgeryTypeFieldIndex.CancerTypeID, value); }
		}

		/// <summary>The ID property of the Entity CTHSurgeryType<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHSurgeryType"."ID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)CTHSurgeryTypeFieldIndex.ID, true); }
			set { SetValue((int)CTHSurgeryTypeFieldIndex.ID, value); }		}

		/// <summary>The SurgeryType property of the Entity CTHSurgeryType<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHSurgeryType"."SurgeryType".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String SurgeryType
		{
			get { return (System.String)GetValue((int)CTHSurgeryTypeFieldIndex.SurgeryType, true); }
			set	{ SetValue((int)CTHSurgeryTypeFieldIndex.SurgeryType, value); }
		}

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHPatientSurgeryEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHPatientSurgeryEntity))]
		public virtual EntityCollection<CTHPatientSurgeryEntity> CTHPatientSurgeryCollection { get { return GetOrCreateEntityCollection<CTHPatientSurgeryEntity, CTHPatientSurgeryEntityFactory>("CTHSurgeryTypeItem", true, false, ref _cTHPatientSurgeryCollection); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHPatientClinicalDataEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHPatientClinicalDataEntity))]
		public virtual EntityCollection<CTHPatientClinicalDataEntity> CTHPatientClinicalDataCollectionViaCTHPatientSurgery { get { return GetOrCreateEntityCollection<CTHPatientClinicalDataEntity, CTHPatientClinicalDataEntityFactory>("CTHSurgeryTypeCollectionViaCTHPatientSurgery", false, true, ref _cTHPatientClinicalDataCollectionViaCTHPatientSurgery); } }

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
	public enum CTHSurgeryTypeFieldIndex
	{
		///<summary>ArSurgeryType. </summary>
		ArSurgeryType,
		///<summary>CancerTypeID. </summary>
		CancerTypeID,
		///<summary>ID. </summary>
		ID,
		///<summary>SurgeryType. </summary>
		SurgeryType,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace SStorm.CTH.DAL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: CTHSurgeryType. </summary>
	public partial class CTHSurgeryTypeRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between CTHSurgeryTypeEntity and CTHPatientSurgeryEntity over the 1:n relation they have, using the relation between the fields: CTHSurgeryType.ID - CTHPatientSurgery.SurgeryTypeId</summary>
		public virtual IEntityRelation CTHPatientSurgeryEntityUsingSurgeryTypeId
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "CTHPatientSurgeryCollection", true, new[] { CTHSurgeryTypeFields.ID, CTHPatientSurgeryFields.SurgeryTypeId }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHSurgeryTypeEntity and CTHCancerTypeEntity over the m:1 relation they have, using the relation between the fields: CTHSurgeryType.CancerTypeID - CTHCancerType.ID</summary>
		public virtual IEntityRelation CTHCancerTypeEntityUsingCancerTypeID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHCancerTypeItem", false, new[] { CTHCancerTypeFields.ID, CTHSurgeryTypeFields.CancerTypeID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCTHSurgeryTypeRelations
	{
		internal static readonly IEntityRelation CTHPatientSurgeryEntityUsingSurgeryTypeIdStatic = new CTHSurgeryTypeRelations().CTHPatientSurgeryEntityUsingSurgeryTypeId;
		internal static readonly IEntityRelation CTHCancerTypeEntityUsingCancerTypeIDStatic = new CTHSurgeryTypeRelations().CTHCancerTypeEntityUsingCancerTypeID;

		/// <summary>CTor</summary>
		static StaticCTHSurgeryTypeRelations() { }
	}
}
