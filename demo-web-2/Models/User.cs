using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demo_web_2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Maximum 30 characters and minimum 6 characters")]
        [Required]
        public string UserName { get; set; }
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Maximum 30 characters and minimum 6 characters")]
        [Required]
        public string Password { get; set; }
    }
}
