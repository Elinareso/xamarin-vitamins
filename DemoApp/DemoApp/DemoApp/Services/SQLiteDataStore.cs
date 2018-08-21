using DemoApp.Core.Entities;
using DemoApp.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDataStore))]
namespace DemoApp.Services
{
    public class SQLiteDataStore : IDataStore<Item>
    {
        private readonly LocalDatabaseConnection _localDatabaseConnection;

        public SQLiteDataStore()
        {
            _localDatabaseConnection = new LocalDatabaseConnection(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LocalDatabase.db3"));
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            await _localDatabaseConnection.Database.InsertAsync(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var itemToDelete = GetItemAsync(id);

            await _localDatabaseConnection.Database.DeleteAsync(itemToDelete.Result);

            return itemToDelete.IsCompleted;
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await _localDatabaseConnection.Database.Table<Item>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_localDatabaseConnection.Database.Table<Item>().ToListAsync().Result);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            await _localDatabaseConnection.Database.UpdateAsync(item);
            return await Task.FromResult(true);
        }

        public Task<List<Item>> GetItemsByDescriptionAsync(string description)
        {
            return _localDatabaseConnection.Database.QueryAsync<Item>($"SELECT * FROM [Item] WHERE [Description] LIKE '%{description}%'");
        }
    }

    public class LocalDatabaseConnection
    {
        public LocalDatabaseConnection(string dbPath)
        {
            Database = new SQLiteAsyncConnection(dbPath);
            Database.CreateTableAsync<Item>().Wait();
        }

        public SQLiteAsyncConnection Database { get; }

    }

}
