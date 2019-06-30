using Hospital.DAL.Enums;
using System.Collections.Generic;


namespace Hospital.DAL.Entities
{
    public class Doctor : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Expirience { get; set; }
        public ClassificationOfDoctors Specialty { get; set; }
        public EnumForMedicRole Role { get; set; }
        public bool Deleted { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<HistoryIllness> HistoryIllnesses { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
