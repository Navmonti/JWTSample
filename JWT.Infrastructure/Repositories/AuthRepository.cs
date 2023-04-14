using JSWSample.Domain.Auth;
using Microsoft.EntityFrameworkCore;
using JWTSample.Application.IRepositories;
using JSWSample.Infrastructure.DatabaseContext;

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
    }
}
