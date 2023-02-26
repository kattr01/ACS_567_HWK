using HWK4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Todos
{

    public class AnalyseModel : PageModel
    {
        public string Analyse = "";
        public Storeitems todo = new();
        public string errorMessage = "";
        public string successMessage = "";
        public string Analyze = "";

        public async void OnGet()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5273");
                //HTTP GET
                var responseTask = client.GetAsync("Storeitem");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    Analyze = readTask;
                }
            }
        }
    }
}
