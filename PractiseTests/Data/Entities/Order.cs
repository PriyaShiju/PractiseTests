using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseTests.Data.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNo { get; set; }
        //public ICollection<OrderItem> Items { get; set; }
        public string Active { get; set; } = "Y";
    }
}
