using FFImageLoading.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JetBanjo.Utils
{
    public class CImage : IComparable
    {
        private string ResourcesString { get; set; }

        /// <summary>
        /// The type of the image
        /// </summary>
        public ImageType Type { get; private set; }

        private CachedImage image;

        public CImage(string resourceString, ImageType type) : base()
        {
            Type = type;
            if (!resourceString.StartsWith("JetBanjo.Resources."))
            {
                ResourcesString = "JetBanjo.Resources." +resourceString;
            }
            else
            {
                ResourcesString = resourceString;
            }

            if (!ResourcesString.EndsWith(".png"))
                ResourcesString += ".png";

            //Such that it is posssible to unit test, because the FFImageLoading does not want to be used outside of Shared or platform specific projects
            if (!App.IsTesting) 
                image = new CachedImage() { Source = ImageSource.FromResource(ResourcesString)};
        }

        /// <summary>
        /// Returns the Cached image
        /// </summary>
        /// <returns></returns>
        public CachedImage GetImage()
        {

            return image;
        }

        /// <summary>
        /// Method to compare two CImage object to check if the are "the same"
        /// </summary>
        /// <param name="obj">Other object</param>
        /// <returns>True if the objects can be considered "the same"</returns>
        public override bool Equals(object obj)
        {
            if (obj is CImage)
            {
                CImage temp = obj as CImage;
                return ResourcesString.Equals(temp.ResourcesString) && Type.Equals(temp.Type);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return ResourcesString.GetHashCode();
        }

        /// <summary>
        /// Overriden for logging 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ResourcesString + ", Type:" + Type;
        }

        /// <summary>
        /// Used for sorting and follows the image specification
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if(obj is CImage)
            {
                CImage other = obj as CImage;
                int res = Type.CompareTo(other.Type);
                return res != 0 ? res : ResourcesString.CompareTo(other.ResourcesString);
            }

            return 0;
        }
    }
}
