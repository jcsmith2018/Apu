using DigiTAD.ViewModels;
using DigitadDAL;
using DigitadDAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DigiTAD
{
    public class ApplicationUserClaimsPrincipalFactory : IUserClaimsPrincipalFactory<AppUser>
    {
        private readonly DigitadDbContext _db;

        public ApplicationUserClaimsPrincipalFactory(DigitadDbContext db)
        {
            _db = db;
        }

        public async Task<ClaimsPrincipal> CreateAsync(AppUser user)
        {
            // Verificar las credenciales del usuario en la base de datos
            IniciosSesion? authUser = await _db.IniciosSesion.FirstOrDefaultAsync(u => u.Usuario == user.Username);
            if (authUser != null && !string.IsNullOrEmpty(authUser.Usuario))
            {
                // Crear los claims del usuario
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, authUser.Usuario),
                    new Claim(ClaimTypes.GivenName, $"{authUser.Nombre} {authUser.Apellidos}")
                    // se pueden agragar más claims...
                };

                // ClaimsPrincipal
                var identity = new ClaimsIdentity(claims, "DigiTADAuthenticationScheme");
                return new ClaimsPrincipal(identity);
            }

            return null; // Credenciales incorrectas
        }
    }

}
