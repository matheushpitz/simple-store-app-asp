using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleStoreApp.Database.DB.Interface;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Extensions.Configuration;

namespace SimpleStoreApp.Database.DB.Implementation
{
    public class OracleDatabase : IDatabase {

        private IConfiguration _configuration;

        public OracleDatabase(IConfiguration configuration) {
            this._configuration = configuration;
        }

        private string getConnectionString() {
            IConfigurationSection dbSettings = this._configuration.GetSection("DbSettings");
            return "Pooling=false;User Id=" + dbSettings.GetSection("User").Value +
                    ";Password=" + dbSettings.GetSection("Password").Value +
                    ";Data Source=" + dbSettings.GetSection("Domain").Value +
                    ":" + dbSettings.GetSection("Port").Value + "/xe;";
        }

        public OracleDataReader Execute(string command, Dictionary<string, object> parameters, OracleConnection conn)
        {            
            OracleCommand cmd = null;
            try
            {
                // Initialize                
                cmd = conn.CreateCommand();
                // Open the connection
                conn.Open();
                cmd.BindByName = true;
                // Set the command
                cmd.CommandText = command;
                // Set the parameters
                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> kv in parameters)
                    {
                        cmd.Parameters.Add(kv.Key, kv.Value);
                    }
                }

                return cmd.ExecuteReader();
            } catch (Exception e) {
                //TODO.
            } finally {                
                if(cmd != null)
                {
                    cmd.Dispose();
                }
            }
            return null;
        }

        public OracleConnection getConnection()
        {
            return new OracleConnection(this.getConnectionString());
        }

        public void closeConnection(OracleConnection conn)
        {
            if(conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
