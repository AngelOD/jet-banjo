using JetBanjo.Resx;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Utils
{
    public static class Translator
    {
        public static string Translate(string key)
        {
            return AppResources.ResourceManager.GetString(key);
        }
    }
}
