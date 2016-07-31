﻿namespace Hotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Review
    {
        public Review()
        {
           this.Comments = new HashSet<Comment>(); 
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        [Required]
        public virtual User Author { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
