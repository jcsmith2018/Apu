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
    public class IndexModel : ApuStorePageModel
    {    

        public IndexModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            
        }

        public IList<ProductosColores> ProductosColores { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ProductosColores = await db.ProductosColores.ToListAsync();
        }
    }
}
