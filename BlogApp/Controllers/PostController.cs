using BlogApp.Application.Models;
using BlogApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
  public class PostController: Controller
  {

    private readonly ICreatePostRequestService _createPostRequestService;

    public PostController(ICreatePostRequestService createPostRequestService)
    {
      _createPostRequestService = createPostRequestService;
    }

    // attribute routing CreatePost ovveride ederek create üzerinden route yaptık

    [HttpGet]
    public async Task<IActionResult> Create()
    {
      var request = new CreatePostRequest();
      request.CategoryName = "Kategori1";
      request.Content = "Gönderi İçerik 1";
      request.Title = "Gönderi1";
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
