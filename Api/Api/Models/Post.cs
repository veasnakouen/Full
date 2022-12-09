namespace Api.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; } = string.Empty;
        public int MyProperty { get; set; }
        public int UserId { get; set; }
        public DateTime PostDatetime { get; set; }=DateTime.Now;
        public string PostDescription { get; set; }=string.Empty;   
    }
}
