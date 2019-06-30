using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BusinessLogic.Models.ViewModels
{
    public class EstablishDiagnosisViewModel
    {
        public int Id { get; set; }
        public string InitialDiagnosis { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public string FinalDiagnosis { get; set; }
        public DateTime? DishargeDate { get; set; }
        public int PatientId { get; set; }


    }
}
