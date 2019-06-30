using Hospital.DAL.Entities;
using Hospital.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.DAL.Repositories
{
    public class HistoryIllnessRepository : BaseRepository<HistoryIllness>, IHistoryIllnessRepository
    {
        public HistoryIllnessRepository(HospitalContext context) : base(context)
        {
        }

        public IEnumerable<HistoryIllness> PatientCard(int id)
        {
            var history = _context.HistoryIllnesses.Where(x => x.Id == id).ToList();

            return history;
        }
    }
}
