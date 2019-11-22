using clu.aspnet.webapplication.mvc.core.client.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace clu.aspnet.webapplication.mvc.core.client.Controllers
{
    public class HomeController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Get()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("http://localhost:44337");

            HttpResponseMessage response = httpClient.GetAsync("api/values/key1").Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;

                return Content(result);
            }
            else
            {
                return Content("An error has occurred");
            }
        }

        public async Task<IActionResult> GetAsync()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("http://localhost:44337");

            HttpResponseMessage response = await httpClient.GetAsync("api/Person");
            if (response.IsSuccessStatusCode)
            {
                Person person = await response.Content.ReadAsAsync<Person>();

                return Content(person.Name);
            }
            else
            {
                return Content("An error has occurred");
            }
        }

        public async Task<IActionResult> PostAsJsonAsync()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("http://localhost:44337");

            Entry entry = new Entry { Key = "key3", Value = "value3" };

            HttpResponseMessage response = await httpClient.PostAsJsonAsync("api/Values", entry);

            if (response.IsSuccessStatusCode)
            {
                return Content("succedded");
            }
            else
            {
                return Content("An error has occurred");
            }
        }
    }
}