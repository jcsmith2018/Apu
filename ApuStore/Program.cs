using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApuStoreDb;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<ApuStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApuStoreDbContext") ?? throw new InvalidOperationException("Connection string 'ApuStoreDbContext' not found.")));

builder.Services.AddDbContext<ApuDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApuStore"))
);


builder.Services.AddHttpsRedirection(options => options.HttpsPort = 7111);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => 
    {
        options.LoginPath = "/Access/Login";
        //options.LoginPath = "/Pages/Index";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.AccessDeniedPath = "/Access/AccessDenied";
    });
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.Run();
