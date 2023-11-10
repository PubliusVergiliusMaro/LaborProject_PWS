using LaborProject_PWS.Services.EmailServices;
using LaborProject_PWS.Web.Models;
using LaborProject_PWS.Web.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LaborProject_PWS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IEmailSender _emailSender;
		public HomeController(ILogger<HomeController> logger, IEmailSender emailSender)
		{
			_logger = logger;
			_emailSender=emailSender;
		}
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> SendEmail([FromBody] EmailPropertyHttpPostModel vm)
		{
			var _vm = vm;
			if (_vm == null)
			{
				return BadRequest();
			}
			await _emailSender.SendEmailAsync(_vm.Email, "Test", _vm.MessageText);
			return Ok();
		}
		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}