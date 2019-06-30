using System;
using System.Collections.Generic;

namespace Hospital.DAL.Entities
{
    public class HistoryIllness : BaseEntity
    {
        public string InitialDiagnosis { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public string FinalDiagnosis { get; set; }
        public DateTime? DishargeDate { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<Medication> Medications { get; set; }

    }
}
