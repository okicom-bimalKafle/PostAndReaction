using Microsoft.AspNetCore.Mvc;
using PostAndComment.CoreLayer.Src.Repository;
using PostAndComment.CoreLayer.Src.Service;
using PostAndReaction.Models;
using System.Diagnostics;

namespace PostAndReaction.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PostServiceInterface _serviceInterface;
        private readonly PostRepositoryInterface postRepositoryInterface;

        public HomeController(ILogger<HomeController> logger, PostServiceInterface serviceInterface, PostRepositoryInterface postRepositoryInterface)
        {
            _logger = logger;
            _serviceInterface = serviceInterface;
            this.postRepositoryInterface = postRepositoryInterface;
        }

        public async Task<ViewResult> Index()
        {
            var post=await postRepositoryInterface.GetAll();
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