using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace EduVault.LearnerProfile
{
    public class SchoolAttended : FullAuditedEntity
    {
        [MaxLength(50)]
        public string AdmissionNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string NameOfSchool { get; set; }

        [Required]
        [MaxLength(100)]
        public string LocationOfSchool { get; set; }

        [Required]
        public DateTime AdmissionDateTime { get; set; }
        public GradeEnum AdmissionGrade { get; set; }
        
        public DateTime? DepartureDateTime { get; set; }
        public GradeEnum? DepartureGrade { get; set; }

        [MaxLength(200)]
        public string Comment { get; set; }

    }
}