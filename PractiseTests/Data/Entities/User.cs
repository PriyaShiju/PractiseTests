using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseTests.Data.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

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
        public bool RememberMe { get; set; }



    }
}
