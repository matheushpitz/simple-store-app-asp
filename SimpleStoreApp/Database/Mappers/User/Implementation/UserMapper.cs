using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleStoreApp.Database.Mappers.User.Interface;
using SimpleStoreApp.Database.Models;
using SimpleStoreApp.Database.DB.Interface;

namespace SimpleStoreApp.Database.Mappers.User.Implementation
{
    public class UserMapper : IUserMapper
    {

        private readonly IDatabase _database;

        public UserMapper(IDatabase database)
        {
            this._database = database;
        }

        public StoreUserModel getUserByUserAndPass(string user, string pass)
        {
            var conn = this._database.getConnection();
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("user", user);
                parameters.Add("pass", pass);
                var reader = this._database.Execute("select id, username, pass from store_user where username = :user and pass = :pass", parameters, conn);
                if(reader != null && reader.Read())
                {
                    StoreUserModel userInstance = new StoreUserModel(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    reader.Dispose();
                    return userInstance;
                }               

            } catch(Exception e)
            {

            } finally
            {
                this._database.closeConnection(conn);
            }

            return null;
        }
    }
}
