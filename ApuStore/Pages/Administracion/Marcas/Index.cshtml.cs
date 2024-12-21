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
    public class IndexModel : ApuStorePageModel
    {
       
        public IndexModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            
        }

        public IList<ProductosMarcas> ProductosMarcas { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ProductosMarcas = await db.ProductosMarcas.ToListAsync();
        }
    }
}
