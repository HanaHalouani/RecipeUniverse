using RecipeUniverse.Areas.Identity.Data;
using RecipeUniverse.Data.Repository.IRepository;

namespace RecipeUniverse.Data.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        var usersList = await _unitOfWork.UserRepository.GetAllAsync();
        return usersList.ToList();
    }

    public async Task<User> GetUserByIdAsync(string? userId)
    {
        var user = await _unitOfWork.UserRepository.GetAsync(r => r.Id == userId);
        return user;
    }

}