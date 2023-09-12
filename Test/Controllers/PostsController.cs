using GroupProj1Weddit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Test.Controllers;
using Test.Data;
using Test.Models;

namespace GroupProj1Weddit.Controllers
{
    public class PostsController : Controller
    {
        private readonly ILogger<PostsController> _logger;
        private readonly ApplicationDbContext _context;

        public PostsController(ILogger<PostsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index(int id)
        {
            var topic = _context.Topics.Include(t => t.Posts).FirstOrDefault(t => t.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        public IActionResult CreatePost(int id)
        {
            // Retrieve the topic based on the id parameter
            var topic = _context.Topics.FirstOrDefault(t => t.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            // Create a new Post and associate it with the topic
            var post = new Post();
            post.TopicId = topic.Id;
            // Assign the user ID to the post
            //post.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(post);
        }

        [HttpPost]
        public IActionResult CreatePost(Post post)
        {
            Console.WriteLine();
            if (ModelState.IsValid)
            {
                // Save the post to the database
                _context.Posts.Add(post);
                _context.SaveChanges();

                // Redirect back to the "Posts" view for the same topic
                return RedirectToAction("Index", new { id = post.TopicId });
            }

            // If validation fails, return the view with validation errors
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
