using System;

namespace ShopHelper.Client.Utils
{
    static class FilesUtil
    {
        private const string AppName = "ShopHelper";

        public readonly static string DataDirectory = GetDataDirectoryByPlatform();

        private static string GetDataDirectoryByPlatform()
        {
#if __ANDROID__
            var localStorage = Android.OS.Environment.ExternalStorageDirectory.ToString();
            return System.IO.Path.Combine(localStorage, AppName, "Data");
#elif __IOS__
            var localStorage = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return System.IO.Path.Combine(localStorage, "..", "Library");
#else
            var localStorage = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            return System.IO.Path.Combine(localStorage, AppName);
#endif
        }
    }
}
