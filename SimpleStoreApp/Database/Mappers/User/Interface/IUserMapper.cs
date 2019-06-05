using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleStoreApp.Database.Models;

namespace SimpleStoreApp.Database.Mappers.User.Interface
{
    public interface IUserMapper
    {
        StoreUserModel getUserByUserAndPass(string user, string pass);
    }
}
