using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Entities;

namespace SuperHeroAPI_DotNet8.Data
{
    // Ctrl + . on DbContext for quickfix
    // Install the latest package 'Microsoft.EntityFrameworkCore
    // Inherit from DBContext
    public class DataContext : DbContext
    {
        // Boiler plate code
        // Constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        // Database Set
        public DbSet<SuperHero> SuperHeroes{ get; set; }
    }
}
