using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis;
using ApuStoreDb;
using ApuStoreDb.Models;



namespace ApuStore.Pages.Administracion.Accesos
{
    [Authorize(Roles = "1,Admin")]
    public class DeleteModel : ApuStorePageModel
    {
        public DeleteModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment) { }

        [BindProperty]
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
            
            Acceso = acceso;
            return Page();
        }

        public IActionResult OnPost(int? id)
        { 
            if (id == null)
            {
                return NotFound();
            }

            var acceso = sesSvc.ById(id ?? 0);
            if (acceso != null)
            {
                Acceso = acceso;
                sesSvc.BorrarAcceso(SessionId, Acceso);
                return RedirectToPage("./Index");
            }

            ViewData["Mensaje"] = "Error al borrar el acceso";
            return Page();
        }
    }
}
