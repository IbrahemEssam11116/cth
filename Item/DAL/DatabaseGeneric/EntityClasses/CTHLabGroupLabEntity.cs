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

	/// <summary>Entity class which represents the entity 'CTHLabGroupLab'.<br/><br/></summary>
	[Serializable]
	public partial class CTHLabGroupLabEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private CTHLabEntity _cTHLabItem;
		private CTHLabGroupEntity _cTHLabGroupItem;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static CTHLabGroupLabEntityStaticMetaData _staticMetaData = new CTHLabGroupLabEntityStaticMetaData();
		private static CTHLabGroupLabRelations _relationsFactory = new CTHLabGroupLabRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CTHLabItem</summary>
			public static readonly string CTHLabItem = "CTHLabItem";
			/// <summary>Member name CTHLabGroupItem</summary>
			public static readonly string CTHLabGroupItem = "CTHLabGroupItem";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class CTHLabGroupLabEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public CTHLabGroupLabEntityStaticMetaData()
			{
				SetEntityCoreInfo("CTHLabGroupLabEntity", InheritanceHierarchyType.None, false, (int)SStorm.CTH.DAL.EntityType.CTHLabGroupLabEntity, typeof(CTHLabGroupLabEntity), typeof(CTHLabGroupLabEntityFactory), false);
				AddNavigatorMetaData<CTHLabGroupLabEntity, CTHLabEntity>("CTHLabItem", "CTHLabGroupLabCollection", (a, b) => a._cTHLabItem = b, a => a._cTHLabItem, (a, b) => a.CTHLabItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHLabGroupLabRelations.CTHLabEntityUsingLabIDStatic, ()=>new CTHLabGroupLabRelations().CTHLabEntityUsingLabID, null, new int[] { (int)CTHLabGroupLabFieldIndex.LabID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHLabEntity);
				AddNavigatorMetaData<CTHLabGroupLabEntity, CTHLabGroupEntity>("CTHLabGroupItem", "CTHLabGroupLabCollection", (a, b) => a._cTHLabGroupItem = b, a => a._cTHLabGroupItem, (a, b) => a.CTHLabGroupItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHLabGroupLabRelations.CTHLabGroupEntityUsingLabGroupIDStatic, ()=>new CTHLabGroupLabRelations().CTHLabGroupEntityUsingLabGroupID, null, new int[] { (int)CTHLabGroupLabFieldIndex.LabGroupID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHLabGroupEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static CTHLabGroupLabEntity()
		{
		}

		/// <summary> CTor</summary>
		public CTHLabGroupLabEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CTHLabGroupLabEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CTHLabGroupLabEntity</param>
		public CTHLabGroupLabEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHLabGroupLab which data should be fetched into this CTHLabGroupLab object</param>
		public CTHLabGroupLabEntity(System.Int32 iD) : this(iD, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHLabGroupLab which data should be fetched into this CTHLabGroupLab object</param>
		/// <param name="validator">The custom validator object for this CTHLabGroupLabEntity</param>
		public CTHLabGroupLabEntity(System.Int32 iD, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CTHLabGroupLabEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHLab' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHLabItem() { return CreateRelationInfoForNavigator("CTHLabItem"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHLabGroup' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHLabGroupItem() { return CreateRelationInfoForNavigator("CTHLabGroupItem"); }
		
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
		/// <param name="validator">The validator object for this CTHLabGroupLabEntity</param>
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
		public static CTHLabGroupLabRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHLab' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHLabItem { get { return _staticMetaData.GetPrefetchPathElement("CTHLabItem", CommonEntityBase.CreateEntityCollection<CTHLabEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHLabGroup' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHLabGroupItem { get { return _staticMetaData.GetPrefetchPathElement("CTHLabGroupItem", CommonEntityBase.CreateEntityCollection<CTHLabGroupEntity>()); } }

		/// <summary>The ID property of the Entity CTHLabGroupLab<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHLabGroup_Lab"."ID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)CTHLabGroupLabFieldIndex.ID, true); }
			set { SetValue((int)CTHLabGroupLabFieldIndex.ID, value); }		}

		/// <summary>The LabGroupID property of the Entity CTHLabGroupLab<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHLabGroup_Lab"."LabGroupID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> LabGroupID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHLabGroupLabFieldIndex.LabGroupID, false); }
			set	{ SetValue((int)CTHLabGroupLabFieldIndex.LabGroupID, value); }
		}

		/// <summary>The LabID property of the Entity CTHLabGroupLab<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHLabGroup_Lab"."LabID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> LabID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHLabGroupLabFieldIndex.LabID, false); }
			set	{ SetValue((int)CTHLabGroupLabFieldIndex.LabID, value); }
		}

		/// <summary>Gets / sets related entity of type 'CTHLabEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHLabEntity CTHLabItem
		{
			get { return _cTHLabItem; }
			set { SetSingleRelatedEntityNavigator(value, "CTHLabItem"); }
		}

		/// <summary>Gets / sets related entity of type 'CTHLabGroupEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHLabGroupEntity CTHLabGroupItem
		{
			get { return _cTHLabGroupItem; }
			set { SetSingleRelatedEntityNavigator(value, "CTHLabGroupItem"); }
		}
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace SStorm.CTH.DAL
{
	public enum CTHLabGroupLabFieldIndex
	{
		///<summary>ID. </summary>
		ID,
		///<summary>LabGroupID. </summary>
		LabGroupID,
		///<summary>LabID. </summary>
		LabID,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace SStorm.CTH.DAL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: CTHLabGroupLab. </summary>
	public partial class CTHLabGroupLabRelations: RelationFactory
	{

		/// <summary>Returns a new IEntityRelation object, between CTHLabGroupLabEntity and CTHLabEntity over the m:1 relation they have, using the relation between the fields: CTHLabGroupLab.LabID - CTHLab.ID</summary>
		public virtual IEntityRelation CTHLabEntityUsingLabID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHLabItem", false, new[] { CTHLabFields.ID, CTHLabGroupLabFields.LabID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHLabGroupLabEntity and CTHLabGroupEntity over the m:1 relation they have, using the relation between the fields: CTHLabGroupLab.LabGroupID - CTHLabGroup.ID</summary>
		public virtual IEntityRelation CTHLabGroupEntityUsingLabGroupID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHLabGroupItem", false, new[] { CTHLabGroupFields.ID, CTHLabGroupLabFields.LabGroupID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCTHLabGroupLabRelations
	{
		internal static readonly IEntityRelation CTHLabEntityUsingLabIDStatic = new CTHLabGroupLabRelations().CTHLabEntityUsingLabID;
		internal static readonly IEntityRelation CTHLabGroupEntityUsingLabGroupIDStatic = new CTHLabGroupLabRelations().CTHLabGroupEntityUsingLabGroupID;

		/// <summary>CTor</summary>
		static StaticCTHLabGroupLabRelations() { }
	}
}
