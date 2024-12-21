using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApuStoreDb;
using ApuStoreDb.Models;
using NuGet.DependencyResolver;
using Microsoft.Data.SqlClient;

namespace ApuStore.Pages.Administracion.Productos
{
    public class DetailsModel : ApuStorePageModel
    {
       
        public DetailsModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
           
        }

        public ApuStoreDb.Models.Productos Productos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await db.Productos
                                    .Include(p => p.Tipo)
                                    .Include(p => p.Marca)
                                    .Include(p => p.Talla)
                                    .Include(p => p.Color)
                                    .Include(p => p.Fotos)
                                    .FirstOrDefaultAsync(m => m.Id == id);           

            if (productos == null)
            {
                return NotFound();
            }            

            Productos = productos;
            Fotos = new ProductosFotos { IdProducto = Productos.Id };
            

            return Page();
        }

        [BindProperty]
        public ProductosFotos Fotos { get; set; } = default!;

        [BindProperty]
        public IFormFile? SubirFoto { get; set; }
       
        public async Task<IActionResult> OnPostFotoAsync()
        {
            if (Fotos == null)
            {
                return NotFound();
            }
           
            using (var memoryStream = new MemoryStream())
            {
                await SubirFoto!.CopyToAsync(memoryStream);
                var fileBytes = memoryStream.ToArray();

                // Aquí guardas 'fileBytes' en la base de datos.
                Fotos.Foto = fileBytes;
                db.ProductosFotos.Add(Fotos.Audit(SessionId));
                await db.SaveChangesAsync();

            }
            return RedirectToPage("./Details", new { id = Fotos.IdProducto });
        }

        public IActionResult OnGetImage(int id)
        {
            var image = db.ProductosFotos.Find(id);
            if (image != null && image.Foto != null)
            {
                return File(image.Foto, "image/jpeg");
            }

            return NotFound();
        }

        public class FotoModel
        {
            public int Id { get; set; }
            public int IdProducto { get; set; }           
            public string? Descripcion { get; set; }
            public byte[]? Foto { get; set; }
            public int? Orden { get; set; }
        }

        [BindProperty]
        public FotoModel Foto { get; set; } = default!;

        public JsonResult OnGetFoto(int id)
        {
            return new JsonResult(db.ProductosFotos.Where(f => f.Id == id).FirstOrDefault());
        }

        public async Task<IActionResult> OnPostFotoEditAsync()
        {
            var fotoedit = await db.ProductosFotos.FirstAsync(t => t.Id == Foto.Id);
            if (fotoedit == null)
            {
                return NotFound();
            }
            
            fotoedit.Orden = Foto.Orden!;
            fotoedit.Descripcion = Foto.Descripcion;
            fotoedit.EdicionSesionId = SessionId;
            fotoedit.EdicionFecha = DateTime.Now;
            var foto = Request.Form.Files["SubirFoto"];
            if (foto != null && foto.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await foto.CopyToAsync(memoryStream);
                    var fileBytes = memoryStream.ToArray();
                    fotoedit.Foto = fileBytes;
                    
                }                
            }
            await db.SaveChangesAsync();
            return RedirectToPage("./Details", new { id = fotoedit.IdProducto });
        }
    }
}
