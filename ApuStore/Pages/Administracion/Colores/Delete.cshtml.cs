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

namespace ApuStore.Pages.Administracion.Colores
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : ApuStorePageModel
    {
        
        public DeleteModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            
        }

        [BindProperty]
        public ProductosColores ProductosColores { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoscolores = await db.ProductosColores.FirstOrDefaultAsync(m => m.Id == id);

            if (productoscolores == null)
            {
                return NotFound();
            }
            else
            {
                ProductosColores = productoscolores;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoscolores = await db.ProductosColores.FindAsync(id);
            if (productoscolores != null)
            {
                ProductosColores = productoscolores;
                db.Attach(ProductosColores.Borrar(SessionId)).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
