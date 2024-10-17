//using EventManagement_Frontend.IService;
//using EventManagement_Frontend.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace EventManagement_Frontend.Controllers
//{
//    public class CategoryController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }



//        private readonly ICategoryService _categoryService;

//        public CategoryController(ICategoryService categoryService)
//        {
//            _categoryService = categoryService;
//        }

//        // GET: Category
//        public async Task<IActionResult> Index()
//        {
//            var categories = await _categoryService.GetCategory();
//            return View(categories); // Pass the list of categories to the view
//        }

//        // GET: Category/Create
//        public IActionResult Create()
//        {
//            return View(); // Return the view for creating a new category
//        }

//        // POST: Category/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(CategoryModel category)
//        {
//            if (ModelState.IsValid)
//            {
//                // Logic to add category (you may want to implement a method in the service)
//                // Assuming you have a method to add category in your ICategoryService
//                var result = await _categoryService.CreateCategory(category);
//                if (result)
//                {
//                    return RedirectToAction(nameof(Index)); // Redirect to Index on success
//                }
//                ModelState.AddModelError("", "Error creating category. Please try again."); // Show error
//            }
//            return View(category); // Return the view with the category model
//        }

//        // GET: Category/Edit/{id}
//        public async Task<IActionResult> Edit(int id)
//        {
//            var category = await _categoryService.G(id); // Assuming you have this method in your service
//            if (category == null)
//            {
//                return NotFound(); // Return 404 if category not found
//            }
//            return View(category); // Return the edit view with the category
//        }

//        // POST: Category/Edit/{id}
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, CategoryModel category)
//        {
//            if (id != category.CategoryId)
//            {
//                return BadRequest(); // Return 400 Bad Request if the ID does not match
//            }

//            if (ModelState.IsValid)
//            {
//                var result = await _categoryService.UpdateCategory(id, category);
//                if (result)
//                {
//                    return RedirectToAction(nameof(Index)); // Redirect to Index on success
//                }
//                ModelState.AddModelError("", "Error updating category. Please try again."); // Show error
//            }
//            return View(category); // Return the view with the updated category model
//        }

//        // POST: Category/Delete/{id}
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var result = await _categoryService.DeleteCategory(id);
//            if (!result)
//            {
//                return NotFound(); // Return 404 if category not found
//            }
//            return RedirectToAction(nameof(Index)); // Redirect to Index on success
//        }
//    }
//}

