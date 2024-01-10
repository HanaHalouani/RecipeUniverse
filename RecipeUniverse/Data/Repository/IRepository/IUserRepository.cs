using RecipeUniverse.Areas.Identity.Data;

namespace RecipeUniverse.Data.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User user);
    }
}
