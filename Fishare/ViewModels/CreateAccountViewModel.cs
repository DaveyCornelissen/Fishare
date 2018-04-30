using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fishare.ViewModels
{
    public class CreateAccountViewModel
    {
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(60)]
        public string UserEmail { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(150)]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        public DateTime Birthday { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string PPath { get; set; }
    }
}
