using System;
using System.IO;

namespace Regravacao.Services.Utils
{
    public static class CacheFileHelper
    {
        public static string GetAppCacheFolder()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var folder = Path.Combine(appData, "Regravacao", "Cache");
            Directory.CreateDirectory(folder);
            return folder;
        }
    }
}
