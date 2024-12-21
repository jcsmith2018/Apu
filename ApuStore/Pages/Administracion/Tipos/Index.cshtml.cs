using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApuStoreDb.Models;
using ApuStoreDb;
//using Apu = ApuStoreDb.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApuStore.Pages.Administracion.Tipos
{
    [Authorize(Roles = "1,Admin")]
    public class IndexModel : ApuStorePageModel
    {        

        public IndexModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            
        }

        public IList<ProductosTipo> ProductosTipo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            IQueryable<ProductosTipo> query = sesSvc.GetProductosTipo();   

            ProductosTipo = await query.ToListAsync();
        }
    }
}
