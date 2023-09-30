using Microsoft.AspNetCore.Mvc;
using SrbWeb.Models;

namespace SrbWeb.Services
{
    public interface IProduct
    {
        Task<List<Product>> GetProduct();
        //Task<ActionResult<Product>> GetById(int ProductId);
        //Task<ActionResult<List<Product>>> CreateProduct(Product product);
        //Task<ActionResult<List<Product>>> UpdateProduct(Product product);
        //Task<ActionResult<List<Product>>> Delete(int ProductId);

    }
}
