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

	/// <summary>Entity class which represents the entity 'CTHLabDetailCondition'.<br/><br/></summary>
	[Serializable]
	public partial class CTHLabDetailConditionEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private CTHLabDetailEntity _cTHLabDetailItem;
		private CTHOperatorEntity _cTHOperatorItem;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static CTHLabDetailConditionEntityStaticMetaData _staticMetaData = new CTHLabDetailConditionEntityStaticMetaData();
		private static CTHLabDetailConditionRelations _relationsFactory = new CTHLabDetailConditionRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CTHLabDetailItem</summary>
			public static readonly string CTHLabDetailItem = "CTHLabDetailItem";
			/// <summary>Member name CTHOperatorItem</summary>
			public static readonly string CTHOperatorItem = "CTHOperatorItem";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class CTHLabDetailConditionEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public CTHLabDetailConditionEntityStaticMetaData()
			{
				SetEntityCoreInfo("CTHLabDetailConditionEntity", InheritanceHierarchyType.None, false, (int)SStorm.CTH.DAL.EntityType.CTHLabDetailConditionEntity, typeof(CTHLabDetailConditionEntity), typeof(CTHLabDetailConditionEntityFactory), false);
				AddNavigatorMetaData<CTHLabDetailConditionEntity, CTHLabDetailEntity>("CTHLabDetailItem", "CTHLabDetailConditionCollection", (a, b) => a._cTHLabDetailItem = b, a => a._cTHLabDetailItem, (a, b) => a.CTHLabDetailItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHLabDetailConditionRelations.CTHLabDetailEntityUsingLabDetailIDStatic, ()=>new CTHLabDetailConditionRelations().CTHLabDetailEntityUsingLabDetailID, null, new int[] { (int)CTHLabDetailConditionFieldIndex.LabDetailID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHLabDetailEntity);
				AddNavigatorMetaData<CTHLabDetailConditionEntity, CTHOperatorEntity>("CTHOperatorItem", "CTHLabDetailConditionCollection", (a, b) => a._cTHOperatorItem = b, a => a._cTHOperatorItem, (a, b) => a.CTHOperatorItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHLabDetailConditionRelations.CTHOperatorEntityUsingOpertorIDStatic, ()=>new CTHLabDetailConditionRelations().CTHOperatorEntityUsingOpertorID, null, new int[] { (int)CTHLabDetailConditionFieldIndex.OpertorID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHOperatorEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static CTHLabDetailConditionEntity()
		{
		}

		/// <summary> CTor</summary>
		public CTHLabDetailConditionEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CTHLabDetailConditionEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CTHLabDetailConditionEntity</param>
		public CTHLabDetailConditionEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHLabDetailCondition which data should be fetched into this CTHLabDetailCondition object</param>
		public CTHLabDetailConditionEntity(System.Int32 iD) : this(iD, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHLabDetailCondition which data should be fetched into this CTHLabDetailCondition object</param>
		/// <param name="validator">The custom validator object for this CTHLabDetailConditionEntity</param>
		public CTHLabDetailConditionEntity(System.Int32 iD, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CTHLabDetailConditionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHLabDetail' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHLabDetailItem() { return CreateRelationInfoForNavigator("CTHLabDetailItem"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHOperator' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHOperatorItem() { return CreateRelationInfoForNavigator("CTHOperatorItem"); }
		
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
		/// <param name="validator">The validator object for this CTHLabDetailConditionEntity</param>
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
		public static CTHLabDetailConditionRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHLabDetail' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHLabDetailItem { get { return _staticMetaData.GetPrefetchPathElement("CTHLabDetailItem", CommonEntityBase.CreateEntityCollection<CTHLabDetailEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHOperator' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHOperatorItem { get { return _staticMetaData.GetPrefetchPathElement("CTHOperatorItem", CommonEntityBase.CreateEntityCollection<CTHOperatorEntity>()); } }

		/// <summary>The ArCondition property of the Entity CTHLabDetailCondition<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHLabDetailCondition"."ArCondition".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ArCondition
		{
			get { return (System.String)GetValue((int)CTHLabDetailConditionFieldIndex.ArCondition, true); }
			set	{ SetValue((int)CTHLabDetailConditionFieldIndex.ArCondition, value); }
		}

		/// <summary>The ArMessage property of the Entity CTHLabDetailCondition<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHLabDetailCondition"."ArMessage".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ArMessage
		{
			get { return (System.String)GetValue((int)CTHLabDetailConditionFieldIndex.ArMessage, true); }
			set	{ SetValue((int)CTHLabDetailConditionFieldIndex.ArMessage, value); }
		}

		/// <summary>The Condition property of the Entity CTHLabDetailCondition<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHLabDetailCondition"."Condition".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Condition
		{
			get { return (System.String)GetValue((int)CTHLabDetailConditionFieldIndex.Condition, true); }
			set	{ SetValue((int)CTHLabDetailConditionFieldIndex.Condition, value); }
		}

		/// <summary>The ID property of the Entity CTHLabDetailCondition<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHLabDetailCondition"."ID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)CTHLabDetailConditionFieldIndex.ID, true); }
			set { SetValue((int)CTHLabDetailConditionFieldIndex.ID, value); }		}

		/// <summary>The LabDetailID property of the Entity CTHLabDetailCondition<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHLabDetailCondition"."LabDetailID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> LabDetailID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHLabDetailConditionFieldIndex.LabDetailID, false); }
			set	{ SetValue((int)CTHLabDetailConditionFieldIndex.LabDetailID, value); }
		}

		/// <summary>The Message property of the Entity CTHLabDetailCondition<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHLabDetailCondition"."Message".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Message
		{
			get { return (System.String)GetValue((int)CTHLabDetailConditionFieldIndex.Message, true); }
			set	{ SetValue((int)CTHLabDetailConditionFieldIndex.Message, value); }
		}

		/// <summary>The Number property of the Entity CTHLabDetailCondition<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHLabDetailCondition"."Number".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> Number
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHLabDetailConditionFieldIndex.Number, false); }
			set	{ SetValue((int)CTHLabDetailConditionFieldIndex.Number, value); }
		}

		/// <summary>The OpertorID property of the Entity CTHLabDetailCondition<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHLabDetailCondition"."OpertorID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> OpertorID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHLabDetailConditionFieldIndex.OpertorID, false); }
			set	{ SetValue((int)CTHLabDetailConditionFieldIndex.OpertorID, value); }
		}

		/// <summary>Gets / sets related entity of type 'CTHLabDetailEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHLabDetailEntity CTHLabDetailItem
		{
			get { return _cTHLabDetailItem; }
			set { SetSingleRelatedEntityNavigator(value, "CTHLabDetailItem"); }
		}

		/// <summary>Gets / sets related entity of type 'CTHOperatorEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHOperatorEntity CTHOperatorItem
		{
			get { return _cTHOperatorItem; }
			set { SetSingleRelatedEntityNavigator(value, "CTHOperatorItem"); }
		}
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace SStorm.CTH.DAL
{
	public enum CTHLabDetailConditionFieldIndex
	{
		///<summary>ArCondition. </summary>
		ArCondition,
		///<summary>ArMessage. </summary>
		ArMessage,
		///<summary>Condition. </summary>
		Condition,
		///<summary>ID. </summary>
		ID,
		///<summary>LabDetailID. </summary>
		LabDetailID,
		///<summary>Message. </summary>
		Message,
		///<summary>Number. </summary>
		Number,
		///<summary>OpertorID. </summary>
		OpertorID,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace SStorm.CTH.DAL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: CTHLabDetailCondition. </summary>
	public partial class CTHLabDetailConditionRelations: RelationFactory
	{

		/// <summary>Returns a new IEntityRelation object, between CTHLabDetailConditionEntity and CTHLabDetailEntity over the m:1 relation they have, using the relation between the fields: CTHLabDetailCondition.LabDetailID - CTHLabDetail.ID</summary>
		public virtual IEntityRelation CTHLabDetailEntityUsingLabDetailID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHLabDetailItem", false, new[] { CTHLabDetailFields.ID, CTHLabDetailConditionFields.LabDetailID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHLabDetailConditionEntity and CTHOperatorEntity over the m:1 relation they have, using the relation between the fields: CTHLabDetailCondition.OpertorID - CTHOperator.ID</summary>
		public virtual IEntityRelation CTHOperatorEntityUsingOpertorID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHOperatorItem", false, new[] { CTHOperatorFields.ID, CTHLabDetailConditionFields.OpertorID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCTHLabDetailConditionRelations
	{
		internal static readonly IEntityRelation CTHLabDetailEntityUsingLabDetailIDStatic = new CTHLabDetailConditionRelations().CTHLabDetailEntityUsingLabDetailID;
		internal static readonly IEntityRelation CTHOperatorEntityUsingOpertorIDStatic = new CTHLabDetailConditionRelations().CTHOperatorEntityUsingOpertorID;

		/// <summary>CTor</summary>
		static StaticCTHLabDetailConditionRelations() { }
	}
}
