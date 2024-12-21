using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using ApuStoreDb;
using ApuStoreDb.Services;
using ApuStore.Extensions;

namespace ApuStore
{
    public class ApuStorePageModel : PageModel
    {
        protected ApuDbContext db;
        protected SesionService sesSvc;       
        
        private IWebHostEnvironment _webHostEnvironment;

        public ApuStorePageModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            
            db = context;
            sesSvc = new(context);            
        }

        public int SessionId => int.Parse(HttpContext?.User?.FindFirst(ClaimTypes.Sid)?.Value ?? "0");
        public string SessionName => HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
        public string SessionGivenName => HttpContext?.User?.FindFirst(ClaimTypes.GivenName)?.Value ?? "";
        public string SessionFullName => HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value ?? "";
        
        //public int RolId => int.Parse(HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value ?? "0");
        //public int Nivel => int.Parse(HttpContext?.User?.FindFirst("Nivel")?.Value ?? "0");
        //public string Perfil => sesSvc.PerfilById(RolId)?.Nombre ?? "???";


        protected string Rm(string valor)
        {
            if (!string.IsNullOrEmpty(valor))
            {
                return valor.
                    Replace(",", "").
                    Replace(";", "");
            }
            return valor;
        }

        protected string GetDirPath(string dirname)
        { 
            return Path.Combine(_webHostEnvironment.WebRootPath, dirname);
        }

        protected string GetFilePath(string dirname, string filename)
        {
            return Path.Combine(GetDirPath(dirname), filename);
        }

        



    }
}
