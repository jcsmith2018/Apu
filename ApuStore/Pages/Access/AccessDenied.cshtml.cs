using ApuStoreDb;
using ApuStoreDb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApuStore;

namespace ApuStore.Pages.Access
{
    public class AccessDeniedModel : ApuStorePageModel
    {
        public AccessDeniedModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment) { }

        
        public IEnumerable<IniciosSesion>? Administradores { get; set; }

        public ActionResult OnGet()
        {
            if (db.IniciosSesion != null) 
            {
                //admin no Tecnológico
                //Administradores = sesSvc.FindAdministradores(false); 
            }
            return Page();
        }
    }
}
