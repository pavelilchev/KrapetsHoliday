using System.ComponentModel.DataAnnotations;

namespace Hotel.App.Models.ViewModels
{
    public class EmailViewModel
    {
        [Required(ErrorMessage ="Името е задължително")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage ="Моля, въведете валиден имейл")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage ="Текста е задължителен")]
        public string Content { get; set; }
    }
}