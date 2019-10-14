using clu.aspnet.webapplication.mvc.core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace clu.aspnet.webapplication.mvc.core.DataAccess
{
    public class HrContext : DbContext
    {
        public HrContext(DbContextOptions<HrContext> options)
            : base(options)
        {

        }

        public DbSet<Person> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var persons = new List<Person>
            {
                new Person
                {
                    PersonId = 1,
                    FirstName = "James",
                    LastName = "Smith",
                    Age = 22,
                    EmailAddress = "jsmith@microsoft.com"
                },
                new Person
                {
                    PersonId = 2,
                    FirstName = "Arthur",
                    LastName = "Adams",
                    Age = 21,
                    EmailAddress = "aadams@microsoft.com"
                }
            };

            persons.ForEach(p => p.Name = $"{p.FirstName} {p.LastName}");

            modelBuilder.Entity<Person>().HasData(persons.ToArray());
        }
    }
}