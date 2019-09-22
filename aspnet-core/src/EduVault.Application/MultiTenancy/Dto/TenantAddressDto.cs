using Abp.AutoMapper;
using EduVault.Common.Dto;

namespace EduVault.MultiTenancy.Dto
{
    [AutoMap(typeof(TenantAddress))]
    public class TenantAddressDto
    {
        public AddressDto Address { get; set; }
        public int AddressId { get; set; }

        public int TenantId { get; set; }
    }
}