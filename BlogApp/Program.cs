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


// IoC container yani merkezi olarak uygulama kullan�lacak olan t�m nesnelerin instance bu dosya �zerinden IServiceColletion yap�s� ile y�netiliyor.

// service register i�lemi yap�yoruz.
// scoped service web programlar� i�in tan�mlanm�� web request bazl� instance olu�turlmas�na olanak sa�layan bir service lifetime scope hizmet.
// buradaki s�n�flar ne kadarl�k bir zaman aral���nda uygulamada instancelar� kullan�lacak.
// unmanagement resource api call, db call, upload gibi operasyonlarda 
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ICreatePostRequestService, CreatePostRequestService>();
builder.Services.AddScoped<IPostDomainService, PostDomainService>();

// Post iste�i yapt���m herhangi bir yerde constructor �zerinden post'un bo� instance halini alabilirim
// builder.Services.AddTransient<Post>(); interface olmadan sadece class yaz�larak da kullan�l�yor.

// not e�er servislerini repostory service ile birlikte kullan�rsan�z bu durumda scoped service tercih ediniz

// her bir �a��r�mda instance almam�z gereken s�n�flar�m�z varsa bu durumda tercih ederiz. Factory pattern kullanan s�n�flarda kullan�labilir, Yada Session, Valiation gibi her bir instance birbirinden farkl� olmas� gereken durumlada tercih edilir.
//builder.Services.AddTransient<>();

// Uygulama a��l�d��� an itibari ile single instance �al���r. Performans ama�l� kullan�lan bir teknik. Singleton Design Pattern kullan�r.
// Utils, Helper servicler single instance tan�mlanmal�d�r, NotificationManager.notify(),DateTimeHelper.getPrettyDate(); Math.Min();
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
