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

	/// <summary>Entity class which represents the entity 'CTHDrugAttachment'.<br/><br/></summary>
	[Serializable]
	public partial class CTHDrugAttachmentEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private CTHDrugEntity _cTHDrugItem;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static CTHDrugAttachmentEntityStaticMetaData _staticMetaData = new CTHDrugAttachmentEntityStaticMetaData();
		private static CTHDrugAttachmentRelations _relationsFactory = new CTHDrugAttachmentRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CTHDrugItem</summary>
			public static readonly string CTHDrugItem = "CTHDrugItem";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class CTHDrugAttachmentEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public CTHDrugAttachmentEntityStaticMetaData()
			{
				SetEntityCoreInfo("CTHDrugAttachmentEntity", InheritanceHierarchyType.None, false, (int)SStorm.CTH.DAL.EntityType.CTHDrugAttachmentEntity, typeof(CTHDrugAttachmentEntity), typeof(CTHDrugAttachmentEntityFactory), false);
				AddNavigatorMetaData<CTHDrugAttachmentEntity, CTHDrugEntity>("CTHDrugItem", "CTHDrugAttachmentCollection", (a, b) => a._cTHDrugItem = b, a => a._cTHDrugItem, (a, b) => a.CTHDrugItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHDrugAttachmentRelations.CTHDrugEntityUsingDrugIDStatic, ()=>new CTHDrugAttachmentRelations().CTHDrugEntityUsingDrugID, null, new int[] { (int)CTHDrugAttachmentFieldIndex.DrugID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHDrugEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static CTHDrugAttachmentEntity()
		{
		}

		/// <summary> CTor</summary>
		public CTHDrugAttachmentEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CTHDrugAttachmentEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CTHDrugAttachmentEntity</param>
		public CTHDrugAttachmentEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHDrugAttachment which data should be fetched into this CTHDrugAttachment object</param>
		public CTHDrugAttachmentEntity(System.Int32 iD) : this(iD, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHDrugAttachment which data should be fetched into this CTHDrugAttachment object</param>
		/// <param name="validator">The custom validator object for this CTHDrugAttachmentEntity</param>
		public CTHDrugAttachmentEntity(System.Int32 iD, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CTHDrugAttachmentEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

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
		/// <param name="validator">The validator object for this CTHDrugAttachmentEntity</param>
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
		public static CTHDrugAttachmentRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHDrug' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHDrugItem { get { return _staticMetaData.GetPrefetchPathElement("CTHDrugItem", CommonEntityBase.CreateEntityCollection<CTHDrugEntity>()); } }

		/// <summary>The Attachment property of the Entity CTHDrugAttachment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHDrugAttachment"."Attachment".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Attachment
		{
			get { return (System.String)GetValue((int)CTHDrugAttachmentFieldIndex.Attachment, true); }
			set	{ SetValue((int)CTHDrugAttachmentFieldIndex.Attachment, value); }
		}

		/// <summary>The DrugID property of the Entity CTHDrugAttachment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHDrugAttachment"."DrugID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> DrugID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHDrugAttachmentFieldIndex.DrugID, false); }
			set	{ SetValue((int)CTHDrugAttachmentFieldIndex.DrugID, value); }
		}

		/// <summary>The ID property of the Entity CTHDrugAttachment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHDrugAttachment"."ID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)CTHDrugAttachmentFieldIndex.ID, true); }
			set { SetValue((int)CTHDrugAttachmentFieldIndex.ID, value); }		}

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
	public enum CTHDrugAttachmentFieldIndex
	{
		///<summary>Attachment. </summary>
		Attachment,
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
	/// <summary>Implements the relations factory for the entity: CTHDrugAttachment. </summary>
	public partial class CTHDrugAttachmentRelations: RelationFactory
	{

		/// <summary>Returns a new IEntityRelation object, between CTHDrugAttachmentEntity and CTHDrugEntity over the m:1 relation they have, using the relation between the fields: CTHDrugAttachment.DrugID - CTHDrug.ID</summary>
		public virtual IEntityRelation CTHDrugEntityUsingDrugID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHDrugItem", false, new[] { CTHDrugFields.ID, CTHDrugAttachmentFields.DrugID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCTHDrugAttachmentRelations
	{
		internal static readonly IEntityRelation CTHDrugEntityUsingDrugIDStatic = new CTHDrugAttachmentRelations().CTHDrugEntityUsingDrugID;

		/// <summary>CTor</summary>
		static StaticCTHDrugAttachmentRelations() { }
	}
}