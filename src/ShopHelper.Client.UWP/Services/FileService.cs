namespace ShopHelper.Client.Services
{
    public class FileService : IFileService
    {
        private readonly string dataDirectory;
        private readonly string logsDirectory;

        public FileService()
        {
            var localStorage = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            dataDirectory = System.IO.Path.Combine(localStorage, "ShopHelper", "Data");
            logsDirectory = System.IO.Path.Combine(localStorage, "ShopHelper", "Logs");
        }

        public string DataDirectory => dataDirectory;

        public string LogsDirectory => logsDirectory;
    }
}
