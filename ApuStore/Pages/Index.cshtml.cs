using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApuStoreDb;
using ApuStoreDb.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ApuStore.Pages
{
    //[Authorize]
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