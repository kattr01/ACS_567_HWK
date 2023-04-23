using HWK4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace CarsWebApp.Pages.Cars
{
    public class Analysis : PageModel
    {
        public string analysis = "";
        // on the fuction call
        public async void OnGet()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5273");

                var responseTask = client.GetAsync("item/AnalyzeData");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    analysis = readTask;
                }
            }
        }
    }
}
