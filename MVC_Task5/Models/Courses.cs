using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Timers;

namespace MVC_Task5.Models
    {
  
    public class Courses
        {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }
        //[RegularExpression(@"\d{2,2}/\d{2,2}/\d{4,4} \d{2,2}:\d{2,2}:\d{2,2}")]
      
        public DateTime? Hour { get; set; }
        public virtual List<User> Users { get; set; }
        


    }
    }
