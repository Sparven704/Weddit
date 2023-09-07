using Microsoft.AspNetCore.Identity;

namespace GroupProj1Weddit.Models.ViewModels
{
    public class CommentViewModel
    {
        public string Content { get; set; }
        public DateTime CommentTime { get; set; }


        public virtual IdentityUser User { get; set; }
    }
}
