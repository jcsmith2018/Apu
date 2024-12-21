using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApuStoreDb.Models;
using ApuStoreDb;
using Microsoft.AspNetCore.Authorization;

namespace ApuStore.Pages.Administracion.Tipos
{
    [Authorize(Roles = "1,Admin")]
    public class DeleteModel : ApuStorePageModel
    {      

        public DeleteModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
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

            var productostipo = await db.ProductosTipo.FirstOrDefaultAsync(m => m.Id == id);

            if (productostipo == null)
            {
                return NotFound();
            }
            else
            {
                ProductosTipo = productostipo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productostipo = await db.ProductosTipo.FindAsync(id);
            if (productostipo != null)
            {
                ProductosTipo = productostipo;                
                db.Attach(productostipo.Borrar(SessionId)).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
