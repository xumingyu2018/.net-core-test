using Microsoft.EntityFrameworkCore;

namespace MvcDemo_EF.Models
{
    public class MvcUserContext : DbContext
    {   
        public MvcUserContext (DbContextOptions<MvcUserContext> options) : base(options)
        {
        }
        public DbSet<UserInfo> UserInfo { get; set; }
    }
}
