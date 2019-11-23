using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DigitalRegistry.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace DigitalRegistry.Controllers
{
    public class HomeController : Controller
    {

        //private readonly ILogger<HomeController> _logger;
        //public List<Schools> schools;
        public RootObject rootObject;
        private readonly IRepository _repository;
        HttpClient httpClient;
        public string BASE_URL = "https://api.gsa.gov/technology/digital-registry/v1/agencies";

        public HomeController(IRepository repository)
        {
            _repository = repository;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new
                System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IActionResult results()
        {

            rootObject = GetAllResults();
            if (_repository.getCount())
            {
                bool areNewRecordsAdded = _repository.SaveResults(rootObject);
            }
            return View(rootObject);

        }

        private RootObject GetAllResults()
        {
            string CompaniesApi_End_Point = BASE_URL + "?API_KEY=qZEyjY0nTO9R8suzDCwQs06eVpyfFOkY7UVacerl";
            string companyList = string.Empty;
            httpClient.BaseAddress = new Uri(CompaniesApi_End_Point);
            HttpResponseMessage response = httpClient.GetAsync(CompaniesApi_End_Point).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                companyList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            }
            if (!string.IsNullOrEmpty(companyList))
            {
                rootObject = JsonConvert.DeserializeObject<RootObject>(companyList);
            }
            return rootObject;




        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(results));
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
