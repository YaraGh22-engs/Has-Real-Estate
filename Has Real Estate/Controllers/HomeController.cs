using AutoMapper;
using Has_Real_Estate.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Has_Real_Estate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepo _homeRepo;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IHomeRepo homeRepo, IMapper mapper)
        {
            _logger = logger;
            _homeRepo = homeRepo;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
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
