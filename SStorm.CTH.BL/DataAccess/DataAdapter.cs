using SD.LLBLGen.Pro.ORMSupportClasses;
using SStorm.CTH.BL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SStorm.CTH.BL.DataAccess
{
    public class DataAdapter : DAL.DatabaseSpecific.DataAccessAdapter
    {
        public int UserID { get; set; }

        public event EventHandler OnAfterEnititySaveCompleted;
        public DataAdapter()
        {
            SetAdapterCatogName();
        }

        public DataAdapter(string connectionString, bool keepConnectionOpen, string DataBaseName = null)
            : base(connectionString, keepConnectionOpen)
        {
            SetAdapterCatogName(DataBaseName);


        }

        private void SetAdapterCatogName(string DataBaseName = null)
        {
            CatalogNameOverwriteHashtable catalog = new CatalogNameOverwriteHashtable();
            catalog.Add("BankFacility", DataBaseName.IFEmpty(DataBase.DataBaseName));
            SchemaNameOverwriteHashtable schema = new SchemaNameOverwriteHashtable();
            schema.Add("dbo", DataBase.SchemaName);

            this.CatalogNameOverwrites = catalog;
            this.SchemaNameOverwrites = schema;

            this.CatalogNameToUse = DataBaseName.IFEmpty(DataBase.DataBaseName);
            this.CatalogNameUsageSetting = CatalogNameUsage.ForceName;
        }

        public string GetSourceColumnName(IEntityField2 field)
        {
            // access the protected method to retrieve the field's info
            IFieldPersistenceInfo fieldInfo = GetFieldPersistenceInfo(field);
            // return the name of the source column
            return fieldInfo.SourceColumnName;
        }

        public string GetSourceTableName(IEntityField2 field)
        {
            // access the protected method to retrieve the field's info
            IFieldPersistenceInfo fieldInfo = GetFieldPersistenceInfo(field);

            // return the name of the source column
            return fieldInfo.SourceObjectName;
        }


        public override bool SaveEntity(IEntity2 entityToSave, bool refetchAfterSave, IPredicateExpression updateRestriction, bool recurse)
        {
            return base.SaveEntity(entityToSave, refetchAfterSave, updateRestriction, recurse);
        }

        public bool AddForSave(IEntity2 entityToSave, bool refetchAfterSave, bool recurse)
        {
            return base.SaveEntity(entityToSave, refetchAfterSave, recurse);
        }
        public bool AddForSave(IEntity2 entityToSave)
        {
            return base.SaveEntity(entityToSave);
        }


        public override int SaveEntityCollection(IEntityCollection2 collectionToSave, bool refetchSavedEntitiesAfterSave, bool recurse)
        {
            // collectionToSave.Cast<IEntity2>().ForEach(x => DBEncryptionHelper.EncryptEntityValues(x));
            return base.SaveEntityCollection(collectionToSave, refetchSavedEntitiesAfterSave, recurse);
        }

        public int AddCollectionForSave(IEntityCollection2 collectionToSave, bool refetchSavedEntitiesAfterSave, bool recurse)
        {
            // collectionToSave.Cast<IEntity2>().ForEach(x => DBEncryptionHelper.EncryptEntityValues(x));
            return base.SaveEntityCollection(collectionToSave, refetchSavedEntitiesAfterSave, recurse);
        }

        public int AddCollectionForDelete(IEntityCollection2 collectionToSave)
        {
            // collectionToSave.Cast<IEntity2>().ForEach(x => DBEncryptionHelper.EncryptEntityValues(x));
            return base.DeleteEntityCollection(collectionToSave);
        }

        public override int UpdateEntitiesDirectly(IEntity2 entityWithNewValues, IRelationPredicateBucket filterBucket)
        {
            // DBEncryptionHelper.EncryptEntityValues(entityWithNewValues);

            return base.UpdateEntitiesDirectly(entityWithNewValues, filterBucket);
        }

        protected override void OnSaveEntity(IActionQuery saveQuery, IEntity2 entityToSave)
        {


            base.OnSaveEntity(saveQuery, entityToSave);

        }

        protected override void OnSaveEntityComplete(IActionQuery saveQuery, IEntity2 entityToSave)
        {
            base.OnSaveEntityComplete(saveQuery, entityToSave);
            if (OnAfterEnititySaveCompleted != null)
                OnAfterEnititySaveCompleted(entityToSave, new EventArgs());
        }

        protected override void OnSaveEntityCollection(IEntityCollection2 entityCollectionToSave)
        {
            base.OnSaveEntityCollection(entityCollectionToSave);
        }

        public override bool FetchEntity(IEntity2 entityToFetch, IPrefetchPath2 prefetchPath, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
        {
            var result = base.FetchEntity(entityToFetch, prefetchPath, contextToUse, excludedIncludedFields);

            //if (DecryptFetchedEntites)
            //    DBEncryptionHelper.DecryptEntityValues(entityToFetch, false);
            return result;
        }
        protected override void OnFetchEntityCollection(IRetrievalQuery selectQuery, IEntityCollection2 entityCollectionToFetch)
        {
            base.OnFetchEntityCollection(selectQuery, entityCollectionToFetch);
        }

        public override void FetchEntityCollection(QueryParameters parameters)
        {
            base.FetchEntityCollection(parameters);
        }

        protected override System.Data.Common.DbDataAdapter CreateNewPhysicalDataAdapter()
        {
            return base.CreateNewPhysicalDataAdapter();
        }

        protected override System.Data.Common.DbConnection CreateNewPhysicalConnection(string connectionString)
        {
            return base.CreateNewPhysicalConnection(connectionString);

        }

        protected override System.Data.Common.DbTransaction CreateNewPhysicalTransaction()
        {
            return base.CreateNewPhysicalTransaction();
        }

        public void AddUpdateEntitiesDirectlyCall<T>(EntityField2 Uniqefield, object UniqeValue, EntityField2 toUpdateField, object newValue) where T : IEntity2, new()
        {
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(Uniqefield == UniqeValue);
            T t = new T();
            t.Fields[toUpdateField.Name].CurrentValue = newValue;
            base.UpdateEntitiesDirectly(t, filter);
        }

        public void AddUpdateEntitiesDirectlyCall<T>(EntityField2 toUpdateField, object newValue, IPredicateExpression predicate) where T : IEntity2, new()
        {
            T t = new T();
            t.Fields[toUpdateField.Name].CurrentValue = newValue;
            base.UpdateEntitiesDirectly(t, new RelationPredicateBucket(predicate));
        }
        public int AddDeleteEntitiesDirectlyCall<T>(IRelationPredicateBucket filterBucket) where T : IEntity2
        {
            return base.DeleteEntitiesDirectly(typeof(T), filterBucket);
        }

        public void AddUpdateEntitiesDirectlyCall(EntityField2 Uniqefield, object UniqeValue, EntityField2 toUpdateField, object newValue, IEntity2 EntityWithNewValue)
        {
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(Uniqefield == UniqeValue);
            EntityWithNewValue.Fields[toUpdateField.Name].CurrentValue = newValue;
            base.UpdateEntitiesDirectly(EntityWithNewValue, filter);
        }




    }
}
