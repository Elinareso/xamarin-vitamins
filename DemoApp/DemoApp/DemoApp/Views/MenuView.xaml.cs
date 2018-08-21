using DemoApp.Core.Entities;
using DemoApp.Models;
using DemoApp.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuView : ContentPage
    {
        MainView RootPage { get => Application.Current.MainPage as MainView; }
        
        private readonly MenuViewModel _menuViewModel;

        public MenuView()
        {
            InitializeComponent();

            BindingContext = _menuViewModel = new MenuViewModel();

            ListViewMenu.SelectedItem = _menuViewModel.MenuItems[0];

            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}