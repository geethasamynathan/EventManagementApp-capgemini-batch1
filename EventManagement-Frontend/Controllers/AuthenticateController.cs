using EventManagement_Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EventManagement_Frontend.Controllers
{
    public class AuthenticateController : Controller
    {
            private readonly HttpClient _httpClient;
            private readonly IConfiguration _config;
            public AuthenticateController(HttpClient httpClient, IConfiguration configuration)
            {
                _httpClient = httpClient;
                _config = configuration;
            }
            public IActionResult Index()
            {
                var token = TempData["Token"] as string;
                ViewBag.Token = token;
                return View();
            }

            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Login(LoginModel login)
            {
                if (ModelState.IsValid)
                {
                    var json = JsonConvert.SerializeObject(login);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync($"{_config["ApiSettings:AuthURL"]}login", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var tokenResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);
                        var token = tokenResponse["token"];
                        TempData["Token"] = token;
                        TempData["SuccessMessage"] = "Login success!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Login Failed";
                        ModelState.AddModelError("", "Login failed");
                        return View();
                    }

                }
                else
                {
                    {
                        TempData["ErrorMessage"] = "Login failed";
                        return View();
                    }
                }
            }
        
    }
}
