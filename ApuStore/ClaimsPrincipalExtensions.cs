using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace ApuStore.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsInAnyRole(this ClaimsPrincipal principal, params string[] roles) 
        {
            foreach (var role in roles)
            {
                if (principal.IsInRole(role))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public static class DatetimeExtensions
    { 
        public static string Format(this DateTime? date, string template) 
        {
            if (date.HasValue)
            { 
                return date.Value.ToString(template);
            }
            return string.Empty;
        }

        public static string Format(this DateTime date, string template)
        {
            if (date > DateTime.MinValue)
            {
                return date.ToString(template);
            }
            return string.Empty;
        }


    }

}
