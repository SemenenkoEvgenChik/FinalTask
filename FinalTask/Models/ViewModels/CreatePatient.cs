using Models.ViewEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
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
