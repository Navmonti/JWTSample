using JSWSample.Domain.Auth; 

namespace JWTSample.Application.IRepositories
{
    public interface IUserRepository
    {
        Task<User> Insert(User model);
        Task<User> Update(User model);
        Task<User> Delete(User model);
        Task<List<User>> GetAll();
        Task<User> GetById(int userId);
        Task<User> GetByUsername(string username);
    }
}
