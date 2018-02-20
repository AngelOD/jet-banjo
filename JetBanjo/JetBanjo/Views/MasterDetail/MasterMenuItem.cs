using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetBanjo.Views.MasterDetail
{

    public class MasterMenuItem
    {
        public MasterMenuItem()
        {
            TargetType = typeof(MasterDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}