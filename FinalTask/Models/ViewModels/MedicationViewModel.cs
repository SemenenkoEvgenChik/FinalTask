using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class MedicationViewModel
    {
        public string Appointment { get; set; }
        public string DestinationDescription { get; set; }
        public DateTime DescriptionDate { get; set; }
        public int HistoryIllnessId { get; set; }

        public virtual HistoryIllnessViewModel HistoryIllness { get; set; }
    }
}
