using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupProj1Weddit.Models.ViewModels
{
	public class PostsViewModel
	{
		public Post Post { get; set; }
		public List<CommentViewModel> Comments { get; set; }
	}
}
