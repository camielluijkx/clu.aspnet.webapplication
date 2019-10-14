using clu.aspnet.webapplication.mvc.core.Models;
using Microsoft.EntityFrameworkCore;

namespace clu.aspnet.webapplication.mvc.core.DataAccess
{
    public class DemographyContext : DbContext
    {
        public DemographyContext(DbContextOptions<DemographyContext> options) 
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Person> People { get; set; }
    }
}