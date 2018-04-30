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
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(60)]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}
