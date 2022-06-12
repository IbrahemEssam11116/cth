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

	/// <summary>Entity class which represents the entity 'CTHTNMType'.<br/><br/></summary>
	[Serializable]
	public partial class CTHTNMTypeEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private EntityCollection<CTHTNMStagingEntity> _cTHTNMStagingCollection;
		private EntityCollection<CTHCancerTypeEntity> _cTHCancerTypeCollectionViaCTHTNMStaging;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static CTHTNMTypeEntityStaticMetaData _staticMetaData = new CTHTNMTypeEntityStaticMetaData();
		private static CTHTNMTypeRelations _relationsFactory = new CTHTNMTypeRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CTHTNMStagingCollection</summary>
			public static readonly string CTHTNMStagingCollection = "CTHTNMStagingCollection";
			/// <summary>Member name CTHCancerTypeCollectionViaCTHTNMStaging</summary>
			public static readonly string CTHCancerTypeCollectionViaCTHTNMStaging = "CTHCancerTypeCollectionViaCTHTNMStaging";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class CTHTNMTypeEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public CTHTNMTypeEntityStaticMetaData()
			{
				SetEntityCoreInfo("CTHTNMTypeEntity", InheritanceHierarchyType.None, false, (int)SStorm.CTH.DAL.EntityType.CTHTNMTypeEntity, typeof(CTHTNMTypeEntity), typeof(CTHTNMTypeEntityFactory), false);
				AddNavigatorMetaData<CTHTNMTypeEntity, EntityCollection<CTHTNMStagingEntity>>("CTHTNMStagingCollection", a => a._cTHTNMStagingCollection, (a, b) => a._cTHTNMStagingCollection = b, a => a.CTHTNMStagingCollection, () => new CTHTNMTypeRelations().CTHTNMStagingEntityUsingTNMTypeID, typeof(CTHTNMStagingEntity), (int)SStorm.CTH.DAL.EntityType.CTHTNMStagingEntity);
				AddNavigatorMetaData<CTHTNMTypeEntity, EntityCollection<CTHCancerTypeEntity>>("CTHCancerTypeCollectionViaCTHTNMStaging", a => a._cTHCancerTypeCollectionViaCTHTNMStaging, (a, b) => a._cTHCancerTypeCollectionViaCTHTNMStaging = b, a => a.CTHCancerTypeCollectionViaCTHTNMStaging, () => new CTHTNMTypeRelations().CTHTNMStagingEntityUsingTNMTypeID, () => new CTHTNMStagingRelations().CTHCancerTypeEntityUsingCancerTypeID, "CTHTNMTypeEntity__", "CTHTNMStaging_", typeof(CTHCancerTypeEntity), (int)SStorm.CTH.DAL.EntityType.CTHCancerTypeEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static CTHTNMTypeEntity()
		{
		}

		/// <summary> CTor</summary>
		public CTHTNMTypeEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CTHTNMTypeEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CTHTNMTypeEntity</param>
		public CTHTNMTypeEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHTNMType which data should be fetched into this CTHTNMType object</param>
		public CTHTNMTypeEntity(System.Int32 iD) : this(iD, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHTNMType which data should be fetched into this CTHTNMType object</param>
		/// <param name="validator">The custom validator object for this CTHTNMTypeEntity</param>
		public CTHTNMTypeEntity(System.Int32 iD, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CTHTNMTypeEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHTNMStaging' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHTNMStagingCollection() { return CreateRelationInfoForNavigator("CTHTNMStagingCollection"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHCancerType' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHCancerTypeCollectionViaCTHTNMStaging() { return CreateRelationInfoForNavigator("CTHCancerTypeCollectionViaCTHTNMStaging"); }
		
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
		/// <param name="validator">The validator object for this CTHTNMTypeEntity</param>
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
		public static CTHTNMTypeRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHTNMStaging' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHTNMStagingCollection { get { return _staticMetaData.GetPrefetchPathElement("CTHTNMStagingCollection", CommonEntityBase.CreateEntityCollection<CTHTNMStagingEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHCancerType' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHCancerTypeCollectionViaCTHTNMStaging { get { return _staticMetaData.GetPrefetchPathElement("CTHCancerTypeCollectionViaCTHTNMStaging", CommonEntityBase.CreateEntityCollection<CTHCancerTypeEntity>()); } }

		/// <summary>The ArTypeName property of the Entity CTHTNMType<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHTNMType"."ArTypeName".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ArTypeName
		{
			get { return (System.String)GetValue((int)CTHTNMTypeFieldIndex.ArTypeName, true); }
			set	{ SetValue((int)CTHTNMTypeFieldIndex.ArTypeName, value); }
		}

		/// <summary>The ID property of the Entity CTHTNMType<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHTNMType"."ID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)CTHTNMTypeFieldIndex.ID, true); }
			set	{ SetValue((int)CTHTNMTypeFieldIndex.ID, value); }
		}

		/// <summary>The TypeName property of the Entity CTHTNMType<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHTNMType"."TypeName".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String TypeName
		{
			get { return (System.String)GetValue((int)CTHTNMTypeFieldIndex.TypeName, true); }
			set	{ SetValue((int)CTHTNMTypeFieldIndex.TypeName, value); }
		}

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHTNMStagingEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHTNMStagingEntity))]
		public virtual EntityCollection<CTHTNMStagingEntity> CTHTNMStagingCollection { get { return GetOrCreateEntityCollection<CTHTNMStagingEntity, CTHTNMStagingEntityFactory>("CTHTNMTypeItem", true, false, ref _cTHTNMStagingCollection); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHCancerTypeEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHCancerTypeEntity))]
		public virtual EntityCollection<CTHCancerTypeEntity> CTHCancerTypeCollectionViaCTHTNMStaging { get { return GetOrCreateEntityCollection<CTHCancerTypeEntity, CTHCancerTypeEntityFactory>("CTHTNMTypeCollectionViaCTHTNMStaging", false, true, ref _cTHCancerTypeCollectionViaCTHTNMStaging); } }
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace SStorm.CTH.DAL
{
	public enum CTHTNMTypeFieldIndex
	{
		///<summary>ArTypeName. </summary>
		ArTypeName,
		///<summary>ID. </summary>
		ID,
		///<summary>TypeName. </summary>
		TypeName,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace SStorm.CTH.DAL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: CTHTNMType. </summary>
	public partial class CTHTNMTypeRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between CTHTNMTypeEntity and CTHTNMStagingEntity over the 1:n relation they have, using the relation between the fields: CTHTNMType.ID - CTHTNMStaging.TNMTypeID</summary>
		public virtual IEntityRelation CTHTNMStagingEntityUsingTNMTypeID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "CTHTNMStagingCollection", true, new[] { CTHTNMTypeFields.ID, CTHTNMStagingFields.TNMTypeID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCTHTNMTypeRelations
	{
		internal static readonly IEntityRelation CTHTNMStagingEntityUsingTNMTypeIDStatic = new CTHTNMTypeRelations().CTHTNMStagingEntityUsingTNMTypeID;

		/// <summary>CTor</summary>
		static StaticCTHTNMTypeRelations() { }
	}
}
