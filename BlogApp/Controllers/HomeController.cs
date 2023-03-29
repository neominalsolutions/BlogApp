
using BlogApp.Domain.Entities;
using BlogApp.Models;
using BlogApp.Persistance.EF.Contexts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogApp.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {

      //var post = new Post("Post-1", "İçerik");
      //post.SetPostedBy("Mert");
      //post.AddComment("Mustafa", "Ne Güzel bir makale");
      //post.AddComment("Mustafa", "Ne Güzel bir makale");
      //post.Delete("Mustafa");

      //// commentleri post üzerinden okuyabilir.
      //post.Commments.ToList();

     


      //var db = new BlogAppContext();
      // tüm tagleri görmek için
      // db.Tags.ToList();
      // db.Posts.ToList();
      // db.Categories.ToList();
      //db.Posts.Add(post);
      //db.SaveChanges();

      // db.Posts.add(post); // hem commment hemde post veri tabanına eklenir.

      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}