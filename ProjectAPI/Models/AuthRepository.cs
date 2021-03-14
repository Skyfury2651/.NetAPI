using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProjectAPI.Models
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;

        private UserManager<UserModel> _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<UserModel>(new UserStore<UserModel>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {

            var result = await _userManager.CreateAsync(userModel, userModel.Password);

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_ctx));
            if (!roleManager.RoleExists("admins"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "admins";
                roleManager.Create(role);
            }
            var result1 = _userManager.AddToRole(userModel.Id, "admins");


            return result;
        }

        public async Task<UserModel> FindUser(string userName, string password)
        {
            UserModel user = await _userManager.FindAsync(userName, password);

            return user;
        }
        public async Task<IList<string>> UserRoles(string userId)
        {
            IList<string> roles = await _userManager.GetRolesAsync(userId);

            return roles;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}