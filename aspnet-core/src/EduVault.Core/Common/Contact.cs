using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace EduVault.Common
{
    public class Contact : FullAuditedEntity
    {
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public ContactType Type { get; set; }

        [MaxLength(100)]
        [Required]
        public string Value { get; set; }
    }

    public enum ContactType
    {
        CellPhone = 1,
        Landline,
        Fax,
        EmailAddress
    }
}
