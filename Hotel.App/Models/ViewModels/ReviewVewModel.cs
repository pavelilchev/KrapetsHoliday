namespace Hotel.App.Models.ViewModels
{
    using System;
    using Hotel.Models;

    public class ReviewVewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public virtual User Author { get; set; }

        public DateTime CreationDate { get; set; }

        public int Rating { get; set; }

        public int CommentsCount { get; set; }
    }
}