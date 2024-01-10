using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeUniverse.Areas.Identity.Data;
using RecipeUniverse.Data.Services;
using RecipeUniverse.Models;

namespace RecipeUniverse.Controllers
{
    public class RecipeController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly IRecipeService _recipeService;

        public RecipeController(
            UserManager<User> userManager,
            IRecipeService recipeService
        )
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _recipeService = recipeService ?? throw new ArgumentNullException(nameof(recipeService));


        }
        public async Task<IActionResult> IndexAsync()
        {
            var user = await GetCurrentUserAsync();
            {
                var recipes = await _recipeService.GetRecipesByUserAsync(user?.Id);
                return View(recipes);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Recipe recipeVm)
        {
            var user = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {
                _recipeService.CreateRecipe(recipeVm, user);
                TempData["success"] = " Recipe Created Successfully";
                return RedirectToAction("Index");

            }
            TempData["error"] = " something is wrong with ModelState ";
            return View(recipeVm);

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
                return NotFound();
            var recipe = await _recipeService.GetRecipeByIdAsync(id);

            return View(recipe);
        }

        [HttpPost]
        public IActionResult Edit(Recipe recipeVmn)
        {
            if (ModelState.IsValid)
            {
                _recipeService.UpdateRecipeAsync(recipeVmn);
                TempData["success"] = " Recipe Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(recipeVmn);
        }

        #region APiCALLs
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            _recipeService.DeleteRecipeAsync(recipe);
            TempData["success"] = " Recipe Deleted Successfully";
            return Json(new { success = true, message = "Recipe deleted" });


        }
        #endregion
        private async Task<User?> GetCurrentUserAsync()
        {
            return await _userManager.GetUserAsync(User);
        }
    }

}
