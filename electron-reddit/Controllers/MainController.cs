using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronNET.API;
using Microsoft.AspNetCore.Mvc;
using reddit_dot_net;

namespace electron_reddit.Controllers
{
    public class MainController : Controller
{
    public IActionResult Index()
    {
        Electron.IpcMain.On("getData", (args) =>
        {
            var posts = new Pictureizer().GetTopPictures(new List<string> { "aww" }, "month", 20);
            var mainWindow = Electron.WindowManager.BrowserWindows.First();
            Electron.IpcMain.Send(mainWindow, "sendData", posts);
        }); 
        
        return View();
    }
}
}
