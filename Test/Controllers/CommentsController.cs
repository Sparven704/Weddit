using GroupProj1Weddit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Test.Controllers;
using Test.Data;
using Test.Models;

namespace GroupProj1Weddit.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ILogger<CommentsController> _logger;
        private readonly ApplicationDbContext _context;

        public CommentsController(ILogger<CommentsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index(int id)
        {
            var post = _context.Posts.Include(p => p.Comments).FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        public IActionResult CreateComment(int id)
        {
            // Retrieve the post based on the id parameter
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            // Create a new Comment and associate it with the post
            var comment = new Comment();
            comment.PostId = post.Id;

            return View(comment);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            Console.WriteLine();
            if (ModelState.IsValid)
            {
                // Save the comment to the database
                _context.Comments.Add(comment);
                _context.SaveChanges();

                // Redirect back to the "Comments" view for the same post
                return RedirectToAction("Index", new { id = comment.PostId });
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
