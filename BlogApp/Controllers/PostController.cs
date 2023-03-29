﻿using BlogApp.Application.Models;
using BlogApp.Application.Services;
using BlogApp.Domain.Entities;
using BlogApp.Domain.Repositories;
using BlogApp.Persistance.EF.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers
{
  public class PostController: Controller
  {

    // ICreatePostRequestService türeyen her sınıf ile çalışabilir.
    // OCP Open Close Prensibine uygun kod yazdık
    // Application Katmanında Request bazlı Operasyonları ayırdığımız Single Responsibity yaptık
    // PostController nesnesine ve diğer katmanlardaki servislere bağımlıkları Arayüzler üzerinden uyguladık (Port and Adapter Mimarisi)  (MediaTR) kğütüphane IMeadiTR bu servis çağırılarını merkezi olarak yönetebilir. DI ile DIP prensibini kullandık
    // Her bir servis operasyonunu özerk otonom yaptık (Interface Seggragation Prensibe denk gelir.)
    // Liskovuda uyguladık ama tam manası ile değil.Interfacelerin Interfacleri implemente etmesi ile.
    // SOLID prensiplere dayanıyor.
    // IoC Inversion Of Controller (bağımlıkların merkezi yöntemi)
    // tight coupled uygulama geliştirme
    private readonly ICreatePostRequestService _createPostRequestService;
    private readonly IPostRepository _postRepository;
    private readonly BlogAppContext _context;

    public PostController(ICreatePostRequestService createPostRequestService, IPostRepository postRepository, BlogAppContext blogAppContext)
    {
      _createPostRequestService = createPostRequestService;
      _postRepository = postRepository;
      _context = blogAppContext;
    }


    public async Task<IActionResult> List()
    {



      // kendi view modelimize göre sql üzerindeki bir GetProductsWithCategoryName store proc çağırma işlemi

      //var param = new SqlParameter("@categoryId", 1);
      //var catProViews = _context.PcView.FromSqlRaw("GetProductsWithCategoryName @categoryId", param).ToList();

      var plist = await _postRepository.ListAsync();



      return View(plist);
    }



    // attribute routing CreatePost ovveride ederek create üzerinden route yaptık

    [HttpGet]
    public async Task<IActionResult> Create()
    {
      var request = new CreatePostRequest();
      request.CategoryName = "Kategori1";
      request.Content = "Gönderi İçerik 2";
      request.Title = "Gönderi2";
      request.Tags.Add("Tag1");
      request.Tags.Add("Tag2");
      request.Tags.Add("Tag3");

      // Presentation Layerdan Application Layer Invoke ettik.
      var response = await _createPostRequestService.HandleAsync(request);

       return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreatePostRequest @request)
    {
      // Presentation Layerdan Application Layer Invoke ettik.
      var response = await _createPostRequestService.HandleAsync(request);

      return View();
    }
  }
}
