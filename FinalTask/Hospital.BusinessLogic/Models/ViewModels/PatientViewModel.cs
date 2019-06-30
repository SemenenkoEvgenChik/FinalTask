using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital.BusinessLogic.ViewModels
{
    public class PatientViewModel : BaseEntity
    {
        [Required(ErrorMessage = "Введите имя пациента")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите фамилию пациента")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Введите дату рождения пациента")]
        public DateTime DateOfBirth { get; set; }

    }
}
