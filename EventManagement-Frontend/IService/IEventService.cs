using EventManagement_Frontend.Models;

namespace EventManagement_Frontend.IService
{
    public interface IEventService
    {
        Task<List<CategoryModel>> GetEvents();
        Task<bool> DeleteEvents(int categoryId);
        Task<bool> UpdateEvents(int categoryId, CategoryModel updatedCategory);
        Task<bool> CreateEvents(string categoryName);
        Task<CategoryModel> GetEventsById(int categoryId);
    }
}
