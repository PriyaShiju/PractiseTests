using PractiseTests.Data;
using System.ComponentModel.DataAnnotations;

namespace PractiseTests.ViewModels
{
    public class CareerViewModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string ResumeUpload { get; set; }

        public string DocUpload { get; set; }

        public void FileUpload()
        {
            
        }
    }

}
