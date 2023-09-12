using DataAccessLayer.Entities;

namespace DataAccessLayer.Repos.UserRepos
{
    public interface IUserRepo: IGenericRepository<User>
    {
        Task<User> GetUserByUsername(string username);

        Task<User> GetUserWithRoles(int id);
    }
}
