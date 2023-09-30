using ApiSrbWeb.Data;
using ApiSrbWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ApiSrbWeb.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;     
        }

        public async Task<ActionResult<List<Category>>> GetCategory()
        {
            var category = await _context.Categories.ToListAsync();
            return category;
        }
        public async Task<ActionResult<Category>> GetById(int CategoryId)
        {
            var category = await _context.Categories.FindAsync(CategoryId);
            return category;
        }
        public async Task<ActionResult<List<Category>>> CreateCategory(Category category)
        {
            if (_context.Categories.Any(x => x.CategoryName == category.CategoryName))
                throw new Exception("Registro de Ean duplicado");

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return await _context.Categories.ToListAsync();
        }
        public async Task<ActionResult<List<Category>>> UpdateCategory(Category category)
        {
            var dbCategory = await _context.Categories.FindAsync(category.CategoryId);
            dbCategory.CategoryId = category.CategoryId;
            dbCategory.CategoryName = category.CategoryName;
            dbCategory.CategoryDescription = category.CategoryDescription;

            await _context.SaveChangesAsync();
            return await _context.Categories.ToListAsync();

        }
        public async  Task<ActionResult<List<Category>>> SearchName(string CategoryName)
        {
            throw new NotImplementedException();
        }
        
    }
}
