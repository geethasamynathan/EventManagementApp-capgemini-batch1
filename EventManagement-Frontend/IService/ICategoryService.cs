using EventManagement_Frontend.Models;

namespace EventManagement_Frontend.IService
{
    public interface ICategoryService
    {
        Task<List<CategoryModel>> GetCategory();
        Task<bool> DeleteCategory(int categoryId);
        Task<bool> UpdateCategory(int categoryId, CategoryModel updatedCategory);
    }
}
