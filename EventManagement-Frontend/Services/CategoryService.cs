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

        public CategoryService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            _url = _config["ApiSettings:BaseUrl"]+"/categories";
            if (string.IsNullOrEmpty(_url))
            {
                throw new ArgumentNullException(nameof(_url), "The base URL for the API cannot be null or empty.");
            }
            _httpClient.BaseAddress = new Uri(_url);

        }
        public async Task<bool> DeleteCategory(int categoryId)
        {
            // Make a DELETE request to the Web API to delete the category from the database
            var response = await _httpClient.DeleteAsync($"{_url}/{categoryId}");

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
            var response = await _httpClient.GetAsync($"{_url}");

    
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
        public async Task<bool> UpdateCategory(int categoryId, CategoryModel updatedCategory)
        {
            var jsonContent = new StringContent(
                           JsonConvert.SerializeObject(updatedCategory),
                           Encoding.UTF8,
                           "application/json");
            string url=_url+"/"+categoryId;
            var response = await _httpClient.PutAsync(url, jsonContent);
            if (response.IsSuccessStatusCode)
            {
                // Update the category in the local list
                //var index = _categories.FindIndex(c => c.CategoryId == categoryId);
                //if (index != -1)
                //{
                //    _categories[index] = updatedCategory;
                //}
                return true;
            }
            return false;
        }
        public async Task<bool> CreateCategory(string categoryName)
        {
            CategoryModel category = new CategoryModel()
            {
                CategoryName = categoryName
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json");
            string url = _url;
            var response = await _httpClient.PostAsync(url, jsonContent);
            if (response.IsSuccessStatusCode)
            {
                string newCategory = await response.Content.ReadAsStringAsync();
                //var newCategory = JsonConvert.DeserializeObject<CategoryModel>(await response.Content.ReadAsStringAsync());
                //if (newCategory != null)
                //{
                //    _categories.Add(newCategory);
                    return true;
                //}
            }
            //else
            
            //{
            //    var errorMessage = await response.Content.ReadAsStringAsync();
            //    Console.WriteLine($"Error: {response.StatusCode}, {errorMessage}");
            //}
            return false;
        }
        public async Task<CategoryModel> GetCategoryById(int categoryId)
        {
            // Make a request to the Web API to fetch the category by its ID
            var response = await _httpClient.GetAsync($"{_url}/{categoryId}");

            // Check if the Web API call was successful
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response into a CategoryModel object
                var category = JsonConvert.DeserializeObject<CategoryModel>(jsonString);

                return category; // Return the fetched category
            }

            // If the Web API call failed, return null or handle it as needed
            return null;
        }


    }
}
