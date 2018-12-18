﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CA_B8IT121.Models
{
    public class Customer
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [RegularExpression("[A-Za-z ]+")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [RegularExpression("[A-Za-z0-9]+")]
       [StringLength (14, ErrorMessage ="Password must be less than 14 characters"), MinLength(7, ErrorMessage ="Min ength is 7 characters")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10), MinLength(8)]
        public string Phone { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Display(Name ="Would you like to be on our mailing list?")]
        public string MailList { get; set; }

        [Required]
        [Display(Name = "Are you a ")]
        public string CustType { get; set; }
    }
}