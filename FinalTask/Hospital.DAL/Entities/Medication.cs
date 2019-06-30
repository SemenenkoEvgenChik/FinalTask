using System;

namespace Hospital.DAL.Entities
{
    public class Medication:BaseEntity
    {
        public string Operations { get; set; }
        public string Procedures { get; set; }
        public string ProceduresDescription { get; set; }
        public DateTime DescriptionDate { get; set; }
        public int HistoryIllnessId { get; set; }
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual HistoryIllness HistoryIllness { get; set; }
    }
}
