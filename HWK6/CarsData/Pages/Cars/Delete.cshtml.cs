using HWK4.Models;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text.Json;

namespace CarsWebApp.Pages.Cars
{
    public class DeleteModel : PageModel
    {
        public Car Car = new();
        public string errorMessage = "";
        public string sucessMessage = "";
        public async void OnGet()
        {
            int IndexNo = int.Parse(Request.Query["IndexNo"]);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5273");

                var responseTask = client.DeleteAsync("item/" + IndexNo);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    Car = JsonConvert.DeserializeObject<Car>(readTask);
                }
            }
        }

        public async void OnPost()
        {
            // delete data on post.
            bool isDelete = false;
            int IndexNo = int.Parse(Request.Form["IndexNo"]);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5273");

                var response = await client.DeleteAsync("item/" + IndexNo);
                if (response.IsSuccessStatusCode)
                {
                    isDelete = true;
                }
            }
            // send the messages 
            if (isDelete)
            {
                sucessMessage = "Sucessfullry Deleted";
            }
            else
            {
                errorMessage = "Error Deleting";
            }
        }
    }
}
