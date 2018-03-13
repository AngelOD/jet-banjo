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
        public MasterMenuItem(Type page)
        {
            PageType = page;
            TargetType = typeof(MasterDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }

        public Type PageType { get; set; }
    }
}