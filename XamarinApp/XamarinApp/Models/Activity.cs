namespace XamarinApp.Models
{
    public class Activity
    {
        public int UserId { get; set; }
        public string Description { get; set; }

        public string ImageUrl => "https://picsum.photos/100";
    }
}
