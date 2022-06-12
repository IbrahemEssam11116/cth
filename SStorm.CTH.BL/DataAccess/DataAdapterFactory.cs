using System;
using System.Collections.Generic;
using System.Text;

namespace SStorm.CTH.BL.DataAccess
{
    internal sealed class DataAdapterFactory
    {
        private DataAdapterFactory()
        {

        }

        public static DataAdapter Create()
        {
            return Create(DataBase.DefaultConnection, DataBase.DefaultTimeOut, false);
        }

        public static DataAdapter Create(string dataBaseName)
        {
            return Create(dataBaseName, DataBase.DefaultConnection, DataBase.DefaultTimeOut, false);
        }

        public static DataAdapter Create(bool keepConnectionOpen)
        {

            return Create(DataBase.DefaultConnection, DataBase.DefaultTimeOut, keepConnectionOpen);
        }
        public static DataAdapter Create(string connection, int timeout)
        {
            return Create(connection, timeout, false);
        }

        public static DataAdapter Create(string connection, int timeout, bool keepConnectionOpen)
        {
            if (string.IsNullOrEmpty(connection))
            {
                connection = DataBase.DefaultConnection;
            }

            DataAdapter toReturn = new DataAdapter(connection, keepConnectionOpen);


            toReturn.CommandTimeOut = timeout;
            return toReturn;
        }

        public static DataAdapter Create(string DatabaseName, string connection, int timeout, bool keepConnectionOpen)
        {
            if (string.IsNullOrEmpty(connection))
            {
                connection = DataBase.DefaultConnection;
            }

            DataAdapter toReturn = new DataAdapter(connection, keepConnectionOpen, DatabaseName);


            toReturn.CommandTimeOut = timeout;
            return toReturn;
        }

    }
}
