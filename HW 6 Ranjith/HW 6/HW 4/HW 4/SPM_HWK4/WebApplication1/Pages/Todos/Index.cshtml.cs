using HWK4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WebApplication1.Pages.Todos
{
    public class IndexModel : PageModel
    {
        public List<Storeitems> Todos = new();


        public async void OnGet()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5273");
                var responseTask = client.GetAsync("Storeitem");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    Todos = JsonConvert.DeserializeObject<List<Storeitems>>(readTask);
                }
            }
        }
    }

}
