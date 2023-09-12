using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupProj1Weddit.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostTime { get; set; } = DateTime.Now;
        
        [ForeignKey("AspNetUsers")]      
        public string UserId { get; set; }
        //public virtual IdentityUser User { get; set; }

        [ForeignKey("Topic")]
        public int TopicId { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }

    }
}
