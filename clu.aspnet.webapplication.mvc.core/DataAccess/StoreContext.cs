using clu.aspnet.webapplication.mvc.core.Models;
using Microsoft.EntityFrameworkCore;

namespace clu.aspnet.webapplication.mvc.core.DataAccess
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}