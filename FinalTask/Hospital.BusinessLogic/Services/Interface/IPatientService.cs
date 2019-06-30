using Hospital.DAL.Entities;
using Hospital.BusinessLogic.Pagination;
using Hospital.BusinessLogic.ViewModels;
using System.Collections.Generic;
using Hospital.BusinessLogic.Models.ViewModels;

namespace Hospital.BusinessLogic.Services.Interface
{
    public interface IPatientService
    {
        PatientProfileViewModel ShowDetails(int id);
        void Create(PatientViewModel patient);
        void DoctorAssigning(DoctorAssigningViewModel doctorAssigningViewModel);
        PaginationViewModel<PatientViewModel> SearchPatient(PatientViewModel patient,int page,int size, int sortIndex,int doctorId);
        void EstablishDiagnos(EstablishDiagnosisViewModel establishDiagnosisViewModel);
        int NumberOfRecords(Patient patient, int doctorId);
        int NumberOfRecordsForHospitalStaff(Patient patient);
        PaginationViewModel<PatientViewModel> SearchPatientForHospitalStaff(PatientViewModel patient, int page, int size, int sortIndex, int doctorId);
        void AddMedicationForDoctor(MedicationForDoctorViewModel medicationViewModel);
        void AddMedicationForDoctor(MedicationForHospitalStaffViewModel medicationForHospitalStaffViewModel );
        IEnumerable<MedicationForDoctorViewModel> GetMedication(int HistoryIllnessId);
        void DischargeFromHospital(EstablishDiagnosisViewModel establishDiagnosisViewModel);

    }
}
