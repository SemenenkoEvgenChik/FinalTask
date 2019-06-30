using Hospital.DAL.Entities;
using Hospital.DAL.Enums;
using Hospital.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.DAL.Repositories
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HospitalContext context) : base(context)
        {

        }
        public int Count(Doctor doctor)
        {
            var result = _context.Doctors.Where(x =>
              (string.IsNullOrEmpty(doctor.Name) || x.Name == doctor.Name) &&
              (string.IsNullOrEmpty(doctor.Surname) || x.Surname == doctor.Surname) &&
              (doctor.Specialty == 0 || x.Specialty == doctor.Specialty) && (x.Deleted == false)
            )
                .Count();
            return result;
        }

        public int GetClassificationDoctor(int classification)
        {
            var doctor = _context.Doctors.Where(x => (int)x.Specialty == classification).FirstOrDefault();
            int speciality = (int)doctor.Specialty;

            return speciality;
        }

        public int GetIdDoctor(string userId)
        {
            var doctor = _context.Doctors.Where(x => x.UserId == userId).FirstOrDefault();
            int id = doctor.Id;

         return id;
        }
        public int CountPatient(int doctorId)
        {
            var count = _context.HistoryIllnesses.Where(h=>h.DoctorId == doctorId && string.IsNullOrEmpty(h.FinalDiagnosis)).Count();
            return count;
        }
        public IEnumerable<Doctor> SearchDoctor(Doctor doctor, int page, int size, int sortIndex)
        {
            Func<Doctor, object> func = d => d.Id;
            if (sortIndex == 1) {
                func = d => d.Surname + d.Name;
            }
            if (sortIndex == 2) {
                func = d => d.Specialty;
            }
            if (sortIndex == 3) {
                func = d => d.HistoryIllnesses.Where(x => string.IsNullOrEmpty(x.FinalDiagnosis) && x.Doctor.Id == x.Id).Count();
            }
            var result = _context.Doctors.Where(x =>
              (string.IsNullOrEmpty(doctor.Name) || x.Name == doctor.Name) &&
              (string.IsNullOrEmpty(doctor.Surname) || x.Surname == doctor.Surname) &&
              ((int)doctor.Specialty == 0 || x.Specialty == doctor.Specialty) && (x.Deleted == false)
            )
                .OrderBy(func)
                .Skip((page - 1) * size)
                .Take(size).ToList();

            return result;
        }

        public IEnumerable<Doctor> SearchToAssign(ClassificationOfDoctors classification)
        {
            var result = _context.Doctors.Where(d => (classification == 0 || d.Specialty == classification) && (d.Deleted==false)).Where(r => r.Role == EnumForMedicRole.Doctor ).ToList();
            return result;
        }

        public bool SotfDelete(int id)
        {
            var entity = _context.Doctors.Where(x => x.Id == id).SingleOrDefault();

            entity.Deleted = true;

            return true;

        }
    }
}
