using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace EduVault.Common.Dto
{
    [AutoMap(typeof(Address))]
    public class AddressDto : EntityDto
    {
        public AddressType Type { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string AddressLine1 { get; set; }

        [MaxLength(100)]
        public string AddressLine2 { get; set; }

        [MaxLength(100)]
        public string AddressLine3 { get; set; }

        [Required]
        [MaxLength(100)]
        public string Locality { get; set; }

        [Required]
        [MaxLength(100)]
        public string Region { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }

        [Required]
        [MaxLength(50)]
        public string PostalCode { get; set; }
    }
}
