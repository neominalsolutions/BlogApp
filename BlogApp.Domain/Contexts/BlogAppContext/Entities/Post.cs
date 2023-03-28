using BlogApp.Domain.Contexts.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain.Contexts.BlogAppContext.Entities
{
  // POCO Object
  public class Post:BaseEntity<string>, IDeletedEntity
  {
    public string Title { get; private set; }
    public string Content { get; private set; }

    public string PostedBy { get; private set; } // User Id

    public string DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }

    // navigation property
    // field üzerinden commentleri yöneteceğim fakat dışarıdan add methodlu çağırılmasın diye de IReadOnlyCollection yaptık
    private List<Comment> _comments = new List<Comment>();
    public IReadOnlyCollection<Comment> Commments => _comments;


    public Post(string title, string content, string by)
    {
      this.SetTitle(title);
      this.SetContent(content);
    }

    public void SetTitle(string title)
    {
      if(string.IsNullOrEmpty(title))
      {
        throw new Exception("Title değeri boş geçildi");
      }

      this.Title = title.Trim();
    }

    public void SetContent(string content)
    {
      this.Content = content;
    }

    public void PostBy(string postedBy)
    {
      this.PostedBy = postedBy;
    }


    public void Delete(string deletedBy)
    {
      this.DeletedBy = deletedBy;
      this.DeletedAt = DateTime.Now;
    }

    public void AddComment(string commentBy,string CommentText)
    {
      this._comments.Add(new Comment(commentBy, CommentText));

    }




  }
}
