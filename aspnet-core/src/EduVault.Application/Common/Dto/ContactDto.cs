using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace EduVault.Common.Dto
{
    [AutoMap(typeof(Contact))]
    public class ContactDto : EntityDto
    {
        [MaxLength(100)]
        public string Description { get; set; }

        public ContactType Type { get; set; }

        public string Value { get; set; }
    }
}