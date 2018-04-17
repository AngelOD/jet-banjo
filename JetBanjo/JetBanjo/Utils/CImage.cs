using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JetBanjo.Utils
{
    public class CImage : Image, IComparable
    {
        private string ResourcesString { get; set; }
        private ImageType Type { get; set; }

        public CImage(string resourceString, ImageType type)
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

            Source = ImageSource.FromResource(resourceString);
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
            return ResourcesString;
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
