using Microsoft.AspNetCore.Mvc;
using ASPNETCoreSignalRDemo.Models;
using ASPNETCoreSignalRDemo.Models.ViewModels;

namespace ASPNETCoreSignalRDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPollManager _pollManager;

        public HomeController(IPollManager pollManager)
        {
            _pollManager = pollManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPoll()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPoll(AddPollViewModel poll)
        {
            if (ModelState.IsValid) {
                if (_pollManager.AddPoll(poll))
                {
                    ViewBag.Message = "Poll added successfully!";
                    //ASPNETCoreSignalRDemo.Hubs.PollHub.FetchPoll();
                }      
            }
            return View(poll);
        }
    }
}
