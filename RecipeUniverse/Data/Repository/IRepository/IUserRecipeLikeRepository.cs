using RecipeUniverse.Models;

namespace RecipeUniverse.Data.Repository.IRepository
{
    public interface IUserRecipeLikeRepository : IRepository<RecipeLikes>
    {
        void Update(RecipeLikes like);
    }
}
