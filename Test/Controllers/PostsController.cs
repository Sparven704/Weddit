using GroupProj1Weddit.Models;
using GroupProj1Weddit.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Test.Data;
using Microsoft.Extensions.Hosting;

namespace GroupProj1Weddit.Controllers
{
    public class PostsController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PostsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index(int id)
        {
            var topic = _context.Topics.Include(t => t.Posts).FirstOrDefault(t => t.Id == id);

            if (topic == null)
            {
                return NotFound();
            }

            var topicViewModel = new TopicViewModel
            {
                Id = topic.Id,
                Name = topic.Name,
                Description = topic.Description,
                Posts = topic.Posts.ToList()
            };

            ViewBag.SomeVariable = id;

            return View(topicViewModel);
        }

        public IActionResult CreatePost(int id)
        {
            var topic = _context.Topics.FirstOrDefault(t => t.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            var createPostViewModel = new CreatePostViewModel
            {
				TopicId = topic.Id
            };
			Console.WriteLine(createPostViewModel.TopicId);
			Console.WriteLine(topic.Id);
			ViewBag.SomeVariable = id;

            return View(createPostViewModel);
        }

        [HttpPost]
        public IActionResult CreatePost(CreatePostViewModel createPostViewModel)
        {
			if (ModelState.IsValid)
            {
                var user = _userManager.GetUserAsync(User).Result; // Retrieve current user
                if (user != null)
                {
                    // Map CreatePostViewModel to Post
                    var post = new Post
                    {
                        Title = createPostViewModel.Title,
                        Description = createPostViewModel.Description,
                        PostTime = DateTime.Now,
                        User = user,
                        TopicId = createPostViewModel.TopicId
                    };
                    Console.WriteLine(post.TopicId);
                    // Save the post to the database
                    _context.Posts.Add(post);
                    _context.SaveChanges();

       
                    return RedirectToAction("Index", new { id = post.TopicId });
                }
            }
            return View(createPostViewModel);
        }

    }
}
