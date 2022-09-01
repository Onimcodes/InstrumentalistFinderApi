using System.ComponentModel.DataAnnotations;

namespace InstrumentalistFinderApi.Models
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match")]
        public string ConfirmPassword {  get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public int YearsOfExperience { get; set; }   
        public int  Age { get; set; }
    }
}
