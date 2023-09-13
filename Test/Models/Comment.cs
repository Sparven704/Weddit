using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupProj1Weddit.Models
{
    public class Comment
{
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CommentTime { get; set; }


        public virtual IdentityUser User { get; set; }
		[ForeignKey("Posts")]
		public int PostId { get; set; }

	}
}
