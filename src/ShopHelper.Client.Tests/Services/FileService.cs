﻿namespace ShopHelper.Client.Services
{
    public class FileService : IFileService
    {
        public string DataDirectory => "Data";

        public string LogsDirectory => "Logs";
    }
}
