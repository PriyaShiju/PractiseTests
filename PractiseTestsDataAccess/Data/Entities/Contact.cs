using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseTests.Data.Entities
{
    public class Contact
    {

        [Key]
        public int ContactId { get; set; }
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
