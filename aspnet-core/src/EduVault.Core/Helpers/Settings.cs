using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduVault.Helpers
{
    public static class Settings
    {
        public static string ConnectionString { get; set; }
        public static AppSettings AppSettings { get; set; }

    }

    public class AppSettings
    {
        public string SrcFolderLocation { get; set; }

        public string ImageFolderLocation => SrcFolderLocation + "\\assets\\images";

        public string SchoolLogoFolder => ImageFolderLocation + "\\SchoolLogos";
    }
}
