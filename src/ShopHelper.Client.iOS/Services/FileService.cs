using System;

namespace ShopHelper.Client.Services
{
    public class FileService : IFileService
    {
        private static readonly string dataDirectory;

        static FileService()
        {
            var localStorage = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dataDirectory = System.IO.Path.Combine(localStorage, "..", "Library");
        }

        public string DataDirectory => dataDirectory;
    }
}
