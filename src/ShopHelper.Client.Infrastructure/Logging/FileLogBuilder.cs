using ShopHelper.Client.Services;

namespace ShopHelper.Client.Logging
{
    public class FileLogBuilder
    {
        private readonly string logsDirectory;

        public FileLogBuilder(IFileService fileService)
        {
            Guard.NotNull(fileService, nameof(fileService));
            logsDirectory = fileService.LogsDirectory;
            if (!System.IO.Directory.Exists(logsDirectory))
            {
                System.IO.Directory.CreateDirectory(logsDirectory);
            }
        }

        public string BuildPath(LogItem logItem)
        {
            var fileName = $"{logItem.Category.Name}_{logItem.When:yyyyMMdd}.log";
            var path = System.IO.Path.Combine(logsDirectory, fileName);
            return path;
        }

        public string BuildMessage(LogItem logItem)
        {
            var message = $"{logItem.When:yyyy-MM-dd HH:mm:ss}\t{logItem.Level}\t{logItem.Message}{System.Environment.NewLine}";
            return message;
        }
    }
}
