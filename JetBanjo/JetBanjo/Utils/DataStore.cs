using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JetBanjo.Utils
{
    public class DataStore
    {

        /// <summary>
        /// Saves a value into the data store
        /// </summary>
        /// <param name="key">The key to identify the value</param>
        /// <param name="value">The value to be saved</param>
        public static void SaveValue(string key, string value)
        {
            Application.Current.Properties[key] = value;
            Application.Current.SavePropertiesAsync();
        }

        /// <summary>
        /// Removes a saved value using its key
        /// </summary>
        /// <param name="key">The key to the value</param>
        public static void RemoveValue(string key)
        {
            if (Application.Current.Properties.ContainsKey(key))
            {
                Application.Current.Properties.Remove(key);
                Application.Current.SavePropertiesAsync();
            }
        }

        /// <summary>
        /// Returns either the value or null depending on if the value exist identified by the key
        /// </summary>
        /// <param name="key">The key to the value</param>
        /// <returns>The value or null if the value does not exist</returns>
        public static string GetValue(string key)
        {
            if (Application.Current.Properties.ContainsKey(key))
            {
                return Application.Current.Properties[key].ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
