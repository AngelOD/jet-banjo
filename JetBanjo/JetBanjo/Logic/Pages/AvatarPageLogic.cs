using JetBanjo.Interfaces.Logic;
using JetBanjo.Interfaces.Views;
using JetBanjo.Logic.Sensor;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Logic.Pages
{
    public class AvatarPageLogic : IAvatarLogic
    {
        private IAvatarView view;

        public void SetView(IAvatarView view)
        {
            this.view = view;

            

        }

        public void updateAvatar()
        {

        }
    }
}
