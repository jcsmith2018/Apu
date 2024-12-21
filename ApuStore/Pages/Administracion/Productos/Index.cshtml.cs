using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApuStoreDb;
using Apu = ApuStoreDb.Models;
using ApuStoreDb.Models;

namespace ApuStore.Pages.Administracion.Productos
{
    public class IndexModel : ApuStorePageModel
    {        

        public IndexModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
          
        }

        public IList<Apu.Productos> Productos { get;set; } = default!;


        public async Task OnGetAsync()
        {
            Productos = await db.Productos.ToListAsync();

            IQueryable<Apu.Productos> query = db.Productos
                .Include(p => p.Tipo)
                .Include(p => p.Talla)
                .Include(p => p.Marca)
                .Include(p => p.Color);

            Productos = query.ToList();

        }
    }
}
