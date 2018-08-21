using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using DemoApp.Models;
using DemoApp.Views;
using DemoApp.Core.Entities;
using System.Threading;

namespace DemoApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private readonly ItemsModel _itemsModel;

        public ObservableCollection<Item> Items => _itemsModel.Items;

        public ItemsViewModel()
        {
            _itemsModel = new ItemsModel();

            Title = "Browse";

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemView, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                await _itemsModel.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await _itemsModel.GetItems();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Command LoadItemsCommand { get; set; }

    }
}