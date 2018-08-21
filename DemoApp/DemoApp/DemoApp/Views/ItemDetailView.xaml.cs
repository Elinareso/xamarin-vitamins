using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DemoApp.Models;
using DemoApp.ViewModels;
using DemoApp.Core.Entities;

namespace DemoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailView : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailView(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailView()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}