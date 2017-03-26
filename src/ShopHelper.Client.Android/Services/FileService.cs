namespace ShopHelper.Client.Services
{
    public class FileService : IFileService
    {
        private static readonly string dataDirectory;

        static FileService()
        {
            var localStorage = Android.OS.Environment.ExternalStorageDirectory.ToString();
            dataDirectory = System.IO.Path.Combine(localStorage, "ShopHelper", "Data");
        }

        public string DataDirectory => dataDirectory;
    }
}