using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TessaWebAPI.Entities;

namespace TessaWebAPI.Data
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Giorgi",
                    Email = "gio@test.com",
                    UserName = "gio@test.com",
                    Address = new Address
                    {
                        FirstName = "Giorgi",
                        LastName = "Datunashvili",
                        Street = "10 The Street",
                        City = "Tbilisi",
                        State = "GE",
                        Zipcode = "90210"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
