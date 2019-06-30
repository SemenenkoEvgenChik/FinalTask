using Hospital.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BusinessLogic.Models.ViewModels
{
    public class MedicationForHospitalStaffViewModel
    {
        public int Id { get; set; }
        public string Procedures { get; set; }
        public string ProceduresDescription { get; set; }
        public DateTime DescriptionDate { get; set; }
        public int HistoryIllnessId { get; set; }
        public HistoryIllness HistoryIllness { get; set; }
    }
}
