using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStoreApp.Database.Models
{
    public class StoreUserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }

        public StoreUserModel(int Id, string Username, string Pass)
        {
            this.Id = Id;
            this.Username = Username;
            this.Pass = Pass;
        }
    }
}
