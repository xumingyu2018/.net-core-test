using Microsoft.EntityFrameworkCore;


namespace EFcoreDemo.Models
{
    public class UserDbContext:DbContext
    {
        public DbSet<User> Users{ get;set;}

        public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
        {
            
        }
    }
}