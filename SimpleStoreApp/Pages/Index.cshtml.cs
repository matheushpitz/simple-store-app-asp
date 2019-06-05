using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oracle.ManagedDataAccess.Client;
using SimpleStoreApp.Database.Mappers.User.Interface;
using SimpleStoreApp.Database.Models;

namespace SimpleStoreApp.Pages
{
    public class IndexModel : PageModel {
        
        private readonly IUserMapper _userMapper;
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public IndexModel(IUserMapper userMapper)
        {
            this._userMapper = userMapper;
        }

        public void OnGet() {                        
        }

        public void OnPost() {
            StoreUserModel user = this._userMapper.getUserByUserAndPass(this.Username, this.Password);
        }
    }
}
