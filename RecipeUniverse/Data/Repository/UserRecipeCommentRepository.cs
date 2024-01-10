using RecipeUniverse.Areas.Identity.Data;
using RecipeUniverse.Data.Repository.IRepository;
using RecipeUniverse.Models;

namespace RecipeUniverse.Data.Repository
{
    public class UserRecipeCommentRepository : Repository<Comment>, IUserRecipeCommentRepository
    {
        private RecipeUniverseContext _db;

        public UserRecipeCommentRepository(RecipeUniverseContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Comment comment)
        {
            _db.Comments.Update(comment);
        }

    }
}