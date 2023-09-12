using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupProj1Weddit.Models.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }

        [Required(ErrorMessage = "Please enter your comment")]
        [MaxLength(500, ErrorMessage = "Your comment is too long")]
        public string Content { get; set; }
    }
}
