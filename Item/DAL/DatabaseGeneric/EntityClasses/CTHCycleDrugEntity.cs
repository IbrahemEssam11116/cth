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

	/// <summary>Entity class which represents the entity 'CTHCycleDrug'.<br/><br/></summary>
	[Serializable]
	public partial class CTHCycleDrugEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private CTHDrugEntity _cTHDrugItem;
		private CTHProtocolCycleEntity _cTHProtocolCycleItem;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static CTHCycleDrugEntityStaticMetaData _staticMetaData = new CTHCycleDrugEntityStaticMetaData();
		private static CTHCycleDrugRelations _relationsFactory = new CTHCycleDrugRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CTHDrugItem</summary>
			public static readonly string CTHDrugItem = "CTHDrugItem";
			/// <summary>Member name CTHProtocolCycleItem</summary>
			public static readonly string CTHProtocolCycleItem = "CTHProtocolCycleItem";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class CTHCycleDrugEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public CTHCycleDrugEntityStaticMetaData()
			{
				SetEntityCoreInfo("CTHCycleDrugEntity", InheritanceHierarchyType.None, false, (int)SStorm.CTH.DAL.EntityType.CTHCycleDrugEntity, typeof(CTHCycleDrugEntity), typeof(CTHCycleDrugEntityFactory), false);
				AddNavigatorMetaData<CTHCycleDrugEntity, CTHDrugEntity>("CTHDrugItem", "CTHCycleDrugCollection", (a, b) => a._cTHDrugItem = b, a => a._cTHDrugItem, (a, b) => a.CTHDrugItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHCycleDrugRelations.CTHDrugEntityUsingDrugIDStatic, ()=>new CTHCycleDrugRelations().CTHDrugEntityUsingDrugID, null, new int[] { (int)CTHCycleDrugFieldIndex.DrugID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHDrugEntity);
				AddNavigatorMetaData<CTHCycleDrugEntity, CTHProtocolCycleEntity>("CTHProtocolCycleItem", "CTHCycleDrugCollection", (a, b) => a._cTHProtocolCycleItem = b, a => a._cTHProtocolCycleItem, (a, b) => a.CTHProtocolCycleItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHCycleDrugRelations.CTHProtocolCycleEntityUsingCycleIDStatic, ()=>new CTHCycleDrugRelations().CTHProtocolCycleEntityUsingCycleID, null, new int[] { (int)CTHCycleDrugFieldIndex.CycleID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHProtocolCycleEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static CTHCycleDrugEntity()
		{
		}

		/// <summary> CTor</summary>
		public CTHCycleDrugEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CTHCycleDrugEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CTHCycleDrugEntity</param>
		public CTHCycleDrugEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHCycleDrug which data should be fetched into this CTHCycleDrug object</param>
		public CTHCycleDrugEntity(System.Int32 iD) : this(iD, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHCycleDrug which data should be fetched into this CTHCycleDrug object</param>
		/// <param name="validator">The custom validator object for this CTHCycleDrugEntity</param>
		public CTHCycleDrugEntity(System.Int32 iD, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CTHCycleDrugEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHDrug' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHDrugItem() { return CreateRelationInfoForNavigator("CTHDrugItem"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHProtocolCycle' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHProtocolCycleItem() { return CreateRelationInfoForNavigator("CTHProtocolCycleItem"); }
		
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
		/// <param name="validator">The validator object for this CTHCycleDrugEntity</param>
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
		public static CTHCycleDrugRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHDrug' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHDrugItem { get { return _staticMetaData.GetPrefetchPathElement("CTHDrugItem", CommonEntityBase.CreateEntityCollection<CTHDrugEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHProtocolCycle' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHProtocolCycleItem { get { return _staticMetaData.GetPrefetchPathElement("CTHProtocolCycleItem", CommonEntityBase.CreateEntityCollection<CTHProtocolCycleEntity>()); } }

		/// <summary>The CycleID property of the Entity CTHCycleDrug<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHCycleDrug"."CycleID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> CycleID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHCycleDrugFieldIndex.CycleID, false); }
			set	{ SetValue((int)CTHCycleDrugFieldIndex.CycleID, value); }
		}

		/// <summary>The DrugID property of the Entity CTHCycleDrug<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHCycleDrug"."DrugID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> DrugID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHCycleDrugFieldIndex.DrugID, false); }
			set	{ SetValue((int)CTHCycleDrugFieldIndex.DrugID, value); }
		}

		/// <summary>The ID property of the Entity CTHCycleDrug<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHCycleDrug"."ID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)CTHCycleDrugFieldIndex.ID, true); }
			set { SetValue((int)CTHCycleDrugFieldIndex.ID, value); }		}

		/// <summary>Gets / sets related entity of type 'CTHDrugEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHDrugEntity CTHDrugItem
		{
			get { return _cTHDrugItem; }
			set { SetSingleRelatedEntityNavigator(value, "CTHDrugItem"); }
		}

		/// <summary>Gets / sets related entity of type 'CTHProtocolCycleEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHProtocolCycleEntity CTHProtocolCycleItem
		{
			get { return _cTHProtocolCycleItem; }
			set { SetSingleRelatedEntityNavigator(value, "CTHProtocolCycleItem"); }
		}
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace SStorm.CTH.DAL
{
	public enum CTHCycleDrugFieldIndex
	{
		///<summary>CycleID. </summary>
		CycleID,
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
	/// <summary>Implements the relations factory for the entity: CTHCycleDrug. </summary>
	public partial class CTHCycleDrugRelations: RelationFactory
	{

		/// <summary>Returns a new IEntityRelation object, between CTHCycleDrugEntity and CTHDrugEntity over the m:1 relation they have, using the relation between the fields: CTHCycleDrug.DrugID - CTHDrug.ID</summary>
		public virtual IEntityRelation CTHDrugEntityUsingDrugID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHDrugItem", false, new[] { CTHDrugFields.ID, CTHCycleDrugFields.DrugID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHCycleDrugEntity and CTHProtocolCycleEntity over the m:1 relation they have, using the relation between the fields: CTHCycleDrug.CycleID - CTHProtocolCycle.ID</summary>
		public virtual IEntityRelation CTHProtocolCycleEntityUsingCycleID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHProtocolCycleItem", false, new[] { CTHProtocolCycleFields.ID, CTHCycleDrugFields.CycleID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCTHCycleDrugRelations
	{
		internal static readonly IEntityRelation CTHDrugEntityUsingDrugIDStatic = new CTHCycleDrugRelations().CTHDrugEntityUsingDrugID;
		internal static readonly IEntityRelation CTHProtocolCycleEntityUsingCycleIDStatic = new CTHCycleDrugRelations().CTHProtocolCycleEntityUsingCycleID;

		/// <summary>CTor</summary>
		static StaticCTHCycleDrugRelations() { }
	}
}