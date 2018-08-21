using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using DemoApp.Models;
using DemoApp.Services;
using DemoApp.Core;

namespace DemoApp.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        bool isBusy = false;
        string title = string.Empty;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
                
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

    }
}
