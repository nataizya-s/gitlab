using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace EduVault.LearnerProfile
{
    public class LearnerProfile : FullAuditedEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }

        [MaxLength(100)]
        public string MiddleNames { get; set; }

        public List<LearnerProfileAttachment> Attachments { get; set; }

        [Required]
        public GradeEnum CurrentGrade { get; set; }

        [Required]
        public GenderEnum Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(100)]
        public string NameByWhichLearnerIsCalled { get; set; }

        [MaxLength(100)]
        public string HomeLanguage { get; set; }

        [MaxLength(100)]
        public string LanguageOfLearning { get; set; }
    }

    public enum GradeEnum
    {
        GradeR = 0,
        Grade1 = 1,
        Grade2 = 2,
        Grade3 = 3,
        Grade4 = 4,
        Grade5 = 5,
        Grade6 = 6,
        Grade7 = 7,
        Grade8 = 8,
        Grade9 = 9,
        Grade10 = 10,
        Grade11 = 11,
        Grade12 = 12
    }

    public enum GenderEnum
    {
        Female = 0,
        Male = 1,
        Other = 2
    }
}