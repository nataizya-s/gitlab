using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace EduVault.LearnerProfile
{
    public class MedicalNote: FullAuditedEntity
    {
        [MaxLength(100)]
        public string Issue { get; set; }

        [MaxLength(500)]
        public string DescriptionNotes { get; set; }
    }
}