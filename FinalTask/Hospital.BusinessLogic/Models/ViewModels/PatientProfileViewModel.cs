using System;
using System.Collections.Generic;

namespace Hospital.BusinessLogic.ViewModels
{
    public class PatientProfileViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<HistoryIllnessViewModel> HistoryIllnesses { get; set; }
    }
}
