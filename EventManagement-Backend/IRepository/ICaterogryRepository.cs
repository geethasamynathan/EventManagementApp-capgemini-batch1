using EventManagement_Backend.Models;

namespace EventManagement_Backend.IRepository
{
    public interface ICaterogryRepository
    {
        List<Category> GetCategories();
        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void RemoveCategory(int id);
    }
}
