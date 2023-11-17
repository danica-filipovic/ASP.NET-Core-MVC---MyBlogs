namespace MyBlogApp.Models.View_Models
{

    // This is a public class that we can use in our application
    public class EditTagRequest
    {

    
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string DisplayName { get; set; }

    }
}
