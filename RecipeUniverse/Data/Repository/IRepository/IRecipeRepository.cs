using RecipeUniverse.Models;

namespace RecipeUniverse.Data.Repository.IRepository
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        void Update(Recipe recipe);
    }
}
