using BlogApp.Domain.Entities;
using BlogApp.Domain.Repositories;
using BlogApp.Domain.SeedWorks;
using BlogApp.Persistance.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Infra.Persistance.EF.Repositories
{
  public class PostRepository : IPostRepository
  {

    // Veri tabanı balantısı ve veri tabanındaki Entity Stateleri yönettiğimiz kısım. DB bazlı EF Altyapı hizmeti


    private readonly BlogAppContext _blogAppContext;


    public PostRepository(BlogAppContext blogAppContext)
    {
      _blogAppContext = blogAppContext;
    }

    public async Task AddAsync(Post Entity)
    {

      await _blogAppContext.Posts.AddAsync(Entity);

      try
      {
        int r = await _blogAppContext.SaveChangesAsync();
      }
      catch (Exception ex)
      {

        throw;
      }

       
    }


    public async Task<Post> FindAsync(Expression<Func<Post, bool>> lamda)
    {// Post ile birlikte Tags,Comments,Category çekilmeli
      return await _blogAppContext.Posts.AsNoTracking().FirstOrDefaultAsync(lamda);
    }

    /// <summary>
    /// Bütün gönderileri listeler
    /// </summary>
    /// <returns></returns>
    public async Task<List<Post>> ListAsync()
    {
      // Post ile birlikte Tags,Comments,Category çekilmeli
      // Include ThenInclude yapmamız gerekecek.
      return await _blogAppContext.Posts.AsNoTracking().ToListAsync();
    }

    /// <summary>
    /// Kritere göre sorgulama
    /// </summary>
    /// <param name="lamda"></param>
    /// <returns></returns>
    public async Task<List<Post>> WhereAsync(Expression<Func<Post, bool>> lamda)
    {// Post ile birlikte Tags,Comments,Category çekilmeli
      return await _blogAppContext.Posts.AsNoTracking().Where(lamda).ToListAsync();
    }
  }
}
