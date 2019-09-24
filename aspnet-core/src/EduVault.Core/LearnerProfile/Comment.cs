using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace EduVault.LearnerProfile
{
    public class Comment : FullAuditedEntity
    {
        [Required]
        public GradeEnum Grade { get; set; }

        [MaxLength(50)]
        public string NameOfSchool { get; set; }

        [MaxLength(500)]
        public string Comments { get; set; }
    }
}