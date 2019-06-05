using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace SimpleStoreApp.Database.DB.Interface
{
    public interface IDatabase {
        OracleDataReader Execute(string command, Dictionary<string, object> parameters, OracleConnection conn);
        OracleConnection getConnection();
        void closeConnection(OracleConnection conn);
    }
}
