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
            var startPage = new NoNetworkPage();
            InitializeComponent();
            MainPage = new NavigationPage(startPage);
        }
    }
}
