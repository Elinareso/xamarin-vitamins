using DemoApp.Core;
using DemoApp.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutView : ContentPage
    {
        public AboutView()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<AboutViewModel, string>(this, MessageNames.PlatformMessage, (sender, message) =>
            {
                DisplayAlert("About Page", message, "Ok");
            });
        }
    }
}