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
                    new Button
                    {
                        Text="Show Network Connection Page",
                        //BorderColor=Color.Blue,
                    }
                }
            };
        }
    }
}
