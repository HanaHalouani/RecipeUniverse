using RecipeUniverse.Areas.Identity.Data;

namespace RecipeUniverse.Data.Services;

public interface IUserService
{
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(string? userId);
}