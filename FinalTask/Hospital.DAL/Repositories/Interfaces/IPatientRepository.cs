using Hospital.DAL.Entities;
using Hospital.DAL.Enums;
using System.Collections.Generic;
namespace Hospital.DAL.Repositories.Interfaces
{
    public interface IPatientRepository:IBaseRepository<Patient>
    {
        IEnumerable<Patient> SearchPatient(Patient patient, int page, int size, int sortIndex,int doctorId);
        IEnumerable<Patient> SearchRecoveredPatient(Patient patient, int page, int size, int sortIndex,int doctorId);
        IEnumerable<Patient> SearchPatientForHospitalStaff(Patient patient, int page, int size, int sortIndex, ClassificationOfDoctors classification);
        int Count(Patient patient, int doctorId);
        int CountForHospitalStaff(Patient patient);
    }

}
