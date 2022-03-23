using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.DTOs
{
    public class ApplicationUserRegisterDto
    {
        [Required]
        public string Email { get; set; }
        [Required ]
        public string Password { get; set; }

    }

    public class ApplicationUserLoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
