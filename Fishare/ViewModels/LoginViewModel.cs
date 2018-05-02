using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fishare.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter your email adress!")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(60, ErrorMessage = "Your email must be less than {1} characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password!")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(255, ErrorMessage = "Your password must be less than {1} characters.")]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}
