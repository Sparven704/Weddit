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
		
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}