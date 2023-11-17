 namespace MyBlogApp.Models.View_Models
{

    // This is a public class that we can use in our application
    public class AddTagRequest
    {

        // In this block of code, we are creating properties for this model, which we will use for transfer form input values to the Database
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
