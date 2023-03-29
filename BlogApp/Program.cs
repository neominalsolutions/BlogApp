using BlogApp.Application.Services;
using BlogApp.Domain.Entities;
using BlogApp.Domain.Repositories;
using BlogApp.Domain.Services;
using BlogApp.Infra.Persistance.EF.Repositories;
using BlogApp.Persistance.EF.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogAppContext>(opt => opt.UseSqlServer( builder.Configuration.GetConnectionString("BlogContextConn")));


// IoC container yani merkezi olarak uygulama kullanýlacak olan tüm nesnelerin instance bu dosya üzerinden IServiceColletion yapýsý ile yönetiliyor.

// service register iþlemi yapýyoruz.
// scoped service web programlarý için tanýmlanmýþ web request bazlý instance oluþturlmasýna olanak saðlayan bir service lifetime scope hizmet.
// buradaki sýnýflar ne kadarlýk bir zaman aralýðýnda uygulamada instancelarý kullanýlacak.
// unmanagement resource api call, db call, upload gibi operasyonlarda 
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ICreatePostRequestService, CreatePostRequestService>();
builder.Services.AddScoped<IPostDomainService, PostDomainService>();

// Post isteði yaptýðým herhangi bir yerde constructor üzerinden post'un boþ instance halini alabilirim
// builder.Services.AddTransient<Post>(); interface olmadan sadece class yazýlarak da kullanýlýyor.

// not eðer servislerini repostory service ile birlikte kullanýrsanýz bu durumda scoped service tercih ediniz

// her bir çaðýrýmda instance almamýz gereken sýnýflarýmýz varsa bu durumda tercih ederiz. Factory pattern kullanan sýnýflarda kullanýlabilir, Yada Session, Valiation gibi her bir instance birbirinden farklý olmasý gereken durumlada tercih edilir.
//builder.Services.AddTransient<>();

// Uygulama açýlýdýðý an itibari ile single instance çalýþýr. Performans amaçlý kullanýlan bir teknik. Singleton Design Pattern kullanýr.
// Utils, Helper servicler single instance tanýmlanmalýdýr, NotificationManager.notify(),DateTimeHelper.getPrettyDate(); Math.Min();
//builder.Services.AddSingleton();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
