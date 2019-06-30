using AutoMapper;
using Hospital.BusinessLogic.Services.Interface;
using Hospital.DAL.Entities;
using Hospital.DAL.UnitOfWorks.Interfaces;
using Hospital.BusinessLogic.Pagination;
using Hospital.BusinessLogic.ViewModels;
using System.Collections.Generic;
using Hospital.BusinessLogic.Models.ViewModels;
using System;
using System.Linq;

namespace Hospital.BusinessLogic.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;

        public PatientService(IUnitOfWork context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }


        public void Create(PatientViewModel patient)
        {
            var map = _mapper.Map<PatientViewModel, Patient>(patient);
            _db.Patients.Add(map);
        }
        public PaginationViewModel<PatientViewModel> SearchPatient(PatientViewModel patient, int page, int size, int sortIndex, int doctorId)
        {
            var result = new PaginationViewModel<PatientViewModel>();
            var map = _mapper.Map<PatientViewModel, Patient>(patient);
            result.Data = _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientViewModel>>(_db.Patients.SearchPatient(map, page, size, sortIndex, doctorId));
            result.PageInfo.PageNumber = page;
            result.PageInfo.PageSize = size;
            result.PageInfo.TotalItems = NumberOfRecords(map,doctorId);

            return result;
        }
        public PaginationViewModel<PatientViewModel> SearchPatientForHospitalStaff(PatientViewModel patient, int page, int size, int sortIndex, int doctorId)
        {
            var result = new PaginationViewModel<PatientViewModel>();
            var map = _mapper.Map<PatientViewModel, Patient>(patient);
            var doctor = _db.Doctors.GetById(doctorId);
            var specialty = doctor.Specialty;
            result.Data = _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientViewModel>>(_db.Patients.SearchPatientForHospitalStaff(map, page, size, sortIndex, specialty));
            result.PageInfo.PageNumber = page;
            result.PageInfo.PageSize = size;
            result.PageInfo.TotalItems = NumberOfRecordsForHospitalStaff(map);

            return result;
        }

        public PatientProfileViewModel ShowDetails(int id)
        {
            var entity = _db.Patients.GetById(id);
            var result = _mapper.Map<Patient, PatientProfileViewModel>(entity);
            return result;
        }

        public void DoctorAssigning(DoctorAssigningViewModel doctorAssigningViewModel)
        {
            var result = _mapper.Map<DoctorAssigningViewModel, HistoryIllness>(doctorAssigningViewModel);
            _db.HistoryIllness.Add(result);
        }

        public int NumberOfRecords(Patient patient, int doctorId)
        {
            return _db.Patients.Count(patient,doctorId);
        }

        public void EstablishDiagnos(EstablishDiagnosisViewModel model)
        {
            var entity = _db.HistoryIllness.GetById(model.Id);

            entity.InitialDiagnosis = model.InitialDiagnosis;
            entity.ReceiptDate = DateTime.Now;

            _db.Save();
        }

        public void AddMedicationForDoctor(MedicationForDoctorViewModel medicationViewModel)
        {
            var map = _mapper.Map<MedicationForDoctorViewModel, Medication>(medicationViewModel);
            map.DescriptionDate = DateTime.Now;
            _db.Medications.Add(map);
            _db.Save();
        }

        public IEnumerable<MedicationForDoctorViewModel> GetMedication(int HistoryIllnessId)
        {
            var medication = _db.Medications.GetMedication(HistoryIllnessId);
            var map = _mapper.Map<IEnumerable<Medication>, IEnumerable<MedicationForDoctorViewModel>>(medication);
            return map;
        }

        public void DischargeFromHospital(EstablishDiagnosisViewModel model)
        {
            var entity = _db.HistoryIllness.GetById(model.Id);

            entity.FinalDiagnosis = model.FinalDiagnosis;
            entity.DishargeDate = DateTime.Now;

            _db.Save();
        }

        public void AddMedicationForDoctor(MedicationForHospitalStaffViewModel medicationForHospitalStaffViewModel)
        {
            var map = _mapper.Map<MedicationForHospitalStaffViewModel, Medication>(medicationForHospitalStaffViewModel);
            map.DescriptionDate = DateTime.Now;
            _db.Medications.Add(map);
            _db.Save();
        }

        public int NumberOfRecordsForHospitalStaff(Patient patient)
        {
            return _db.Patients.CountForHospitalStaff(patient);
        }

        public PaginationViewModel<PatientViewModel> SearchRecoveredPatient(PatientViewModel patient, int page, int size, int sortIndex, int doctorId)
        {
            var result = new PaginationViewModel<PatientViewModel>();
            var map = _mapper.Map<PatientViewModel, Patient>(patient);
            result.Data = _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientViewModel>>(_db.Patients.SearchRecoveredPatient(map, page, size, sortIndex, doctorId));
            result.PageInfo.PageNumber = page;
            result.PageInfo.PageSize = size;
            result.PageInfo.TotalItems = NumberOfRecords(map, doctorId);

            return result;
        }
    }
}

