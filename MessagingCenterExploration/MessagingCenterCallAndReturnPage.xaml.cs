using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

// https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.MessagingCenter?view=xamarin-forms
namespace MessagingCenterExploration
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagingCenterCallAndReturnPage : ContentPage
    {
        public MessagingCenterCallAndReturnPage()
        {
            InitializeComponent();

            ReportStackLayout.Children.Clear();
        }

        public void HandleCall(MessagingCenterCallAndReturnViewModel sender)
        {
            // You will enter multiple times here, but only one item will be added to the ReportStackLayout, but the children count will show the total times you entered here
            Debug.WriteLine("Handling Call from ViewModel");
            var count = ReportStackLayout.Children.Count;
            ReportStackLayout.Children.Add(new Label { Text = $"Handling Call from ViewModel {count}" });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<MessagingCenterCallAndReturnViewModel>(this, "CallViewFromViewModel", HandleCall);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<MessagingCenterCallAndReturnViewModel>(this, "CallViewFromViewModel");
        }
    }
}
