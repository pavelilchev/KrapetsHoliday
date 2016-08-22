namespace Hotel.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ReviewComment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Коментарът трябва да е дълъг поне 10 символа")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        public virtual User Author { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        [Required]
        public virtual Review Review { get; set; }

        public bool IsPublished { get; set; }
    }
}