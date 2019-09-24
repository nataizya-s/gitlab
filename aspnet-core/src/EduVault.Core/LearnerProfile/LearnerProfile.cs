using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using JetBrains.Annotations;

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

        [CanBeNull]
        [MaxLength(50)]
        public string AdmissionNumber { get; set; }

        /// <summary>
        /// A list of all attachments for different kinds of areas.
        /// </summary>
        public List<LearnerProfileAttachment> Attachments { get; set; }

        [Required]
        public GradeEnum CurrentGrade { get; set; }

        [Required]
        public GenderEnum Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [CanBeNull]
        [MaxLength(100)]
        public string NameByWhichLearnerIsCalled { get; set; }

        [MaxLength(100)]
        public string HomeLanguage { get; set; }

        [MaxLength(100)]
        public string LanguageOfLearning { get; set; }

        public List<Guardian> Guardians { get; set; }

        public int? NumberOfChildrenInFamily { get; set; }

        public int? PositionInFamily { get; set; }

        public List<SchoolAttended> SchoolsAttended { get; set; }

        public List<Absent> Absence { get; set; }

        /// <summary>
        /// Examples are Soccer, Netball, Choir etc.
        /// </summary>
        public List<Comment> ExtraCurricularActivities { get; set; }

        /// <summary>
        /// Achievement (in and out of school) academic/sport/cultural/other.
        /// </summary>
        public List<Comment> Achievements { get; set; }

        /// <summary>
        /// Social: Learner->Parent/Learner->Sibling/Learner->Educator/Learner->Peer group;
        /// Emotional: Insecure, Aggressive, Shy, Secure, Happy, Self-image;
        /// </summary>
        public List<Comment> EmotionalSocialBehaviour { get; set; }

        /// <summary>
        /// Reason and outcome.
        /// </summary>
        public List<Comment> ParentalInvolvements { get; set; }

        /// <summary>
        /// Support services for learner in need of support.
        /// </summary>
        public List<ProvidedSupport> ProvidedSupports { get; set; }
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

    public enum TermEnum
    {
        Term1 = 1,
        Term2 = 2,
        Term3 = 3,
        Term4 = 4
    }

    public enum GenderEnum
    {
        Female = 0,
        Male = 1,
        Other = 2
    }
}