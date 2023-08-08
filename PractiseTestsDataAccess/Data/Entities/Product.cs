using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseTests.Data.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string CategoryCode { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }

    }
}
