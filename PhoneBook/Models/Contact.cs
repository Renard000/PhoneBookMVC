using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhoneBook.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [StringLength(20, ErrorMessage = "Phone number must be 10 digits.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number.")]
        [Required]
        public string Phone { get; set; }

        [StringLength(100, ErrorMessage = "Email address is too long.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Display(Name = "Email Address")]
        [Required]
        public string Email { get; set; }
    }
}