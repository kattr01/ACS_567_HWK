using HWK4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CarsWebApp.Pages.Cars
{
    public class GetItemModel : PageModel
    {
        public Car Car = new();
        public string errorMessage = "";
        public string sucessMessage = "";

        // Get individual item
        public async void OnPost()
        {
            int IndexNo = int.Parse(Request.Form["IndexNo"]);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5273");
                var responseTask = client.GetAsync("item/" + IndexNo);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    Car = JsonConvert.DeserializeObject<Car>(readTask);
                }
            }
        }
    }
}
