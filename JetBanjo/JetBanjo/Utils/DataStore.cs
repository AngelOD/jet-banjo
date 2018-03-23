using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JetBanjo.Utils
{
    public class DataStore
    {

        public static void SaveValue(string key, string value)
        {
            Application.Current.Properties[key] = value;
            Application.Current.SavePropertiesAsync();
        }

        public static string GetValue(string valueKey)
        {
            return Application.Current.Properties[valueKey].ToString();
        }
    }
}
