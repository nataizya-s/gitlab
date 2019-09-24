using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using EduVault.Common;
using JetBrains.Annotations;

namespace EduVault.LearnerProfile
{
    public class LearnerProfileAttachment : FullAuditedEntity
    {
        public LearnerProfile LearnerProfile { get; set; }
        public int LearnerProfileId { get; set; }
        public Attachment Attachment { get; set; }
        public long AttachmentId { get; set; }
        public LearnerProfileAttachmentType AttachmentType { get; set; }
        public GradeEnum GradeEnum { get; set; }
        [CanBeNull]
        [MaxLength(100)]
        public string NameOfSchool { get; set; }
        [CanBeNull]
        [MaxLength(200)]
        public string Comments { get; set; }
    }

    public enum LearnerProfileAttachmentType
    {
        ProfilePhotoFoundationPhase = 1,
        ProfilePhotoIntermediatePhase,
        ProfilePhotoSeniorPhase,
        MedicalHistory,
        ProvidedSupport,
        ExampleWork,
        SummativeRecordOfSpecificOutcomes,
        MotivationToRetainLearnerGDE450C
    }
}