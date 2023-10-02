using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SrbWeb.Models;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Text;

namespace SrbWeb.Controllers
{
    public class ProductController : Controller
    {
        Uri baseAdrress = new Uri("https://localhost:7218/api");

        private readonly HttpClient _client;

        public ProductController ()
        {
            _client = new HttpClient(); 
            _client.BaseAddress = baseAdrress;
        }
        
        [HttpGet]
        public IActionResult Index()
        {           
            List<Product> productlist = new List<Product>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Product").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;                
                productlist = JsonConvert.DeserializeObject<List<Product>>(data);
            }
            
            return View(productlist);
        }
       
        [HttpGet]
        public ActionResult Search(string ProductName)
        {
            IEnumerable<Product> product = null;
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Product/name?ProductName=" + ProductName).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<List<Product>>(data);
            }
            else
            {
                product = Enumerable.Empty<Product>();
                ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
            }
            return View(product);
        }
      
        [HttpGet]
        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Product", content).Result;            

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Produto cadastrado.";
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
        public IActionResult Edit(int ProductId)
        {
            LoadCategories();

            try
            {
                Product product = new Product();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Product/" + ProductId).Result;
                
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<Product>(data);
                }
                return View(product);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Product/UpdateProduct", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Produto atualizado com sucesso!";
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
        public IActionResult Details(int ProductId)
        {
            try
            {
                Product product = new Product();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Product/" + ProductId).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<Product>(data);
                }
                return View(product);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int? ProductId)
        {
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Product/" + ProductId).Result;


                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Produto removido com sucesso!";
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

        [NonAction]
        public IActionResult LoadCategories()
        {
            List<Category> categorylist = new List<Category>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Category").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                categorylist = JsonConvert.DeserializeObject<List<Category>>(data);
                ViewBag.Categories = new MultiSelectList(categorylist,"CategoryId","CategoryName");
            }
            return View();
        }
        
    }
}


