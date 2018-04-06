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
using JetBanjo.Utils.DependencyService;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkDiscovery))]
namespace JetBanjo.Droid.Utils
{
    public class NetworkDiscovery : INetworkDiscovery
    {
        private bool found = false;
        private bool elapsed = false;
        private string result = null;
        private NsdServiceInfo resultData = null;
        private NsdManager nsdManager;
        private NsdManagerDiscoveryListener listener;

        public async Task<string> FindBackEnd()
        {
            Timer t = new Timer(10000) { AutoReset=false};
            t.Elapsed += T_Elapsed;
            return await Task.Run(() => { t.Start(); while (!found) { if (elapsed) break; }; return result; });
        }

        public void OnAppStart()
        {
            nsdManager = (NsdManager)Forms.Context.GetSystemService(Context.NsdService);
            listener = new NsdManagerDiscoveryListener(nsdManager);
            nsdManager.DiscoverServices("_ipp._tcp", NsdProtocol.DnsSd, listener);
        }

        public void OnAppStop()
        {
            nsdManager?.StopServiceDiscovery(listener);
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            elapsed = true;
        }

        internal class NsdManagerDiscoveryListener : Java.Lang.Object, NsdManager.IDiscoveryListener
        {
            private NsdManager manager;

            public NsdManagerDiscoveryListener(NsdManager manager)
            {
                this.manager = manager;
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
                Console.WriteLine("Found service " + serviceInfo.ServiceName);
            }

            public void OnServiceLost(NsdServiceInfo serviceInfo)
            {
                Console.WriteLine(serviceInfo.ServiceName);
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