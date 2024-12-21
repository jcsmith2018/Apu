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

namespace ApuStore.Pages.Administracion.Marcas
{
    [Authorize(Roles = "Admin")]
    public class EditModel : ApuStorePageModel
    {
       
        public EditModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
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

            var productosmarcas =  await db.ProductosMarcas.FirstOrDefaultAsync(m => m.Id == id);
            if (productosmarcas == null)
            {
                return NotFound();
            }
            ProductosMarcas = productosmarcas;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Attach(ProductosMarcas.Audit(SessionId)).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosMarcasExists(ProductosMarcas.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductosMarcasExists(int id)
        {
            return db.ProductosMarcas.Any(e => e.Id == id);
        }
    }
}
