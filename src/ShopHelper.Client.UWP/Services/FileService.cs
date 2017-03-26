namespace ShopHelper.Client.Services
{
    public class FileService : IFileService
    {
        private static readonly string dataDirectory;

        static FileService()
        {
            var localStorage = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            dataDirectory = System.IO.Path.Combine(localStorage, "ShopHelper");
        }

        public string DataDirectory => dataDirectory;
    }
}
