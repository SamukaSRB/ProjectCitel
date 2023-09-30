using ApiSrbWeb.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiSrbWeb.Repository
{
    public interface IProductRepository
    {
        Task<ActionResult<List<Product>>> GetProduct();
        Task<ActionResult<Product>> GetById(int ProductId);
        Task<ActionResult<List<Product>>> CreateProduct(Product product);
        Task<ActionResult<List<Product>>> UpdateProduct(Product product);
        //Task<ActionResult<List<Product>>> Delete(int ProductId);
        Task<ActionResult<List<Product>>> SearchName(string ProductName);
    }
}
