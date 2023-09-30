using ApiSrbWeb.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiSrbWeb.Repository
{
    public interface ICategoryRepository
    {
        Task<ActionResult<List<Category>>> GetCategory();
        Task<ActionResult<Category>> GetById(int CategoryId);
        Task<ActionResult<List<Category>>> CreateCategory(Category category);
        Task<ActionResult<List<Category>>> UpdateCategory(Category category);
        //Task<ActionResult<List<Category>>> Delete(int CategoryId);
        Task<ActionResult<List<Category>>> SearchName(string CategoryName);
    }
}
