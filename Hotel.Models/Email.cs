namespace Hotel.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Email
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Текста е задължителен")]
        public string Content { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
