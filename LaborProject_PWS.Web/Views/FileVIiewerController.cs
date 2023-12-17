using Microsoft.AspNetCore.Mvc;
public class FileVIiewerController : Controller
{
    private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
    public FileVIiewerController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public IActionResult Index()
    {
        var imagesDirectory = Path.Combine(_hostingEnvironment.WebRootPath, "files");
        var fileNames = Directory.EnumerateFiles(imagesDirectory)
                                 .Select(Path.GetFileName);
        return View(fileNames);
    }

}
