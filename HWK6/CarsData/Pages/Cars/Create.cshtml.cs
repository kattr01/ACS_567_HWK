using HWK4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace CarWebApp.Pages.Cars
{
    public class CreateModel : PageModel
    {
        // Create a reference to Car
        public Car Car = new();
        public string errorMessage = "";
        public string sucessMessage = "";
        public async void OnPost()
        {
            /// Get all the forms to fill the data
            Car.IndexNo = int.Parse(Request.Form["IndexNo"]);
            Car.CarName = Request.Form["CarName"];
            Car.ReleaseYear = int.Parse(Request.Form["ReleaseYear"]);
            Car.CarCompany = Request.Form["CarCompany"];
            Car.ModelName = Request.Form["ModelName"];
            Car.CarPrice = int.Parse(Request.Form["CarPrice"]);
            
            var opt = new JsonSerializerOptions() { WriteIndented= true };
                string json = System.Text.Json.JsonSerializer.Serialize<Car>(Car, opt);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5273");

                    var content = new StringContent(json,System.Text.Encoding.UTF8,"application/json");

                    var result = await client.PostAsync("item",content);
                    String resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);
                    // Adding the message.
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
