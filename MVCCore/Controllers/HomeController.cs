using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MVCCore.Models;
using MVCCore.Repository;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MVCCore.Controllers
{   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookRepository _bookRepository;
        const string SessionName = "_Name";
        const string SessionAge = "_Age";
        public HomeController(ILogger<HomeController> logger,IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;   
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
          

            ViewBag.BookData = await _bookRepository.GetBooks();
            //ViewBag["BookData"] = data;
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(MasterBook masterBook)
        {
            //var name = HttpContext.Session.GetString(SessionName);
            //var age = HttpContext.Session.GetInt32(SessionAge);
            //ViewBag["BookData"] = await _bookRepository.GetBooks();
            //ViewBag["BookData"] = data;
            return RedirectToAction("Index");
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