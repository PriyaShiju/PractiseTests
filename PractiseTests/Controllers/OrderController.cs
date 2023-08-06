using PractiseTests.Data;
using PractiseTests.ViewModels;
using PractiseTests.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PractiseTests.Areas.Identity.Data;

namespace PractiseTests.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _repository;
        private readonly ILogger<Order> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<PractiseTestsUser> _userManager;
        private readonly SignInManager<PractiseTestsUser> _signInManager;

        
        public OrderController(IOrderRepository repository, ILogger<Order> logger, IMapper mapper) 
        {
            _repository = repository;
            _logger = logger;
            this._mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<OrderViewModel>> GetAll() 
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<OrderViewModel>>(_repository.GetAll()));
                //_mapper.Map<IEnumerable<OrderViewModel>>
            }
            catch (Exception ex) {
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
                    return Ok(_mapper.Map<Order,OrderViewModel>(order));
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
                    var newOrder = _mapper.Map<OrderViewModel,Order>(model);
                    //var newOrder = new Order()
                    //{
                    //    OrderDate = model.OrderDate,
                    //    OrderId = model.OrderId,
                    //    OrderNo = model.OrderNo
                    //};

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

        //public IActionResult Index( UserManager<PractiseTestsUser> userManager, SignInManager<PractiseTestsUser> signInManager)
        //    {
        //        _userManager = userManager;
        //        _signInManager = signInManager;
        //    }
        }
}
