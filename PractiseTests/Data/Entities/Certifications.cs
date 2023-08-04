using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseTests.Data.Entities
{
    public class Certifications //:Product
    {
        [Key]
        public int CertificationTestId { get; set; }

        //public int ProductId { get; set; } = 1;
        public string CertificationName { get; set; } //DevOps

        public string CertificationDescription { get; set; }

        //[DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int NoTestPapers { get; set; }

        public int Questions { get; set; }

        public string FileName { get; set; }

        public Boolean Active { get; set; }
        
    }
}
