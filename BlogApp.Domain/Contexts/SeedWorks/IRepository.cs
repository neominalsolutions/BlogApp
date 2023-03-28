using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain.Contexts.SeedWorks
{

  // Code Defensing ile sadece IEntity Interface impement olan sınıf ile çalış
  public interface IRepository<T> where T: IEntity
  {
    Task AddAsync(T Entity);
    Task<List<T>> ListAsync();
    Task<List<T>> WhereAsync(Expression<Func<T, bool>> lamda);
  }
}
