using Microsoft.AspNetCore.Identity;
using Repository.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Tools
{
    public class RoleFinder
    {
        private readonly UserManager<AppUser> _userManager;
    

        public  RoleFinder(UserManager<AppUser> userManager)
        {
            _userManager = userManager;           
        }

        public async Task<string> FindRole(AppUser user)
        {
            string roleName = "";
            var role = await _userManager.GetRolesAsync(user);
            if (role[0].ToString() == "Admin")
                roleName = "Admin";
            else if (role[0].ToString() == "Organization")
                roleName = "Organization";
            else if (role[0].ToString() == "Report")
                roleName = "Report";
            else if (role[0].ToString() == "Model")
                roleName = "Model";
            else if (role[0].ToString() == "Member")
                roleName = "Member";

            return roleName.ToString();



        }

    }
}
