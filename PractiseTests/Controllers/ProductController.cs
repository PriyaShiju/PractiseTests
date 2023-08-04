using PractiseTests.Data;
using PractiseTests.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PractiseTests.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<Product> _logger;

        public ProductController(IProductRepository repository, ILogger<Product> logger) 
        {
            _repository = repository;
            _logger= logger; 
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]    //public IActionResult GetAll() {
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to get Product: {ex}");
                return BadRequest("Failed to get Product");
            }
        }
        [HttpGet("{Id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]    //public IActionResult GetAll() {
        public IActionResult GetProductById(int Id)
        {
            try
            {
                var product = _repository.GetProductById(Id);
                if (product != null)
                    return Ok(product);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get Product: {ex}");
                return BadRequest("Failed to get Product");
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
