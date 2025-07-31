using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Unitrust_Test.DataAccess;
using Unitrust_Test.Models;

namespace Unitrust_Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVisitorRepository _visitorRepository;

        public HomeController(ILogger<HomeController> logger, IVisitorRepository visitorRepository)
        {
            _logger = logger;
            _visitorRepository = visitorRepository;
        }

        public async Task<IActionResult> Index()
        {
            var visitors = await _visitorRepository.GetAllAsync();
            ViewBag.Visitors = visitors;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(Visitor visitor)
        {
            if (!ModelState.IsValid) {

                var visitors = await _visitorRepository.GetAllAsync();
                ViewBag.Visitors = visitors;

                return View(visitor);
            }

            try {
                var existingvisitor = await _visitorRepository.GetByEmailAsync(visitor.Email);
                if (existingvisitor != null) {
                    TempData["ErrorMessage"] = $"Visitor with email {existingvisitor.Email} exists";
                    var allvisitors = await _visitorRepository.GetAllAsync();
                    ViewBag.Visitors = allvisitors;

                    ModelState.AddModelError("", "An unexpected error occured");
                    return View();
                }

                _visitorRepository.AddAsync(visitor);
                TempData["SuccessMessage"] = "Visitor created successfully!";

                var visitors = await _visitorRepository.GetAllAsync();
                _visitorRepository.SaveChangesAsync();
                ViewBag.Visitors = visitors;

                return RedirectToAction("Index");

            }
            catch (Exception ex) {

                var visitors = await _visitorRepository.GetAllAsync();
                ViewBag.Visitors = visitors;

                ModelState.AddModelError("", "An unexpected error occured");
                return View();
            }
 
        }

    }
}
