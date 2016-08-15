using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NetStatus
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //var isConnected = CrossConnectivity.Current.IsConnected;
            MainPage = new NoNetworkPage();
            //MainPage = new NetworkViewPage();
            //MainPage = (CrossConnectivity.Current.IsConnected)
            //    ? (Page)new NetworkViewPage()
            //    : new NoNetworkPage();
        }
    }
}
