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
        
        
        public virtual IdentityUser User { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }

    }
}
