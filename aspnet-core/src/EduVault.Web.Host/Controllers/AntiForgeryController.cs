using Microsoft.AspNetCore.Antiforgery;
using EduVault.Controllers;

namespace EduVault.Web.Host.Controllers
{
    public class AntiForgeryController : EduVaultControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
