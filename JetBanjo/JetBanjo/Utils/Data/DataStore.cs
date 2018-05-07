using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static JetBanjo.Utils.Data.DataStoreKeys;

namespace JetBanjo.Utils.Data
{
    public class DataStore
    {

        /// <summary>
        /// Saves a value into the data store
        /// </summary>
        /// <param name="key">The key to identify the value</param>
        /// <param name="value">The value to be saved</param>
        public static void SaveValue(Keys key, string value)
        {
            Application.Current.Properties[key.ToString()] = value;
            Application.Current.SavePropertiesAsync();
        }

        /// <summary>
        /// Removes a saved value using its key
        /// </summary>
        /// <param name="key">The key to the value</param>
        public static void RemoveValue(Keys key)
        {
            if (Application.Current.Properties.ContainsKey(key.ToString()))
            {
                Application.Current.Properties.Remove(key.ToString());
                Application.Current.SavePropertiesAsync();
            }
        }

        /// <summary>
        /// Returns either the value or empty string depending on if the value exist identified by the key
        /// </summary>
        /// <param name="key">The key to the value</param>
        /// <returns>The value or empty string if the value does not exist</returns>
        public static string GetValue(Keys key)
        {
            if (Application.Current.Properties.ContainsKey(key.ToString()))
            {
                if (Application.Current.Properties[key.ToString()] != null)
                    return Application.Current.Properties[key.ToString()].ToString();
                else
                    return "";
            }
            else
            {
                return "";
            }
        }
    }
}
