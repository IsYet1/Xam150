using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace NetStatus
{
    public class NoNetworkPage : ContentPage
    {
        public NoNetworkPage()
        {
            Button btnShowConnectionPage = new Button();
            btnShowConnectionPage.Clicked += btnShowConnectionPage_Click;
            btnShowConnectionPage.Text = "Show Network Connection Page";

            BackgroundColor = Color.FromRgb(0xf0, 0xf0, 0xf0);

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    new Label {
                        Text = "No Networks are Available",
                        TextColor = Color.FromRgb(0x40, 0x40, 0x40),
                    },
                    btnShowConnectionPage,
                }
            };
        }

        private void btnShowConnectionPage_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NetworkViewPage());
        }
    }
}
