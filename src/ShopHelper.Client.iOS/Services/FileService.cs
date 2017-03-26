using System;

namespace ShopHelper.Client.Services
{
    public class FileService : IFileService
    {
        private readonly string dataDirectory;
        private readonly string logsDirectory;

        public FileService()
        {
            var localStorage = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dataDirectory = System.IO.Path.Combine(localStorage, "..", "Library"); // TODO check on iOS
            logsDirectory = System.IO.Path.Combine(localStorage, "..", "Library"); // TODO check on iOS
        }

        public string DataDirectory => dataDirectory;

        public string LogsDirectory => logsDirectory;
    }
}
