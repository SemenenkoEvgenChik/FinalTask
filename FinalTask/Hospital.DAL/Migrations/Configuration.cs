using Hospital.DAL.Enums;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;


namespace Hospital.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Hospital.DAL.HospitalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Hospital.DAL.HospitalContext";
        }

        protected override void Seed(Hospital.DAL.HospitalContext context)
        {

            var roles = new List<IdentityRole>() {

                new IdentityRole{
                    Id = Guid.NewGuid().ToString(),
                    Name = EnumRole.Admin.ToString()
                },
                new IdentityRole{
                    Id = Guid.NewGuid().ToString(),
                    Name = EnumRole.Doctor.ToString()
                },
                new IdentityRole{
                    Id = Guid.NewGuid().ToString(),
                    Name = EnumRole.HospitalStaff.ToString()
                }
            };
            roles.ForEach(rol => context.Roles.Add(rol));

            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
