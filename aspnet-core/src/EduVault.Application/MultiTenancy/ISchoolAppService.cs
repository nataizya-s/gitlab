namespace EduVault.MultiTenancy
{
    public interface ISchoolAppService
    {
        string GetLogoLocation(int tenantId);
    }
}