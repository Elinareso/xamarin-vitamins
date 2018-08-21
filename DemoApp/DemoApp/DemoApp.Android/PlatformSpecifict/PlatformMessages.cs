using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DemoApp.Core;
using DemoApp.Droid.PlatformSpecifict;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlatformMessages))]
namespace DemoApp.Droid.PlatformSpecifict
{
    public class PlatformMessages : IPlatformMessages
    {
        public string GetDeviceMessage()
        {
            return "This is a platform specifict message from Android Device!";
        }
    }
}