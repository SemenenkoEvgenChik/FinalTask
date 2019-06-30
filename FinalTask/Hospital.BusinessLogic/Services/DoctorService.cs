using AutoMapper;
using Hospital.BusinessLogic.Services.Interface;
using Hospital.DAL.Entities;
using Hospital.DAL.UnitOfWorks.Interfaces;
using Hospital.BusinessLogic.ViewModels;
using System.Collections.Generic;
using Hospital.BusinessLogic.Pagination;
using Hospital.BusinessLogic.ViewEnums;
using Hospital.DAL.Enums;
using System;
using System.Net.Mail;
using System.Text;
using System.Linq;
using System.IO;
namespace Hospital.BusinessLogic.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        private readonly ApplicationUserManager _userManager;

        public DoctorService(IUnitOfWork context, IMapper mapper, ApplicationUserManager userManager)
        {
            _db = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        private static Random random = new Random((int)DateTime.Now.Ticks);
        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
        public int AddDoctor(DoctorViewModel doctorViewModel)
        {
            var doctor = _mapper.Map<DoctorViewModel, Doctor>(doctorViewModel);
            var user = new ApplicationUser() { Email = doctorViewModel.Email, UserName = doctorViewModel.Email };

            var password = RandomString(10);

            var task = _userManager.CreateAsync(user, password);
            task.Wait();

            if (!task.Result.Succeeded) throw new Exception("Fail");

            doctor.UserId = user.Id;
            var medicRole = doctorViewModel.Role.ToString();

            var role = _userManager.AddToRoleAsync(user.Id, medicRole);
            role.Wait();

            _db.Doctors.Add(doctor);

            string s = user.Email.ToString();

            MailMessage message = new MailMessage();
            message.To.Add(s);
            message.Subject = "Your Password";
            message.Body = "Используйте этот пароль при входе в учетную запись: " + password;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(message);

            _db.Save();
            return doctor.Id;
        }

        public void Appoint(DoctorAssigningViewModel doctorAssigningViewModel)
        {
            var map = _mapper.Map<DoctorAssigningViewModel, HistoryIllness>(doctorAssigningViewModel);
            _db.HistoryIllness.Add(map);
        }

        public void SotfDelete(int id)
        {
            _db.Doctors.SotfDelete(id);
            _db.Save();
        }

        public DoctorViewModel GetDoctor(int id)
        {
            return _mapper.Map<Doctor, DoctorViewModel>(_db.Doctors.GetById(id));
        }

        public int NumberOfRecords(Doctor doctor)
        {
            return _db.Doctors.Count(doctor);
        }

        public PaginationViewModel<DoctorViewModel> SearchDoctor(DoctorViewModel doctor, int page, int size, int sortIndex)
        {
            var result = new PaginationViewModel<DoctorViewModel>();
            var map = _mapper.Map<DoctorViewModel, Doctor>(doctor);
            result.Data = _mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorViewModel>>(_db.Doctors.SearchDoctor(map, page, size, sortIndex));
            result.PageInfo.PageNumber = page;
            result.PageInfo.PageSize = size;
            result.PageInfo.TotalItems =  NumberOfRecords(map);

            foreach (var element in result.Data)
            {
                element.CountOfPatients = _db.Doctors.CountPatient(element.Id);
            }

            return result;
        }

        public IEnumerable<DoctorViewModel> SearchToAssign(ViewClassificationOfDoctors classification)
        {
            var map = _db.Doctors.SearchToAssign((ClassificationOfDoctors)classification);
            var result = _mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorViewModel>>(map);

            return result;
        }

        public DoctorViewModel ShowDetails(int id)
        {
            return GetDoctor(id);
        }

        public int GetIdIdentityDoctor(string userId)
        {
            return _db.Doctors.GetIdDoctor(userId);
        }

        public bool Edit(DoctorViewModel doctorViewModel)
        {
            var entity = _db.Doctors.GetById(doctorViewModel.Id);
            entity.Name = (string.IsNullOrEmpty(doctorViewModel.Name)) ? entity.Name : doctorViewModel.Name;
            entity.Surname = (string.IsNullOrEmpty(doctorViewModel.Surname))? entity.Surname : doctorViewModel.Surname;
            entity.Role = ((EnumForMedicRole)doctorViewModel.Role==0)? entity.Role:(EnumForMedicRole)doctorViewModel.Role;
            entity.Specialty = ((ClassificationOfDoctors)doctorViewModel.Specialty==0)? entity.Specialty : (ClassificationOfDoctors)doctorViewModel.Specialty;
            entity.Expirience = (doctorViewModel.Expirience == 0 )? entity.Expirience : doctorViewModel.Expirience;
            _db.Save();
            return true;
        }

        public int CreateCertificate(int id, string path)
        {
            var entity = _db.HistoryIllness.GetById(id);
            using (StreamWriter stream = new StreamWriter(path))
            {

                stream.WriteLine("          СПРАВКА" + "\r\n" +
                    entity.Patient.Name.ToString() +" "+ entity.Patient.Surname.ToString() + "\r\n" +
                    "Поступил: " + entity.ReceiptDate.ToString() + " Диагноз: " + entity.InitialDiagnosis.ToString()+ "\r\n" +
                    "Выписан: " + entity.DishargeDate.ToString() + " Диагноз: " +entity.FinalDiagnosis.ToString()+ "\r\n" +
                    "Доктор: " + entity.Doctor.Name.ToString() +" "+entity.Doctor.Surname.ToString() +" "+ entity.Doctor.Specialty.ToString());
            }

            return id;
        }
    }
}
