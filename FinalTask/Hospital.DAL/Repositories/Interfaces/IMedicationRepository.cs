using Hospital.DAL.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Hospital.DAL.Repositories.Interfaces
{
    public interface IMedicationRepository : IBaseRepository<Medication>
    {
        IEnumerable<Medication> GetMedication(int id);
    }
}
