namespace RecipeUniverse.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IRecipeRepository RecipeRepository { get; }
        IUserRecipeLikeRepository UserRecipeLikeRepository { get; }
        IUserRecipeCommentRepository UserRecipeCommentRepository { get; }
        IUserRepository UserRepository { get; }

        void Save();
    }
}
