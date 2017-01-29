using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using mvccoreappgithub;
using mvccoreappgithub.Data;
using System;
using System.Linq;

namespace mvccoreappgithub.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceprovider)
        {
            using (var context = new
                ApplicationDbContext
                (serviceprovider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.People.Any())
                {
                    return;
                }
                else
                {
                    context.People.Add(new Person() { JID = 999, Salary = 999, Age = 455, UserName = "999", Name = "999" });
                    context.SaveChanges();
                }
            }

        }
    }
}
