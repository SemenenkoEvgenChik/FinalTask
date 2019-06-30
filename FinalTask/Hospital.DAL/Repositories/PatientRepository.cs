using System.Collections.Generic;
using Hospital.DAL.Entities;
using Hospital.DAL.Repositories.Interfaces;
using System.Linq;
using System;
using Hospital.DAL.Enums;

namespace Hospital.DAL.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientRepository(HospitalContext context) : base(context)
        {
        }

        public int Count(Patient patient, int doctorId)
        {
            var result = _context.Patients
                .Where(s => doctorId == 0 || s.HistoryIllnesses.Where(i => i.DoctorId == doctorId && string.IsNullOrEmpty(i.FinalDiagnosis)).Count() > 0)
                .Where(x =>
                    (string.IsNullOrEmpty(patient.Name) || x.Name == patient.Name) &&
                    (string.IsNullOrEmpty(patient.Surname) || x.Surname == patient.Surname) &&
                    (patient.DateOfBirth.Equals(DateTime.MinValue) || x.DateOfBirth == patient.DateOfBirth)
                ).Count();
            return result;
        }
        public int CountForHospitalStaff(Patient patient)
        {
            var result = _context.Patients
                .Where(s => s.HistoryIllnesses.Where(i => i.Doctor.Role == EnumForMedicRole.HospitalStaff && string.IsNullOrEmpty(i.FinalDiagnosis)).Count() > 0)
                .Where(x =>
                    (string.IsNullOrEmpty(patient.Name) || x.Name == patient.Name) &&
                    (string.IsNullOrEmpty(patient.Surname) || x.Surname == patient.Surname) &&
                    (patient.DateOfBirth.Equals(DateTime.MinValue) || x.DateOfBirth == patient.DateOfBirth)
                ).Count();
            return result;
        }

        public IEnumerable<Patient> SearchPatient(Patient patient, int page, int size, int sortIndex, int doctorId = 0)
        {
            Func<Patient, object> func = p => p.Id;
            if (sortIndex == 1)
            {
                func = p => p.DateOfBirth;
            }
            if (sortIndex == 2)
            {
                func = p => p.Surname + p.Name;
            }
            var result = _context.Patients
                .Where(s => doctorId == 0 || s.HistoryIllnesses.Where(i => i.DoctorId == doctorId && string.IsNullOrEmpty(i.FinalDiagnosis)).Count() > 0)
                .Where(x =>
                    (string.IsNullOrEmpty(patient.Name) || x.Name == patient.Name) &&
                    (string.IsNullOrEmpty(patient.Surname) || x.Surname == patient.Surname) &&
                    (patient.DateOfBirth.Equals(DateTime.MinValue) || x.DateOfBirth == patient.DateOfBirth)
                )
                .OrderBy(func)
                .Skip((page - 1) * size)
                .Take(size).ToList();

            return result;
        }

        public IEnumerable<Patient> SearchPatientForHospitalStaff(Patient patient, int page, int size, int sortIndex, ClassificationOfDoctors classification)
        {
            Func<Patient, object> func = p => p.Id;
            if (sortIndex == 1)
            {
                func = p => p.DateOfBirth;
            }
            if (sortIndex == 2)
            {
                func = p => p.Surname + p.Name;
            }
            var result = _context.Patients
                .Where(s => s.HistoryIllnesses.Where(i => i.Doctor.Specialty == classification && string.IsNullOrEmpty(i.FinalDiagnosis)).Count() > 0)
                .Where(x =>
                    (string.IsNullOrEmpty(patient.Name) || x.Name == patient.Name) &&
                    (string.IsNullOrEmpty(patient.Surname) || x.Surname == patient.Surname) &&
                    (patient.DateOfBirth.Equals(DateTime.MinValue) || x.DateOfBirth == patient.DateOfBirth)
                )
                .OrderBy(func)
                .Skip((page - 1) * size)
                .Take(size).ToList();

            return result;
        }

        public IEnumerable<Patient> SearchRecoveredPatient(Patient patient, int page, int size, int sortIndex, int doctorId)
        {
            Func<Patient, object> func = p => p.Id;
            if (sortIndex == 1)
            {
                func = p => p.DateOfBirth;
            }
            if (sortIndex == 2)
            {
                func = p => p.Surname + p.Name;
            }
            var result = _context.Patients
                .Where(s => doctorId == 0 || s.HistoryIllnesses.Where(i => i.DoctorId == doctorId).Count() > 0)
                .Where(x =>
                    (string.IsNullOrEmpty(patient.Name) || x.Name == patient.Name) &&
                    (string.IsNullOrEmpty(patient.Surname) || x.Surname == patient.Surname) &&
                    (patient.DateOfBirth.Equals(DateTime.MinValue) || x.DateOfBirth == patient.DateOfBirth)
                )
                .OrderBy(func)
                .Skip((page - 1) * size)
                .Take(size).ToList();

            return result;
        }
    }
}
