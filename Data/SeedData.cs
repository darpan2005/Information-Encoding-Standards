using ContactManager.Authorization;
using ContactManager.Models;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// This file contains static methods to seed initial data for the application

namespace ContactManager.Data
{
    public static class SeedData
    {
        // Initializes the database with test users and contacts
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Ensure admin user and manager user with respective roles
                var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@contoso.com");
                await EnsureRole(serviceProvider, adminID, Constants.ContactAdministratorsRole);

                var managerID = await EnsureUser(serviceProvider, testUserPw, "manager@contoso.com");
                await EnsureRole(serviceProvider, managerID, Constants.ContactManagersRole);

                // Seed the database with contacts owned by the admin user
                SeedDB(context, adminID);
            }
        }

        // Ensures the existence of a user with the specified username
        private static async Task<string> EnsureUser(IServiceProvider serviceProvider, string testUserPw,
            string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("The Password is probably not strong enough!");
            }

            return user.Id;
        }

        // Ensures the existence of a role and adds the user to that role
        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider, string uid, string role)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            IdentityResult IR;
            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }

        // Seeds the database with initial contact data if the database is empty
        public static void SeedDB(ApplicationDbContext context, string adminID)
        {
            if (context.Contact.Any())
            {
                return;   // DB has been seeded
            }

            // Add sample contacts owned by the admin user
            context.Contact.AddRange(
                new Contact
                {
                    Name = "Drishti Aryal",
                    Address = "222 eve",
                    City = "San Deigo",
                    State = "CA",
                    Zip = "5588",
                    Email = "dristi123@gmail.com",
                    Status = ContactStatus.Approved,
                    OwnerID = adminID
                },
                new Contact
                {
                    Name = "Monika Paudel",
                    Address = "Nawalpur",
                    City = "Hetauda",
                    State = "Makwanpur",
                    Zip = "44899",
                    Email = "mpaudel@hotmail.com"
                },
                new Contact
                {
                    Name = "Siddharth Singh Bohara",
                    Address = "877 dexter crt",
                    City = "Lalitpur",
                    State = "KTM",
                    Zip = "47699",
                    Email = "sid211@gmail.com"
                },
                new Contact
                {
                    Name = "Ujjwal Subedi",
                    Address = "Bakhundole",
                    City = "Kathmandu",
                    State = "NEP",
                    Zip = "45100",
                    Email = "ujjwal@yahoo.com"
                }
             );
            context.SaveChanges();
        }

    }
}
