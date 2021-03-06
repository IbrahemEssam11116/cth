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

	/// <summary>Entity class which represents the entity 'CTHSolution'.<br/><br/></summary>
	[Serializable]
	public partial class CTHSolutionEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private EntityCollection<CTHDrugEntity> _cTHDrugCollection;
		private EntityCollection<CTHChemotherapyProtocolEntity> _cTHChemotherapyProtocolCollectionViaCTHDrug;
		private EntityCollection<CTHDoseUnitEntity> _cTHDoseUnitCollectionViaCTHDrug;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static CTHSolutionEntityStaticMetaData _staticMetaData = new CTHSolutionEntityStaticMetaData();
		private static CTHSolutionRelations _relationsFactory = new CTHSolutionRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CTHDrugCollection</summary>
			public static readonly string CTHDrugCollection = "CTHDrugCollection";
			/// <summary>Member name CTHChemotherapyProtocolCollectionViaCTHDrug</summary>
			public static readonly string CTHChemotherapyProtocolCollectionViaCTHDrug = "CTHChemotherapyProtocolCollectionViaCTHDrug";
			/// <summary>Member name CTHDoseUnitCollectionViaCTHDrug</summary>
			public static readonly string CTHDoseUnitCollectionViaCTHDrug = "CTHDoseUnitCollectionViaCTHDrug";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class CTHSolutionEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public CTHSolutionEntityStaticMetaData()
			{
				SetEntityCoreInfo("CTHSolutionEntity", InheritanceHierarchyType.None, false, (int)SStorm.CTH.DAL.EntityType.CTHSolutionEntity, typeof(CTHSolutionEntity), typeof(CTHSolutionEntityFactory), false);
				AddNavigatorMetaData<CTHSolutionEntity, EntityCollection<CTHDrugEntity>>("CTHDrugCollection", a => a._cTHDrugCollection, (a, b) => a._cTHDrugCollection = b, a => a.CTHDrugCollection, () => new CTHSolutionRelations().CTHDrugEntityUsingSolutionID, typeof(CTHDrugEntity), (int)SStorm.CTH.DAL.EntityType.CTHDrugEntity);
				AddNavigatorMetaData<CTHSolutionEntity, EntityCollection<CTHChemotherapyProtocolEntity>>("CTHChemotherapyProtocolCollectionViaCTHDrug", a => a._cTHChemotherapyProtocolCollectionViaCTHDrug, (a, b) => a._cTHChemotherapyProtocolCollectionViaCTHDrug = b, a => a.CTHChemotherapyProtocolCollectionViaCTHDrug, () => new CTHSolutionRelations().CTHDrugEntityUsingSolutionID, () => new CTHDrugRelations().CTHChemotherapyProtocolEntityUsingProtocolID, "CTHSolutionEntity__", "CTHDrug_", typeof(CTHChemotherapyProtocolEntity), (int)SStorm.CTH.DAL.EntityType.CTHChemotherapyProtocolEntity);
				AddNavigatorMetaData<CTHSolutionEntity, EntityCollection<CTHDoseUnitEntity>>("CTHDoseUnitCollectionViaCTHDrug", a => a._cTHDoseUnitCollectionViaCTHDrug, (a, b) => a._cTHDoseUnitCollectionViaCTHDrug = b, a => a.CTHDoseUnitCollectionViaCTHDrug, () => new CTHSolutionRelations().CTHDrugEntityUsingSolutionID, () => new CTHDrugRelations().CTHDoseUnitEntityUsingDoseUnitID, "CTHSolutionEntity__", "CTHDrug_", typeof(CTHDoseUnitEntity), (int)SStorm.CTH.DAL.EntityType.CTHDoseUnitEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static CTHSolutionEntity()
		{
		}

		/// <summary> CTor</summary>
		public CTHSolutionEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CTHSolutionEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CTHSolutionEntity</param>
		public CTHSolutionEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHSolution which data should be fetched into this CTHSolution object</param>
		public CTHSolutionEntity(System.Int32 iD) : this(iD, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHSolution which data should be fetched into this CTHSolution object</param>
		/// <param name="validator">The custom validator object for this CTHSolutionEntity</param>
		public CTHSolutionEntity(System.Int32 iD, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CTHSolutionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
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

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHDoseUnit' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHDoseUnitCollectionViaCTHDrug() { return CreateRelationInfoForNavigator("CTHDoseUnitCollectionViaCTHDrug"); }
		
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
		/// <param name="validator">The validator object for this CTHSolutionEntity</param>
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
		public static CTHSolutionRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHDrug' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHDrugCollection { get { return _staticMetaData.GetPrefetchPathElement("CTHDrugCollection", CommonEntityBase.CreateEntityCollection<CTHDrugEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHChemotherapyProtocol' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHChemotherapyProtocolCollectionViaCTHDrug { get { return _staticMetaData.GetPrefetchPathElement("CTHChemotherapyProtocolCollectionViaCTHDrug", CommonEntityBase.CreateEntityCollection<CTHChemotherapyProtocolEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHDoseUnit' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHDoseUnitCollectionViaCTHDrug { get { return _staticMetaData.GetPrefetchPathElement("CTHDoseUnitCollectionViaCTHDrug", CommonEntityBase.CreateEntityCollection<CTHDoseUnitEntity>()); } }

		/// <summary>The ArDescription property of the Entity CTHSolution<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHSolution"."ArDescription".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ArDescription
		{
			get { return (System.String)GetValue((int)CTHSolutionFieldIndex.ArDescription, true); }
			set	{ SetValue((int)CTHSolutionFieldIndex.ArDescription, value); }
		}

		/// <summary>The ArName property of the Entity CTHSolution<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHSolution"."ArName".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ArName
		{
			get { return (System.String)GetValue((int)CTHSolutionFieldIndex.ArName, true); }
			set	{ SetValue((int)CTHSolutionFieldIndex.ArName, value); }
		}

		/// <summary>The Description property of the Entity CTHSolution<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHSolution"."Description".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)CTHSolutionFieldIndex.Description, true); }
			set	{ SetValue((int)CTHSolutionFieldIndex.Description, value); }
		}

		/// <summary>The ID property of the Entity CTHSolution<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHSolution"."ID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)CTHSolutionFieldIndex.ID, true); }
			set { SetValue((int)CTHSolutionFieldIndex.ID, value); }		}

		/// <summary>The Name property of the Entity CTHSolution<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHSolution"."Name".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)CTHSolutionFieldIndex.Name, true); }
			set	{ SetValue((int)CTHSolutionFieldIndex.Name, value); }
		}

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHDrugEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHDrugEntity))]
		public virtual EntityCollection<CTHDrugEntity> CTHDrugCollection { get { return GetOrCreateEntityCollection<CTHDrugEntity, CTHDrugEntityFactory>("CTHSolutionItem", true, false, ref _cTHDrugCollection); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHChemotherapyProtocolEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHChemotherapyProtocolEntity))]
		public virtual EntityCollection<CTHChemotherapyProtocolEntity> CTHChemotherapyProtocolCollectionViaCTHDrug { get { return GetOrCreateEntityCollection<CTHChemotherapyProtocolEntity, CTHChemotherapyProtocolEntityFactory>("CTHSolutionCollectionViaCTHDrug", false, true, ref _cTHChemotherapyProtocolCollectionViaCTHDrug); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHDoseUnitEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHDoseUnitEntity))]
		public virtual EntityCollection<CTHDoseUnitEntity> CTHDoseUnitCollectionViaCTHDrug { get { return GetOrCreateEntityCollection<CTHDoseUnitEntity, CTHDoseUnitEntityFactory>("CTHSolutionCollectionViaCTHDrug", false, true, ref _cTHDoseUnitCollectionViaCTHDrug); } }
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace SStorm.CTH.DAL
{
	public enum CTHSolutionFieldIndex
	{
		///<summary>ArDescription. </summary>
		ArDescription,
		///<summary>ArName. </summary>
		ArName,
		///<summary>Description. </summary>
		Description,
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
	/// <summary>Implements the relations factory for the entity: CTHSolution. </summary>
	public partial class CTHSolutionRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between CTHSolutionEntity and CTHDrugEntity over the 1:n relation they have, using the relation between the fields: CTHSolution.ID - CTHDrug.SolutionID</summary>
		public virtual IEntityRelation CTHDrugEntityUsingSolutionID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "CTHDrugCollection", true, new[] { CTHSolutionFields.ID, CTHDrugFields.SolutionID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCTHSolutionRelations
	{
		internal static readonly IEntityRelation CTHDrugEntityUsingSolutionIDStatic = new CTHSolutionRelations().CTHDrugEntityUsingSolutionID;

		/// <summary>CTor</summary>
		static StaticCTHSolutionRelations() { }
	}
}
