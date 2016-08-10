namespace Hotel.App.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ReviewCommentViewModel
    {
        [Required]
        [MinLength(10, ErrorMessage = "Коментарът трябва да е дълъг поне 10 символа")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }   

        [Required]
        public int ReviewId { get; set; }
    }
}