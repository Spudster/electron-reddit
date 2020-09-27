using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ElectronNET.API;
using electron_reddit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using reddit_dot_net;

namespace electron_reddit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            Electron.IpcMain.On("getData", (args) =>
            {
                var subReddits = new List<string> { "earthporn", "oldschoolcool", "astrophotography", "spaceporn" };
                var posts = new SubRedditPictures().GetTopPicturesStrings(subReddits);
                var mainWindow = Electron.WindowManager.BrowserWindows.First();
                Electron.IpcMain.Send(mainWindow, "sendData", posts);
            });

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
