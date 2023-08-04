using PractiseTests.Data;
using PractiseTests.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace PractiseTests.Controllers
{
    //[Route("api/[Controller]")]
    public class CareerController : Controller
    {
        //private readonly ICareerRepository _careerrepository;
        //public CareerController(ICertificationRepository, ILogger<> ) { }
        //public CareerController(ICareerRepository career)
        //{
        //    _careerrepository = career;
        //}

        public IActionResult Career()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FileUpload()
        {
            //_careerrepository.FileUpload();
            return View();
        }

        
    }
}
