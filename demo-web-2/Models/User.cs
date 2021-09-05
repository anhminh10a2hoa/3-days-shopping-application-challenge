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
        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string UserName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
