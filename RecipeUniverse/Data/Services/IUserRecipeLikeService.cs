using RecipeUniverse.Models;

namespace RecipeUniverse.Data.Services;

public interface IUserRecipeLikeService
{
    Task<IEnumerable<RecipeLikes>> GetAllAsync();
    void AddLike(RecipeLikes like);
    Task DeleteLikeAsync(int? id);
    Task<RecipeLikes?> GetLikeByUserRecipeAsync(string userId, int? recipeId);
    Task<List<RecipeLikes>?> GetLikesByRecipeIdAsync(int? recipeId);
}