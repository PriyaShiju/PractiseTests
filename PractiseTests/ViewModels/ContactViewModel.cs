using System.ComponentModel.DataAnnotations;

namespace PractiseTests.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; } 
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [MaxLength(255)]
        public string Message { get; set; }

        

    }
}
