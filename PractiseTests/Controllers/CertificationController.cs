using PractiseTests.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace PractiseTests.Controllers
{
    public class CertificationController : Controller
    {
        private readonly ICertificationRepository _repository;
        private readonly IPractiseTestListRepository _PractiseTestrepository;
        
        public CertificationController(ICertificationRepository repository, IPractiseTestListRepository PractiseTestrepository)
        {
            _repository = repository;
            _PractiseTestrepository = PractiseTestrepository;
        }
        public IActionResult Index()
        {
            var results = _repository.GetAll();
            return View(results);
        }
        public IActionResult DevOps()
        {

            var results = _repository.GetAll();
            return View(results);
        }

        //[HttpGet("PractiseTestList /{id}")]

        public IActionResult PractiseTestList(int id, int TestType)
        {
            TempData["CertificationId"] = id;
            TempData["TestType"] = TestType;
            //var results = _PractiseTestrepository.GetPractiseTestList(id, Convert.ToBoolean(TestType));
            // List<String> TestPaperList = results.Select(e => new { e.TestPaperName }).ToList();
            //.GroupBy(m => new { m.TestPaperName })
            //.DistinctBy(s => new { s.TestPaperName })
            //.ToList();

            List<String> TestPapersList = _PractiseTestrepository.GetPractiseTestList(id, Convert.ToBoolean(TestType));
            return View(TestPapersList.Distinct().ToList());
            

        }

        public IActionResult PractiseTestPaper(string TestPaper)
        {
            int Id = Convert.ToInt32(TempData["CertificationId"]);
            bool TestType = Convert.ToBoolean(TempData["TestType"]);
            var results = _PractiseTestrepository.GetTestPaper(Id, TestType, TestPaper);
            return View(results);
        }

        [HttpPost]
        public void SaveResults()
        {
            Response.Redirect("/Certification/DevOps");
        }

        [HttpPost]
        public IActionResult Calculatemarks()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveUserMarks()
        {
            return View();
        }
    }
}
