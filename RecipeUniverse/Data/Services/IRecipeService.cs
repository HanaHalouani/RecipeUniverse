using RecipeUniverse.Areas.Identity.Data;
using RecipeUniverse.Models;

namespace RecipeUniverse.Data.Services;

public interface IRecipeService
{
    Task<List<Recipe>> GetRecipesByUserAsync(string userId);
    void CreateRecipe(Recipe recipe, User user);
    Task UpdateRecipeAsync(Recipe recipe);
    void DeleteRecipeAsync(Recipe? recipe);
    Task<List<Recipe>> GetAllRecipesAsync();
    Task<Recipe> GetRecipeByIdAsync(int? recipeId);
}