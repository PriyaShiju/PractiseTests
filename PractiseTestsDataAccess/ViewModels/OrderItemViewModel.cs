using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace PractiseTests.ViewModels
{
    public class OrderItemViewModel
    {
        public int OrderItemId { get; set; }
        //[ForeignKey("OrderId")]
        public int OrderId { get; set; } //order id details
        public DateTime OrderDate { get; set; }
        public string OrderNo { get; set; }
        public int ProductId { get; set; } // product Id details
        public string CategoryCode { get; set; }

        public decimal TotPrice { get; set; } = 0;

        public int Quantity { get; set; }
        //public int ProductId { get; set; }

        //public string CategoryCode { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public decimal Price { get; set; }

    }
}
