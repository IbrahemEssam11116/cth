using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SStorm.CTH.BL.DataAccess
{
    public class SysUnitOfWork : UnitOfWork2
    {
        public int UserID { get; set; }
        private bool AllowAudit = true;

        public event EventHandler OnAfterEnititySaveCompleted;
        /// <summary>
        /// Reorder all commit orders 
        /// </summary>
        public SysUnitOfWork(int UserID)
        {
            this.UserID = UserID;
            this.CommitOrder[0] = UnitOfWorkBlockType.DeletesPerformedDirectly;
            this.CommitOrder[1] = UnitOfWorkBlockType.Deletes;
            this.CommitOrder[2] = UnitOfWorkBlockType.UpdatesPerformedDirectly;
            this.CommitOrder[3] = UnitOfWorkBlockType.Updates;
            this.CommitOrder[4] = UnitOfWorkBlockType.Inserts;

        }


        public override int Commit(IDataAccessAdapter adapterToUse, bool autoCommit)
        {
            return base.Commit(adapterToUse, autoCommit);
        }


        public int Commit()
        {

            var adapter = DataAccess.DataAdapterFactory.Create();
            adapter.OnAfterEnititySaveCompleted += adapter_OnAfterEnititySaveCompleted;
            return base.Commit(adapter);

        }

        void adapter_OnAfterEnititySaveCompleted(object sender, EventArgs e)
        {
            if (OnAfterEnititySaveCompleted != null)
                OnAfterEnititySaveCompleted(this, new EventArgs());
        }


        /// <summary>
        /// build aduit
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="auditType"></param>
        /// <param name="entity"></param>

        public static void SaveCollection(IEntityCollection2 collection, int UserID)
        {
            SysUnitOfWork uow = new SysUnitOfWork(UserID);
            uow.AddCollectionForSave(collection);
            uow.Commit();
        }
        public static void SaveEntity(IEntity2 Entity, int UserID)
        {
            SysUnitOfWork uow = new SysUnitOfWork(UserID);
            uow.AddForSave(Entity);
            uow.Commit();
        }

        public static void DeleteEntity(IEntity2 Entity, int UserID)
        {
            SysUnitOfWork uow = new SysUnitOfWork(UserID);
            uow.AddForDelete(Entity);
            uow.Commit();
        }

        public static void SaveEntity(IEntity2 Entity, PredicateExpression restriction, bool refetch, bool recursive, int UserID)
        {
            SysUnitOfWork uow = new SysUnitOfWork(UserID);
            uow.AddForSave(Entity, restriction, refetch, recursive);
            uow.Commit();
        }

        public void AddDeleteEntitiesDirectlyCall(Type entityType, EntityField2 field, object value)
        {
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(field == value);
            base.AddDeleteEntitiesDirectlyCall(entityType, filter);
        }


        public void AddUpdateEntitiesDirectlyCall(EntityField2 Uniqefield, object UniqeValue, IEntity2 EntityWithNewValue)
        {
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(Uniqefield == UniqeValue);
            base.AddUpdateEntitiesDirectlyCall(EntityWithNewValue, filter);
        }

        public void AddUpdateEntitiesDirectlyCall(EntityField2 Uniqefield, object UniqeValue, EntityField2 toUpdateField, object newValue, IEntity2 EntityWithNewValue)
        {
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(Uniqefield == UniqeValue);
            EntityWithNewValue.Fields[toUpdateField.Name].CurrentValue = newValue;
            base.AddUpdateEntitiesDirectlyCall(EntityWithNewValue, filter);
        }

        public void AddUpdateEntitiesDirectlyCall<T>(EntityField2 toUpdateField, object newValue, IPredicateExpression predicate) where T : IEntity2, new()
        {
            T t = new T();
            t.Fields[toUpdateField.Name].CurrentValue = newValue;
            base.AddUpdateEntitiesDirectlyCall(t, new RelationPredicateBucket(predicate));
        }

        public void AddUpdateEntitiesDirectlyCall<T>(EntityField2 Uniqefield, object UniqeValue, IExpression expressionToApply, EntityField2 toUpdateField) where T : IEntity2, new()
        {
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(Uniqefield == UniqeValue);
            T t = new T();
            t.Fields[toUpdateField.Name].ExpressionToApply = expressionToApply;
            base.AddUpdateEntitiesDirectlyCall(t, filter);
        }

        public void AddUpdateEntitiesDirectlyCall<T>(EntityField2 Uniqefield, object UniqeValue, EntityField2 toUpdateField, object newValue) where T : IEntity2, new()
        {
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(Uniqefield == UniqeValue);
            T t = new T();
            t.Fields[toUpdateField.Name].CurrentValue = newValue;
            base.AddUpdateEntitiesDirectlyCall(t, filter);
        }


        public void AddUpdateEntitiesDirectlyCall<T>(RelationPredicateBucket filter, EntityField2 toUpdateField, object newValue) where T : IEntity2, new()
        {
            T t = new T();
            t.Fields[toUpdateField.Name].CurrentValue = newValue;
            base.AddUpdateEntitiesDirectlyCall(t, filter);
        }


        public void AddDeleteEntitiesDirectlyCall<T>(RelationPredicateBucket filter) where T : IEntity2, new()
        {
            base.AddDeleteEntitiesDirectlyCall(typeof(T), filter);
        }

        public void AddDeleteEntitiesDirectlyCall<T>(EntityField2 field, object value) where T : IEntity2, new()
        {
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(field == value);
            base.AddDeleteEntitiesDirectlyCall(typeof(T), filter);
        }

        public static void DeleteEntitiesDirectly<T>(EntityField2 field, object value, int UserID) where T : IEntity2, new()
        {
            SysUnitOfWork uow = new SysUnitOfWork(UserID);
            uow.AddDeleteEntitiesDirectlyCall<T>(field, value);
            uow.Commit();
        }

        public bool AddForSave(IEntity2 entityToSave, bool refetch, bool recurse)
        {
            return AddForSave(entityToSave, null, refetch, recurse);
        }

        public override void AddCollectionForDelete(IEntityCollection2 collectionToDelete)
        {
            if (collectionToDelete == null) return;
            base.AddCollectionForDelete(collectionToDelete);
        }


        public override bool AddForSave(IEntity2 entityToSave, IPredicateExpression restriction, bool refetch, bool recurse)
        {
            return base.AddForSave(entityToSave, restriction, refetch, recurse);
        }

        public override bool AddForDelete(IEntity2 entityToDelete, IPredicateExpression restriction)
        {
            return base.AddForDelete(entityToDelete, restriction);
        }

    }
}
