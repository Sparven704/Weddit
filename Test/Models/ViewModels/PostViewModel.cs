using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupProj1Weddit.Models.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        [DisplayName("Title")]
        [Required(ErrorMessage = "You must have a title")]
        [MaxLength(50, ErrorMessage = "Your title was too long")]
        public string Title { get; set; }

        [DisplayName("Description")]
        [MaxLength(2000, ErrorMessage = "Your description was too long")]
        public string Description { get; set; }
        public DateTime PostTime { get; set; } = DateTime.Now;

        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }
        [ForeignKey("Topic")]
        public int TopicId { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
