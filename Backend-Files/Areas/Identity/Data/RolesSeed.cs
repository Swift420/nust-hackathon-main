using Microsoft.AspNetCore.Identity;
using schoolAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolAdmin.Areas.Identity.Data
{
    public static class RoleSeed
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(AccessLevels.Dean.ToString()));
            await roleManager.CreateAsync(new IdentityRole(AccessLevels.HOD.ToString()));
            await roleManager.CreateAsync(new IdentityRole(AccessLevels.DVC.ToString()));
            await roleManager.CreateAsync(new IdentityRole(AccessLevels.Staff.ToString()));
        }
    }
}
