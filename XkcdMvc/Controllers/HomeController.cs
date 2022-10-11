using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XkcdMvc.Models;


namespace XkcdMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Wrap return type within Task:  Task<IActionResult> 
        //Add "async" before the word public
        async public Task<IActionResult> Index(string comicnum)
        {
            HttpClient web = new HttpClient();
            web.BaseAddress = new Uri("https://xkcd.com/");

            //await can only be used within an async method 
            var connection = await web.GetAsync($"{comicnum}/info.0.json");

            try
            {
                Comic com = await connection.Content.ReadAsAsync<Comic>();
                return View(com);
            }
            catch (Exception e)
            {
                return View();
            }

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