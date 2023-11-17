 using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlogApp.Data;
using MyBlogApp.Models.Domain;
using MyBlogApp.Models.View_Models;
using System.Reflection.Metadata.Ecma335;

namespace MyBlogApp.Controllers
{
    public class AdminTagsController : Controller //This main controller comes from the package Microsoft.AspNetCore.Mvc
    {

        //This is a private variable that can be used inside this whole class anywhere, because we can't use constructor parameter anywhere else beside constructor itself
        private dbContextBlog _dbContextBlog;

        //This is costsructor injection for using Service from Program.cs where dependecy injections are
        public AdminTagsController(dbContextBlog dbContextBlog)
        {
            _dbContextBlog = dbContextBlog;
        }




        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {

            // Mapping AddTagRequest to domain model Tag.cs 
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };

            // await makes the method async truly async
            await _dbContextBlog.Tags.AddAsync(tag);
            await _dbContextBlog.SaveChangesAsync(); //This is a MUST if you want to save dbContext data to Database

            return RedirectToAction("List");
        }


        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            // use dbContextBlogs to read the tags from the Database
            var allTags = await _dbContextBlog.Tags.ToListAsync();

            return View(allTags);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var tag = await _dbContextBlog.Tags.FirstOrDefaultAsync(x => x.Id == id);

            if (tag != null)
            {
                // Mapping some Id to view model EditTagRequest.cs 
                var editTagRequest = new EditTagRequest 
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };

                return View(editTagRequest);
            }
            return View(null);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {

            //Mapping EditTagRequest to domain model Tag.cs 
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };

            var existingTag = await _dbContextBlog.Tags.FindAsync(tag.Id);

            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                await _dbContextBlog.SaveChangesAsync();

                //Show success notification
                return RedirectToAction("List", new { id = editTagRequest.Id });
            }
            //Show error notification
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete (EditTagRequest editTagRequest)
        {
               var tag = await _dbContextBlog.Tags.FindAsync(editTagRequest.Id);
                   
                    if(tag!=null)
                    {
                    _dbContextBlog.Tags.Remove(tag);
                    await _dbContextBlog.SaveChangesAsync();

                    //Show success notification
                    return RedirectToAction("List");
                    }

                //Show an error notification
                return RedirectToAction("Edit", new { id = editTagRequest.Id });
                
            }
    }
}