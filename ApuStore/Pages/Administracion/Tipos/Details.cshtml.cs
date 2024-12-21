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
    public class DetailsModel : ApuStorePageModel
    {
       
        public DetailsModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            
        }

        public ProductosTipo ProductosTipo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productostipo = await sesSvc.GetProductosTipo().FirstOrDefaultAsync(m => m.Id == id);
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
    }
}
