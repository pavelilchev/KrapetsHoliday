namespace Hotel.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        [Required]
        public virtual User Author { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        [Required]
        public virtual Review Review { get; set; }
    }
}