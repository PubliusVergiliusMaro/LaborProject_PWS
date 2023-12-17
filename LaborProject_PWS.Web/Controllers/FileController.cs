using Microsoft.AspNetCore.Mvc;

namespace LaborProject_PWS.Web.Controllers
{
	public class FileController : Controller
	{
		private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
		public FileController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
		{
			_hostingEnvironment = hostingEnvironment;
		}
		[HttpGet]
		public IActionResult Index()
		{
			var filesPath = Path.Combine(_hostingEnvironment.WebRootPath, "files");
			var files = Directory.GetFiles(filesPath).Select(Path.GetFileName).ToList();
			return View(files);
		}
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile Upload)
        {
            if (Upload != null)
            {
                var fileExtension = Path.GetExtension(Upload.FileName).ToLower();

                if (fileExtension == ".jpg")
                {
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "files", Upload.FileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await Upload.CopyToAsync(stream);
                    }
                }
            }

            var filesPath = Path.Combine(_hostingEnvironment.WebRootPath, "files");
            var files = Directory.GetFiles(filesPath).Select(Path.GetFileName).ToList();
            return View(files);
        }
        [HttpGet]
		public IActionResult FileView()
		{
			return View();
		}
	}
}
