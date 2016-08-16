using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NetStatus
{
    public partial class NetworkViewPage : ContentPage
    {
        public NetworkViewPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ConnectioDetails.Text = CrossConnectivity.Current.ConnectionTypes.First().ToString();

            CrossConnectivity.Current.ConnectivityChanged += UpdateNetworkInfo;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            CrossConnectivity.Current.ConnectivityChanged -= UpdateNetworkInfo;
        }

        private void UpdateNetworkInfo(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if (    CrossConnectivity.Current != null
                &&  CrossConnectivity.Current.ConnectionTypes != null)
                {
                    var connectionType = CrossConnectivity.Current.ConnectionTypes.FirstOrDefault();
                    ConnectioDetails.Text = connectionType.ToString();
                }
        }

        private void openNoNetworkPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NoNetworkPage());
        }
    }

}
