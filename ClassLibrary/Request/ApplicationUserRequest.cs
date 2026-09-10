using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary.Request
{
    public class ApplicationUserRequest : IdentityUser
    {
        //[Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        //[Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        //[Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [DisplayName("Role")]
        public string SelectRole { get; set; } = string.Empty;
    }
}
