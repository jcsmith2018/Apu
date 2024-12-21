using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApuStoreDb;
using ApuStoreDb.Models;

namespace ApuStore.Pages.Administracion.Tallas
{
    public class IndexModel : ApuStorePageModel
    {
      
        public IndexModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
          
        }

        public IList<ProductosTallas> ProductosTallas { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ProductosTallas = await db.ProductosTallas.ToListAsync();
        }
    }
}
