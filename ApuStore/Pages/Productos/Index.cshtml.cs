using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApuStoreDb;
using ApuStoreDb.Models;
using Apu = ApuStoreDb.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace ApuStore.Pages.Productos
{
    public class IndexModel : ApuStorePageModel
    {

        public IndexModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {

        }

        public IList<Apu.Productos> Productos { get; set; } = default!;

        public IList<ProductosFotos> Fotos { get; set; } = default!;

        public Task OnGetAsync()
        {
            var products = db.Productos
                             .Include(p => p.Tipo)
                             .Include(p => p.Marca)
                             .Include(p => p.Talla)
                             .Include(p => p.Color)
                             .Include(f => f.Fotos).ToList();

            foreach (var r in products)
            {
                foreach (var foto in r.Fotos!)
                {
                    var query = db.ProductosFotos.Where(f => f.Orden == 1).AsQueryable();
                    Fotos = query.ToList();
                }
            }
            return Task.CompletedTask;
        }
    }
}
