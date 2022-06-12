using SD.LLBLGen.Pro.ORMSupportClasses;
using SStorm.CTH.BL.DataAccess;
using SStorm.CTH.BL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SStorm.CTH.BL
{
    public class DataBaseClassHelper
    {
        public static void SaveEntity(IEntity2 IntityToSave, bool refetch, bool recursive, int UserID, bool exclude = false, params IEntityField2[] changedFields)
        {

            if (changedFields != null && changedFields.Count() > 0)
            {
                if (!exclude)
                    IntityToSave.Fields.ForEach(x => x.IsChanged = x.IsChanged ? !changedFields.Any(f => f.Name.IsEqualTo(x.Name)) : false);
                else
                    IntityToSave.Fields.ForEach(x => x.IsChanged = x.IsChanged ? changedFields.Any(f => f.Name.IsEqualTo(x.Name)) : false);
            }

            SysUnitOfWork uow = new SysUnitOfWork(UserID);
            uow.AddForSave(IntityToSave, refetch, recursive);
            uow.Commit();
        }

        public static void Delete(IEntity2 IntityToDelete, int UserID)
        {
            SysUnitOfWork uow = new SysUnitOfWork(UserID);
            uow.AddForDelete(IntityToDelete);
            uow.Commit();
        }
        public static void DeleteEntitiesDirectly<T>(EntityField2 field, object value, int UserID) where T : IEntity2, new()
        {
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(field == value);
            SysUnitOfWork uow = new SysUnitOfWork(UserID);
            uow.AddDeleteEntitiesDirectlyCall<T>(filter);
            uow.Commit();
        }

        public static void DeleteEntitiesDirectly<T>(RelationPredicateBucket filter, int UserID) where T : IEntity2, new()
        {

            SysUnitOfWork uow = new SysUnitOfWork(UserID);
            uow.AddDeleteEntitiesDirectlyCall<T>(filter);
            uow.Commit();
        }
        public static void SaveCollection(IEntityCollection2 collectionToInsert, bool refetch, bool recursive, int UserID)
        {
            SysUnitOfWork uow = new SysUnitOfWork(UserID);
            uow.AddCollectionForSave(collectionToInsert, refetch, recursive);
            if (collectionToInsert.RemovedEntitiesTracker != null)
                uow.AddCollectionForDelete(collectionToInsert.RemovedEntitiesTracker);
            uow.Commit();
        }

        public static int UpdateEntityDirectly(IEntity2 entityWithNewValues, RelationPredicateBucket filter, int UserID)
        {
            SysUnitOfWork uow = new SysUnitOfWork(UserID);

            uow.AddUpdateEntitiesDirectlyCall(entityWithNewValues, filter);
            return uow.Commit();
        }

        public static void UpdateEntitiesDirectly<T>(EntityField2 Uniqefield, object UniqeValue, EntityField2 toUpdateField, object newValue, int UserID) where T : IEntity2, new()
        {
            SysUnitOfWork uow = new SysUnitOfWork(UserID);
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(Uniqefield == UniqeValue);
            T t = new T();
            t.Fields[toUpdateField.Name].CurrentValue = newValue;
            uow.AddUpdateEntitiesDirectlyCall(t, filter);
            uow.Commit();
        }

        public static void FillCollection(IEntityCollection2 ec, RelationPredicateBucket filter)
        {
            FillCollection(ec, filter, 0, null);
        }

        public static void FillCollection(IEntityCollection2 ec, RelationPredicateBucket filter, int UserID)
        {
            FillCollection(ec, filter, 0, null, null, 0, 0, UserID);
        }

        public static IEntityCollection2 GetCollection<T>(RelationPredicateBucket filterBucket,
           int maxNumberOfItemsToReturn,
           ISortExpression sortClauses,
           IPrefetchPath2 prefetchPath,
           int pageNumber, int pageSize,
           params IEntityField2[] fieldsToInclude) where T : IEntity2, new()
        {
            return GetCollection<T>(filterBucket, maxNumberOfItemsToReturn, sortClauses, prefetchPath, pageNumber, pageSize, 0, fieldsToInclude);
        }
        public static IEntityCollection2 GetCollection<T>(RelationPredicateBucket filterBucket,
            int maxNumberOfItemsToReturn,
            ISortExpression sortClauses,
            IPrefetchPath2 prefetchPath,
            int pageNumber, int pageSize, int UserID,
            params IEntityField2[] fieldsToInclude) where T : IEntity2, new()
        {
            T t = new T();
            var collectionToFill = t.GetEntityFactory().CreateEntityCollection();
            FillCollection(collectionToFill, filterBucket,
            maxNumberOfItemsToReturn,
            sortClauses,
            prefetchPath,
            pageNumber, pageSize, UserID,
             fieldsToInclude);
            return collectionToFill;
        }

        public static void FillCollection(IEntityCollection2 collectionToFill, RelationPredicateBucket filterBucket,
           int maxNumberOfItemsToReturn,
           ISortExpression sortClauses,
           IPrefetchPath2 prefetchPath,
           int pageNumber, int pageSize,
           params IEntityField2[] fieldsToInclude)
        {
            FillCollection(collectionToFill, filterBucket,
             maxNumberOfItemsToReturn,
             sortClauses,
             prefetchPath,
             pageNumber, pageSize, 0,
            fieldsToInclude);
        }
        public static void FillCollection(IEntityCollection2 collectionToFill, RelationPredicateBucket filterBucket,
            int maxNumberOfItemsToReturn,
            ISortExpression sortClauses,
            IPrefetchPath2 prefetchPath,
            int pageNumber, int pageSize, int UserID,
            params IEntityField2[] fieldsToInclude)
        {
            using (var adapter = BL.DataAccess.DataAdapterFactory.Create())
            {
                var included = new IncludeFieldsList();
                adapter.UserID = UserID;
                if (fieldsToInclude != null && fieldsToInclude.Count() > 0)
                {
                    foreach (IEntityField2 item in fieldsToInclude)
                    {
                        included.Add(item);
                    }
                }
                adapter.FetchEntityCollection(collectionToFill, filterBucket, maxNumberOfItemsToReturn, sortClauses, prefetchPath, included, pageNumber, pageSize);
            }
        }


        public static void CopyFieldNewAndDBValues(IEntity2 Source, IEntity2 distination, bool changedOnly = false, params IEntityField2[] Execludedfields)
        {
            foreach (IEntityField2 item in Source.Fields.Where(f => !Execludedfields.Any(e => e.Name.IsEqualTo(f.Name))))
            {

                if (!item.IsReadOnly)
                {
                    distination.Fields[item.Name].ForcedCurrentValueWrite(Source.Fields[item.Name].CurrentValue, Source.Fields[item.Name].DbValue);
                    distination.Fields[item.Name].IsChanged = changedOnly ? item.IsChanged : true;

                }
            }
            distination.IsDirty = true;


        }

        public static void CopyFieldNewValues(IEntity2 CopyFrom, IEntity2 CopyTo)
        {
            foreach (IEntityField2 item in CopyFrom.Fields)
            {

                if (!item.IsPrimaryKey)
                {
                    CopyTo.Fields[item.Name].ForcedCurrentValueWrite(CopyFrom.Fields[item.Name].CurrentValue);
                    CopyTo.Fields[item.Name].IsChanged = true;
                }
            }
            CopyTo.IsDirty = true;

        }
        public static void CopyFieldDBValues(IEntity2 CopyFrom, IEntity2 CopyTo)
        {
            foreach (IEntityField2 item in CopyFrom.Fields)
            {

                if (!item.IsReadOnly)
                {
                    CopyTo.Fields[item.Name].ForcedCurrentValueWrite(CopyTo.Fields[item.Name].CurrentValue, CopyFrom.Fields[item.Name].DbValue);
                }
            }
            CopyTo.IsDirty = true;

        }

        public static T FillEntityByID<T>(object ID, PrefetchPath2 path, params IEntityField2[] fieldsToInclude) where T : IEntity2, new()
        {
            var included = new IncludeFieldsList();

            if (fieldsToInclude != null && fieldsToInclude.Count() > 0)
            {
                foreach (IEntityField2 item in fieldsToInclude)
                {
                    included.Add(item);
                }
            }
            T entity = new T();
            var adapter = DataAccess.DataAdapterFactory.Create();
            foreach (IEntityField2 field in entity.Fields)
            {
                if (field.IsPrimaryKey)
                {
                    entity.Fields[field.Name].ForcedCurrentValueWrite(ID);
                    break;
                }

            }

            adapter.FetchEntity(entity, path, null, included);
            return entity;
        }

        public static void FillCollection(IEntityCollection2 ec, RelationPredicateBucket filter, int MaxResult, ISortExpression sortClause, IPrefetchPath2 path, ExcludeIncludeFieldsList _ExcludeIncludeFieldsList)
        {
            var adapter = BL.DataAccess.DataAdapterFactory.Create();

            adapter.FetchEntityCollection(ec, filter, MaxResult, sortClause, path, _ExcludeIncludeFieldsList);
        }
        public static void FillCollection(IEntityCollection2 ec, RelationPredicateBucket filter, int MaxResult, ISortExpression sortClause)
        {
            FillCollection(ec, filter, MaxResult, sortClause, null, null);
        }

        public static void FillEntity(IEntity2 en, PrefetchPath2 path, params IEntityField2[] fields)
        {
            var _excludeIncludeFieldsList = new ExcludeIncludeFieldsList(fields == null || fields.Count() == 0);
            foreach (var item in fields)
            {
                _excludeIncludeFieldsList.Add(item);
            }

            var adapter = DataAccess.DataAdapterFactory.Create();
            
            adapter.FetchEntity(en, path, null, _excludeIncludeFieldsList);
        }

        public static T FillNewEntity<T>(Predicate filter, PrefetchPath2 path) where T : IEntity2, new()
        {
            var adapter = DataAccess.DataAdapterFactory.Create();
            T t = new T();
            return (T)adapter.FetchNewEntity(t.GetEntityFactory(), new RelationPredicateBucket(filter), path);
        }
        public static T FillNewEntity<T>(Predicate filter) where T : IEntity2, new()
        {
            return FillNewEntity<T>(filter, null);
        }

        public static T GetScaler<T>(IEntityField2 entityField, IPredicate filter, IRelationCollection relationCollection)
        {
            return DataBase.GetScaler<T>(entityField, filter, relationCollection);
        }

        public static T GetMax<T>(IEntityField2 entityField, IPredicate filter)
        {
            return DataBase.GetMax<T>(entityField, filter, AggregateFunction.Max);
        }

        public static T GetScaler<T>(IEntityField2 entityField, IPredicate filter)
        {
            return DataBase.GetScaler<T>(entityField, filter, null);
        }


        public static int GetCount(IEntityField2 entityField, IRelationPredicateBucket filter)
        {
            return DataBase.Count(entityField, filter);
        }




    }
}
