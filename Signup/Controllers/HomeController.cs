using Microsoft.AspNetCore.Mvc;
using Signup.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;

namespace Signup.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignupModel model)
        {
            var apiResponse = string.Empty;

            if (ModelState.IsValid)
            {
                try
                {
                    var client = new HttpClient();
                    var response = await client.PostAsJsonAsync("https://django-dev.aakscience.com/signup/", model);

                    if (response.IsSuccessStatusCode)
                    {
                        apiResponse = "Signup successful!";
                    }
                    else
                    {
                        apiResponse = $"Error: {response.ReasonPhrase}";
                    }
                }
                catch (Exception ex)
                {
                    apiResponse = $"Error: {ex.Message}";
                }

                return View("Outcome", apiResponse);
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
