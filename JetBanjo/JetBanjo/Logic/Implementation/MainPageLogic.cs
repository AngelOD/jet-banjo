using JetBanjo.Logic.Interfaces.Logic;
using JetBanjo.Logic.Interfaces.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Logic.Implementation
{
    public class MainPageLogic : IMainPageLogic
    {
        private IMainPageView view;

        public void SetView(IMainPageView view)
        {
            this.view = view;
        }
    }
}
