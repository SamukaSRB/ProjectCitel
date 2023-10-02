using ApiSrbWeb.Data;
using ApiSrbWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSrbWeb.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<List<Product>>> GetProduct()
        {
            var product = await _context.Products.ToListAsync();
            return product;
        }
        public async Task<ActionResult<Product>> GetById(int ProductId)
        {
            var product = await _context.Products.FindAsync(ProductId);
            return product;

        }
        public async Task<ActionResult<List<Product>>> CreateProduct(Product product)
        {
            if (_context.Products.Any(x => x.ProductEan == product.ProductEan))
                throw new Exception("Registro de Ean duplicado");

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return await _context.Products.ToListAsync();
        }
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product product)
        {
            var dbProduct = await _context.Products.FindAsync(product.ProductId);

            dbProduct.ProductId = product.ProductId;
            dbProduct.ProductEan = product.ProductEan;
            dbProduct.ProductCod = product.ProductCod;
            dbProduct.ProductName = product.ProductName;
            dbProduct.ProductDescription = product.ProductDescription;
            dbProduct.ProductPrice = product.ProductPrice;
            dbProduct.ProductStock = product.ProductStock;
            dbProduct.CategoryId = product.CategoryId;

            await _context.SaveChangesAsync();

            return await _context.Products.ToListAsync();
        }
        //public async Task<ActionResult<List<Product>>> Delete(int ProductId)
        //{
        //    var dbProduct = await _context.Products.FindAsync(ProductId);          

        //    _context.Remove(dbProduct);

        //    await _context.SaveChangesAsync();

        //    return await _context.Products.ToListAsync();
        //}
        public async Task<ActionResult<List<Product>>> SearchName(string ProductName)
        {
            var products = _context.Products.Where(p => p.ProductName.StartsWith(ProductName))
                    .Select(s => new Product()
                    {
                        ProductId = s.ProductId,
                        ProductCod = s.ProductCod,
                        ProductName = s.ProductName,
                        ProductPrice = s.ProductPrice,
                        ProductDescription = s.ProductDescription,
                        ProductStock = s.ProductStock

                    }).ToList();

            return products;
        }

    }
}
