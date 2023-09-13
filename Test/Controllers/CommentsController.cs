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
            // Retrieves post with matching id and loads in all associated comments to memory
			var post = _context.Posts.Include(p => p.Comments).FirstOrDefault(p => p.Id == id);
			if (post == null)
			{
				return NotFound();
			}

            var user = _userManager.GetUserAsync(User).Result; // Retrieve current user

            // Create a list of CommentViewModel objects
            var commentViewModels = post.Comments.Select(comment => new CommentViewModel
			{ 
                Content = comment.Content,
				UserName = user.UserName,
				CommentTime = comment.CommentTime
			}).ToList();

			var model = new PostsViewModel
			{
				Post = post,
				Comments = commentViewModels
			};

			return View(model);
		}

		public IActionResult CreateComment(int id)
        {
            // Retrieve the post based on the id
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            var createCommentViewModel = new CreateCommentViewModel
            {
                PostId = post.Id
            };

            return View(createCommentViewModel);
        }


        [HttpPost]
        public IActionResult CreateComment(CreateCommentViewModel createCommentViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.GetUserAsync(User).Result;
                if (user != null)
                {
                    var post = _context.Posts.Include(p => p.Comments).FirstOrDefault(p => p.Id == createCommentViewModel.PostId);

                    if (post != null)
                    {
                        // Maps ViewModel to model
                        var comment = new Comment
                        {
                            Content = createCommentViewModel.Content,
                            CommentTime = DateTime.Now,
                            User = user,
                            PostId = createCommentViewModel.PostId
                        };
                        // Save the Comment to the database
                        _context.Comments.Add(comment);
                        _context.SaveChanges();

                        return RedirectToAction("Index", new { id = createCommentViewModel.PostId });
                    }
                }
            }

            return View(createCommentViewModel);
        }

    }
}
