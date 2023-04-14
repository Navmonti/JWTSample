using JSWSample.Domain.Auth; 

namespace JSWSample.Domain.IServices
{
    public interface IUserService
    {
        Task<User> Insert(User user);
        Task<User> Update(User user);
        Task<User> Delete(User user);
        Task<List<User>> GetAll();
        Task<User> GetById(int userId);
        Task<User> GetByUsername(string username);
    }
}
