using Hospital.DAL.Entities;
using System;

namespace Hospital.BusinessLogic.ViewModels
{
    public class MedicationViewModel
    {
        public int Id { get; set; }
        public string Appointment { get; set; }
        public string DestinationDescription { get; set; }
        public DateTime DescriptionDate { get; set; }
        public int HistoryIllnessId { get; set; }

        public HistoryIllness HistoryIllness { get; set; }
    }
}
