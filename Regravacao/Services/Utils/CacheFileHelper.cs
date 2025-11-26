using System;
using System.IO;

namespace Regravacao.Utils
{
    public static class CacheFileHelper
    {
        /// <summary>
        /// Retorna a pasta de cache do aplicativo (LocalAppData\Regravacao\Cache) e garante que exista.
        /// </summary>
        public static string GetAppCacheFolder()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var appFolder = Path.Combine(appData, "Regravacao", "Cache");
            Directory.CreateDirectory(appFolder);
            return appFolder;
        }
    }
}
