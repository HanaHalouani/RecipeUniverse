using RecipeUniverse.Data.Repository.IRepository;
using RecipeUniverse.Models;

namespace RecipeUniverse.Data.Services
{
    public class UserRecipeCommentService : IUserRecipeCommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public UserRecipeCommentService(
            IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userService = userService ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            var allLikes = await _unitOfWork.UserRecipeCommentRepository.GetAllAsync();
            return allLikes;
        }

        public void AddComment(Comment comment)
        {
            _unitOfWork.UserRecipeCommentRepository.Add(comment);
            _unitOfWork.Save();
        }

        public async Task DeleteCommentAsync(int? id)
        {
            var comment = await _unitOfWork.UserRecipeCommentRepository.GetAsync(i => i.Id == id);
            _unitOfWork.UserRecipeCommentRepository.Delete(comment);
            _unitOfWork.Save();
        }

        public async Task<List<Comment>?> GetCommentsByRecipeIdAsync(int? recipeId)
        {
            var allUserRecipeComment = await _unitOfWork.UserRecipeCommentRepository.GetAllAsync();
            var userRecipeComments = allUserRecipeComment.Where(r => r.RecipeId == recipeId).ToList();
            foreach (var comment in userRecipeComments)
            {
                comment.User = await _userService.GetUserByIdAsync(comment.UserId);
            }
            return userRecipeComments;
        }
    }

}
