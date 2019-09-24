using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using Abp.MultiTenancy;
using Abp.UI;
using AutoMapper;
using EduVault.Authorization;
using EduVault.Authorization.Roles;
using EduVault.Authorization.Users;
using EduVault.Common;
using EduVault.Editions;
using EduVault.Helpers;
using EduVault.MultiTenancy.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduVault.MultiTenancy
{
    [AbpAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantAppService : AsyncCrudAppService<Tenant, TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>, ITenantAppService
    {
        private readonly TenantManager _tenantManager;
        private readonly EditionManager _editionManager;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IAbpZeroDbMigrator _abpZeroDbMigrator;
        private readonly IRepository<Attachment, long> _attachmentRepository;

        public TenantAppService(
            IRepository<Tenant, int> repository,
            IRepository<Attachment, long> attachmentRepository,
            TenantManager tenantManager,
            EditionManager editionManager,
            UserManager userManager,
            RoleManager roleManager,
            IAbpZeroDbMigrator abpZeroDbMigrator)
            : base(repository)
        {
            _tenantManager = tenantManager;
            _editionManager = editionManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _abpZeroDbMigrator = abpZeroDbMigrator;
            _attachmentRepository = attachmentRepository;
        }

        public override async Task<TenantDto> Create(CreateTenantDto input)
        {
            CheckCreatePermission();

            // Create tenant
            var tenant = ObjectMapper.Map<Tenant>(input);
            tenant.ConnectionString = null;

            var defaultEdition = await _editionManager.FindByNameAsync(EditionManager.DefaultEditionName);
            if (defaultEdition != null)
            {
                tenant.EditionId = defaultEdition.Id;
            }

            await _tenantManager.CreateAsync(tenant);
            await CurrentUnitOfWork.SaveChangesAsync(); // To get new tenant's id.

            // Create tenant database
            _abpZeroDbMigrator.CreateOrMigrateForTenant(tenant);

            // We are working entities of new tenant, so changing tenant filter
            using (CurrentUnitOfWork.SetTenantId(tenant.Id))
            {
                if (input.SchoolLogoAttachmentId != null)
                {
                    CreateImages((long)input.SchoolLogoAttachmentId, tenant.Id);
                    await CurrentUnitOfWork.SaveChangesAsync();
                }

                // Create static roles for new tenant
                CheckErrors(await _roleManager.CreateStaticRoles(tenant.Id));

                await CurrentUnitOfWork.SaveChangesAsync(); // To get static role ids

                // Grant all permissions to admin role
                var adminRole = _roleManager.Roles.Single(r => r.Name == StaticRoleNames.Tenants.Admin);
                await _roleManager.GrantAllPermissionsAsync(adminRole);

                // Create admin user for the tenant
                var adminUser = User.CreateTenantAdminUser(tenant.Id, input.AdminEmailAddress);
                await _userManager.InitializeOptionsAsync(tenant.Id);
                CheckErrors(await _userManager.CreateAsync(adminUser, User.DefaultPassword));
                await CurrentUnitOfWork.SaveChangesAsync(); // To get admin user's id

                // Assign admin user to role!
                CheckErrors(await _userManager.AddToRoleAsync(adminUser, adminRole.Name));
                await CurrentUnitOfWork.SaveChangesAsync();
            }

            return MapToEntityDto(tenant);
        }

        public override async Task<TenantDto> Update(TenantDto input)
        {
            CheckUpdatePermission();

            Tenant entity = await GetEntityByIdAsync(input.Id);

            MapToEntity(input, entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            if (input.SchoolLogoAttachmentId != null)
            {
                CreateImages((long)input.SchoolLogoAttachmentId, input.Id);
                await CurrentUnitOfWork.SaveChangesAsync();
            }

            return MapToEntityDto(entity);
        }

        private void CreateImages(long attachmentId, long tenantId)
        {
            Attachment attachment = _attachmentRepository.Get(attachmentId);
            string location = Settings.AppSettings.SchoolLogoFolder + "\\" + tenantId + "\\";
            CreateFolderLocation(location);
            location += "SchoolLogo" + GetFileExtension(attachment.Name);
            File.WriteAllBytes(location, attachment.Data);
            attachment.Location = "\\" + tenantId + "\\" + "SchoolLogo" + GetFileExtension(attachment.Name);
            _attachmentRepository.Update(attachment);
        }

        private string GetFileExtension(string fileName)
        {
            int index = fileName.LastIndexOf(".", StringComparison.InvariantCulture);
            return fileName.Substring(index);
        }

        private void CreateFolderLocation(string location)
        {
            Directory.CreateDirectory(location);
        }

        public async Task<long?> UploadFile([FromForm]IFormFile file)
        {
            if (file == null || file.Length <= 0) throw new UserFriendlyException("No file uploaded.");
            long? attachmentId;
            using (Stream fs1 = file.OpenReadStream())
            using (MemoryStream ms1 = new MemoryStream())
            {
                fs1.CopyTo(ms1);
                Attachment attachment = new Attachment()
                {
                    Data = ms1.ToArray(),
                    Type = AttachmentType.Image,
                    CreatorUserId = AbpSession.UserId,
                    Name = file.FileName
                };
                attachmentId = _attachmentRepository.InsertAndGetId(attachment);
            }
            await CurrentUnitOfWork.SaveChangesAsync();

            return attachmentId;
        }

        protected override IQueryable<Tenant> CreateFilteredQuery(PagedTenantResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.TenancyName.Contains(input.Keyword) || x.Name.Contains(input.Keyword))
                .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive);
        }

        protected override void MapToEntity(TenantDto updateInput, Tenant entity)
        {
            // Manually mapped since TenantDto contains non-editable properties too.
            entity.Name = updateInput.Name;
            entity.TenancyName = updateInput.TenancyName;
            entity.IsActive = updateInput.IsActive;
            entity.SchoolLogoAttachmentId = updateInput.SchoolLogoAttachmentId;
            entity.Addresses = ObjectMapper.Map<List<TenantAddress>>(updateInput.Addresses);
            entity.Contacts = ObjectMapper.Map<List<TenantContact>>(updateInput.Contacts);
            entity.Principal = updateInput.Principal;
            entity.DeputyPrincipal = updateInput.DeputyPrincipal;
            entity.District = updateInput.District;
            entity.WebsiteAddress = updateInput.WebsiteAddress;
        }

        public override async Task Delete(EntityDto<int> input)
        {
            CheckDeletePermission();

            var tenant = await _tenantManager.GetByIdAsync(input.Id);
            await _tenantManager.DeleteAsync(tenant);
        }

        private void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        protected override Task<Tenant> GetEntityByIdAsync(int id)
        {
            return Repository
                .GetAll()
                .Include(c=> c.Addresses).ThenInclude(c=>c.Address)
                .Include(c=> c.Contacts).ThenInclude(c=>c.Contact)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

