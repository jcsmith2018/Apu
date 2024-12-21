using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApuStoreDb;
using Apu = ApuStoreDb.Models;

namespace ApuStore.Pages.Administracion.Productos
{
    public class CreateModel : ApuStorePageModel
    {        
        public CreateModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
           
        }

        public IActionResult OnGet()
        {
            ViewData["Tipos"] = new SelectList(db.ProductosTipo.OrderBy(t => t.Nombre).ToList(), "Id", "Nombre");
            ViewData["Marcas"] = new SelectList(db.ProductosMarcas.OrderBy(t => t.Nombre).ToList(), "Id", "Nombre");
            ViewData["Tallas"] = new SelectList((db.ProductosTallas).ToList(),"Id", "Nombre");
            ViewData["Colores"] = new SelectList((db.ProductosColores).ToList(), "Id", "Nombre");


            return Page();
        }

        [BindProperty]
        public Apu.Productos Productos { get; set; } = default!;     
        

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Productos.Add(Productos.Audit(SessionId));
            await db.SaveChangesAsync();           

           return RedirectToPage("./Index");
        }
    }
}
