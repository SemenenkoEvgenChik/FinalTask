using Hospital.DAL.Entities;
using Hospital.DAL.Repositories;
using Hospital.DAL.Repositories.Interfaces;
using Hospital.DAL.UnitOfWorks.Interfaces;
using System;

namespace Hospital.DAL.UnitOfWorks
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly HospitalContext _db;

        private  IDoctorRepository _doctorRepository;
        private  IHistoryIllnessRepository _historyIllnessRepository;
        private  IMedicationRepository _medicationRepository;
        private  IPatientRepository _patientRepository;


        public EFUnitOfWork(HospitalContext db)
        {
            _db = db;
        }

        public IDoctorRepository Doctors
        {
            get
            {
                if (_doctorRepository == null)
                    _doctorRepository = new DoctorRepository(_db);

                return _doctorRepository;
            }
        }

        public IHistoryIllnessRepository HistoryIllness
        {
            get
            {
                if (_historyIllnessRepository == null)
                    _historyIllnessRepository = new HistoryIllnessRepository(_db);

                return _historyIllnessRepository;
            }
        }
        public IMedicationRepository Medications
        {
            get
            {
                if (_medicationRepository == null)
                    _medicationRepository = new MedicationRepository(_db);

                return _medicationRepository;
            }
        }
        public IPatientRepository Patients
        {
            get
            {
                if (_patientRepository == null)
                    _patientRepository = new PatientRepository(_db);

                return _patientRepository;
            }
        }

        

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
