using PractiseTests.Data;
using PractiseTests.ViewModels;
using PractiseTests.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PractiseTests.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _repository;
        private readonly ILogger<Order> _logger;
        public OrderController(IOrderRepository repository, ILogger<Order> logger) 
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Order>> GetAll() 
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch(Exception ex) {
                _logger.LogError($"Failed to get Order:  {ex}");
                return BadRequest("Failed to get Order:  " + ex.Message);
            }
        }
        [HttpGet("{Id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]    //public IActionResult GetAll() {
        public IActionResult GetOrderById(int Id)
        {
            try
            {
                var order = _repository.GetOrderById(Id);
                if (order != null)
                    return Ok(order);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get Order: {ex}");
                return BadRequest("Failed to get Order");
            }
        }

        [HttpPost]
        public IActionResult SaveOrder([FromBody]OrderViewModel model)
        {   
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = new Order()
                    {
                        OrderDate = model.OrderDate,
                        OrderId = model.OrderId,
                        OrderNo = model.OrderNo
                    };

                    if (newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }
                    _repository.AddEntity(newOrder);


                    if (_repository.SaveChanges())
                    {
                        //var vm = new OrderViewModel()
                        //{
                        //    OrderId = newOrder.OrderId,
                        //    OrderNo = newOrder.OrderNo,
                        //    OrderDate = newOrder.OrderDate
                        //};
                        return Created($"/api/order/{newOrder.OrderId}", newOrder);
                    }     
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to add Entity {ex}");              
                
            }
            return BadRequest("Failed to Save Entity : " + model);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
