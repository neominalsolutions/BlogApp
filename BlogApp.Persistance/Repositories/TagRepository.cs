using BlogApp.Domain.Contexts.BlogAppContext.Entities;
using BlogApp.Domain.Contexts.SeedWorks;
using System.Linq.Expressions;

namespace BlogApp.Repositories
{
  public class TagRepository : IRepository<Tag>
  {
    public Task AddAsync(Tag Entity)
    {
      throw new NotImplementedException();
    }

    public Task<List<Tag>> ListAsync()
    {
      throw new NotImplementedException();
    }

    public Task<List<Tag>> WhereAsync(Expression<Func<Tag, bool>> lamda)
    {
      throw new NotImplementedException();
    }
  }
}
