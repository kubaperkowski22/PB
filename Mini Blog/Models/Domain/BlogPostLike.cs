namespace Bloggie.Web.Models.Domain
{
    public class BlogPostLike
    {
        public Guid Id { get; set; }
        public Guid BlockPostId { get; set; }    
        public Guid UserId { get; set; } 
    }
}
