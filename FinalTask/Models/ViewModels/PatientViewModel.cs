using System;

namespace Models.ViewModels
{
    public class PatientViewModel:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
