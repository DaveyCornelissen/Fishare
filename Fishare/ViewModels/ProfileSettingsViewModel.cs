using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fishare.ViewModels
{
    public class ProfileSettingsViewModel
    {
        [Required(ErrorMessage = "Please enter an email address!")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(60, ErrorMessage = "Your email must be less than {1} characters.")]
        public string UserEmail { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255, ErrorMessage = "Your password must be less than {1} characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter an first name!")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, ErrorMessage = "Your first name must be less than {1} characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter an last name!")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, ErrorMessage = "Your last name must be less than {1} characters.")]
        public string LastName { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime Birthday { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(20, ErrorMessage = "Your phone number must be less than {1} characters.")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string PPath { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255, ErrorMessage = "Your bio must be less than {1} characters.")]
        public string Bio { get; set; }
    }
}
