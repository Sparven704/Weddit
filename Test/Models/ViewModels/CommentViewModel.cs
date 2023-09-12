using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GroupProj1Weddit.Models.ViewModels
{
    public class CommentViewModel
    {
        [DisplayName("Comment")]
        [Required(ErrorMessage = "You must have at least one letter in your comment")]
        [MaxLength(2000, ErrorMessage = "Too big of a comment")]
        public string Content { get; set; }
        public DateTime CommentTime { get; set; }


        public virtual IdentityUser User { get; set; }
    }
}
