using Hospital.DAL.Entities;
using System.Collections.Generic;

namespace Hospital.DAL.Repositories.Interfaces
{
    public interface IHistoryIllnessRepository : IBaseRepository<HistoryIllness>
    {
    IEnumerable<HistoryIllness> PatientCard(int id);
    }
}
