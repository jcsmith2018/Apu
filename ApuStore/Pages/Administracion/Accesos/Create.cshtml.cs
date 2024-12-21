using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ApuStoreDb;
using ApuStoreDb.Models;


namespace ApuStore.Pages.Administracion.Accesos
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : ApuStorePageModel
    {
        public CreateModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment) 
        {
            //Roles = db.Roles.ToList();
        }

        public IActionResult OnGet()
        {
            ViewData["Roles"] = new SelectList(db.Roles.OrderBy(r => r.Orden), "Id", "Nombre");
            return Page();
        }

        //public IEnumerable<Roles> Roles { get; set; }

        [BindProperty]
        public IniciosSesion Acceso { get; set; } = default!;



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            ViewData["Error"] = string.Empty;

            if (!ModelState.IsValid || db.IniciosSesion == null)
            {
                ViewData["Roles"] = new SelectList(db.Roles.OrderBy(r => r.Orden), "Id", "Nombre");
                return Page();
            }

            string login = Acceso.Usuario!;
            if (!string.IsNullOrEmpty(login))
            {
                var a = sesSvc.ByUsername(login);
                if (a != null)
                {
                    ViewData["Error"] = $"<strong>{login}</strong> ya está registrado en Accesos de Dietario";
                    return Page();
                }
            }

            Acceso.Nivel = 1; //por defecto se crea con nivel 1
           
            db.IniciosSesion.Add(Acceso.Audit(SessionId));
            db.SaveChanges();

            return RedirectToPage("./Details", new { Acceso.Id });
        }
    }
}
