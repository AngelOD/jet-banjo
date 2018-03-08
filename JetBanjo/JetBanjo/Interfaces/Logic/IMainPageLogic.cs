using JetBanjo.Interfaces.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Interfaces.Logic
{
    public interface IMainPageLogic
    {
        void SetView(IMainPageView view);
    }
}
