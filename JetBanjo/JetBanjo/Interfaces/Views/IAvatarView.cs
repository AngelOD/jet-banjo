using System;
using System.Collections.Generic;
using System.Text;
using static JetBanjo.Pages.AvatarPage;

namespace JetBanjo.Interfaces.Views
{
    public interface IAvatarView
    {
        void updateAvatar(AvatarType newAvatar);
    }
}
