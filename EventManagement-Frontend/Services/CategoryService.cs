using EventManagement_Frontend.IService;
using EventManagement_Frontend.Models;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Newtonsoft.Json;
using System.Text;

namespace EventManagement_Frontend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly List<CategoryModel> _categories = new List<CategoryModel>();
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private string _url = "";
        
        public  CategoryService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            _url = _config["BaseUrl"]; 
        }
        public async Task<bool> DeleteCategory(int categoryId)
        {
            // Make a DELETE request to the Web API to delete the category from the database
            var response = await _httpClient.DeleteAsync($"{_url}/categories/{categoryId}");

            // Check if the Web API call was successful (category deleted in the database)
            if (response.IsSuccessStatusCode)
            {
                // Remove the category from the in-memory list
                _categories.RemoveAll(c => c.CategoryId == categoryId);
                return true;
            }

            // If the API call failed, return false
            return false;
        }
        public async Task<List<CategoryModel>> GetCategory()
        {
            // Check if the local cache (_categories) is already populated
            if (_categories.Any())
            {
                return _categories; // Return the local list if it already contains categories
            }

            // If not found in the local list, make a request to the Web API to fetch all categories
            var response = await _httpClient.GetAsync($"{_url}/categories");

            // Check if the Web API call was successful
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response into a list of CategoryModel objects
                var fetchedCategories = JsonConvert.DeserializeObject<List<CategoryModel>>(jsonString);

                if (fetchedCategories != null && fetchedCategories.Any())
                {
                    // Add the fetched categories to the in-memory list
                    _categories.AddRange(fetchedCategories);
                }

                return fetchedCategories; // Return the list of categories from the Web API
            }

            // If the Web API call failed, return an empty list
            return new List<CategoryModel>();
        }
        public async Task<bool> UpdateCategory(int categoryId,CategoryModel updatedCategory)
        {
            var jsonContent = new StringContent(
                           JsonConvert.SerializeObject(updatedCategory),
                           Encoding.UTF8,
                           "application/json");

            var response = await _httpClient.PutAsync($"{_url}/categories/{categoryId}", jsonContent);
            if (response.IsSuccessStatusCode)
            {
                // Update the category in the local list
                var index = _categories.FindIndex(c => c.CategoryId == categoryId);
                if (index != -1)
                {
                    _categories[index] = updatedCategory;
                }
                return true;
            }
            return false;
        }
    }
}
