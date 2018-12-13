using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GrapeWine.Models
{
    public class Customer
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [RegularExpression("[A-Za-z ]+")]
        public string CustName { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "Password must be between 7 and 14 characters"), MinLength(7, ErrorMessage = "Min ength is 7 characters")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [StringLength(10), MinLength(8)]
        public string Phone { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Would you like to be on our mailing list?")]
        public string MailList { get; set; }



    }
}