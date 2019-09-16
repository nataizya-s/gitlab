using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace EduVault.General
{
    public class Attachment: FullAuditedEntity<long>
    {
        public byte[] Data { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public AttachmentType Type { get; set; }
        public string Location { get; set; }
    }

    public enum AttachmentType
    {
        Image = 1,
        Document,
        Text,
        Audio,
        Other
    }
}
