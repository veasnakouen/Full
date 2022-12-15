namespace Api.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; } = string.Empty;
        public long? UserId { get; set; }
        public DateTime? PostDatetime { get; set; }
        public string PostDescription { get; set; }=string.Empty;   
    }
}
