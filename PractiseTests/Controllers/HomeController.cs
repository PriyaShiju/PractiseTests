using PractiseTests.Models;
using PractiseTests.ViewModels;
using PractiseTests.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;
using PractiseTests.Data;

namespace PractiseTests.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IMailService _mailservice;
        //private readonly CertificationDbContext _context;
        private readonly ICertificationRepository _repository;
        private readonly string AdminEmail = "itsmepriyap@gmail.com";
        private readonly int intPwdLength = 8;
        private UserViewModel _user;
        private string strChangePasswordUrl = "http://localhost:/ChangePassword";

        public HomeController(IMailService mailservice,ICertificationRepository repository)
        {
            _mailservice = mailservice;
            //_context = context;
            _repository = repository;
            //_user = new UserViewModel();
        }

        public IActionResult Index()
        {
            //var results = from p in _context.certifications orderby p.CertificationName select p 
            // return View(results.ToList());

            //var results = _context.Certifications.OrderBy(p => p.CertificationName)
             // .ToList();

            var results = _repository.GetAll();
            return View(results);

            //return View();
        }
        [HttpGet("Contact")]
        public IActionResult Contact()
        {

            return View();
        }
        [HttpPost("Contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailservice.SendMessage(model.Name, model.EmailAddress, AdminEmail, model.Subject, model.Message);
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            else
            {
                ViewBag.ErrorMessage = "Mail not sent successfully, please try after sometime...";
            }

            return View();
        }
        public IActionResult Careers()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Aboutus()
        {

            return View();
        }
        public IActionResult Copyright()
        {

            return View();
        }
        public IActionResult Terms()
        {

            return View();
        }
        public IActionResult Checkout()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }
          
        public string GetChangePasswordLink()
        {
        return "<a href='"+ strChangePasswordUrl + "' target='_blank'> Change Password </a> ";
        }

        [HttpPost]
        public IActionResult ForgotPassword(string EMailAddress) 
        {
            UserViewModel model = _user;//.fetch(EmailAddress= EMailAddress);
            string strMessage = "Your password is updated with new password "+ getRandomPassword() + " and We strongly recommend you to click the link " + GetChangePasswordLink() +" and update the password.";
            _mailservice.SendMessage(model.Name, AdminEmail, model.EmailAddress, "Reset Password", strMessage);
            ViewBag.UserMessage = "The email is send to you with the updated password and we recommend you to click the link and update the password.";
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }

        public string getRandomPassword()
        {
            string allowedChars = "";

            allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";

            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";

            allowedChars += "1,2,3,4,5,6,7,8,9,0,!,@,#,$,%,&,?";

            char[] sep = { ',' };

            string[] arr = allowedChars.Split(sep);

            string passwordString = "";

            string temp = "";

            Random rand = new Random();

            for (int i = 0; i < intPwdLength; i++)

            {

                temp = arr[rand.Next(0, arr.Length)];

                passwordString += temp;

            }

            return passwordString;

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}