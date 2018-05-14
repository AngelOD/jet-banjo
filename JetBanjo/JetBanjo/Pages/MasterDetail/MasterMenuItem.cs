using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JetBanjo.Pages.MasterDetail
{

    public class MasterMenuItem
    {
        //The constructor that takes the type of a page
        public MasterMenuItem(Type page)
        {
            PageType = page;
            TargetType = typeof(MasterDetail);
        }

        //The constructor that takes a page as the item
        public MasterMenuItem(Page page)
        {
            Page = page;
            TargetType = typeof(MasterDetail);
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }

        public Type PageType { get; set; }

        public Page Page { get; set; }
    }
}