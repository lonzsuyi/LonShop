using LonShop.BaseCore.Entities.UserAggregate;
using LonShop.BaseCore.Constants;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace LonShop.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            // Add admin
            await roleManager.CreateAsync(new ApplicationRole(Roles.ADMINISTRATORS));
            string defaultAdminName = "admin@test.com";
            var defaultAdmin = new ApplicationUser { UserName = defaultAdminName, Email = defaultAdminName };
            await userManager.CreateAsync(defaultAdmin, AuthorizationConstants.DEFAULT_PASSWORD);
            defaultAdmin = await userManager.FindByEmailAsync(defaultAdminName);
            await userManager.AddToRoleAsync(defaultAdmin, Roles.ADMINISTRATORS);

            // Add custmer
            await roleManager.CreateAsync(new ApplicationRole(Roles.CUSTOMER));
            string defaultCustmerName = "user1@test.com";
            var defaultCustmer = new ApplicationUser { UserName = defaultCustmerName, Email = defaultCustmerName };
            await userManager.CreateAsync(defaultCustmer, AuthorizationConstants.DEFAULT_PASSWORD);
            defaultCustmer = await userManager.FindByEmailAsync(defaultCustmerName);
            await userManager.AddToRoleAsync(defaultCustmer, Roles.CUSTOMER);
        }
    }
}