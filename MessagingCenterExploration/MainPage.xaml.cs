using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MessagingCenterExploration
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var page = new MessagingCenterCallAndReturnPage();
            MessagingCenter.Subscribe<MessagingCenterCallAndReturnViewModel>(page, "CallViewFromViewModel", page.HandleCall);
            await Navigation.PushAsync(page);
        }
    }
}
