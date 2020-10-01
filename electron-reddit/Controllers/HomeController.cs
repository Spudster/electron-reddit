using System.Collections.Generic;
using electron_reddit.Models;
using ElectronNET.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using reddit_dot_net;
using System.Diagnostics;
using System.Linq;

namespace electron_reddit.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
