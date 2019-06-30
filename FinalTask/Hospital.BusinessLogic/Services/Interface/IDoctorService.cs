using Hospital.DAL.Entities;
using Hospital.BusinessLogic.Pagination;
using Hospital.BusinessLogic.ViewEnums;
using Hospital.BusinessLogic.ViewModels;
using System.Collections.Generic;

namespace Hospital.BusinessLogic.Services.Interface
{
    public interface IDoctorService
    {
        DoctorViewModel GetDoctor(int id);
        int AddDoctor(DoctorViewModel doctorViewModel);
        DoctorViewModel ShowDetails(int id);
        int NumberOfRecords(Doctor doctor);
        void SotfDelete(int id);
        PaginationViewModel<DoctorViewModel> SearchDoctor(DoctorViewModel doctor, int page, int size, int sortIndex);
        IEnumerable<DoctorViewModel> SearchToAssign(ViewClassificationOfDoctors classification);
        void Appoint(DoctorAssigningViewModel doctorAssigningViewModel);
        int GetIdIdentityDoctor(string userId);
        bool Edit(DoctorViewModel doctorViewModel);
        int CreateCertificate(int id, string path);
    }
}
