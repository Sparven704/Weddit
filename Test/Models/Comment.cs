using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupProj1Weddit.Models
{
    public class Comment
{
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CommentTime { get; set; }


        //public virtual IdentityUser User { get; set; }
        //public virtual Post Post { get; set; }
        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }
        //public virtual IdentityUser User { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
    }
}
