using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace EFcoreDemo.Models
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
        {
            
        }
        public DbSet<User> Users{ get;set;}

        public DbSet<MyFile> MyFiles { get; set; }
        
    }

}