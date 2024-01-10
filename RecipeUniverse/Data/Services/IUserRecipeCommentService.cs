using RecipeUniverse.Models;

namespace RecipeUniverse.Data.Services;

public interface IUserRecipeCommentService
{
    Task<IEnumerable<Comment>> GetAllAsync();
    void AddComment(Comment comment);
    Task<List<Comment>?> GetCommentsByRecipeIdAsync(int? recipeId);
}