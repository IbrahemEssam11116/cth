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

	/// <summary>Entity class which represents the entity 'CTHDoseUnit'.<br/><br/></summary>
	[Serializable]
	public partial class CTHDoseUnitEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private EntityCollection<CTHDrugEntity> _cTHDrugCollection;
		private EntityCollection<CTHChemotherapyProtocolEntity> _cTHChemotherapyProtocolCollectionViaCTHDrug;
		private EntityCollection<CTHSolutionEntity> _cTHSolutionCollectionViaCTHDrug;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static CTHDoseUnitEntityStaticMetaData _staticMetaData = new CTHDoseUnitEntityStaticMetaData();
		private static CTHDoseUnitRelations _relationsFactory = new CTHDoseUnitRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CTHDrugCollection</summary>
			public static readonly string CTHDrugCollection = "CTHDrugCollection";
			/// <summary>Member name CTHChemotherapyProtocolCollectionViaCTHDrug</summary>
			public static readonly string CTHChemotherapyProtocolCollectionViaCTHDrug = "CTHChemotherapyProtocolCollectionViaCTHDrug";
			/// <summary>Member name CTHSolutionCollectionViaCTHDrug</summary>
			public static readonly string CTHSolutionCollectionViaCTHDrug = "CTHSolutionCollectionViaCTHDrug";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class CTHDoseUnitEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public CTHDoseUnitEntityStaticMetaData()
			{
				SetEntityCoreInfo("CTHDoseUnitEntity", InheritanceHierarchyType.None, false, (int)SStorm.CTH.DAL.EntityType.CTHDoseUnitEntity, typeof(CTHDoseUnitEntity), typeof(CTHDoseUnitEntityFactory), false);
				AddNavigatorMetaData<CTHDoseUnitEntity, EntityCollection<CTHDrugEntity>>("CTHDrugCollection", a => a._cTHDrugCollection, (a, b) => a._cTHDrugCollection = b, a => a.CTHDrugCollection, () => new CTHDoseUnitRelations().CTHDrugEntityUsingDoseUnitID, typeof(CTHDrugEntity), (int)SStorm.CTH.DAL.EntityType.CTHDrugEntity);
				AddNavigatorMetaData<CTHDoseUnitEntity, EntityCollection<CTHChemotherapyProtocolEntity>>("CTHChemotherapyProtocolCollectionViaCTHDrug", a => a._cTHChemotherapyProtocolCollectionViaCTHDrug, (a, b) => a._cTHChemotherapyProtocolCollectionViaCTHDrug = b, a => a.CTHChemotherapyProtocolCollectionViaCTHDrug, () => new CTHDoseUnitRelations().CTHDrugEntityUsingDoseUnitID, () => new CTHDrugRelations().CTHChemotherapyProtocolEntityUsingProtocolID, "CTHDoseUnitEntity__", "CTHDrug_", typeof(CTHChemotherapyProtocolEntity), (int)SStorm.CTH.DAL.EntityType.CTHChemotherapyProtocolEntity);
				AddNavigatorMetaData<CTHDoseUnitEntity, EntityCollection<CTHSolutionEntity>>("CTHSolutionCollectionViaCTHDrug", a => a._cTHSolutionCollectionViaCTHDrug, (a, b) => a._cTHSolutionCollectionViaCTHDrug = b, a => a.CTHSolutionCollectionViaCTHDrug, () => new CTHDoseUnitRelations().CTHDrugEntityUsingDoseUnitID, () => new CTHDrugRelations().CTHSolutionEntityUsingSolutionID, "CTHDoseUnitEntity__", "CTHDrug_", typeof(CTHSolutionEntity), (int)SStorm.CTH.DAL.EntityType.CTHSolutionEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static CTHDoseUnitEntity()
		{
		}

		/// <summary> CTor</summary>
		public CTHDoseUnitEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CTHDoseUnitEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CTHDoseUnitEntity</param>
		public CTHDoseUnitEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHDoseUnit which data should be fetched into this CTHDoseUnit object</param>
		public CTHDoseUnitEntity(System.Int32 iD) : this(iD, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHDoseUnit which data should be fetched into this CTHDoseUnit object</param>
		/// <param name="validator">The custom validator object for this CTHDoseUnitEntity</param>
		public CTHDoseUnitEntity(System.Int32 iD, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CTHDoseUnitEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHDrug' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHDrugCollection() { return CreateRelationInfoForNavigator("CTHDrugCollection"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHChemotherapyProtocol' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHChemotherapyProtocolCollectionViaCTHDrug() { return CreateRelationInfoForNavigator("CTHChemotherapyProtocolCollectionViaCTHDrug"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHSolution' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHSolutionCollectionViaCTHDrug() { return CreateRelationInfoForNavigator("CTHSolutionCollectionViaCTHDrug"); }
		
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
		/// <param name="validator">The validator object for this CTHDoseUnitEntity</param>
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
		public static CTHDoseUnitRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHDrug' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHDrugCollection { get { return _staticMetaData.GetPrefetchPathElement("CTHDrugCollection", CommonEntityBase.CreateEntityCollection<CTHDrugEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHChemotherapyProtocol' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHChemotherapyProtocolCollectionViaCTHDrug { get { return _staticMetaData.GetPrefetchPathElement("CTHChemotherapyProtocolCollectionViaCTHDrug", CommonEntityBase.CreateEntityCollection<CTHChemotherapyProtocolEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHSolution' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHSolutionCollectionViaCTHDrug { get { return _staticMetaData.GetPrefetchPathElement("CTHSolutionCollectionViaCTHDrug", CommonEntityBase.CreateEntityCollection<CTHSolutionEntity>()); } }

		/// <summary>The ArName property of the Entity CTHDoseUnit<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHDoseUnit"."ArName".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ArName
		{
			get { return (System.String)GetValue((int)CTHDoseUnitFieldIndex.ArName, true); }
			set	{ SetValue((int)CTHDoseUnitFieldIndex.ArName, value); }
		}

		/// <summary>The ID property of the Entity CTHDoseUnit<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHDoseUnit"."ID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)CTHDoseUnitFieldIndex.ID, true); }
			set { SetValue((int)CTHDoseUnitFieldIndex.ID, value); }		}

		/// <summary>The Name property of the Entity CTHDoseUnit<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHDoseUnit"."Name".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)CTHDoseUnitFieldIndex.Name, true); }
			set	{ SetValue((int)CTHDoseUnitFieldIndex.Name, value); }
		}

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHDrugEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHDrugEntity))]
		public virtual EntityCollection<CTHDrugEntity> CTHDrugCollection { get { return GetOrCreateEntityCollection<CTHDrugEntity, CTHDrugEntityFactory>("CTHDoseUnitItem", true, false, ref _cTHDrugCollection); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHChemotherapyProtocolEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHChemotherapyProtocolEntity))]
		public virtual EntityCollection<CTHChemotherapyProtocolEntity> CTHChemotherapyProtocolCollectionViaCTHDrug { get { return GetOrCreateEntityCollection<CTHChemotherapyProtocolEntity, CTHChemotherapyProtocolEntityFactory>("CTHDoseUnitCollectionViaCTHDrug", false, true, ref _cTHChemotherapyProtocolCollectionViaCTHDrug); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHSolutionEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHSolutionEntity))]
		public virtual EntityCollection<CTHSolutionEntity> CTHSolutionCollectionViaCTHDrug { get { return GetOrCreateEntityCollection<CTHSolutionEntity, CTHSolutionEntityFactory>("CTHDoseUnitCollectionViaCTHDrug", false, true, ref _cTHSolutionCollectionViaCTHDrug); } }
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace SStorm.CTH.DAL
{
	public enum CTHDoseUnitFieldIndex
	{
		///<summary>ArName. </summary>
		ArName,
		///<summary>ID. </summary>
		ID,
		///<summary>Name. </summary>
		Name,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace SStorm.CTH.DAL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: CTHDoseUnit. </summary>
	public partial class CTHDoseUnitRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between CTHDoseUnitEntity and CTHDrugEntity over the 1:n relation they have, using the relation between the fields: CTHDoseUnit.ID - CTHDrug.DoseUnitID</summary>
		public virtual IEntityRelation CTHDrugEntityUsingDoseUnitID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "CTHDrugCollection", true, new[] { CTHDoseUnitFields.ID, CTHDrugFields.DoseUnitID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCTHDoseUnitRelations
	{
		internal static readonly IEntityRelation CTHDrugEntityUsingDoseUnitIDStatic = new CTHDoseUnitRelations().CTHDrugEntityUsingDoseUnitID;

		/// <summary>CTor</summary>
		static StaticCTHDoseUnitRelations() { }
	}
}
