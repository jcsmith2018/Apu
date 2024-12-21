using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApuStoreDb;
using ApuStoreDb.Models;

namespace ApuStore.Pages.Administracion.Productos
{
    public class DeleteModel : ApuStorePageModel
    {        

        public DeleteModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
          
        }

        [BindProperty]
        public ApuStoreDb.Models.Productos Productos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await db.Productos.FirstOrDefaultAsync(m => m.Id == id);

            if (productos == null)
            {
                return NotFound();
            }
            else
            {
                Productos = productos;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await db.Productos.FindAsync(id);
            if (productos != null)
            {
                Productos = productos;
                db.Productos.Remove(Productos);
                await db.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
