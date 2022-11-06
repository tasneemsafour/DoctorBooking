using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorBooking.Models
{
    public class User
    {
        [Required(ErrorMessage = "This field is required.")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("Password")]
        public string confirmPassword { get; set; }
        public string Email { get; set; }
    }
}