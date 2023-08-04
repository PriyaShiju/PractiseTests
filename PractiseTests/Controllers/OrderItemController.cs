using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PractiseTests.Data.Entities;
using PractiseTests.Data;
using PractiseTests.ViewModels;

namespace PractiseTests.Controllers
{
    [Route("/api/order/{OrderId}/items")]
    public class OrderItemController : Controller
    {
        private readonly IOrderRepository _repository;
        private readonly ILogger<OrderItemController> _logger;
        private readonly IMapper _mapper;

        public OrderItemController(IOrderRepository repository, ILogger<OrderItemController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            this._mapper = mapper;
        }

        [HttpGet] //("{Id:int}")
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]    //public IActionResult GetAll() {
        public IActionResult GetItemsById(int Id)
        {
            try
            {
                var order = _repository.GetItemsById(Id);
                if (order != null)
                    return Ok(_mapper.Map<IEnumerable<OrderItemViewModel>>(order));
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get Items: {ex}");
                return BadRequest("Failed to get Items");
            }
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
