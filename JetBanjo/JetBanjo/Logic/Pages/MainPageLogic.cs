using JetBanjo.Interfaces.Logic;
using JetBanjo.Interfaces.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Logic.Pages
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
