using Microsoft.AspNetCore.Mvc;
using ApuStoreDb;
using ApuStoreDb.Models;
using Microsoft.AspNetCore.Authorization;


namespace ApuStore.Pages.Administracion.Accesos
{
    [Authorize(Roles = "1,Admin")]
    public class DetailsModel : ApuStorePageModel
    {
        public DetailsModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment) { }


        
        public IniciosSesion? Acceso { get; set; } = default!; 
        
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
                        
            var acceso = sesSvc.ById(id ?? 0);
            if (acceso == null)
            {
                return NotFound();
            }
            else 
            {
                acceso.Roles = sesSvc.GetRoles(acceso);
                Acceso = acceso;
            }
            return Page();
        }
    }
}
