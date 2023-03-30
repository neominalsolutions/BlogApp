using BlogApp.Domain.Entities;
using BlogApp.Domain.Repositories;
using BlogApp.Infra.Persistance.EF.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Views.Shared.Components.PostList
{
  public class PostListViewComponent:ViewComponent
  {
    private readonly IPostRepository _postRepository;

    public PostListViewComponent(IPostRepository postRepository)
    {
      _postRepository = postRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync(string? categoryName, int? tagId)
    {
      var model = new List<Post>();

      tagId = (tagId == 0 ? null : tagId);


      if(string.IsNullOrEmpty(categoryName) && tagId == null)
      {
        model = await _postRepository.ListAsync();

      }
      else if(string.IsNullOrEmpty(categoryName) && tagId!=null)
      {
        model = await _postRepository.WhereAsync(x => x.Tags.Any(x=> x.Id == tagId));

      } else if(!string.IsNullOrEmpty(categoryName) && tagId == null)
      {
        model = await _postRepository.WhereAsync(x => EF.Functions.Like(x.Category.Name,categoryName));
     
      }
      else if (!string.IsNullOrEmpty(categoryName) && tagId != null)
      {
        model = await _postRepository.WhereAsync(x => EF.Functions.Like(x.Category.Name, categoryName) && x.Tags.Any(x => x.Id == tagId));
     
      }

      return View(model);

    }
  }
}
