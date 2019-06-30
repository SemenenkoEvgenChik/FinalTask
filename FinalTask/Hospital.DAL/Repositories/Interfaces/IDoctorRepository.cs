using Hospital.DAL.Entities;
using Hospital.DAL.Enums;
using System.Collections.Generic;

namespace Hospital.DAL.Repositories.Interfaces
{
    public interface IDoctorRepository:IBaseRepository<Doctor>
    {
        int Count(Doctor doctor);
        IEnumerable<Doctor> SearchDoctor(Doctor doctor, int page, int size, int sortIndex);
        IEnumerable<Doctor> SearchToAssign(ClassificationOfDoctors classification);
        bool SotfDelete(int id);
        int GetIdDoctor(string userId);
        int GetClassificationDoctor(int classification);
        int CountPatient(int doctorId);

    }
}
