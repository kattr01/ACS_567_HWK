using HWK4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication1.Pages.Todos
{
    public class DeleteModel : PageModel
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
                var responseTask = client.GetAsync("Storeitem/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    todo =JsonConvert.DeserializeObject<Storeitems>(readTask);
                }
            }
        }
        public async void OnPost()
        {
            bool isDeleted = false;
            int id = int.Parse(Request.Form["id"]);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5273");
                var response = await client.DeleteAsync("/Storeitem/" + id);
                if (response.IsSuccessStatusCode)   
                {
                    isDeleted = true;
                }

            }
            if (isDeleted)
            {
                successMessage = "Successfully deleted";
            }
            else
            {
                errorMessage = "Error deleting";
            }
        }
    }
}
