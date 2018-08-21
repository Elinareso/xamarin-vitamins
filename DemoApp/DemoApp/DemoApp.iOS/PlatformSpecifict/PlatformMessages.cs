using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoApp.Core;
using DemoApp.iOS.PlatformSpecifict;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlatformMessages))]
namespace DemoApp.iOS.PlatformSpecifict
{
    public class PlatformMessages : IPlatformMessages
    {
        public string GetDeviceMessage()
        {
            return "This is a platform specifict message from iOS Device!";
        }
    }
}