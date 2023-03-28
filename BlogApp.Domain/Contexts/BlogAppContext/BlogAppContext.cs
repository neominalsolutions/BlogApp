using BlogApp.Domain.Contexts.BlogAppContext.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain.Contexts.BlogAppContext
{
    public class BlogAppContext:DbContext
    {

    public BlogAppContext()
    {

    }

    // bu ops değeri sayesinde farklı veri kaynaklarına bağlanabiliyor.
    // addDbContext(Config.useNpgl())
    public BlogAppContext(DbContextOptions<BlogAppContext> opt):base(opt)
    {

    }

    // EF için Eğer Commentslere arayüzden direkt olarak bğlanmak istemiyorsak DbSet yazmak zorunda değilidi.
    public DbSet<Post> Posts { get; set; }

    public DbSet<Comment> Comments { get; set; }







  }
}
