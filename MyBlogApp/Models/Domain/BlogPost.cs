namespace MyBlogApp.Models.Domain
{



        // This is a public class that we can use in our application
    public class BlogPost
    {
        // In this block of code, we are creating properties for this model, which we will use thruout our app

        // access modifier of this property * type of this property * name of this property * GETTERS and SETTERS
        public Guid Id { get; set; } // Unique identifier - guid
        public string Heading { get; set; }
        public string PageTitle { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string imageURL{ get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }


        // This is navigation property, where we are telling to Entity Framework Core that this BlogPost can have muliple Tags and vice versa
        public ICollection<Tag> Tags { get; set; }
    }
}
