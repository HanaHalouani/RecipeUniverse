using RecipeUniverse.Areas.Identity.Data;
using RecipeUniverse.Data.Repository.IRepository;

namespace RecipeUniverse.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private RecipeUniverseContext _db;

        public UserRepository(RecipeUniverseContext db) : base(db)
        {
            _db = db;
        }
        public void Update(User user)
        {
            _db.Users.Update(user);
        }
    }
}
