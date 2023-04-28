using JSWSample.Domain.Auth;
using JSWSample.Infrastructure.DatabaseContext;
using JWTSample.Application.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace JSWSample.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AuthRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<User> Login(string username, string password)
        { 
            return await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
        }

        public Task<User> Signup(User user)
        {
            throw new NotImplementedException();
        }
    }
}
