using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using JetBanjo.Utils.DependencyService;
using JetBanjo.iOS.Utils;
using System.Threading.Tasks;
using JetBanjo.Utils;
using System.Timers;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkDiscovery))]
namespace JetBanjo.iOS.Utils
{
    public class NetworkDiscovery : INetworkDiscovery
    {
        private NSNetService result;
        private Boolean elapsed = false;
        private NSNetServiceBrowser serviceBrowser;

        public async Task<string> FindBackEnd()
        {
            Timer t = new Timer(10000) { AutoReset = false };
            t.Elapsed += (s, a) => { elapsed = true; };
            return await Task.Run(() => { t.Start(); while (result != null) { if (elapsed) break; } return CreateIp(); });
        }

        private string CreateIp()
        {
            if (result != null)
            {
                string ip = result.HostName;
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
            serviceBrowser = new NSNetServiceBrowser();
            serviceBrowser.FoundService += OnServiceFound;
            serviceBrowser.ServiceRemoved += OnServiceLost;
            serviceBrowser.SearchStarted += OnServiceStarted;
            serviceBrowser.SearchStopped += OnServiceStopped;
            serviceBrowser.NotSearched += OnServiceNotSearched;
            serviceBrowser.Schedule(NSRunLoop.Current, NSRunLoopMode.Default.ToString());
            serviceBrowser.SearchForServices(Constants.NETWORK_SEARCH, "local");
        }

        public void OnAppStop()
        {
            serviceBrowser?.Stop();
        }

        private void OnServiceFound(object sender, NSNetServiceEventArgs e)
        {
            if (e.Service.Name.ToLower().Equals("_lora_server"))
            {
                result = e.Service;
                Console.WriteLine("Found service " + e.Service.Name);
            }
        }

        private void OnServiceLost(object sender, NSNetServiceEventArgs e)
        {
            if (e.Service.Name.ToLower().Equals("_lora_server"))
            {
                result = null;
                Console.WriteLine("Lost service " + e.Service.Name);
            }
        }


        private void OnServiceStarted(object sender, EventArgs e)
        {
            Console.WriteLine("Discovery started");
        }


        private void OnServiceStopped(object sender, EventArgs e)
        {
            Console.WriteLine("Discovery stopped");
        }

        private void OnServiceNotSearched(object sender, EventArgs e)
        {
            Console.WriteLine("Discovery not searched");
        }

    }
}