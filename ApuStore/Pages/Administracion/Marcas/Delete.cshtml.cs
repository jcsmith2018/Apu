using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApuStoreDb;
using ApuStoreDb.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApuStore.Pages.Administracion.Marcas
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : ApuStorePageModel
    {
       
        public DeleteModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
           
        }

        [BindProperty]
        public ProductosMarcas ProductosMarcas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productosmarcas = await db.ProductosMarcas.FirstOrDefaultAsync(m => m.Id == id);

            if (productosmarcas == null)
            {
                return NotFound();
            }
            else
            {
                ProductosMarcas = productosmarcas;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productosmarcas = await db.ProductosMarcas.FindAsync(id);
            if (productosmarcas != null)
            {
                ProductosMarcas = productosmarcas;
                db.Attach(ProductosMarcas.Borrar(SessionId)).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
