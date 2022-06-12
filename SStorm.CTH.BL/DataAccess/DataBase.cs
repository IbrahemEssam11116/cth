using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SStorm.CTH.BL.DataAccess
{
    public sealed class DataBase
    {
        public static bool UseDataBaseEncryption = false;
        public static string ConfigFileConnection
        {
            get
            {
                //   return ConfigurationManager.ConnectionStrings[Globals.ConnectionStringConfigKey].ConnectionString;
                return ConnectionString;
            }
        }

        public static string DefaultConnection { get { return ConfigFileConnection; } }

        public static int DefaultTimeOut
        {
            get
            {
                return 300;
            }
        }



        public static int Count<T>(IRelationPredicateBucket filter) where T : IEntity2, new()
        {
            int count = 0;

            var adapter = DataAdapterFactory.Create();

            count = adapter.GetDbCount(new T().GetEntityFactory().CreateEntityCollection(), filter);
            return count;
        }

        internal static int Count(IEntityCollection2 toCount, IRelationPredicateBucket filter)
        {
            int count = 0;

            if (toCount != null)
                using (var adapter = DataAdapterFactory.Create())
                {
                    count = adapter.GetDbCount(toCount, filter);

                }
            return count;
        }


        internal static int Count(IEntityField2 toCount, IRelationPredicateBucket filter)
        {
            using (var adapter = DataAccess.DataAdapterFactory.Create())
            {

                return (int)adapter.GetScalar(toCount, null, AggregateFunction.Count, filter != null ? filter.PredicateExpression : null, null, filter != null ? filter.Relations : null);
            }

        }

        internal static int Count(IEntityFields2 toCount, IRelationPredicateBucket filter)
        {
            int count = 0;

            if (toCount != null)
                using (var adapter = DataAdapterFactory.Create())
                {
                    count = adapter.GetDbCount(toCount, filter);

                }
            return count;
        }


        internal static T GetMax<T>(IEntityField2 entityField)
        {
            return GetMax<T>(entityField, null);
        }

        internal static T GetMax<T>(IEntityField2 entityField, IPredicate filter)
        {
            try
            {
                T maxValue = default(T);

                using (var adapter = DataAccess.DataAdapterFactory.Create())
                {
                    var val = adapter.GetScalar(entityField, null, AggregateFunction.Max, filter);
                    if (val is T)
                        maxValue = (T)val;
                }
                return maxValue;
            }
            catch (System.Exception exp)
            {

                throw exp;
            }
        }

        internal static T GetMax<T>(IEntityField2 entityField, IPredicate filter, AggregateFunction function)
        {
            T maxValue = default(T);

            using (var adapter = DataAccess.DataAdapterFactory.Create())
            {
                var val = adapter.GetScalar(entityField, null, function, filter);
                if (val is T)
                    maxValue = (T)val;
            }
            return maxValue;
        }

        internal static T GetMax<T>(IEntityField2 entityField, IPredicate filter, AggregateFunction function, IRelationCollection relations)
        {
            T maxValue = default(T);

            using (var adapter = DataAccess.DataAdapterFactory.Create())
            {
                var val = adapter.GetScalar(entityField, null, function, filter, null, relations);
                if (val is T)
                    maxValue = (T)val;
            }
            return maxValue;
        }


        internal static object GetScaler(IEntityField2 entityField, IPredicate filter)
        {
            using (var adapter = DataAccess.DataAdapterFactory.Create())
            {
                var val = adapter.GetScalar(entityField, null, AggregateFunction.None, filter);
                return val;
            }
        }

        internal static object GetScaler(string DataBaseName, IEntityField2 entityField, IPredicate filter)
        {
            using (var adapter = DataAccess.DataAdapterFactory.Create(DataBaseName))
            {
                var val = adapter.GetScalar(entityField, null, AggregateFunction.None, filter);
                return val;
            }
        }

        internal static object GetScaler(IEntityField2 entityField, IPredicate filter, IRelationCollection relationCollection)
        {
            using (var adapter = DataAccess.DataAdapterFactory.Create())
            {
                var val = adapter.GetScalar(entityField, null, AggregateFunction.None, filter, null, relationCollection);
                return val;
            }
        }

        internal static T GetScaler<T>(IEntityField2 entityField, IPredicate filter, IRelationCollection relationCollection)
        {
            T result = default(T);
            var val = GetScaler(entityField, filter, relationCollection);
            if (val is T)
                result = (T)val;
            return result;
        }

        internal static T GetScaler<T>(IEntityField2 entityField, IPredicate filter)
        {
            T result = default(T);
            var val = GetScaler(entityField, filter);
            if (val == null || val == System.DBNull.Value)
                return result;
            try
            {
                if (val is T)
                    return (T)val;
                if (typeof(T) == typeof(bool))
                {
                    if (val.Equals("1"))
                        val = bool.TrueString;
                    if (val.Equals("0"))
                        val = bool.FalseString;
                }

                return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(val);
            }
            catch
            {
            }

            return result;
        }


        internal static T GetScaler<T>(string DatabaseName, IEntityField2 entityField, IPredicate filter)
        {
            T result = default(T);
            var val = GetScaler(DatabaseName, entityField, filter);
            if (val == null || val == System.DBNull.Value)
                return result;
            try
            {
                if (val is T)
                    return (T)val;
                if (typeof(T) == typeof(bool))
                {
                    if (val.Equals("1"))
                        val = bool.TrueString;
                    if (val.Equals("0"))
                        val = bool.FalseString;
                }

                return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(val);
            }
            catch
            {
            }

            return result;
        }




        static string _dataBaseName;

        public static string DataBaseName
        {
            get { return DataBase._dataBaseName; }
            set { DataBase._dataBaseName = value; }
        }

        static string _schemaName;

        public static string SchemaName
        {
            get { return DataBase._schemaName; }
            set { DataBase._schemaName = value; }
        }

        static string connectionString;

        public static string ConnectionString
        {
            get { return DataBase.connectionString; }
            set { DataBase.connectionString = value; }
        }


    }
}
