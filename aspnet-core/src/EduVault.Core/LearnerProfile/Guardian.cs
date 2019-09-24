using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using EduVault.Common;
using JetBrains.Annotations;

namespace EduVault.LearnerProfile
{
    public class Guardian : FullAuditedEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }

        [Required]
        public bool EmergencyContact { get; set; }

        /// <summary>
        /// Relationship with learner. For example Farther, Mother or Uncle.
        /// </summary>
        [Required]
        [MaxLength(250)]
        public string RelationshipWithLearner { get; set; }

        [Required]
        public MaritalStatusType MaritalStatusType { get; set; }

        [CanBeNull]
        [MaxLength(100)]
        public string Occupation { get; set; }

        public Address PhysicalAddress { get; set; }
        public int? PhysicalAddressId { get; set; }

        public Address PostalAddress { get; set; }
        public int? PostalAddressId { get; set; }

        public Contact HomeContact { get; set; }
        public int? HomeContactId { get; set; }

        public Contact WorkContact { get; set; }
        public int? WorkContactId { get; set; }

        public Contact CellContact { get; set; }
        public int? CellContactId { get; set; }
    }

    public enum MaritalStatusType
    {
        Single = 1,
        Married = 2,
        Divorced = 3,
        Widowed = 4,
        NotApplicable = 5
    }
}