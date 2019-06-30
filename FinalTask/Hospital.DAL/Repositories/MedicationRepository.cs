using System.Collections.Generic;
using System.Linq;
using Hospital.DAL.Entities;
using Hospital.DAL.Repositories.Interfaces;

namespace Hospital.DAL.Repositories
{
    public class MedicationRepository : BaseRepository<Medication>, IMedicationRepository
    {
        public MedicationRepository(HospitalContext context) : base(context)
        {
        }

        public IEnumerable<Medication> GetMedication(int HistoryIllnessId)
        {
            var medication = _context.Medications.Where(m=>m.HistoryIllnessId == HistoryIllnessId).ToList();

            return medication;
        }
    }
}
