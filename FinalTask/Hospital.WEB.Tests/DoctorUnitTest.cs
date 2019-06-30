using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Hospital.BusinessLogic.Services;
using Hospital.BusinessLogic.ViewModels;
using Hospital.DAL.Entities;
using Hospital.DAL.Enums;
using Hospital.DAL.Repositories.Interfaces;
using Hospital.DAL.UnitOfWorks.Interfaces;
using Hospital.WEB.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Hospital.Web.Tests
{
    [TestClass]
    public class DoctorUnitTest
    {
        [TestMethod]
        public void Edit()
        {
            //Arrange
            Mock<IDoctorRepository> mock = new Mock<IDoctorRepository>();
            int id = 0;
            Doctor doctor = new Doctor
            {
                Id = 0,
                Deleted = false,
                Expirience = 10,
                HistoryIllnesses = null,
                Name = "Petro",
                Surname = "Petrov",
                Role = EnumForMedicRole.Doctor,
                Specialty = ClassificationOfDoctors.Гинеколог,
                User = null,
                UserId = Guid.NewGuid().ToString()
            };
            List<Doctor> doctors = new List<Doctor>() { doctor };
            mock.Setup(x => x.GetById(id)).Returns(doctors.Where(d => d.Id == id).FirstOrDefault());
            DoctorViewModel doctorViewModel = new DoctorViewModel
            {
                Id = id,
                Name = "Vasya"
            };
            Mock<IUnitOfWork> mock2 = new Mock<IUnitOfWork>();
            mock2.Setup(x => x.Doctors).Returns(mock.Object);
            mock2.Setup(x => x.Save());

            var service = new DoctorService(mock2.Object, null, null);

            //Act
            service.Edit(doctorViewModel);

            //Assert
            if (string.IsNullOrEmpty(doctorViewModel.Name))
            {
                Assert.AreEqual(doctorViewModel.Name, doctorViewModel.Name);
            }
        }

        [TestMethod]
        public void GetDoctorTest()
        {
            //Arrange
            Mock<IDoctorRepository> mock = new Mock<IDoctorRepository>();
            int id = 0;
            Doctor item = new Doctor()
            {
                Id = 0,
                Deleted = false,
                Expirience = 10,
                HistoryIllnesses = null,
                Name = "Petro",
                Surname = "Petrov",
                Role = EnumForMedicRole.Doctor,
                Specialty = ClassificationOfDoctors.Гинеколог,
                User = null,
                UserId = Guid.NewGuid().ToString()
            };

            List<Doctor> doctors = new List<Doctor>();
            doctors.Add(item);
            mock.Setup(x => x.GetById(id)).Returns(doctors.Where(d => d.Id == id).FirstOrDefault());
            Mock<IUnitOfWork> unitOfWorkMoq = new Mock<IUnitOfWork>();
            unitOfWorkMoq.Setup(x => x.Doctors).Returns(mock.Object);
            var service = new DoctorService(unitOfWorkMoq.Object, MapperTest.AutoMapper, null);
            //Act
            DoctorViewModel doctor = service.GetDoctor(id);
            //Assert
            Assert.AreEqual(item.Id, doctor.Id);
        }

        [TestMethod]
        public void GetIdIdentityDoctor()
        {
            //Arrange
            Mock<IDoctorRepository> mock = new Mock<IDoctorRepository>();
            string userId = Guid.NewGuid().ToString();
            Doctor doc = new Doctor
            {
                Id = 0,
                Deleted = false,
                Expirience = 10,
                HistoryIllnesses = null,
                Name = "Petro",
                Surname = "Petrov",
                Role = EnumForMedicRole.Doctor,
                Specialty = ClassificationOfDoctors.Гинеколог,
                User = null,
                UserId = userId
            };
            List<Doctor> doctors = new List<Doctor>() { doc };

            mock.Setup(x => x.GetIdDoctor(userId)).Returns(doctors.FirstOrDefault(d => d.UserId == userId).Id);
            Mock<IUnitOfWork> mock2 = new Mock<IUnitOfWork>();
            mock2.Setup(x => x.Doctors).Returns(mock.Object);
            //Act
            int actual = new DoctorService(mock2.Object, null, null).GetIdIdentityDoctor(userId);
            //Assert
            Assert.AreEqual<int>(doc.Id, actual);
        }
        [TestMethod]
        public void SoftDelete()
        {
            //Arrange
            int id = 0;
            Doctor doc = new Doctor
            {
                Id = 0,
                Deleted = false,
                Expirience = 10,
                HistoryIllnesses = null,
                Name = "Petro",
                Surname = "Petrov",
                Role = EnumForMedicRole.Doctor,
                Specialty = ClassificationOfDoctors.Гинеколог,
                User = null,
                UserId = Guid.NewGuid().ToString()
            };
            List<Doctor> doctors = new List<Doctor>() { doc };

            Mock<IDoctorRepository> reposMoq = new Mock<IDoctorRepository>();
            reposMoq.Setup(x => x.SotfDelete(id)).Callback(() => { doctors.FirstOrDefault(d => d.Id == id).Deleted = true; });
            Mock<IUnitOfWork> unitOfWorkMoq = new Mock<IUnitOfWork>();
            unitOfWorkMoq.Setup(x => x.Doctors).Returns(reposMoq.Object);
            unitOfWorkMoq.Setup(x => x.Save());

            var service = new DoctorService(unitOfWorkMoq.Object, null, null);
            //Act
            service.SotfDelete(id);
            //Assert
            Assert.AreEqual(true, doc.Deleted);
        }
    }
}
