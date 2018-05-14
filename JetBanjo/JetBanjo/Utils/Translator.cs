using JetBanjo.Resx;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Utils
{
    public static class Translator
    {
        /// <summary>
        /// Simple method to Translate a key, used for platform specific projects
        /// </summary>
        /// <param name="key">The key of the resource</param>
        /// <returns>The translated resource string</returns>
        public static string Translate(string key)
        {
            return AppResources.ResourceManager.GetString(key);
        }
    }
}
