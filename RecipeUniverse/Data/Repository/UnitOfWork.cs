using RecipeUniverse.Areas.Identity.Data;
using RecipeUniverse.Data.Repository.IRepository;

namespace RecipeUniverse.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRecipeRepository RecipeRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public IUserRecipeLikeRepository UserRecipeLikeRepository { get; private set; }
        public IUserRecipeCommentRepository UserRecipeCommentRepository { get; private set; }

        private readonly RecipeUniverseContext _db;
        public UnitOfWork(RecipeUniverseContext db)
        {
            _db = db;
            RecipeRepository = new RecipeRepository(_db);
            UserRepository = new UserRepository(_db);
            UserRecipeLikeRepository = new UserRecipeLikeRepository(db);
            UserRecipeCommentRepository = new UserRecipeCommentRepository(_db);

        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
