using Microsoft.AspNetCore.Mvc;

namespace LaborProject_PWS.Web.Controllers
{
    public class FileViewerController : Controller
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public FileViewerController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult Viewer()
        {
            var imagesDirectory = Path.Combine(_hostingEnvironment.WebRootPath, "files");
            var fileNames = Directory.EnumerateFiles(imagesDirectory)
                                     .Select(Path.GetFileName);
            return View(fileNames);
        }
    }
}
