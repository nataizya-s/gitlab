using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace EduVault.LearnerProfile
{
    public class Absent : Comment
    {
        [Required]
        public TermEnum Term { get; set; }

        [Required]
        public int NumberOfDays { get; set; }
    }
}