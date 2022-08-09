using Microsoft.AspNetCore.Identity;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Data
{
    public class Seed
    {
        public static async void SeedData(IApplicationBuilder applicationBuilder)
        {
            

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if(!context.SuperHeroes.Any())
                {
                    context.SuperHeroes.AddRange(new List<SuperHero>()
                    {
                        new SuperHero()
                        {
                            Name="Peter Parker",
                            Alias="Spiderman"
                        },
                        new SuperHero()
                        {
                            Name="Bruce Wayne",
                            Alias="Batman"
                        },
                        new SuperHero()
                        {
                            Name="Tony Stark",
                            Alias="Iron Man"
                        },
                        new SuperHero()
                        {
                            Name="Logan",
                            Alias="Wolverine"
                        }
                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                if (!userManager.Users.Any())
                {
                    var users = new List<AppUser>
                        {
                            new AppUser
                            {
                                UserName="Jimmy",
                                Email="jimmy@test.ca",
                                Country="Canada"
                            },
                            new AppUser
                            {
                                UserName="Sarah",
                                Email="sarah@test.ca",
                                Country="USA"
                            },
                            new AppUser
                            {
                                UserName="Tom",
                                Email="tom@test.ca",
                                Country="Canada"
                            }


                        };
                    foreach (var user in users)
                    {
                        await userManager.CreateAsync(user, "Pa$$w0rd");
                        await userManager.AddToRoleAsync(user, UserRoles.User);
                    }
                }

            }
        }
    }
}
