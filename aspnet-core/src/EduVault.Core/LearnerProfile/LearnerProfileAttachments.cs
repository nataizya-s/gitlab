using Abp.Domain.Entities.Auditing;
using EduVault.General;

namespace EduVault.LearnerProfile
{
    public class LearnerProfileAttachment : FullAuditedEntity
    {
        public LearnerProfile LearnerProfile { get; set; }
        public int LearnerProfileId { get; set; }
        public Attachment Attachment { get; set; }
        public long AttachmentId { get; set; }
        public LearnerProfileAttachmentType AttachmentType { get; set; }
    }

    public enum LearnerProfileAttachmentType
    {
        ProfilePhoto = 1,

    }
}