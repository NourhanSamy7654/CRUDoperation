using System.ComponentModel.DataAnnotations;

namespace MVC_Task5.Models.View_Model
    {
    public class UserVald
        {
       public int id { get; set; }


        [Required(ErrorMessage = "*")]
        [MaxLength(30), MinLength(3, ErrorMessage = "Name must be greater than 2 letters.")]
        public string Name { get; set; }


        [Range(20,66,ErrorMessage = "{0} Must be between {1} and {2}")]
        public int Age { get; set; }


        [Required(ErrorMessage = "******")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string? email { get; set; }


        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }

        public int coursesId { get; set; }
    }
    }
