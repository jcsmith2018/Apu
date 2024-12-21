using ApuStoreDb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApuStore.Pages.Administracion
{
    [Authorize(Roles="Admin")]
    public class IndexModel : ApuStorePageModel
    {
        public IndexModel(ApuDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
        }

        public void OnGet()
        {
        }
    }
}
