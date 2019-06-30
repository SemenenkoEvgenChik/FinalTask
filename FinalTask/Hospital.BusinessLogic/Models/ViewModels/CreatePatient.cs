using Hospital.BusinessLogic.ViewEnums;
using System;

namespace Hospital.BusinessLogic.ViewModels
{
    public class CreatePatient
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string InitialDiagnosis { get; set; }
        public ViewClassificationOfDoctors ClassificationOfDoctors { get; set; } 
      


    }
}
