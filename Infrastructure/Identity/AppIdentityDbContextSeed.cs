using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName="Satya",
                    Email= "sahusatya2002@gmail.com",
                    UserName ="sahusatya2002@gmail.com",
                    PhoneNumber="8017585020",
                    Address = new Address
                    {
                        FirstName = "Satya",
                        LastName = "sahu",
                        PhoneNo = "8017585020",
                        Street = " 10 The Street",
                        City ="Kolkata",
                        State ="WB",
                        ZipCode ="700001"

                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
                }
        }


    }
}