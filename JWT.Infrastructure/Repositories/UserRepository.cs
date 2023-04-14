using JSWSample.Domain.Auth;
using Microsoft.EntityFrameworkCore;
using JWTSample.Application.IRepositories;
using JSWSample.Infrastructure.DatabaseContext;

namespace JSWSample.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<User> Insert(User model)
        {
            _applicationDbContext.Users.AddAsync(model);
            await _applicationDbContext.SaveChangesAsync();
            return model;
        }

        public async Task<User> Update(User model)
        {
            _applicationDbContext.Users.Update(model);
            await _applicationDbContext.SaveChangesAsync();
            return model;
        }

        public async Task<User> Delete(User model)
        {
            _applicationDbContext.Users.Remove(model);
            await _applicationDbContext.SaveChangesAsync();
            return model;
        }

        public async Task<List<User>> GetAll() =>
            await _applicationDbContext.Users.ToListAsync();

        public async Task<User> GetById(int userId) =>
            await _applicationDbContext.Users.FindAsync(userId);

        public async Task<User> GetByUsername(string username) =>
            await _applicationDbContext.Set<User>().FirstOrDefaultAsync(x => x.Username == username);

    }
}
