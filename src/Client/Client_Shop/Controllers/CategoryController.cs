using Client_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client_Shop.Controllers
{
    public class CategoryController : Controller
    {
        public async Task<IActionResult> List()
        {
            List<Category> categories = new List<Category>();

            using (var httpClient= new HttpClient())
            {
                using var request = await httpClient.GetAsync("http://localhost:64040/api/Category");
                string response = await request.Content.ReadAsStringAsync();

                categories = JsonConvert.DeserializeObject<List<Category>>(response);
            }

            return View(categories);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json");
                    using var request = await httpClient.PostAsync("http://localhost:64040/api/Category", content);
                    return RedirectToAction("List");
                }
            }
            return View();
        }


        public async Task<IActionResult> Update(int id)
        {
            Category category = new Category();

            using (var httpClient = new HttpClient())
            {
                using var request = await httpClient.GetAsync($"http://localhost:64040/api/Category/{id}");
                string response = await request.Content.ReadAsStringAsync();

                category = JsonConvert.DeserializeObject<Category>(response);
            }

            return View(category);
        } 


        [HttpPost]
        public async Task<IActionResult> Update(Category category)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json");
                    using var request = await httpClient.PutAsync("http://localhost:64040/api/Category", content);
                }
                return RedirectToAction("List"); 
            }

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using var request = await httpClient.DeleteAsync($"http://localhost:64040/api/Category/{id}");
            }

            return RedirectToAction("List");
        }
    }
}
