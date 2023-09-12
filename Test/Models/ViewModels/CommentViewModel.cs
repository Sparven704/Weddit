using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupProj1Weddit.Models.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        [DisplayName("Comment")]
        [Required(ErrorMessage = "You must have at least one letter in your comment")]
        [MaxLength(2000, ErrorMessage = "Too big of a comment")]
        public string Content { get; set; }
        public DateTime CommentTime { get; set; }


        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
    }
}
