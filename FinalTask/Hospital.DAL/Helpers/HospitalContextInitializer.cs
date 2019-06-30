using Hospital.DAL.Entities;
using Hospital.DAL.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Hospital.DAL.Helpers
{
    class HospitalContextInitializer : CreateDatabaseIfNotExists<HospitalContext>
    {
        protected override void Seed(HospitalContext context)
        {
           //ApplicationUserManager userManager = new UserManager<ApplicationUser>(context);
           //var user = new List<IdentityUser>
           //{
                    

           //};

            var doctors = new List<Doctor>
            {
                new Doctor
                {
                    Name = "Евгений",
                    Surname = "Семененко",
                    Expirience = 3,
                    Specialty = ClassificationOfDoctors.Психиатр,
                    

                },
                new Doctor
                {
                    Name = "Вася",
                    Surname = "Пупкин",
                    Expirience = 12,
                    Specialty = ClassificationOfDoctors.Гинеколог
                },
            };
            doctors.ForEach(doc => context.Doctors.Add(doc));

            DateTime dateOfBirth = new DateTime(2015, 7, 20);

            var patient = new Patient
            {
                Name = "Екатерина",
                Surname = "Строгачева",
                DateOfBirth = dateOfBirth,

            };

            context.Patients.Add(patient);

            context.SaveChanges();

         

        }
    }
}
