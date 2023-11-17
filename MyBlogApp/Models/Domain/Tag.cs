namespace MyBlogApp.Models.Domain
{

        // This is a public class that we can use in our application
    public class Tag
    {
        // In this block of code, we are creating properties for this model, which we will use thruout our app

        // access modifier of this property * type of this property * name of this property * GETTERS and SETTERS
        public Guid Id{ get; set; } // Unique identifier - guid
        public string Name { get; set; }
        public string DisplayName { get; set; }

        // This is navigation property, where we are telling to Entity Framework Core that Tag can have muliple BlogPosts and vice versa
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
