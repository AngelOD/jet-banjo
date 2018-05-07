using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Android.App;
using Android.Content;
using Android.Net.Nsd;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using JetBanjo.Droid.Utils;
using JetBanjo.Utils;
using JetBanjo.Utils.DependencyService;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkDiscovery))]
namespace JetBanjo.Droid.Utils
{
    public class NetworkDiscovery : INetworkDiscovery
    {
        private Boolean elapsed = false;
        public NsdServiceInfo result = null;
        private NsdManager nsdManager;
        private NsdManagerDiscoveryListener listener;

        public async Task<string> FindBackEnd()
        {
            Timer t = new Timer(10000) { AutoReset=false};
            t.Elapsed += (s,a) => { elapsed = true; };
            return await Task.Run(() => { t.Start(); while (result != null) { if (elapsed) { break; } } return CreateIp(); });
        }

        private string CreateIp()
        {

            if (result != null) {
                string ip = result.Host.HostName;
                if (result.Port != 0)
                {
                    ip += ":" + result.Port;
                }
                return ip;
            }
            return "";
        }

        public void OnAppStart()
        {
            nsdManager = (NsdManager)Forms.Context.GetSystemService(Context.NsdService);
            listener = new NsdManagerDiscoveryListener(nsdManager, this);
            nsdManager.DiscoverServices(Constants.NETWORK_SEARCH, NsdProtocol.DnsSd, listener);
        }

        public void OnAppStop()
        {
            try
            {
                nsdManager?.StopServiceDiscovery(listener);
            }
            catch (Exception)
            {
            }
            
        }

        internal class NsdManagerDiscoveryListener : Java.Lang.Object, NsdManager.IDiscoveryListener
        {
            private NsdManager manager;
            private NetworkDiscovery networkDiscovery;

            public NsdManagerDiscoveryListener(NsdManager manager, NetworkDiscovery networkDiscovery)
            {
                this.manager = manager;
                this.networkDiscovery = networkDiscovery;
            }

            public void OnDiscoveryStarted(string serviceType)
            {
                Console.WriteLine("Discovery started");
            }

            public void OnDiscoveryStopped(string serviceType)
            {
                Console.WriteLine("Discovery stopped");
            }

            public void OnServiceFound(NsdServiceInfo serviceInfo)
            {
                if (serviceInfo.ServiceName.ToLower().Equals("_lora_server"))
                {
                    networkDiscovery.result = serviceInfo;
                    Console.WriteLine("Found service " + serviceInfo.ServiceName);
                }
            }

            public void OnServiceLost(NsdServiceInfo serviceInfo)
            {
                //if (serviceInfo.ServiceName.ToLower().Equals("_lora_server"))
                //{
                    networkDiscovery.result = null;
                    Console.WriteLine("Lost service " + serviceInfo.ServiceName);
                //}
            }

            public void OnStartDiscoveryFailed(string serviceType, [GeneratedEnum] NsdFailure errorCode)
            {
                Console.WriteLine(errorCode);
            }

            public void OnStopDiscoveryFailed(string serviceType, [GeneratedEnum] NsdFailure errorCode)
            {
                Console.WriteLine(errorCode);
            }
        }
    }
}