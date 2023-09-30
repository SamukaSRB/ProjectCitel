using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SrbWeb.Services
{
    public class Product : IProduct
    {
        Uri baseAdrress = new Uri("https://localhost:7218/api");

        private readonly HttpClient _client;

        public Product()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAdrress;
        }


        public async Task<List<Product>> GetProduct()
        {
            List<Product> productlist = new List<Product>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Product").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                productlist = JsonConvert.DeserializeObject<List<Product>>(data);
            }
            return productlist;

        }
    }
}
