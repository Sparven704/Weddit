using Microsoft.AspNetCore.Mvc;

namespace GroupProj1Weddit.Controllers
{
    public class PostsController : Controller
    {
        public IActionResult Posts()
        {
            return View();
        }
        public IActionResult Comments()
        {
            return View();
        }
    }
}
