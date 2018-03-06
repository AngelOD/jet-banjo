using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JetBanjo.Views.MasterDetail
{

    public class MasterMenuItem
    {
        public MasterMenuItem(Page page)
        {
            Page = page;
            TargetType = typeof(MasterDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }

        //The page to be shown when the item is clicked
        public Page Page { get; set; }
    }
}