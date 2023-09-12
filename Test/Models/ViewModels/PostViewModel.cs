using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GroupProj1Weddit.Models.ViewModels
{
    public class PostViewModel
    {
        [DisplayName("Title")]
        [Required(ErrorMessage = "You must have a title")]
        [MaxLength(50, ErrorMessage = "Your title was too long")]
        public string Title { get; set; }

        [DisplayName("Description")]
        [MaxLength(2000, ErrorMessage = "Your description was too long")]
        public string Description { get; set; }
        public DateTime PostTime { get; set; } = DateTime.Now;

        public virtual IdentityUser User { get; set; }
    }
}
