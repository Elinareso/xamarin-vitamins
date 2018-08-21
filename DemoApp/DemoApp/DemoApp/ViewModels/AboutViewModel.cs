using DemoApp.Core;
using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace DemoApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private bool _moreInfo;

        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));

            ShowPlatformMessageCommand = new Command(() =>
            {
                var platformMessagesImplementation = DependencyService.Get<IPlatformMessages>();
                var platformMessage = platformMessagesImplementation.GetDeviceMessage();

                MessagingCenter.Send(this, MessageNames.PlatformMessage, platformMessage);
            });
        }

        public string DeviceName => Xamarin.Essentials.DeviceInfo.Name;

        public bool MoreInfo
        {
            get
            {
                return _moreInfo;
            }
            set
            {
                SetProperty(ref _moreInfo, value);
            }
        }

        public ICommand OpenWebCommand { get; }

        public ICommand ShowPlatformMessageCommand { get; }
    }
}