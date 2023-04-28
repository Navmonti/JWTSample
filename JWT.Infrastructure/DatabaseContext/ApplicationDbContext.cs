using JSWSample.Domain.Auth;
using JSWSample.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace JSWSample.Infrastructure.DatabaseContext
{
    public class ApplicationDbContext : DbContext  
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = Guid.NewGuid(),
                    Username = "Admin",
                    Password = new Utiles().HashedString("123456"),
                    Salt = "123",
                    Firstname = "Navid",
                    Lastname = "Montazeripour",
                    Token = null,
                    TokenExpireDate = null
                });
        }

        public DbSet<User> Users { get; set; } 
    }
}
