using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.DAL.Entities
{
    public class Patient:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<HistoryIllness> HistoryIllnesses { get; set; }
    }
}
