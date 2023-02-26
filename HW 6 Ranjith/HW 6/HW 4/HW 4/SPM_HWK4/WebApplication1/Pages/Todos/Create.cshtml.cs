using System.Text.Json;
using HWK4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Todos
{
    public class CreateModel : PageModel
    {
        public Storeitems todo = new();
        public string errorMessage = "";
        public string successMessage = "";

        public async void OnPost()
        {
            todo.Description = Request.Form["description"];
            if (todo.Description.Length == 0)
            {
                errorMessage = "Description 1s required";
            }
            else
            {
                var opt = new JsonSerializerOptions() { WriteIndented = true };
                string json = System.Text.Json.JsonSerializer.Serialize(todo, opt);
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://Localhost:5273");
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("Storeitem", content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);

                    if (!result.IsSuccessStatusCode)
                    {
                        errorMessage = "Error adding";
                    }
                    else
                    {
                        successMessage = "Successfully added";
                    }
                }
            }

        }
    }
}
