namespace Hotel.App.Models.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AppointmentViewModel
    {
        [Required(ErrorMessage = "Моля, въведете име")]
        [MinLength(3, ErrorMessage = "Името не може да е по-късо от 3 символа"), MaxLength(50, ErrorMessage = "Името не може да е по-дълго от 50 символа")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Моля, въведете фамилия")]
        [MinLength(3, ErrorMessage = "Фамилията не може да е по-къса от 3 символа"), MaxLength(50, ErrorMessage = "Фамилията не може да е по-дълга от 50 символа")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Моля, въведете имейл")]
        [EmailAddress(ErrorMessage = "Моля, въведете валиден имейл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Моля, въведете телефон")]
        [RegularExpression("([\\d ]+)", ErrorMessage = "Моля, въведете валиден телефонен номер /само цифри/")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Моля, изберете брой")]
        [Range(1, 4, ErrorMessage = "Броят трябва да бъде между 1 и 4")]
        public int HosesCount { get; set; }

        [Required(ErrorMessage = "Моля, изберете начална дата")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Моля, изберете крайна дата")]
        public DateTime EndDate { get; set; }

        public string Comment { get; set; }
    }
}