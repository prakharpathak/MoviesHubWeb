using Microsoft.EntityFrameworkCore;
using MoviesHubWeb.Models;

namespace MoviesHubWeb.DATA
{
    public class MHB_DBContext: DbContext
    {
        public MHB_DBContext(DbContextOptions<MHB_DBContext> options) : base(options)
        {
            
        }

        public DbSet<Movies> Movies { get; set; } 
    }
}
