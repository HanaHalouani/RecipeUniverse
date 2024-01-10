using RecipeUniverse.Data.Repository.IRepository;
using RecipeUniverse.Models;

namespace RecipeUniverse.Data.Services
{
    public class UserRecipeLikeService : IUserRecipeLikeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserRecipeLikeService(
            IUnitOfWork unitOfWork,
            IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));

        }

        public async Task<IEnumerable<RecipeLikes>> GetAllAsync()
        {
            var allLikes = await _unitOfWork.UserRecipeLikeRepository.GetAllAsync();
            return allLikes;
        }

        public void AddLike(RecipeLikes like)
        {
            _unitOfWork.UserRecipeLikeRepository.Add(like);
            _unitOfWork.Save();
        }

        public async Task DeleteLikeAsync(int? id)
        {
            var like = await _unitOfWork.UserRecipeLikeRepository.GetAsync(i => i.RecipeId == id);
            _unitOfWork.UserRecipeLikeRepository.Delete(like);
            _unitOfWork.Save();
        }
        public async Task<RecipeLikes?> GetLikeByUserRecipeAsync(string userId, int? recipeId)
        {
            var allUserRecipeLike = await _unitOfWork.UserRecipeLikeRepository.GetAllAsync();
            var userLikeRecipe = allUserRecipeLike.FirstOrDefault(b => b.UserId == userId && b.RecipeId == recipeId);
            return userLikeRecipe;

        }
        public async Task<List<RecipeLikes>?> GetLikesByRecipeIdAsync(int? recipeId)
        {
            var allRecipeLike = await _unitOfWork.UserRecipeLikeRepository.GetAllAsync();
            var recipeLikes = allRecipeLike.Where(r => r.RecipeId == recipeId);
            return recipeLikes.ToList();

        }
    }

}
