﻿using System.ComponentModel.DataAnnotations;

namespace InstrumentalistFinderApi.Models
{
    public class Login
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        
    }
}
