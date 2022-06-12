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

	/// <summary>Entity class which represents the entity 'CTHChemoLab'.<br/><br/></summary>
	[Serializable]
	public partial class CTHChemoLabEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private CTHKimoSurveyEntity _cTHKimoSurveyItem;
		private CTHLabDetailEntity _cTHLabDetailItem;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static CTHChemoLabEntityStaticMetaData _staticMetaData = new CTHChemoLabEntityStaticMetaData();
		private static CTHChemoLabRelations _relationsFactory = new CTHChemoLabRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CTHKimoSurveyItem</summary>
			public static readonly string CTHKimoSurveyItem = "CTHKimoSurveyItem";
			/// <summary>Member name CTHLabDetailItem</summary>
			public static readonly string CTHLabDetailItem = "CTHLabDetailItem";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class CTHChemoLabEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public CTHChemoLabEntityStaticMetaData()
			{
				SetEntityCoreInfo("CTHChemoLabEntity", InheritanceHierarchyType.None, false, (int)SStorm.CTH.DAL.EntityType.CTHChemoLabEntity, typeof(CTHChemoLabEntity), typeof(CTHChemoLabEntityFactory), false);
				AddNavigatorMetaData<CTHChemoLabEntity, CTHKimoSurveyEntity>("CTHKimoSurveyItem", "CTHChemoLabCollection", (a, b) => a._cTHKimoSurveyItem = b, a => a._cTHKimoSurveyItem, (a, b) => a.CTHKimoSurveyItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHChemoLabRelations.CTHKimoSurveyEntityUsingChemoIDStatic, ()=>new CTHChemoLabRelations().CTHKimoSurveyEntityUsingChemoID, null, new int[] { (int)CTHChemoLabFieldIndex.ChemoID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHKimoSurveyEntity);
				AddNavigatorMetaData<CTHChemoLabEntity, CTHLabDetailEntity>("CTHLabDetailItem", "CTHChemoLabCollection", (a, b) => a._cTHLabDetailItem = b, a => a._cTHLabDetailItem, (a, b) => a.CTHLabDetailItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHChemoLabRelations.CTHLabDetailEntityUsingLabDetailsIDStatic, ()=>new CTHChemoLabRelations().CTHLabDetailEntityUsingLabDetailsID, null, new int[] { (int)CTHChemoLabFieldIndex.LabDetailsID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHLabDetailEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static CTHChemoLabEntity()
		{
		}

		/// <summary> CTor</summary>
		public CTHChemoLabEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CTHChemoLabEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CTHChemoLabEntity</param>
		public CTHChemoLabEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHChemoLab which data should be fetched into this CTHChemoLab object</param>
		public CTHChemoLabEntity(System.Int32 iD) : this(iD, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHChemoLab which data should be fetched into this CTHChemoLab object</param>
		/// <param name="validator">The custom validator object for this CTHChemoLabEntity</param>
		public CTHChemoLabEntity(System.Int32 iD, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CTHChemoLabEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHKimoSurvey' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHKimoSurveyItem() { return CreateRelationInfoForNavigator("CTHKimoSurveyItem"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHLabDetail' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHLabDetailItem() { return CreateRelationInfoForNavigator("CTHLabDetailItem"); }
		
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
		/// <param name="validator">The validator object for this CTHChemoLabEntity</param>
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
		public static CTHChemoLabRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHKimoSurvey' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHKimoSurveyItem { get { return _staticMetaData.GetPrefetchPathElement("CTHKimoSurveyItem", CommonEntityBase.CreateEntityCollection<CTHKimoSurveyEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHLabDetail' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHLabDetailItem { get { return _staticMetaData.GetPrefetchPathElement("CTHLabDetailItem", CommonEntityBase.CreateEntityCollection<CTHLabDetailEntity>()); } }

		/// <summary>The ArTextResult property of the Entity CTHChemoLab<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHChemoLab"."ArTextResult".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ArTextResult
		{
			get { return (System.String)GetValue((int)CTHChemoLabFieldIndex.ArTextResult, true); }
			set	{ SetValue((int)CTHChemoLabFieldIndex.ArTextResult, value); }
		}

		/// <summary>The Attachment property of the Entity CTHChemoLab<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHChemoLab"."Attachment".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Attachment
		{
			get { return (System.String)GetValue((int)CTHChemoLabFieldIndex.Attachment, true); }
			set	{ SetValue((int)CTHChemoLabFieldIndex.Attachment, value); }
		}

		/// <summary>The AttachmentResult property of the Entity CTHChemoLab<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHChemoLab"."AttachmentResult".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AttachmentResult
		{
			get { return (System.String)GetValue((int)CTHChemoLabFieldIndex.AttachmentResult, true); }
			set	{ SetValue((int)CTHChemoLabFieldIndex.AttachmentResult, value); }
		}

		/// <summary>The ChemoID property of the Entity CTHChemoLab<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHChemoLab"."ChemoID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ChemoID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHChemoLabFieldIndex.ChemoID, false); }
			set	{ SetValue((int)CTHChemoLabFieldIndex.ChemoID, value); }
		}

		/// <summary>The Date property of the Entity CTHChemoLab<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHChemoLab"."Date".<br/>Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> Date
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CTHChemoLabFieldIndex.Date, false); }
			set	{ SetValue((int)CTHChemoLabFieldIndex.Date, value); }
		}

		/// <summary>The ID property of the Entity CTHChemoLab<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHChemoLab"."ID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)CTHChemoLabFieldIndex.ID, true); }
			set { SetValue((int)CTHChemoLabFieldIndex.ID, value); }		}

		/// <summary>The LabDetailsID property of the Entity CTHChemoLab<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHChemoLab"."LabDetailsID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> LabDetailsID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHChemoLabFieldIndex.LabDetailsID, false); }
			set	{ SetValue((int)CTHChemoLabFieldIndex.LabDetailsID, value); }
		}

		/// <summary>The TextResult property of the Entity CTHChemoLab<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHChemoLab"."TextResult".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String TextResult
		{
			get { return (System.String)GetValue((int)CTHChemoLabFieldIndex.TextResult, true); }
			set	{ SetValue((int)CTHChemoLabFieldIndex.TextResult, value); }
		}

		/// <summary>Gets / sets related entity of type 'CTHKimoSurveyEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHKimoSurveyEntity CTHKimoSurveyItem
		{
			get { return _cTHKimoSurveyItem; }
			set { SetSingleRelatedEntityNavigator(value, "CTHKimoSurveyItem"); }
		}

		/// <summary>Gets / sets related entity of type 'CTHLabDetailEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHLabDetailEntity CTHLabDetailItem
		{
			get { return _cTHLabDetailItem; }
			set { SetSingleRelatedEntityNavigator(value, "CTHLabDetailItem"); }
		}
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace SStorm.CTH.DAL
{
	public enum CTHChemoLabFieldIndex
	{
		///<summary>ArTextResult. </summary>
		ArTextResult,
		///<summary>Attachment. </summary>
		Attachment,
		///<summary>AttachmentResult. </summary>
		AttachmentResult,
		///<summary>ChemoID. </summary>
		ChemoID,
		///<summary>Date. </summary>
		Date,
		///<summary>ID. </summary>
		ID,
		///<summary>LabDetailsID. </summary>
		LabDetailsID,
		///<summary>TextResult. </summary>
		TextResult,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace SStorm.CTH.DAL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: CTHChemoLab. </summary>
	public partial class CTHChemoLabRelations: RelationFactory
	{

		/// <summary>Returns a new IEntityRelation object, between CTHChemoLabEntity and CTHKimoSurveyEntity over the m:1 relation they have, using the relation between the fields: CTHChemoLab.ChemoID - CTHKimoSurvey.ID</summary>
		public virtual IEntityRelation CTHKimoSurveyEntityUsingChemoID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHKimoSurveyItem", false, new[] { CTHKimoSurveyFields.ID, CTHChemoLabFields.ChemoID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHChemoLabEntity and CTHLabDetailEntity over the m:1 relation they have, using the relation between the fields: CTHChemoLab.LabDetailsID - CTHLabDetail.ID</summary>
		public virtual IEntityRelation CTHLabDetailEntityUsingLabDetailsID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHLabDetailItem", false, new[] { CTHLabDetailFields.ID, CTHChemoLabFields.LabDetailsID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCTHChemoLabRelations
	{
		internal static readonly IEntityRelation CTHKimoSurveyEntityUsingChemoIDStatic = new CTHChemoLabRelations().CTHKimoSurveyEntityUsingChemoID;
		internal static readonly IEntityRelation CTHLabDetailEntityUsingLabDetailsIDStatic = new CTHChemoLabRelations().CTHLabDetailEntityUsingLabDetailsID;

		/// <summary>CTor</summary>
		static StaticCTHChemoLabRelations() { }
	}
}