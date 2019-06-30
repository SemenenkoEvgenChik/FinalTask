using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class HistoryIllnessViewModel
    {
        public int Id { get; set; }
        public string InitialDiagnosis { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string FinalDiagnosis { get; set; }
        public DateTime DishargeDate { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public virtual PatientViewModel Patient { get; set; }
        public virtual DoctorViewModel Doctor { get; set; }
        public virtual ICollection<MedicationViewModel> Medications { get; set; }
    }
}
