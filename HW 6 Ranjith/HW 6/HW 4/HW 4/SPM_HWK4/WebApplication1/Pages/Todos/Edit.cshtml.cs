using System.Text.Json;
using HWK4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WebApplication1.Pages.Todos
{
    public class EditModel : PageModel
    {
        public Storeitems todo = new();
        public string errorMessage = "";
        public string successMessage = "";

        public async void OnGet()
        {
            string id = Request.Query["id"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5273");
                //HTTP GET
                var responseTask = client.GetAsync("CalorieIntake/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    todo = JsonConvert.DeserializeObject<Storeitems>(readTask);
                }
            }
        }

        public async void OnPost()
        {
            todo.Id = int.Parse(Request.Form["id"]);
            todo.Description = Request.Form["description"];
            //todo.IsCompleted = Request.Form["isCompleted"] == "on";
            if (todo.Description.Length == 0)
            {
                errorMessage = "Description is required";
            }
            else
            {
                var opt = new JsonSerializerOptions() { WriteIndented = true };
                string json = System.Text.Json.JsonSerializer.Serialize(todo, opt);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5273");
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    var result = await client.PutAsync("Storeitem", content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);

                    if (!result.IsSuccessStatusCode)
                    {
                        errorMessage = "Error editing";
                    }
                    else
                    {
                        successMessage = "Successfully edited";
                    }
                }
            }
        }
    }
}
