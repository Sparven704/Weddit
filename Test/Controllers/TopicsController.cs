using GroupProj1Weddit.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
            List<TopicViewModel> topicViewModels = _context.Topics.Select(topic => new TopicViewModel
           {
               Id = topic.Id,
               Name = topic.Name,
               Description = topic.Description,
               Posts = topic.Posts
           })
           .ToList();

            return View(topicViewModels);
        }
		
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}