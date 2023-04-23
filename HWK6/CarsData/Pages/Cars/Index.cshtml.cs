using HWK4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CarsWebApp.Pages.Cars
{
    public class IndexModel : PageModel
    {
        public List<Car> Cars = new();
        public async void OnGet()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5273");
                // http get
                var responseTask = client.GetAsync("item");

                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    Cars = JsonConvert.DeserializeObject<List<Car>>(readTask);
                }
            }
        }
    }
}
