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

        private void openNoNetworkPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NoNetworkPage());
        }
    }

}
