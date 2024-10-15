using EventManagement_Backend.IRepository;
using EventManagement_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagement_Backend.Repository
{
    public class CategoryRepository : ICaterogryRepository
    {
        private readonly EventManagementDbContext _context;
        public CategoryRepository(EventManagementDbContext context)
        {
            _context = context;
        }
        public string AddCategory(Category category)
        {
            if (category != null)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return "Category Added Successfully";
            }
            else
            {
                return "Error Adding Category";
            }
            
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public string RemoveCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return "Category Removed Successfully";
            }
            else
            {
                return "Error Category Removing";
            }
        }

        public string UpdateCategory(Category category)
        {
            var existingCategory = _context.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (existingCategory != null)
            {
                existingCategory.CategoryName = category.CategoryName;
                _context.SaveChanges();
                return "Updated SuucessFully";
            }
            else
            {
                return "Error Updating Category";
            }
        }
    }
}
