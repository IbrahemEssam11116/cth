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

	/// <summary>Entity class which represents the entity 'CTHPaymentType'.<br/><br/></summary>
	[Serializable]
	public partial class CTHPaymentTypeEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private EntityCollection<CTHPatientEntity> _cTHPatientCollection;
		private EntityCollection<CTHDoctorEntity> _cTHDoctorCollectionViaCTHPatient;
		private EntityCollection<CTHUserEntity> _cTHUserCollectionViaCTHPatient;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static CTHPaymentTypeEntityStaticMetaData _staticMetaData = new CTHPaymentTypeEntityStaticMetaData();
		private static CTHPaymentTypeRelations _relationsFactory = new CTHPaymentTypeRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CTHPatientCollection</summary>
			public static readonly string CTHPatientCollection = "CTHPatientCollection";
			/// <summary>Member name CTHDoctorCollectionViaCTHPatient</summary>
			public static readonly string CTHDoctorCollectionViaCTHPatient = "CTHDoctorCollectionViaCTHPatient";
			/// <summary>Member name CTHUserCollectionViaCTHPatient</summary>
			public static readonly string CTHUserCollectionViaCTHPatient = "CTHUserCollectionViaCTHPatient";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class CTHPaymentTypeEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public CTHPaymentTypeEntityStaticMetaData()
			{
				SetEntityCoreInfo("CTHPaymentTypeEntity", InheritanceHierarchyType.None, false, (int)SStorm.CTH.DAL.EntityType.CTHPaymentTypeEntity, typeof(CTHPaymentTypeEntity), typeof(CTHPaymentTypeEntityFactory), false);
				AddNavigatorMetaData<CTHPaymentTypeEntity, EntityCollection<CTHPatientEntity>>("CTHPatientCollection", a => a._cTHPatientCollection, (a, b) => a._cTHPatientCollection = b, a => a.CTHPatientCollection, () => new CTHPaymentTypeRelations().CTHPatientEntityUsingPaymentTypeId, typeof(CTHPatientEntity), (int)SStorm.CTH.DAL.EntityType.CTHPatientEntity);
				AddNavigatorMetaData<CTHPaymentTypeEntity, EntityCollection<CTHDoctorEntity>>("CTHDoctorCollectionViaCTHPatient", a => a._cTHDoctorCollectionViaCTHPatient, (a, b) => a._cTHDoctorCollectionViaCTHPatient = b, a => a.CTHDoctorCollectionViaCTHPatient, () => new CTHPaymentTypeRelations().CTHPatientEntityUsingPaymentTypeId, () => new CTHPatientRelations().CTHDoctorEntityUsingDoctorID, "CTHPaymentTypeEntity__", "CTHPatient_", typeof(CTHDoctorEntity), (int)SStorm.CTH.DAL.EntityType.CTHDoctorEntity);
				AddNavigatorMetaData<CTHPaymentTypeEntity, EntityCollection<CTHUserEntity>>("CTHUserCollectionViaCTHPatient", a => a._cTHUserCollectionViaCTHPatient, (a, b) => a._cTHUserCollectionViaCTHPatient = b, a => a.CTHUserCollectionViaCTHPatient, () => new CTHPaymentTypeRelations().CTHPatientEntityUsingPaymentTypeId, () => new CTHPatientRelations().CTHUserEntityUsingUserID, "CTHPaymentTypeEntity__", "CTHPatient_", typeof(CTHUserEntity), (int)SStorm.CTH.DAL.EntityType.CTHUserEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static CTHPaymentTypeEntity()
		{
		}

		/// <summary> CTor</summary>
		public CTHPaymentTypeEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CTHPaymentTypeEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CTHPaymentTypeEntity</param>
		public CTHPaymentTypeEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHPaymentType which data should be fetched into this CTHPaymentType object</param>
		public CTHPaymentTypeEntity(System.Int32 iD) : this(iD, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHPaymentType which data should be fetched into this CTHPaymentType object</param>
		/// <param name="validator">The custom validator object for this CTHPaymentTypeEntity</param>
		public CTHPaymentTypeEntity(System.Int32 iD, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CTHPaymentTypeEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHPatient' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHPatientCollection() { return CreateRelationInfoForNavigator("CTHPatientCollection"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHDoctor' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHDoctorCollectionViaCTHPatient() { return CreateRelationInfoForNavigator("CTHDoctorCollectionViaCTHPatient"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHUser' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHUserCollectionViaCTHPatient() { return CreateRelationInfoForNavigator("CTHUserCollectionViaCTHPatient"); }
		
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
		/// <param name="validator">The validator object for this CTHPaymentTypeEntity</param>
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
		public static CTHPaymentTypeRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHPatient' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHPatientCollection { get { return _staticMetaData.GetPrefetchPathElement("CTHPatientCollection", CommonEntityBase.CreateEntityCollection<CTHPatientEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHDoctor' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHDoctorCollectionViaCTHPatient { get { return _staticMetaData.GetPrefetchPathElement("CTHDoctorCollectionViaCTHPatient", CommonEntityBase.CreateEntityCollection<CTHDoctorEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHUser' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHUserCollectionViaCTHPatient { get { return _staticMetaData.GetPrefetchPathElement("CTHUserCollectionViaCTHPatient", CommonEntityBase.CreateEntityCollection<CTHUserEntity>()); } }

		/// <summary>The ArPaymentType property of the Entity CTHPaymentType<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHPaymentType"."ArPaymentType".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ArPaymentType
		{
			get { return (System.String)GetValue((int)CTHPaymentTypeFieldIndex.ArPaymentType, true); }
			set	{ SetValue((int)CTHPaymentTypeFieldIndex.ArPaymentType, value); }
		}

		/// <summary>The ID property of the Entity CTHPaymentType<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHPaymentType"."ID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)CTHPaymentTypeFieldIndex.ID, true); }
			set { SetValue((int)CTHPaymentTypeFieldIndex.ID, value); }		}

		/// <summary>The PaymentType property of the Entity CTHPaymentType<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHPaymentType"."PaymentType".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PaymentType
		{
			get { return (System.String)GetValue((int)CTHPaymentTypeFieldIndex.PaymentType, true); }
			set	{ SetValue((int)CTHPaymentTypeFieldIndex.PaymentType, value); }
		}

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHPatientEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHPatientEntity))]
		public virtual EntityCollection<CTHPatientEntity> CTHPatientCollection { get { return GetOrCreateEntityCollection<CTHPatientEntity, CTHPatientEntityFactory>("CTHPaymentTypeItem", true, false, ref _cTHPatientCollection); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHDoctorEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHDoctorEntity))]
		public virtual EntityCollection<CTHDoctorEntity> CTHDoctorCollectionViaCTHPatient { get { return GetOrCreateEntityCollection<CTHDoctorEntity, CTHDoctorEntityFactory>("CTHPaymentTypeCollectionViaCTHPatient", false, true, ref _cTHDoctorCollectionViaCTHPatient); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHUserEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHUserEntity))]
		public virtual EntityCollection<CTHUserEntity> CTHUserCollectionViaCTHPatient { get { return GetOrCreateEntityCollection<CTHUserEntity, CTHUserEntityFactory>("CTHPaymentTypeCollectionViaCTHPatient", false, true, ref _cTHUserCollectionViaCTHPatient); } }
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace SStorm.CTH.DAL
{
	public enum CTHPaymentTypeFieldIndex
	{
		///<summary>ArPaymentType. </summary>
		ArPaymentType,
		///<summary>ID. </summary>
		ID,
		///<summary>PaymentType. </summary>
		PaymentType,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace SStorm.CTH.DAL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: CTHPaymentType. </summary>
	public partial class CTHPaymentTypeRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between CTHPaymentTypeEntity and CTHPatientEntity over the 1:n relation they have, using the relation between the fields: CTHPaymentType.ID - CTHPatient.PaymentTypeId</summary>
		public virtual IEntityRelation CTHPatientEntityUsingPaymentTypeId
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "CTHPatientCollection", true, new[] { CTHPaymentTypeFields.ID, CTHPatientFields.PaymentTypeId }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCTHPaymentTypeRelations
	{
		internal static readonly IEntityRelation CTHPatientEntityUsingPaymentTypeIdStatic = new CTHPaymentTypeRelations().CTHPatientEntityUsingPaymentTypeId;

		/// <summary>CTor</summary>
		static StaticCTHPaymentTypeRelations() { }
	}
}
