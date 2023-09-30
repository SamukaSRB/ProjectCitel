using ApiSrbWeb.Data;
using ApiSrbWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSrbWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Busca todos as categorias
        /// </summary>        
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategory()
        {
            return await _context.Categories.ToListAsync();
        }

        /// <summary>
        /// Busca as categorias por identificador
        /// </summary> 
        /// <param name="SupplierId">Id da categoria</param>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpGet("{CategoryId}")]
        public async Task<ActionResult<Category>> GetById(int CategoryId)
        {
            var category = await _context.Categories.FindAsync(CategoryId);
            if (category == null)
                return BadRequest("Hero not found.");
            return Ok(category);
        }

        /// <summary>
        /// Salvar
        /// </summary> 
        /// <param name="Category">Adiciona uma categoria</param>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpPost ]
        public async Task<ActionResult<List<Category>>> CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return await _context.Categories.ToListAsync();
        }

        /// <summary>
        /// Atualizar
        /// </summary> 
        /// <param name="CategoryId">Id da categoria</param>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpPut("{CategoriaId}")]
        public async Task<ActionResult<List<Category>>> UpdateCategory(Category category)
        {
            var dbCategory = await _context.Categories.FindAsync(category.CategoryId);
            if (dbCategory == null)
                return BadRequest("Categoria não encontrado");

            dbCategory.CategoryId = category.CategoryId;
            dbCategory.CategoryName = category.CategoryName;
            dbCategory.CategoryDescription = category.CategoryDescription;

            await _context.SaveChangesAsync();

            return await _context.Categories.ToListAsync();
        }

        /// <summary>
        /// Deletar
        /// </summary>
        /// <param name="CategoryId">Id da Categoria</param>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpDelete("{CategoryId}")]
        public async Task<ActionResult<List<Category>>> Delete(int CategoryId)
        {
            var dbCategory = await _context.Categories.FindAsync(CategoryId);
            if (dbCategory == null)
                return BadRequest("Product não encontrado");

            _context.Remove(dbCategory);

            await _context.SaveChangesAsync();

            return Ok("Categoria deletado com sucesso");
        }


    }

}

