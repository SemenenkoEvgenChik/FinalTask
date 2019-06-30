using Hospital.DAL.Entities;
using Hospital.DAL.Repositories.Interfaces;
using System;


namespace Hospital.DAL.UnitOfWorks.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IDoctorRepository Doctors { get; }
        IHistoryIllnessRepository HistoryIllness { get; }
        IMedicationRepository Medications { get; }
        IPatientRepository  Patients { get; }
        void Save();
    }
}
