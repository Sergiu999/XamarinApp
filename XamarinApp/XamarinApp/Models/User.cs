﻿namespace XamarinApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string ImageUrl => "https://picsum.photos/100";
    }
}
