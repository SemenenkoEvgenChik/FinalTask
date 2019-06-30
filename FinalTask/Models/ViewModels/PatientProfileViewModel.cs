using System;
using System.Collections.Generic;

namespace Models.ViewModels
{
    public class PatientProfileViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<HistoryIllnessViewModel> HistoryIllnesses { get; set; }
    }
}
