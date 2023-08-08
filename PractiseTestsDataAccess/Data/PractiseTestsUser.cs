using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseTests.Areas.Identity.Data
{
    public class PractiseTestsUser : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public override string Id { get; set; }

        [PersonalData]
        public string UserName { get; set; }
        //[PersonalData]
        //public DateTime DOB { get; set; }


    }
}
