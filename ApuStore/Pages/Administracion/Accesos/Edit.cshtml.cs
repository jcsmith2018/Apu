using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApuStoreDb;
using ApuStoreDb.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApuStore.Pages.Administracion.Accesos
{
    [Authorize(Roles = "1,Admin")]
    public class EditModel : ApuStorePageModel
    {
        public EditModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment) 
        { 
            Roles = db.Roles.ToList();
        }

        [BindProperty]
        public IniciosSesion Acceso { get; set; } = default!;

        public IEnumerable<Roles> Roles { get; set; }
        
        public IActionResult OnGet(int? id)
        {
            if (id == null || db.IniciosSesion == null)
            {
                return NotFound();
            }

            var acceso = sesSvc.ById(id ?? 0);
            if (acceso == null)
            {
                return NotFound();
            }
            //ViewData["Perfiles"] = new SelectList(db.InicioSesionPerfiles, "Id", "Nombre");
            
            acceso.Roles = sesSvc.GetRoles(acceso);
            Acceso = acceso;
            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            ViewData["Error"] = string.Empty;

            if (!ModelState.IsValid)
            {
                //ViewData["Perfiles"] = new SelectList(db.InicioSesionPerfiles, "Id", "Nombre");
                return Page();
            }
            
            db.Attach(Acceso.Audit(SessionId)).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccesoExists(Acceso.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Details", new { Acceso.Id });
        }

        private bool AccesoExists(int id)
        {
          return (db.IniciosSesion?.Any(a => a.Id == id)).GetValueOrDefault();
        }
    }
}
