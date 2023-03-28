using BlogApp.Domain.Contexts.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain.Contexts.BlogAppContext.Entities
{
  public class Comment:BaseEntity<string>
  {
 
    public string Text { get; set; }
    public string By { get; set; }
    public DateTime? IssuedAt { get; set; }



    public Comment(string by,string text)
    {
      Id = Guid.NewGuid().ToString();
      IssuedAt = DateTime.Now;
    }

  }
}
