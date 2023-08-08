using System.ComponentModel.DataAnnotations;

namespace PractiseTests.ViewModels
{
    public class OrderViewModel
    {
        
        public int OrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [MinLength(3)]
        public string OrderNo { get; set; }
    }
}
