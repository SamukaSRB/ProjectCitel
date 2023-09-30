using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SrbWeb.Models;
using System.Text;

namespace SrbWeb.Controllers
{
    public class CategoryController : Controller
    {
        Uri baseAdrress = new Uri("https://localhost:7218/api");

        private readonly HttpClient _client;
        public CategoryController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAdrress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categorylist = new List<Category>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Category").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                categorylist = JsonConvert.DeserializeObject<List<Category>>(data);
            }
            return View(categorylist);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Category", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Categoria cadastrada.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }

            return View();

        }

        [HttpGet]
        public IActionResult Edit(int CategoryId)
        {
            try
            {
                Category category = new Category();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Category/" + CategoryId).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    category = JsonConvert.DeserializeObject<Category>(data);
                }
                return View(category);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }

        }

        [HttpPost]
        public IActionResult Edit(Category model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Category/UpdateCategory", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Categoria atualizado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Details(int CategoryId)
        {
            try
            {
                Category category = new Category();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Category/" + CategoryId).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    category = JsonConvert.DeserializeObject<Category>(data);
                }
                return View(category);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }


        }
        [HttpGet]
        public IActionResult Delete(int? CategoryId)
        {
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Category/" + CategoryId).Result;


                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Categoria removido com sucesso!";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }

        }    
    }
}
