using clu.aspnet.webapplication.mvc.core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace clu.aspnet.webapplication.mvc.core.DataAccess
{
    public class AuthenticationContext : IdentityDbContext<WebsiteUser>
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options)
            : base(options)
        {

        }
    }
}