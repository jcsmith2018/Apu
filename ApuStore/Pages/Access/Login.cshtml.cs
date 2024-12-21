using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using ApuStoreDb;
using ApuStoreDb.Models;
using ApuStore;

namespace ApuStore.Pages.Access
{
    
    public class LoginModel : ApuStorePageModel
    {

        public LoginModel(ApuDbContext db, IWebHostEnvironment webHostEnvironment) : base(db, webHostEnvironment)
        {
            Creds = new LoginViewModel
            {
                Username = String.Empty,
                Password = String.Empty
            };
        }


        [BindProperty]
        public LoginViewModel Creds { get; set; }
        
        public void OnGet()
        {           
            ClaimsPrincipal sesion = HttpContext.User;
            if (sesion?.Identity?.IsAuthenticated ?? false)
            {
                RedirectToPage("/Index");
            }
        }

        public IEnumerable<IniciosSesion> Administradores { get; set; } = default!;

        public async Task<IActionResult> OnPost()
        {
            if (!string.IsNullOrEmpty(Creds.Username) && !string.IsNullOrEmpty(Creds.Password))
            {
                // comprobar la contraseña contra el AD
                if (DirectoryLoginService.LdapAuth(Creds.Username, Creds.Password, true))
                {
                    //si AD auth Ok: buscar usuario en tabla: [inicios_sesion] para consultar su perfil (o rol o nivel o estado o ...)
                    var user = sesSvc.ByUsername(Creds.Username);
                    if (user?.Activo ?? false)
                    {
                        user.Roles = sesSvc.GetRoles(user); //[not mapped]: para facilitar la gestión de roles

                        List<Claim> claims = new()
                        {
                            new Claim(ClaimTypes.Sid, user.Id.ToString()),
                            new Claim(ClaimTypes.NameIdentifier, Creds.Username),
                            //new Claim(ClaimTypes.Role, user.PerfilId.ToString()),
                            //new Claim("Nivel", user.Nivel.ToString()),
                            new Claim(ClaimTypes.Name, $"{user.Nombre} {user.Apellidos}"),
                            new Claim(ClaimTypes.GivenName, $"{user.Nombre}"),
                            new Claim(ClaimTypes.Surname, $"{user.Apellidos}")
                        };

                        // Agregar múltiples roles
                        foreach (var r in user.Roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, r.Nombre!));
                        }

                        ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        AuthenticationProperties props = new()
                        {
                            AllowRefresh = true,
                            IsPersistent = false
                        };

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(identity),
                            props
                        );

                        return RedirectToPage("/Index");
                    }
                }
            }

            ViewData["login-error"] = "Acceso denegado: usuario desconocido o contraseña incorrecta";
            //Administradores = sesSvc.FindAdministradores(false);
            return Page();
        }



        public class LoginViewModel
        {
            public LoginViewModel()
            {
                Username = String.Empty;
                Password = String.Empty;
            }
            

            [Required(ErrorMessage = "Se debe indicar un usuario")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Se debe indicar una contraseña")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
