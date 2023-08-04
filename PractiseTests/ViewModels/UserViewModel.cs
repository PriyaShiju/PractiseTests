using System.ComponentModel.DataAnnotations;

namespace PractiseTests.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [MinLength(8)]    
        public string Password { get; set; } 
        /// <summary>
        /// https://www.c-sharpcorner.com/uploadfile/f9935e/password-policystrength-Asp-Net-mvc-validator/ 
        /// </summary>
        [Required]
        public string CPassword { get; set; }
        public Boolean RememberMe { get; set; }

        
    }
}
