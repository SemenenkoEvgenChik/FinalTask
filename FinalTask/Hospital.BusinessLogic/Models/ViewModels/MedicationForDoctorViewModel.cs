using Hospital.DAL.Entities;
using System;

namespace Hospital.BusinessLogic.ViewModels
{
    public class MedicationForDoctorViewModel
    {
        public int Id { get; set; }
        public string Operations { get; set; }
        public string Procedures { get; set; }
        public string ProceduresDescription { get; set; }
        public DateTime DescriptionDate { get; set; }
        public int HistoryIllnessId { get; set; }
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public HistoryIllness HistoryIllness { get; set; }
    }
}
