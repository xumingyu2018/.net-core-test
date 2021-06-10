using Microsoft.EntityFrameworkCore;


namespace demo2.Models
{
    public class MvcMovieContext :DbContext
    {       
       
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options):base(options)
        {
        }
         public DbSet<Movie> Movie { get; set; }
        

    }
}