using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApuStoreDb;
using ApuStoreDb.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApuStore.Pages.Administracion.Tallas
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : ApuStorePageModel
    {        
        public CreateModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
           
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProductosTallas ProductosTallas { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.ProductosTallas.Add(ProductosTallas.Audit(SessionId));
            await db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
