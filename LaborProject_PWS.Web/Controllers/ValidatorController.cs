using LaborProject_PWS.Domain.Models;
using LaborProject_PWS.Domain.Validations;
using Microsoft.AspNetCore.Mvc;

namespace LaborProject_PWS.Web.Controllers
{
    public class ValidatorController : Controller
    {
        public IActionResult Validator()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SampleModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Validator");
        }
    }
}
