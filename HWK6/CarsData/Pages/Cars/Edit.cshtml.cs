using Microsoft.AspNetCore.Mvc;
using HWK4.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text.Json;

namespace CarsWebApp.Pages.Cars
{
    public class EditModel : PageModel
    {
        // define Car
        public Car Car = new();
        public string errorMessage = "";
        public string sucessMessage = "";

        //on getting the function call
        public async void OnGet()
        {
            int IndexNo = int.Parse(Request.Query["IndexNo"]);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5273");
                var responseTask = client.GetAsync("item/" + IndexNo);
                responseTask.Wait();

                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    Car = JsonConvert.DeserializeObject<Car>(readTask);

                }
            }
        }
        // Do the following after the call
        public async void OnPost()
        {
           
            Car.IndexNo = int.Parse(Request.Form["IndexNo"]);
            Car.CriticScore = int.Parse(Request.Form["CriticScore"]);

            var opt = new JsonSerializerOptions() { WriteIndented = true };
            string json = System.Text.Json.JsonSerializer.Serialize<Car>(Car, opt);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5273");

                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await client.PutAsync("item", content);
                String resultContent = await result.Content.ReadAsStringAsync();

                if (!result.IsSuccessStatusCode)
                {
                    errorMessage = "Error Adding";
                }
                else
                {
                    sucessMessage = "Sucessfully added";
                }
            }
        }
    }
}
