using ApiSrbWeb.Data;
using ApiSrbWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSrbWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        #region Crud
        /// <summary>
        /// Busca todos os produtos
        /// </summary>        
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        /// 
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProduct()
        {
            var products = await _context.Products.Include(c => c.Category).ToListAsync();
            if (products == null)
                return BadRequest("Não existe produtos entre contato com administrador.");
            return Ok(products);
        }

        /// <summary>
        /// Busca os produtos por identificador
        /// </summary> 
        /// <param name="ProductId">Id do product</param>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpGet("{ProductId}")]
        public async Task<ActionResult<Product>> GetById(int ProductId)
        {
            var product = await _context.Products.Include(c => c.Category).FirstOrDefaultAsync(m => m.ProductId == ProductId);
            if (product == null)
                return BadRequest("Product não encontrado.");
            return Ok(product);
        }

        /// <summary>
        /// Salvar
        /// </summary> 
        /// <param name="Produto">Adiciona um produto</param>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpPost]
        public async Task<ActionResult<List<Product>>> CreateProduct(Product product)
        {
            if (_context.Products.Any(x => x.ProductEan == product.ProductEan))
                throw new Exception("Registro de Ean duplicado");

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }

        /// <summary>
        /// Atualizar
        /// </summary> 
        /// <param name="ProductId">Id do produto</param>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpPut("{ProductId}")]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product product)
        {
            var dbProduct = await _context.Products.FindAsync(product.ProductId);

            if (dbProduct == null)
                return BadRequest("Produto não encontrado");

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

        /// <summary>
        /// Deletar
        /// </summary>
        /// <param name="ProductId">Id do product</param>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpDelete("{ProductId}")]
        public async Task<ActionResult<List<Product>>> Delete(int ProductId)
        {
            var dbProduct = await _context.Products.FindAsync(ProductId);
            if (dbProduct == null)
                return BadRequest("Product não encontrado");

            _context.Remove(dbProduct);

            await _context.SaveChangesAsync();

            return Ok("Product deletado com sucesso");
        }

        [HttpGet("name")]
        public async Task<ActionResult<List<Product>>> SearchName(string ProductName)
        {
            if (string.IsNullOrWhiteSpace(ProductName))
            {
                return BadRequest("O nome não pode estar em branco.");
            }

            var products = _context.Products.Where(p => p.ProductName.StartsWith(ProductName))
                    .Select(s => new Product()
                    {
                        ProductId = s.ProductId,
                        ProductCod = s.ProductCod,
                        ProductName = s.ProductName,
                        ProductPrice = s.ProductPrice,
                        ProductDescription = s.ProductDescription,
                        ProductStock = s.ProductStock,
                        CategoryId = s.CategoryId,

                    }).ToList();

            if (products.Count == 0)
            {
                return NotFound("Nenhum produto localizado");
            }

            return Ok(products);
        }


        #endregion

    }
}
