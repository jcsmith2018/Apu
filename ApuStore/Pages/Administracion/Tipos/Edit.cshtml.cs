using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApuStoreDb.Models;
using Microsoft.AspNetCore.Authorization;
using ApuStoreDb;

namespace ApuStore.Pages.Administracion.Tipos
{
    [Authorize(Roles = "1,Admin")]
    public class EditModel : ApuStorePageModel
    {
       
        public EditModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            
        }

        [BindProperty]
        public ProductosTipo ProductosTipo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productostipo =  await sesSvc.GetProductosTipo().FirstOrDefaultAsync(m => m.Id == id);
            if (productostipo == null)
            {
                return NotFound();
            }
            ProductosTipo = productostipo;
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
                       
            db.Attach(ProductosTipo.Audit(SessionId)).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosTipoExists(ProductosTipo.Id))
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

        private bool ProductosTipoExists(int id)
        {
            return db.ProductosTipo.Any(e => e.Id == id);
        }
    }
}
