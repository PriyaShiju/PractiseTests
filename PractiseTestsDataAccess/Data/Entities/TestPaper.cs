using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseTests.Data.Entities
{

    public class TestPaper
    {

        [Key]
        public int TestPaperId { get; set; } 

        public string TestPaperName { get; set; }

        public int CertificationTestId { get; set; }
        
        public int QuestionNo { get; set; }

        public string Question { get; set; }

        public string Answer1 { get; set; }

        public string Answer2 { get; set; }

        public string Answer3 { get; set; }

        public string Answer4 { get; set; }

        public string CorrectAnswer { get; set; }

        public bool Active { get; set; } 


    }
}
