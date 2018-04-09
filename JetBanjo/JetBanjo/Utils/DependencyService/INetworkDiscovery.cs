using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JetBanjo.Utils.DependencyService
{
    public interface INetworkDiscovery
    {
        Task<string> FindBackEnd();

        void OnAppStart();

        void OnAppStop();
    }
}
