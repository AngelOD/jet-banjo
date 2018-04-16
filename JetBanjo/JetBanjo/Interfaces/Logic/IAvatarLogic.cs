using JetBanjo.Utils;
using JetBanjo.Web.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JetBanjo.Interfaces.Logic
{
    public interface IAvatarLogic
    {
        Task<List<CImage>> GetAvatar(SensorData sensorData, DateTime dateTime);
    }
}
