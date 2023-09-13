using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GroupProj1Weddit.Models.ViewModels
{
	public class CreateCommentViewModel
	{
		public int Id { get; set; }
		[ForeignKey("Post")]
		public int PostId { get; set; }

		[Required(ErrorMessage = "Please enter your comment")]
		[MaxLength(500, ErrorMessage = "Your comment is too long")]
		public string Content { get; set; }
		
	}
}
