namespace Hotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Review
    {
        public Review()
        {
           this.Comments = new HashSet<ReviewComment>(); 
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(20, ErrorMessage = "Отзивът трябва да е поне 20 символа дълъг.")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public virtual User Author { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public int Rating { get; set; }

        public virtual ICollection<ReviewComment> Comments { get; set; }

        public bool IsPublished { get; set; }
    }
}
