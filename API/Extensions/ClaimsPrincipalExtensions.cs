using System.Linq;
using System.Security.Claims;
using System.Linq;

namespace API.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string RetrieveEmailFromPrincipal(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Email);

            //return user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        }

         public static string RetrievePhoneFromPrincipal(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.MobilePhone);

            //return user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        }
    }
}