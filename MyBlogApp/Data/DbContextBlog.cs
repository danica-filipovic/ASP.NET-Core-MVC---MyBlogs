using Microsoft.EntityFrameworkCore; // using statment package
using MyBlogApp.Models.Domain;

namespace MyBlogApp.Data
{
    // This is a public class that we can use in our application
    public class dbContextBlog : DbContext // dbContextBlog class inherits from DbContext (that comes from Microsoft.EntityFrameworkCore package)  
    {   
        // This block of code is a Constructor
        public dbContextBlog(DbContextOptions options) : base(options)
        {

        }

        // In this block of code, we created Tables (Entities) that Entity Framework will create inside DataBase

        public DbSet<BlogPost> BlogPosts { get; set; } // Table 1
        public DbSet<Tag> Tags { get; set; } // Table 2
    }
}
