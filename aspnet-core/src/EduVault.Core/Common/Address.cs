﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace EduVault.Common
{
    public class Address : FullAuditedEntity
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

    public enum AddressType
    {
        Home = 1,
        Business,
        Billing, 
        Shipping,
        NA
    }
}