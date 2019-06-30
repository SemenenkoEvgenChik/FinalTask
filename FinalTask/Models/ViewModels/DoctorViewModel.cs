using Models.ViewEnums;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class DoctorViewModel : BaseEntity
    {
        [Required(ErrorMessage = "Введите свое имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите свою фамилию")]
        public string Surname { get; set; }
        [Range(0, 50, ErrorMessage = "Недопустимый опыт работы")]
        public int Expirience { get; set; }
        [Range(1, 5, ErrorMessage = "Выберете пожалуйста специальность")]
        public ViewClassificationOfDoctors Specialty { get; set; }
    }
}
