using RecipeUniverse.Areas.Identity.Data;
using RecipeUniverse.Data.Repository.IRepository;
using RecipeUniverse.Models;

namespace RecipeUniverse.Data.Repository
{
    public class UserRecipeLikeRepository : Repository<RecipeLikes>, IUserRecipeLikeRepository
    {
        private RecipeUniverseContext _db;

        public UserRecipeLikeRepository(RecipeUniverseContext db) : base(db)
        {
            _db = db;
        }

        public void Update(RecipeLikes like)
        {
            _db.Likes.Update(like);
        }

    }
}