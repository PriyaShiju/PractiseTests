using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseTests.Data.Entities
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        //[ForeignKey("OrderId")]
        public int OrderId { get; set; } //order id details
        public int ProductId { get; set; } // product Id details
        public string CategoryCode { get; set; }

        public decimal TotPrice { get; set; } = 0;

        public int Quantity { get; set; }

       




    }
}
