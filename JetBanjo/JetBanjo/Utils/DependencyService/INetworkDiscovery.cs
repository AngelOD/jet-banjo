using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JetBanjo.Utils.DependencyService
{
    public interface INetworkDiscovery
    {
        /// <summary>
        /// Finds the backend and returns the IP Address as as string
        /// </summary>
        /// <returns>IP Address</returns>
        Task<string> FindBackEnd();

        /// <summary>
        /// Called when the app starts
        /// </summary>
        void OnAppStart();

        /// <summary>
        /// Called when the app stops (is inactive or sleeping)
        /// </summary>
        void OnAppStop();
    }
}
