using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JetBanjo.Utils
{
    public class CImage : Image
    {
        private string ResourcesString { get; set; }

        public CImage(string resourceString)
        {
            ResourcesString = resourceString;
            Source = ImageSource.FromResource(resourceString);
        }

        public override bool Equals(object obj)
        {
            if (obj is CImage)
            {
                CImage temp = obj as CImage;
                return ResourcesString.Equals(temp.ResourcesString);
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

    }
}
