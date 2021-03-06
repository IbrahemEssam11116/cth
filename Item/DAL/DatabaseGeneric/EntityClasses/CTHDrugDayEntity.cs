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

	/// <summary>Entity class which represents the entity 'CTHDrugDay'.<br/><br/></summary>
	[Serializable]
	public partial class CTHDrugDayEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private EntityCollection<CTHPatientDrugEntity> _cTHPatientDrugCollection;
		private EntityCollection<CTHDrugEntity> _cTHDrugCollectionViaCTHPatientDrug;
		private EntityCollection<CTHKimoSurveyEntity> _cTHKimoSurveyCollectionViaCTHPatientDrug;
		private CTHDrugEntity _cTHDrugItem;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static CTHDrugDayEntityStaticMetaData _staticMetaData = new CTHDrugDayEntityStaticMetaData();
		private static CTHDrugDayRelations _relationsFactory = new CTHDrugDayRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CTHDrugItem</summary>
			public static readonly string CTHDrugItem = "CTHDrugItem";
			/// <summary>Member name CTHPatientDrugCollection</summary>
			public static readonly string CTHPatientDrugCollection = "CTHPatientDrugCollection";
			/// <summary>Member name CTHDrugCollectionViaCTHPatientDrug</summary>
			public static readonly string CTHDrugCollectionViaCTHPatientDrug = "CTHDrugCollectionViaCTHPatientDrug";
			/// <summary>Member name CTHKimoSurveyCollectionViaCTHPatientDrug</summary>
			public static readonly string CTHKimoSurveyCollectionViaCTHPatientDrug = "CTHKimoSurveyCollectionViaCTHPatientDrug";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class CTHDrugDayEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public CTHDrugDayEntityStaticMetaData()
			{
				SetEntityCoreInfo("CTHDrugDayEntity", InheritanceHierarchyType.None, false, (int)SStorm.CTH.DAL.EntityType.CTHDrugDayEntity, typeof(CTHDrugDayEntity), typeof(CTHDrugDayEntityFactory), false);
				AddNavigatorMetaData<CTHDrugDayEntity, EntityCollection<CTHPatientDrugEntity>>("CTHPatientDrugCollection", a => a._cTHPatientDrugCollection, (a, b) => a._cTHPatientDrugCollection = b, a => a.CTHPatientDrugCollection, () => new CTHDrugDayRelations().CTHPatientDrugEntityUsingDrugDayID, typeof(CTHPatientDrugEntity), (int)SStorm.CTH.DAL.EntityType.CTHPatientDrugEntity);
				AddNavigatorMetaData<CTHDrugDayEntity, CTHDrugEntity>("CTHDrugItem", "CTHDrugDayCollection", (a, b) => a._cTHDrugItem = b, a => a._cTHDrugItem, (a, b) => a.CTHDrugItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHDrugDayRelations.CTHDrugEntityUsingDrugIDStatic, ()=>new CTHDrugDayRelations().CTHDrugEntityUsingDrugID, null, new int[] { (int)CTHDrugDayFieldIndex.DrugID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHDrugEntity);
				AddNavigatorMetaData<CTHDrugDayEntity, EntityCollection<CTHDrugEntity>>("CTHDrugCollectionViaCTHPatientDrug", a => a._cTHDrugCollectionViaCTHPatientDrug, (a, b) => a._cTHDrugCollectionViaCTHPatientDrug = b, a => a.CTHDrugCollectionViaCTHPatientDrug, () => new CTHDrugDayRelations().CTHPatientDrugEntityUsingDrugDayID, () => new CTHPatientDrugRelations().CTHDrugEntityUsingDrugID, "CTHDrugDayEntity__", "CTHPatientDrug_", typeof(CTHDrugEntity), (int)SStorm.CTH.DAL.EntityType.CTHDrugEntity);
				AddNavigatorMetaData<CTHDrugDayEntity, EntityCollection<CTHKimoSurveyEntity>>("CTHKimoSurveyCollectionViaCTHPatientDrug", a => a._cTHKimoSurveyCollectionViaCTHPatientDrug, (a, b) => a._cTHKimoSurveyCollectionViaCTHPatientDrug = b, a => a.CTHKimoSurveyCollectionViaCTHPatientDrug, () => new CTHDrugDayRelations().CTHPatientDrugEntityUsingDrugDayID, () => new CTHPatientDrugRelations().CTHKimoSurveyEntityUsingKimoID, "CTHDrugDayEntity__", "CTHPatientDrug_", typeof(CTHKimoSurveyEntity), (int)SStorm.CTH.DAL.EntityType.CTHKimoSurveyEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static CTHDrugDayEntity()
		{
		}

		/// <summary> CTor</summary>
		public CTHDrugDayEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CTHDrugDayEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CTHDrugDayEntity</param>
		public CTHDrugDayEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHDrugDay which data should be fetched into this CTHDrugDay object</param>
		public CTHDrugDayEntity(System.Int32 iD) : this(iD, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHDrugDay which data should be fetched into this CTHDrugDay object</param>
		/// <param name="validator">The custom validator object for this CTHDrugDayEntity</param>
		public CTHDrugDayEntity(System.Int32 iD, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CTHDrugDayEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHPatientDrug' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHPatientDrugCollection() { return CreateRelationInfoForNavigator("CTHPatientDrugCollection"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHDrug' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHDrugCollectionViaCTHPatientDrug() { return CreateRelationInfoForNavigator("CTHDrugCollectionViaCTHPatientDrug"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHKimoSurvey' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHKimoSurveyCollectionViaCTHPatientDrug() { return CreateRelationInfoForNavigator("CTHKimoSurveyCollectionViaCTHPatientDrug"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHDrug' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHDrugItem() { return CreateRelationInfoForNavigator("CTHDrugItem"); }
		
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
		/// <param name="validator">The validator object for this CTHDrugDayEntity</param>
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
		public static CTHDrugDayRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHPatientDrug' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHPatientDrugCollection { get { return _staticMetaData.GetPrefetchPathElement("CTHPatientDrugCollection", CommonEntityBase.CreateEntityCollection<CTHPatientDrugEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHDrug' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHDrugCollectionViaCTHPatientDrug { get { return _staticMetaData.GetPrefetchPathElement("CTHDrugCollectionViaCTHPatientDrug", CommonEntityBase.CreateEntityCollection<CTHDrugEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHKimoSurvey' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHKimoSurveyCollectionViaCTHPatientDrug { get { return _staticMetaData.GetPrefetchPathElement("CTHKimoSurveyCollectionViaCTHPatientDrug", CommonEntityBase.CreateEntityCollection<CTHKimoSurveyEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHDrug' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHDrugItem { get { return _staticMetaData.GetPrefetchPathElement("CTHDrugItem", CommonEntityBase.CreateEntityCollection<CTHDrugEntity>()); } }

		/// <summary>The Day property of the Entity CTHDrugDay<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHDrugDay"."Day".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> Day
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHDrugDayFieldIndex.Day, false); }
			set	{ SetValue((int)CTHDrugDayFieldIndex.Day, value); }
		}

		/// <summary>The DrugID property of the Entity CTHDrugDay<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHDrugDay"."DrugID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> DrugID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHDrugDayFieldIndex.DrugID, false); }
			set	{ SetValue((int)CTHDrugDayFieldIndex.DrugID, value); }
		}

		/// <summary>The ID property of the Entity CTHDrugDay<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHDrugDay"."ID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)CTHDrugDayFieldIndex.ID, true); }
			set { SetValue((int)CTHDrugDayFieldIndex.ID, value); }		}

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHPatientDrugEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHPatientDrugEntity))]
		public virtual EntityCollection<CTHPatientDrugEntity> CTHPatientDrugCollection { get { return GetOrCreateEntityCollection<CTHPatientDrugEntity, CTHPatientDrugEntityFactory>("CTHDrugDayItem", true, false, ref _cTHPatientDrugCollection); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHDrugEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHDrugEntity))]
		public virtual EntityCollection<CTHDrugEntity> CTHDrugCollectionViaCTHPatientDrug { get { return GetOrCreateEntityCollection<CTHDrugEntity, CTHDrugEntityFactory>("CTHDrugDayCollectionViaCTHPatientDrug", false, true, ref _cTHDrugCollectionViaCTHPatientDrug); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHKimoSurveyEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHKimoSurveyEntity))]
		public virtual EntityCollection<CTHKimoSurveyEntity> CTHKimoSurveyCollectionViaCTHPatientDrug { get { return GetOrCreateEntityCollection<CTHKimoSurveyEntity, CTHKimoSurveyEntityFactory>("CTHDrugDayCollectionViaCTHPatientDrug", false, true, ref _cTHKimoSurveyCollectionViaCTHPatientDrug); } }

		/// <summary>Gets / sets related entity of type 'CTHDrugEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHDrugEntity CTHDrugItem
		{
			get { return _cTHDrugItem; }
			set { SetSingleRelatedEntityNavigator(value, "CTHDrugItem"); }
		}
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace SStorm.CTH.DAL
{
	public enum CTHDrugDayFieldIndex
	{
		///<summary>Day. </summary>
		Day,
		///<summary>DrugID. </summary>
		DrugID,
		///<summary>ID. </summary>
		ID,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace SStorm.CTH.DAL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: CTHDrugDay. </summary>
	public partial class CTHDrugDayRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between CTHDrugDayEntity and CTHPatientDrugEntity over the 1:n relation they have, using the relation between the fields: CTHDrugDay.ID - CTHPatientDrug.DrugDayID</summary>
		public virtual IEntityRelation CTHPatientDrugEntityUsingDrugDayID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "CTHPatientDrugCollection", true, new[] { CTHDrugDayFields.ID, CTHPatientDrugFields.DrugDayID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHDrugDayEntity and CTHDrugEntity over the m:1 relation they have, using the relation between the fields: CTHDrugDay.DrugID - CTHDrug.ID</summary>
		public virtual IEntityRelation CTHDrugEntityUsingDrugID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHDrugItem", false, new[] { CTHDrugFields.ID, CTHDrugDayFields.DrugID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCTHDrugDayRelations
	{
		internal static readonly IEntityRelation CTHPatientDrugEntityUsingDrugDayIDStatic = new CTHDrugDayRelations().CTHPatientDrugEntityUsingDrugDayID;
		internal static readonly IEntityRelation CTHDrugEntityUsingDrugIDStatic = new CTHDrugDayRelations().CTHDrugEntityUsingDrugID;

		/// <summary>CTor</summary>
		static StaticCTHDrugDayRelations() { }
	}
}
