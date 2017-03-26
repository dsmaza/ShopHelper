using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShopHelper.Client.Services;

namespace ShopHelper.Client.ShoppingList
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly string dataFilePath;
        private ShoppingListData data;

        public ShoppingListService(IFileService fileService)
        {
            Guard.NotNull(fileService, nameof(fileService));
            dataFilePath = Path.Combine(fileService.DataDirectory, $"{nameof(ShoppingListData)}.json");
            InitLocalData();
        }

        private void InitLocalData()
        {
            var directory = Path.GetDirectoryName(dataFilePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            if (!File.Exists(dataFilePath))
            {
                data = new ShoppingListData();
                data.Items = new List<ShoppingListItem>();
                SaveLocalData();
            }
        }

        public Task<IEnumerable<ShoppingListItem>> Get()
        {
            if (data == null)
            {
                LoadLocalData();
            }
            return Task.FromResult(data.Items.AsEnumerable());
        }

        public Task Add(ShoppingListItem item)
        {
            if (data == null)
            {
                LoadLocalData();
            }
            data.Items.Add(item);
            return Task.Run(() => SaveLocalData());
        }

        private void LoadLocalData()
        {
            using (var file = File.OpenText(dataFilePath))
            {
                var serializer = new JsonSerializer();
                data = (ShoppingListData)serializer.Deserialize(file, typeof(ShoppingListData));
            }
        }

        private void SaveLocalData()
        {
            data.Saved = DateTime.UtcNow;
            using (var file = File.CreateText(dataFilePath))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, data);
            }
        }
    }
}
