using GroupProj1Weddit.Models;
using GroupProj1Weddit.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
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
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CommentsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

            var commentViewModel = new CommentViewModel
            {
                PostId = post.Id
            };

            return View(commentViewModel);
        }

        [HttpPost]
        public IActionResult CreateComment(CommentViewModel commentViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.GetUserAsync(User).Result;
                if (user != null)
                {
                    var post = _context.Posts.FirstOrDefault(p => p.Id == commentViewModel.PostId);

                    if (post != null)
                    {
                        var comment = new Comment
                        {
                            Content = commentViewModel.Content,
                            CommentTime = DateTime.Now,
                            User = user,
                        };

                        post.Comments.Add(comment); // Associate the comment with the post

                        _context.SaveChanges();

                        return RedirectToAction("Index", new { id = commentViewModel.PostId });
                    }
                }
            }

            return View(commentViewModel);
        }
    }
}
