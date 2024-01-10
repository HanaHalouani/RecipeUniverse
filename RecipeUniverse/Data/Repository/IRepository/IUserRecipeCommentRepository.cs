using RecipeUniverse.Models;

namespace RecipeUniverse.Data.Repository.IRepository
{
    public interface IUserRecipeCommentRepository : IRepository<Comment>
    {
        void Update(Comment comment);
    }
}
