using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using EduVault.General;
using EduVault.Helpers;

namespace EduVault.MultiTenancy
{
    public class SchoolAppService: ApplicationService, ISchoolAppService
    {
        private readonly IRepository<Attachment, long> _attachmentRepository;
        private readonly IRepository<Tenant, int> _tenantRepository;

        public SchoolAppService(IRepository<Attachment, long> attachmentRepository, IRepository<Tenant, int> tenantRepository)
        {
            _attachmentRepository = attachmentRepository;
            _tenantRepository = tenantRepository;
        }

        public string GetLogoLocation(int tenantId)
        {
            try
            {
                Tenant tenant = _tenantRepository.Get(tenantId);
                if (tenant?.SchoolLogoAttachmentId == null) return null;
                Attachment attachment = _attachmentRepository.Get((long)tenant.SchoolLogoAttachmentId);
                string location =
                    Settings.AppSettings.SchoolLogoFolder.Replace(Settings.AppSettings.SrcFolderLocation, "");
                return location + attachment.Location;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
