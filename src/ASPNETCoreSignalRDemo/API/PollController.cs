using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreSignalRDemo.Models.ViewModels;
using ASPNETCoreSignalRDemo.Models;

namespace ASPNETCoreSignalRDemo.API
{
    [Route("api/[controller]")]
    public class PollController : Controller
    {
        private readonly IPollManager _pollManager;

        public PollController(IPollManager pollManager)
        {
            _pollManager = pollManager;
        }

        [HttpGet]
        public IEnumerable<PollDetailsViewModel> Get()
        {
           var res =  _pollManager.GetActivePoll();
           return res.ToList();
        }
    
    }
}
