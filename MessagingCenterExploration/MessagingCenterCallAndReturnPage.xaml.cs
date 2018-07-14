using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MessagingCenterExploration
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagingCenterCallAndReturnPage : ContentPage
    {
        public MessagingCenterCallAndReturnPage()
        {
            InitializeComponent();
            // MessagingCenter.Unsubscribe<MessagingCenterCallAndReturnViewModel>(this, "CallViewFromViewModel"); // This will not do anything
            MessagingCenter.Subscribe<MessagingCenterCallAndReturnViewModel>(this, "CallViewFromViewModel", HandleCall);
        }

        public void HandleCall(MessagingCenterCallAndReturnViewModel sender)
        {
            // You will enter multiple times here, but only one item will be added to the ReportStackLayout
            Debug.WriteLine("Handling Call from ViewModel");

            Device.BeginInvokeOnMainThread(() =>
            {
                ReportStackLayout.Children.Add(new Label { Text = $"Handling Call from ViewModel {ReportStackLayout.Children.Count}" });
            });
        }

    }
}