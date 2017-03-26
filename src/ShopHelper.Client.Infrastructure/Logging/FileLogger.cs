namespace ShopHelper.Client.Logging
{
    public class FileLogger<T> : ILogger<T>
    {
        private static object logSync = new object();
        private readonly FileLogBuilder logBuilder;

        public FileLogger(FileLogBuilder logBuilder)
        {
            Guard.NotNull(logBuilder, nameof(logBuilder));
            this.logBuilder = logBuilder;
        }

        public virtual void Log(LogLevel level, string message)
        {
            var logItem = new LogItem(level, message, typeof(T));
            var path = logBuilder.BuildPath(logItem);
            var text = logBuilder.BuildMessage(logItem);

            lock (logSync)
            {
                System.IO.File.AppendAllText(path, text, System.Text.Encoding.UTF8);
            }
        }
    }
}
