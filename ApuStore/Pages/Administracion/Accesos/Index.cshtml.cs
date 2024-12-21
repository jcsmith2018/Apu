using Microsoft.AspNetCore.Mvc;
using ApuStoreDb;
using ApuStoreDb.Models;
using Microsoft.AspNetCore.Authorization;
using ApuStore.Extensions;



namespace ApuStore.Pages.Administracion.Accesos
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : ApuStorePageModel
    {
        public IndexModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            ValorDeBusqueda = "";
        }

        [BindProperty(SupportsGet = true)]
        public string ValorDeBusqueda { get; set; }
        public List<IniciosSesion> Accesos { get; set; } = default!;
        

        public async Task OnGetAsync()
        {
            Accesos = new List<IniciosSesion>();
            Accesos.AddRange(await sesSvc.Buscar(ValorDeBusqueda));
            Accesos.ForEach(i => i.Roles = sesSvc.GetRoles(i));
        }
    }
}
