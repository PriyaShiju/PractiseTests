using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseTests.Data.Entities
{
    public class ProductCategory
    {
        [Key]
       public int ProdCategoryId { get; set; }
        public string CategoryCode { get; set; }
       public string CategoryName { get; set; }
    }
}
