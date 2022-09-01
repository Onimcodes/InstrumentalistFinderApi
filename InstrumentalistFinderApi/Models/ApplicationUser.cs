using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace InstrumentalistFinderApi.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string State { get; set; }
        [Required]
        public string Street { get; set; }
        
        public int YearsOfExperience { get; set; }   
        public int Age { get; set; }        
    }
}
