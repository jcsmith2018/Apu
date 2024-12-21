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

namespace ApuStore.Pages.Administracion.Tallas
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : ApuStorePageModel
    {
        

        public DetailsModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
           
        }

        public ProductosTallas ProductosTallas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productostallas = await db.ProductosTallas.FirstOrDefaultAsync(m => m.Id == id);
            if (productostallas == null)
            {
                return NotFound();
            }
            else
            {
                ProductosTallas = productostallas;
            }
            return Page();
        }
    }
}
