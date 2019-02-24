using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K_Systems.Presentation.Web.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Key]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(256,MinimumLength =6,ErrorMessage = "Maximum lenght for {0} is 256 and minimum is 6")]
        public string Password { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }
    }
}