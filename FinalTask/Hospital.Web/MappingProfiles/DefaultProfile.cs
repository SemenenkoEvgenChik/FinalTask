using AutoMapper;
using Hospital.BusinessLogic.Models.ViewModels;
using Hospital.BusinessLogic.ViewModels;
using Hospital.DAL.Entities;

namespace Hospital.Web.MappingProfiles
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<HistoryIllness, HistoryIllnessViewModel>();
            CreateMap<Doctor, DoctorViewModel>();
            CreateMap<Patient, PatientViewModel>();
            CreateMap<Patient, PatientProfileViewModel>();
            CreateMap<DoctorViewModel, Doctor>();
            CreateMap<PatientViewModel, Patient>();
            CreateMap<HistoryIllness, DoctorAssigningViewModel>();
            CreateMap<DoctorAssigningViewModel, HistoryIllness>();
            CreateMap<EstablishDiagnosisViewModel, HistoryIllness>();
            CreateMap<MedicationForDoctorViewModel, Medication>();
            CreateMap<Medication, MedicationForDoctorViewModel>();
            CreateMap<Medication, MedicationForHospitalStaffViewModel>();
            CreateMap<MedicationForHospitalStaffViewModel,Medication>();

        }
    }
}