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

	/// <summary>Entity class which represents the entity 'CTHRole'.<br/><br/></summary>
	[Serializable]
	public partial class CTHRoleEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		private EntityCollection<CTHRolePermissionEntity> _cTHRolePermissionCollection;
		private EntityCollection<CTHUserRoleEntity> _cTHUserRoleCollection;
		private EntityCollection<CTHPermissionEntity> _cTHPermissionCollectionViaCTHRolePermission;
		private EntityCollection<CTHUserEntity> _cTHUserCollectionViaCTHUserRole;
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static CTHRoleEntityStaticMetaData _staticMetaData = new CTHRoleEntityStaticMetaData();
		private static CTHRoleRelations _relationsFactory = new CTHRoleRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CTHRolePermissionCollection</summary>
			public static readonly string CTHRolePermissionCollection = "CTHRolePermissionCollection";
			/// <summary>Member name CTHUserRoleCollection</summary>
			public static readonly string CTHUserRoleCollection = "CTHUserRoleCollection";
			/// <summary>Member name CTHPermissionCollectionViaCTHRolePermission</summary>
			public static readonly string CTHPermissionCollectionViaCTHRolePermission = "CTHPermissionCollectionViaCTHRolePermission";
			/// <summary>Member name CTHUserCollectionViaCTHUserRole</summary>
			public static readonly string CTHUserCollectionViaCTHUserRole = "CTHUserCollectionViaCTHUserRole";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class CTHRoleEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public CTHRoleEntityStaticMetaData()
			{
				SetEntityCoreInfo("CTHRoleEntity", InheritanceHierarchyType.None, false, (int)SStorm.CTH.DAL.EntityType.CTHRoleEntity, typeof(CTHRoleEntity), typeof(CTHRoleEntityFactory), false);
				AddNavigatorMetaData<CTHRoleEntity, EntityCollection<CTHRolePermissionEntity>>("CTHRolePermissionCollection", a => a._cTHRolePermissionCollection, (a, b) => a._cTHRolePermissionCollection = b, a => a.CTHRolePermissionCollection, () => new CTHRoleRelations().CTHRolePermissionEntityUsingRoleID, typeof(CTHRolePermissionEntity), (int)SStorm.CTH.DAL.EntityType.CTHRolePermissionEntity);
				AddNavigatorMetaData<CTHRoleEntity, EntityCollection<CTHUserRoleEntity>>("CTHUserRoleCollection", a => a._cTHUserRoleCollection, (a, b) => a._cTHUserRoleCollection = b, a => a.CTHUserRoleCollection, () => new CTHRoleRelations().CTHUserRoleEntityUsingRoleID, typeof(CTHUserRoleEntity), (int)SStorm.CTH.DAL.EntityType.CTHUserRoleEntity);
				AddNavigatorMetaData<CTHRoleEntity, EntityCollection<CTHPermissionEntity>>("CTHPermissionCollectionViaCTHRolePermission", a => a._cTHPermissionCollectionViaCTHRolePermission, (a, b) => a._cTHPermissionCollectionViaCTHRolePermission = b, a => a.CTHPermissionCollectionViaCTHRolePermission, () => new CTHRoleRelations().CTHRolePermissionEntityUsingRoleID, () => new CTHRolePermissionRelations().CTHPermissionEntityUsingPermissionID, "CTHRoleEntity__", "CTHRolePermission_", typeof(CTHPermissionEntity), (int)SStorm.CTH.DAL.EntityType.CTHPermissionEntity);
				AddNavigatorMetaData<CTHRoleEntity, EntityCollection<CTHUserEntity>>("CTHUserCollectionViaCTHUserRole", a => a._cTHUserCollectionViaCTHUserRole, (a, b) => a._cTHUserCollectionViaCTHUserRole = b, a => a.CTHUserCollectionViaCTHUserRole, () => new CTHRoleRelations().CTHUserRoleEntityUsingRoleID, () => new CTHUserRoleRelations().CTHUserEntityUsingUserID, "CTHRoleEntity__", "CTHUserRole_", typeof(CTHUserEntity), (int)SStorm.CTH.DAL.EntityType.CTHUserEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static CTHRoleEntity()
		{
		}

		/// <summary> CTor</summary>
		public CTHRoleEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CTHRoleEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CTHRoleEntity</param>
		public CTHRoleEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHRole which data should be fetched into this CTHRole object</param>
		public CTHRoleEntity(System.Int32 iD) : this(iD, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for CTHRole which data should be fetched into this CTHRole object</param>
		/// <param name="validator">The custom validator object for this CTHRoleEntity</param>
		public CTHRoleEntity(System.Int32 iD, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CTHRoleEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHRolePermission' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHRolePermissionCollection() { return CreateRelationInfoForNavigator("CTHRolePermissionCollection"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHUserRole' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHUserRoleCollection() { return CreateRelationInfoForNavigator("CTHUserRoleCollection"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHPermission' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHPermissionCollectionViaCTHRolePermission() { return CreateRelationInfoForNavigator("CTHPermissionCollectionViaCTHRolePermission"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'CTHUser' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCTHUserCollectionViaCTHUserRole() { return CreateRelationInfoForNavigator("CTHUserCollectionViaCTHUserRole"); }
		
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
		/// <param name="validator">The validator object for this CTHRoleEntity</param>
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
		public static CTHRoleRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHRolePermission' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHRolePermissionCollection { get { return _staticMetaData.GetPrefetchPathElement("CTHRolePermissionCollection", CommonEntityBase.CreateEntityCollection<CTHRolePermissionEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHUserRole' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHUserRoleCollection { get { return _staticMetaData.GetPrefetchPathElement("CTHUserRoleCollection", CommonEntityBase.CreateEntityCollection<CTHUserRoleEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHPermission' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHPermissionCollectionViaCTHRolePermission { get { return _staticMetaData.GetPrefetchPathElement("CTHPermissionCollectionViaCTHRolePermission", CommonEntityBase.CreateEntityCollection<CTHPermissionEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CTHUser' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCTHUserCollectionViaCTHUserRole { get { return _staticMetaData.GetPrefetchPathElement("CTHUserCollectionViaCTHUserRole", CommonEntityBase.CreateEntityCollection<CTHUserEntity>()); } }

		/// <summary>The ArRoleNmae property of the Entity CTHRole<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHRole"."ArRoleNmae".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ArRoleNmae
		{
			get { return (System.String)GetValue((int)CTHRoleFieldIndex.ArRoleNmae, true); }
			set	{ SetValue((int)CTHRoleFieldIndex.ArRoleNmae, value); }
		}

		/// <summary>The ID property of the Entity CTHRole<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHRole"."ID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)CTHRoleFieldIndex.ID, true); }
			set { SetValue((int)CTHRoleFieldIndex.ID, value); }		}

		/// <summary>The RoleNmae property of the Entity CTHRole<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CTHRole"."RoleNmae".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String RoleNmae
		{
			get { return (System.String)GetValue((int)CTHRoleFieldIndex.RoleNmae, true); }
			set	{ SetValue((int)CTHRoleFieldIndex.RoleNmae, value); }
		}

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHRolePermissionEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHRolePermissionEntity))]
		public virtual EntityCollection<CTHRolePermissionEntity> CTHRolePermissionCollection { get { return GetOrCreateEntityCollection<CTHRolePermissionEntity, CTHRolePermissionEntityFactory>("CTHRoleItem", true, false, ref _cTHRolePermissionCollection); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHUserRoleEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHUserRoleEntity))]
		public virtual EntityCollection<CTHUserRoleEntity> CTHUserRoleCollection { get { return GetOrCreateEntityCollection<CTHUserRoleEntity, CTHUserRoleEntityFactory>("CTHRoleItem", true, false, ref _cTHUserRoleCollection); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHPermissionEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHPermissionEntity))]
		public virtual EntityCollection<CTHPermissionEntity> CTHPermissionCollectionViaCTHRolePermission { get { return GetOrCreateEntityCollection<CTHPermissionEntity, CTHPermissionEntityFactory>("CTHRoleCollectionViaCTHRolePermission", false, true, ref _cTHPermissionCollectionViaCTHRolePermission); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'CTHUserEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(CTHUserEntity))]
		public virtual EntityCollection<CTHUserEntity> CTHUserCollectionViaCTHUserRole { get { return GetOrCreateEntityCollection<CTHUserEntity, CTHUserEntityFactory>("CTHRoleCollectionViaCTHUserRole", false, true, ref _cTHUserCollectionViaCTHUserRole); } }
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace SStorm.CTH.DAL
{
	public enum CTHRoleFieldIndex
	{
		///<summary>ArRoleNmae. </summary>
		ArRoleNmae,
		///<summary>ID. </summary>
		ID,
		///<summary>RoleNmae. </summary>
		RoleNmae,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace SStorm.CTH.DAL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: CTHRole. </summary>
	public partial class CTHRoleRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between CTHRoleEntity and CTHRolePermissionEntity over the 1:n relation they have, using the relation between the fields: CTHRole.ID - CTHRolePermission.RoleID</summary>
		public virtual IEntityRelation CTHRolePermissionEntityUsingRoleID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "CTHRolePermissionCollection", true, new[] { CTHRoleFields.ID, CTHRolePermissionFields.RoleID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between CTHRoleEntity and CTHUserRoleEntity over the 1:n relation they have, using the relation between the fields: CTHRole.ID - CTHUserRole.RoleID</summary>
		public virtual IEntityRelation CTHUserRoleEntityUsingRoleID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "CTHUserRoleCollection", true, new[] { CTHRoleFields.ID, CTHUserRoleFields.RoleID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCTHRoleRelations
	{
		internal static readonly IEntityRelation CTHRolePermissionEntityUsingRoleIDStatic = new CTHRoleRelations().CTHRolePermissionEntityUsingRoleID;
		internal static readonly IEntityRelation CTHUserRoleEntityUsingRoleIDStatic = new CTHRoleRelations().CTHUserRoleEntityUsingRoleID;

		/// <summary>CTor</summary>
		static StaticCTHRoleRelations() { }
	}
}
