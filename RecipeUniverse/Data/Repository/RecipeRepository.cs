using RecipeUniverse.Areas.Identity.Data;
using RecipeUniverse.Data.Repository.IRepository;
using RecipeUniverse.Models;

namespace RecipeUniverse.Data.Repository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        private readonly RecipeUniverseContext _db;

        public RecipeRepository(RecipeUniverseContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Recipe recipe)
        {
            _db.Recipes.Update(recipe);
        }

    }
}
