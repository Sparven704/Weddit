using GroupProj1Weddit.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    public class TopicsController : Controller
    {
        private readonly ILogger<TopicsController> _logger;
        private readonly ApplicationDbContext _context;

        public TopicsController(ILogger<TopicsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            List<Topic> topics = _context.Topics.ToList();
            return View(topics);
        }


        public IActionResult Posts(int id)
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

            return View(post);
        }

        [HttpPost]
        public IActionResult CreatePost(Post post)
        {
            if (ModelState.IsValid)
            {

                // Save the post to the database
                _context.Posts.Add(post);
                _context.SaveChanges();

                // Redirect back to the "Posts" view for the same topic
                return RedirectToAction("Posts", new { id = post.TopicId });
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