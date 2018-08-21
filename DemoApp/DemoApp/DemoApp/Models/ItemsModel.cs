using DemoApp.Core;
using DemoApp.Core.Entities;
using DemoApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoApp.Models
{
    internal class ItemsModel : BindableBase
    {
        private ObservableCollection<Item> _items;
        private IDataStore<Item> _dataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();

        public ItemsModel()
        {
            _items = new ObservableCollection<Item>();
        }

        public async Task GetItems()
        {
            _items.Clear();

            var items = await _dataStore.GetItemsAsync(true);

            foreach (var item in items)
            {
                _items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            Items.Add(item);
            return await _dataStore.AddItemAsync(item);
        }

        public ObservableCollection<Item> Items
        {
            get
            {
                return _items;
            }
            set
            {
                SetProperty(ref _items, value);
            }
        }
    }
}
