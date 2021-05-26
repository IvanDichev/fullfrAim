using FullFraim.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Data.Seed
{
    public class UsersRolesSeeder : ISeeder
    {
        public async Task SeedAsync(FullFraimDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();

            await this.SeedRoles(roleManager);
            await this.SeedAdmin(userManager, configuration);
            await this.SeedUsers(userManager);
        }

        private async Task SeedRoles(RoleManager<IdentityRole<int>> roleManager)
        {
            var roles = new List<string>()
            {
                Constants.RolesSeed.Admin,
                Constants.RolesSeed.Organizer,
                Constants.RolesSeed.User,
            };

            foreach (var role in roles)
            {
                if (!(await roleManager.RoleExistsAsync(role)))
                    await roleManager.CreateAsync(new IdentityRole<int>(role));
            }
        }

        private async Task SeedUsers(UserManager<User> userManager)
        {
            var usersToSeed = new List<User>
            {
                new User()
                {
                    //Id = 2,
                    FirstName = Constants.UserSeed.Valentin,
                    LastName = Constants.UserSeed.Shikov,
                    UserName = Constants.UserSeed.VShikovEmail,
                    NormalizedUserName = Constants.UserSeed.VShikovEmail.ToUpper(),
                    Email = Constants.UserSeed.VShikovEmail,
                    NormalizedEmail = Constants.UserSeed.VShikovEmail.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    Points = 0,
                },
                new User()
                {
                    //Id = 3,
                    FirstName = Constants.UserSeed.Ivan,
                    LastName = Constants.UserSeed.Dichev,
                    UserName = Constants.UserSeed.IDichevEmail,
                    NormalizedUserName = Constants.UserSeed.IDichevEmail.ToUpper(),
                    Email = Constants.UserSeed.IDichevEmail,
                    NormalizedEmail = Constants.UserSeed.IDichevEmail.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    Points = 0,
                },
                new User()
                {
                    //Id = 4,
                    FirstName = Constants.UserSeed.Boryana,
                    LastName = Constants.UserSeed.BMihaylovaEmail,
                    UserName = Constants.UserSeed.BMihaylovaEmail,
                    NormalizedUserName = Constants.UserSeed.BMihaylovaEmail.ToUpper(),
                    Email = Constants.UserSeed.BMihaylovaEmail,
                    NormalizedEmail = Constants.UserSeed.BMihaylovaEmail.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    Points = 0,
                },
                new User()
                {
                    //Id = 5,
                    FirstName = Constants.UserSeed.Dimitar,
                    LastName = Constants.UserSeed.Dimitrov,
                    UserName = Constants.UserSeed.DDimitrovEmail,
                    NormalizedUserName = Constants.UserSeed.DDimitrovEmail.ToUpper(),
                    Email = Constants.UserSeed.DDimitrovEmail,
                    NormalizedEmail = Constants.UserSeed.DDimitrovEmail.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    Points = 0,
                },
                new User()
                {
                    //Id = 6,
                    FirstName = Constants.UserSeed.Emily,
                    LastName = Constants.UserSeed.Ivanova,
                    UserName = Constants.UserSeed.EIvanovaEmail,
                    NormalizedUserName = Constants.UserSeed.EIvanovaEmail.ToUpper(),
                    Email = Constants.UserSeed.EIvanovaEmail,
                    NormalizedEmail = Constants.UserSeed.EIvanovaEmail.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    Points = 0,
                },
            };

            foreach (var user in usersToSeed)
            {
                if (await userManager.FindByEmailAsync(user.Email) == null)
                {
                    var createdUserResult = await userManager.CreateAsync(user, "12345678901");

                    if (createdUserResult.Succeeded)
                    {
                        var createdUser = await userManager.FindByEmailAsync(user.Email);

                        await userManager.AddToRoleAsync(createdUser, Constants.RolesSeed.User);
                    }
                }
            }
        }

        public async Task SeedAdmin(UserManager<User> userManager, IConfiguration configuration)
        {
            var admin = new User()
            {
                //Id = 1,
                FirstName = configuration["AccountAdminInfo:UserName"],
                LastName = configuration["AccountAdminInfo:LastName"],
                UserName = configuration["AccountAdminInfo:UserName"],
                NormalizedUserName = configuration["AccountAdminInfo:UserName"].ToUpper(),
                Email = configuration["AccountAdminInfo:Email"],
                NormalizedEmail = configuration["AccountAdminInfo:UserName"].ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                Points = 0,
            };

            if (await userManager.FindByEmailAsync(admin.Email) == null)
            {
                var createdAdmin = await userManager.CreateAsync(admin, configuration["AccountAdminInfo:Password"]);

                if (createdAdmin.Succeeded)
                {
                    var createdUser = await userManager.FindByEmailAsync(admin.Email);

                    await userManager.AddToRoleAsync(createdUser, Constants.RolesSeed.Organizer);
                    await userManager.AddToRoleAsync(createdUser, Constants.RolesSeed.Admin);
                }
            }
        }
    }
}
