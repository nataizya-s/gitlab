using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace EduVault.LearnerProfile
{
    public class Allergy: FullAuditedEntity
    {
        [MaxLength(500)]
        public string DescriptionNotes { get; set; }

        [MaxLength(100)]
        public string Allergen { get; set; }
    }
}