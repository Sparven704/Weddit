using System.ComponentModel.DataAnnotations;

namespace GroupProj1Weddit.Models.ViewModels
{
    public class CreatePostViewModel
    {
        public int TopicId { get; set; }

        [Required(ErrorMessage = "You must have a title")]
        [MaxLength(50, ErrorMessage = "Your title was too long")]
        public string Title { get; set; }

        [MaxLength(2000, ErrorMessage = "Your description was too long")]
        public string Description { get; set; }
    }
}
