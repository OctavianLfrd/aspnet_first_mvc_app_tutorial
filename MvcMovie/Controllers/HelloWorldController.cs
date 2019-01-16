using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /HelloWorld/
        public IActionResult Index() //methods like this usually return IActionResult or derivved from ActionResult class
                                     //but not types like strings
        {
            return View();
        }

        //GET: HelloWorld/Welcome

        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }
        //HtmlEncoder.Default.Encode === htmlspecialchars in php
        
        public string Hello(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
            //the ID parameter is matched with an ID parameter in the method MapRoute in the startup.cs
        }
        public IActionResult SettingViewData(string name, int numTimes = 1)
        {
            ViewData["message"] = "Hello" + name;
            ViewData["NumTimes"] = numTimes;
            //ViewData is the dictionary that we can use for passing data from controller to the view
            //but it's actually better to use model not such a stuff
            //there is also another stuff like : ViewBag, TempData, ViewData
            return View();
        }
    }
}
//MVC default routing logic : /[Controller]/[ActionName]/[Parameters]