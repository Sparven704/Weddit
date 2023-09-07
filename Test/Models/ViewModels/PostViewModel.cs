using Microsoft.AspNetCore.Identity;

namespace GroupProj1Weddit.Models.ViewModels
{
    public class PostViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostTime { get; set; } = DateTime.Now;

        public virtual IdentityUser User { get; set; }
    }
}
