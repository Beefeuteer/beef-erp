using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using verimlilik_raporu.Models;

using Newtonsoft.Json;

namespace verimlilik_raporu.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        /* verimilik raporu post request */


        // This is an example controller action that calls PostSomeData.
        public async Task<ActionResult> GetProductivityResults(
       DateTime startDatetemp,
       DateTime endDate,
       int[] departmentList,
       int[] machineListtemp,
       string[] machineTypeListtemp,
       int[] shiftListtemp,
       bool isViewPlannedStoptemp)
        {
            string url = "http://api.mikroportal.com/api/VerimlilikRaporlari/Productivity_Test";
            string token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRlc3QiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiIxOTEiLCJuYmYiOjE2Nzg5Njk1ODgsImV4cCI6MTY3OTgzMzU4OCwiaWF0IjoxNjc4OTY5NTg4LCJpc3MiOiJNaWtyb3BvcnRhbCBBcGkifQ.NJYRwSl4TR_dfyth2eRUoKA9K_ZJOKpNFjCJxwJRlFYPqdXkdjyhhwWT_6OVFhEuvykwJjBBtd3X-Q2sTKVbHg";

            if (machineTypeListtemp == null)
            {
                machineTypeListtemp = new[] { "MONTAJ", "YM" };
            }

            if (machineListtemp == null)
            {
                machineListtemp = new[] { 76, 77 };
            }

            if (isViewPlannedStoptemp == false)
            {
                isViewPlannedStoptemp = false;
            }
            else isViewPlannedStoptemp = true;

            if (shiftListtemp == null)
            {
                shiftListtemp = new[] { 1, 4 };
            }

            var data = new
            {
                departmentList = new[] { 2, 4 },
                machineList = machineListtemp,
                machineTypeList = machineTypeListtemp,
                shiftList = shiftListtemp,
                startDate = DateTime.Parse("2023-03-06T12:37:53.234Z"),
                finishDate = DateTime.Parse("2023-03-16T12:37:53.234Z"),
                isViewPlannedStop = isViewPlannedStoptemp,
            };

            try
            {
                var response = await PostSomeData(url, token, data);

                //var viewModel = JsonConvert.DeserializeObject<ProductivityResultsViewModel>(response);
                //return View(viewModel);

                return Content(response, "application/json");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that were thrown...
                return Content($"An error occurred: {ex.Message}", "text/plain");
            }
        }

        // This is a private method that can be called by the controller actions.
        private async Task<string> PostSomeData(string url, string token, object data)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Received HTTP {response.StatusCode} ({response.ReasonPhrase})");
                }

                return await response.Content.ReadAsStringAsync();
            }
        }

        /* verimilik raporu post request */

    }
}