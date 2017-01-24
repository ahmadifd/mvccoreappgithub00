using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvccoreappgithub.Models;

namespace mvccoreappgithub.Data
{
    public class ApplicationDbContext : DbContext /*IdentityDbContext<ApplicationUser>*/
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Person>(e => e.HasKey(f=>new { f.ID , f.JID }));



            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Person> People { get; set; }


        public ApplicationDbContext() : base()
        {

        }
    }
}
