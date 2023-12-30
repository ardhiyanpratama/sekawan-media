using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SekawanMedia.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Data.DataSeed
{
    public class SeedData
    {
        public static void Seed(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            applicationDbContext.Database.Migrate();

            if (!applicationDbContext.MsUserRoles.Any())
            {
                var userGroup = new List<MsUserRoles> {
                    new MsUserRoles
                    {
                        Name = "Admin",
                        IsActive= true,
                        CreatedBy = "admin"
                    },
                    new MsUserRoles
                    {
                        Name = "Manager",
                        IsActive= true,
                        CreatedBy = "admin"
                    },
                    new MsUserRoles
                    {
                        Name = "Driver",
                        IsActive= true,
                        CreatedBy = "admin"
                    }
                };

                applicationDbContext.AddRange(userGroup);
                applicationDbContext.SaveChanges();
            }


        }
    }
}
