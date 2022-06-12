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

	/// <summary>Entity class which represents the entity 'CTHTNMStagingMatrix'.<br/><br/></summary>
	[Serializable]
	public partial class CTHTNMStagingMatrixEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private CTHCancerTypeEntity _cTHCancerTypeItem;
		private CTHStagingEntity _cTHStagingItem;
		private CTHTNMStagingEntity _cTHTNMStagingItem;
		private CTHTNMStagingEntity _cTHTNMStagingItem1;
		private CTHTNMStagingEntity _cTHTNMStagingItem2;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static CTHTNMStagingMatrixEntityStaticMetaData _staticMetaData = new CTHTNMStagingMatrixEntityStaticMetaData();
		private static CTHTNMStagingMatrixRelations _relationsFactory = new CTHTNMStagingMatrixRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CTHCancerTypeItem</summary>
			public static readonly string CTHCancerTypeItem = "CTHCancerTypeItem";
			/// <summary>Member name CTHStagingItem</summary>
			public static readonly string CTHStagingItem = "CTHStagingItem";
			/// <summary>Member name CTHTNMStagingItem</summary>
			public static readonly string CTHTNMStagingItem = "CTHTNMStagingItem";
			/// <summary>Member name CTHTNMStagingItem1</summary>
			public static readonly string CTHTNMStagingItem1 = "CTHTNMStagingItem1";
			/// <summary>Member name CTHTNMStagingItem2</summary>
			public static readonly string CTHTNMStagingItem2 = "CTHTNMStagingItem2";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class CTHTNMStagingMatrixEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public CTHTNMStagingMatrixEntityStaticMetaData()
			{
				SetEntityCoreInfo("CTHTNMStagingMatrixEntity", InheritanceHierarchyType.None, false, (int)SStorm.CTH.DAL.EntityType.CTHTNMStagingMatrixEntity, typeof(CTHTNMStagingMatrixEntity), typeof(CTHTNMStagingMatrixEntityFactory), false);
				AddNavigatorMetaData<CTHTNMStagingMatrixEntity, CTHCancerTypeEntity>("CTHCancerTypeItem", "CTHTNMStagingMatrixCollection", (a, b) => a._cTHCancerTypeItem = b, a => a._cTHCancerTypeItem, (a, b) => a.CTHCancerTypeItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHTNMStagingMatrixRelations.CTHCancerTypeEntityUsingCancerTypeIDStatic, ()=>new CTHTNMStagingMatrixRelations().CTHCancerTypeEntityUsingCancerTypeID, null, new int[] { (int)CTHTNMStagingMatrixFieldIndex.CancerTypeID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHCancerTypeEntity);
				AddNavigatorMetaData<CTHTNMStagingMatrixEntity, CTHStagingEntity>("CTHStagingItem", "CTHTNMStagingMatrixCollection", (a, b) => a._cTHStagingItem = b, a => a._cTHStagingItem, (a, b) => a.CTHStagingItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHTNMStagingMatrixRelations.CTHStagingEntityUsingStageIDStatic, ()=>new CTHTNMStagingMatrixRelations().CTHStagingEntityUsingStageID, null, new int[] { (int)CTHTNMStagingMatrixFieldIndex.StageID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHStagingEntity);
				AddNavigatorMetaData<CTHTNMStagingMatrixEntity, CTHTNMStagingEntity>("CTHTNMStagingItem", "CTHTNMStagingMatrixCollection", (a, b) => a._cTHTNMStagingItem = b, a => a._cTHTNMStagingItem, (a, b) => a.CTHTNMStagingItem = b, SStorm.CTH.DAL.RelationClasses.StaticCTHTNMStagingMatrixRelations.CTHTNMStagingEntityUsingMIDStatic, ()=>new CTHTNMStagingMatrixRelations().CTHTNMStagingEntityUsingMID, null, new int[] { (int)CTHTNMStagingMatrixFieldIndex.MID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHTNMStagingEntity);
				AddNavigatorMetaData<CTHTNMStagingMatrixEntity, CTHTNMStagingEntity>("CTHTNMStagingItem1", "CTHTNMStagingMatrixCollection1", (a, b) => a._cTHTNMStagingItem1 = b, a => a._cTHTNMStagingItem1, (a, b) => a.CTHTNMStagingItem1 = b, SStorm.CTH.DAL.RelationClasses.StaticCTHTNMStagingMatrixRelations.CTHTNMStagingEntityUsingNIDStatic, ()=>new CTHTNMStagingMatrixRelations().CTHTNMStagingEntityUsingNID, null, new int[] { (int)CTHTNMStagingMatrixFieldIndex.NID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHTNMStagingEntity);
				AddNavigatorMetaData<CTHTNMStagingMatrixEntity, CTHTNMStagingEntity>("CTHTNMStagingItem2", "CTHTNMStagingMatrixCollection2", (a, b) => a._cTHTNMStagingItem2 = b, a => a._cTHTNMStagingItem2, (a, b) => a.CTHTNMStagingItem2 = b, SStorm.CTH.DAL.RelationClasses.StaticCTHTNMStagingMatrixRelations.CTHTNMStagingEntityUsingTIDStatic, ()=>new CTHTNMStagingMatrixRelations().CTHTNMStagingEntityUsingTID, null, new int[] { (int)CTHTNMStagingMatrixFieldIndex.TID }, null, true, (int)SStorm.CTH.DAL.EntityType.CTHTNMStagingEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static CTHTNMStagingMatrixEntity()
		{
		}

		/// <summary> CTor</summary>
		public CTHTNMStagingMatrixEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CTHTNMStagingMatrixEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CTHTNMStagingMatrixEntity</param>
		public CTHTNMStagingMatrixEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHTNMStagingMatrix which data should be fetched into this CTHTNMStagingMatrix object</param>
		public CTHTNMStagingMatrixEntity(System.Int32 iD) : this(iD, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHTNMStagingMatrix which data should be fetched into this CTHTNMStagingMatrix object</param>
		/// <param name="validator">The custom validator object for this CTHTNMStagingMatrixEntity</param>
		public CTHTNMStagingMatrixEntity(System.Int32 iD, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CTHTNMStagingMatrixEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHCancerType' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHCancerTypeItem() { return CreateRelationInfoForNavigator("CTHCancerTypeItem"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHStaging' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHStagingItem() { return CreateRelationInfoForNavigator("CTHStagingItem"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHTNMStaging' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHTNMStagingItem() { return CreateRelationInfoForNavigator("CTHTNMStagingItem"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHTNMStaging' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHTNMStagingItem1() { return CreateRelationInfoForNavigator("CTHTNMStagingItem1"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'CTHTNMStaging' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHTNMStagingItem2() { return CreateRelationInfoForNavigator("CTHTNMStagingItem2"); }
		
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
		/// <param name="validator">The validator object for this CTHTNMStagingMatrixEntity</param>
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
		public static CTHTNMStagingMatrixRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHCancerType' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHCancerTypeItem { get { return _staticMetaData.GetPrefetchPathElement("CTHCancerTypeItem", CommonEntityBase.CreateEntityCollection<CTHCancerTypeEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHStaging' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHStagingItem { get { return _staticMetaData.GetPrefetchPathElement("CTHStagingItem", CommonEntityBase.CreateEntityCollection<CTHStagingEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHTNMStaging' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHTNMStagingItem { get { return _staticMetaData.GetPrefetchPathElement("CTHTNMStagingItem", CommonEntityBase.CreateEntityCollection<CTHTNMStagingEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHTNMStaging' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHTNMStagingItem1 { get { return _staticMetaData.GetPrefetchPathElement("CTHTNMStagingItem1", CommonEntityBase.CreateEntityCollection<CTHTNMStagingEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHTNMStaging' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHTNMStagingItem2 { get { return _staticMetaData.GetPrefetchPathElement("CTHTNMStagingItem2", CommonEntityBase.CreateEntityCollection<CTHTNMStagingEntity>()); } }

		/// <summary>The CancerTypeID property of the Entity CTHTNMStagingMatrix<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHTNMStagingMatrix"."CancerTypeID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> CancerTypeID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHTNMStagingMatrixFieldIndex.CancerTypeID, false); }
			set	{ SetValue((int)CTHTNMStagingMatrixFieldIndex.CancerTypeID, value); }
		}

		/// <summary>The ID property of the Entity CTHTNMStagingMatrix<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHTNMStagingMatrix"."ID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)CTHTNMStagingMatrixFieldIndex.ID, true); }
			set { SetValue((int)CTHTNMStagingMatrixFieldIndex.ID, value); }		}

		/// <summary>The MID property of the Entity CTHTNMStagingMatrix<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHTNMStagingMatrix"."MID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> MID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHTNMStagingMatrixFieldIndex.MID, false); }
			set	{ SetValue((int)CTHTNMStagingMatrixFieldIndex.MID, value); }
		}

		/// <summary>The NID property of the Entity CTHTNMStagingMatrix<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHTNMStagingMatrix"."NID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> NID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHTNMStagingMatrixFieldIndex.NID, false); }
			set	{ SetValue((int)CTHTNMStagingMatrixFieldIndex.NID, value); }
		}

		/// <summary>The StageID property of the Entity CTHTNMStagingMatrix<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHTNMStagingMatrix"."StageID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> StageID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHTNMStagingMatrixFieldIndex.StageID, false); }
			set	{ SetValue((int)CTHTNMStagingMatrixFieldIndex.StageID, value); }
		}

		/// <summary>The TID property of the Entity CTHTNMStagingMatrix<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHTNMStagingMatrix"."TID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> TID
		{
			get { return (Nullable<System.Int32>)GetValue((int)CTHTNMStagingMatrixFieldIndex.TID, false); }
			set	{ SetValue((int)CTHTNMStagingMatrixFieldIndex.TID, value); }
		}

		/// <summary>Gets / sets related entity of type 'CTHCancerTypeEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHCancerTypeEntity CTHCancerTypeItem
		{
			get { return _cTHCancerTypeItem; }
			set { SetSingleRelatedEntityNavigator(value, "CTHCancerTypeItem"); }
		}

		/// <summary>Gets / sets related entity of type 'CTHStagingEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHStagingEntity CTHStagingItem
		{
			get { return _cTHStagingItem; }
			set { SetSingleRelatedEntityNavigator(value, "CTHStagingItem"); }
		}

		/// <summary>Gets / sets related entity of type 'CTHTNMStagingEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHTNMStagingEntity CTHTNMStagingItem
		{
			get { return _cTHTNMStagingItem; }
			set { SetSingleRelatedEntityNavigator(value, "CTHTNMStagingItem"); }
		}

		/// <summary>Gets / sets related entity of type 'CTHTNMStagingEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHTNMStagingEntity CTHTNMStagingItem1
		{
			get { return _cTHTNMStagingItem1; }
			set { SetSingleRelatedEntityNavigator(value, "CTHTNMStagingItem1"); }
		}

		/// <summary>Gets / sets related entity of type 'CTHTNMStagingEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual CTHTNMStagingEntity CTHTNMStagingItem2
		{
			get { return _cTHTNMStagingItem2; }
			set { SetSingleRelatedEntityNavigator(value, "CTHTNMStagingItem2"); }
		}
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace SStorm.CTH.DAL
{
	public enum CTHTNMStagingMatrixFieldIndex
	{
		///<summary>CancerTypeID. </summary>
		CancerTypeID,
		///<summary>ID. </summary>
		ID,
		///<summary>MID. </summary>
		MID,
		///<summary>NID. </summary>
		NID,
		///<summary>StageID. </summary>
		StageID,
		///<summary>TID. </summary>
		TID,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace SStorm.CTH.DAL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: CTHTNMStagingMatrix. </summary>
	public partial class CTHTNMStagingMatrixRelations: RelationFactory
	{

		/// <summary>Returns a new IEntityRelation object, between CTHTNMStagingMatrixEntity and CTHCancerTypeEntity over the m:1 relation they have, using the relation between the fields: CTHTNMStagingMatrix.CancerTypeID - CTHCancerType.ID</summary>
		public virtual IEntityRelation CTHCancerTypeEntityUsingCancerTypeID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHCancerTypeItem", false, new[] { CTHCancerTypeFields.ID, CTHTNMStagingMatrixFields.CancerTypeID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHTNMStagingMatrixEntity and CTHStagingEntity over the m:1 relation they have, using the relation between the fields: CTHTNMStagingMatrix.StageID - CTHStaging.ID</summary>
		public virtual IEntityRelation CTHStagingEntityUsingStageID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHStagingItem", false, new[] { CTHStagingFields.ID, CTHTNMStagingMatrixFields.StageID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHTNMStagingMatrixEntity and CTHTNMStagingEntity over the m:1 relation they have, using the relation between the fields: CTHTNMStagingMatrix.MID - CTHTNMStaging.ID</summary>
		public virtual IEntityRelation CTHTNMStagingEntityUsingMID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHTNMStagingItem", false, new[] { CTHTNMStagingFields.ID, CTHTNMStagingMatrixFields.MID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHTNMStagingMatrixEntity and CTHTNMStagingEntity over the m:1 relation they have, using the relation between the fields: CTHTNMStagingMatrix.NID - CTHTNMStaging.ID</summary>
		public virtual IEntityRelation CTHTNMStagingEntityUsingNID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHTNMStagingItem1", false, new[] { CTHTNMStagingFields.ID, CTHTNMStagingMatrixFields.NID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHTNMStagingMatrixEntity and CTHTNMStagingEntity over the m:1 relation they have, using the relation between the fields: CTHTNMStagingMatrix.TID - CTHTNMStaging.ID</summary>
		public virtual IEntityRelation CTHTNMStagingEntityUsingTID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "CTHTNMStagingItem2", false, new[] { CTHTNMStagingFields.ID, CTHTNMStagingMatrixFields.TID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCTHTNMStagingMatrixRelations
	{
		internal static readonly IEntityRelation CTHCancerTypeEntityUsingCancerTypeIDStatic = new CTHTNMStagingMatrixRelations().CTHCancerTypeEntityUsingCancerTypeID;
		internal static readonly IEntityRelation CTHStagingEntityUsingStageIDStatic = new CTHTNMStagingMatrixRelations().CTHStagingEntityUsingStageID;
		internal static readonly IEntityRelation CTHTNMStagingEntityUsingMIDStatic = new CTHTNMStagingMatrixRelations().CTHTNMStagingEntityUsingMID;
		internal static readonly IEntityRelation CTHTNMStagingEntityUsingNIDStatic = new CTHTNMStagingMatrixRelations().CTHTNMStagingEntityUsingNID;
		internal static readonly IEntityRelation CTHTNMStagingEntityUsingTIDStatic = new CTHTNMStagingMatrixRelations().CTHTNMStagingEntityUsingTID;

		/// <summary>CTor</summary>
		static StaticCTHTNMStagingMatrixRelations() { }
	}
}