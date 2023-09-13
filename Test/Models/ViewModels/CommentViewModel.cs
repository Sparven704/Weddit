namespace GroupProj1Weddit.Models.ViewModels
{
	public class CommentViewModel
	{
		public string Content { get; set; }
		public string UserName { get; set; }
		public DateTime CommentTime { get; set; } = DateTime.Now;
    }
}
