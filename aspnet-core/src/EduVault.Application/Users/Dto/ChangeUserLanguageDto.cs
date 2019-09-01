using System.ComponentModel.DataAnnotations;

namespace EduVault.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}