using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using EduVault.Common;
using JetBrains.Annotations;

namespace EduVault.LearnerProfile
{
    public class MedicalHistory : FullAuditedEntity
    {
        public bool? ClinicCardSubmitted { get; set; }

        [MaxLength(100)]
        public string FamilyPractitioner { get; set; }

        [CanBeNull]
        public Contact FamilyPractitionerContact { get; set; }
        public int? FamilyPractitionerContactId { get; set; }

        public List<Allergy> AllergiesList { get; set; }

        public List<ChronicIllness> ChronicIllnessList{ get; set; }

        [CanBeNull]
        [MaxLength(100)]
        public string NameOfMedicalAidScheme { get; set; }

        [CanBeNull]
        [MaxLength(20)]
        public string MedicalAidNumber { get; set; }

        [CanBeNull]
        [MaxLength(100)]
        public string NameOfMemberCardHolder { get; set; }
    }
}