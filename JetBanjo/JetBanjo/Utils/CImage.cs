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
        }


        public CachedImage GetImage()
        {
            if (image == null)
            {
                image = new CachedImage() { Source = ImageSource.FromResource(ResourcesString) };
            }
            return image;
        }

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

        public override string ToString()
        {
            return ResourcesString + ", Type:" + Type;
        }

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
