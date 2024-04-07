using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Task5.Models
    {
   
    public record User
        {
        [Key]
        public int id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
      
        public int Age { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required]
        [MaxLength(150)]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [MaxLength(150)]
        public string? ConfirmPassword { get; set; }
        [MaxLength(150)]
        public string? email { get; set; }
     
        [ForeignKey(nameof(courses))]
        [DisplayName("courses")]
        public int? coursesId { get; set; }
        public Courses? courses { get; set; }
    }
    }
