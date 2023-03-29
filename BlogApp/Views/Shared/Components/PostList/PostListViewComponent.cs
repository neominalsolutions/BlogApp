using BlogApp.Domain.Repositories;
using BlogApp.Infra.Persistance.EF.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Views.Shared.Components.PostList
{
  public class PostListViewComponent:ViewComponent
  {
    private readonly IPostRepository _postRepository;

    public PostListViewComponent(IPostRepository postRepository)
    {
      _postRepository = postRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync(string? categoryName)
    {

      if(string.IsNullOrEmpty(categoryName))
      {
        return View( await _postRepository.ListAsync());
      }

      var model = await _postRepository.WhereAsync(x => x.Category.Name == categoryName);

      return View(model);
    }
  }
}
