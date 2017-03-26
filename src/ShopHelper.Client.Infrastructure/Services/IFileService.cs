namespace ShopHelper.Client.Services
{
    public interface IFileService
    {
        string DataDirectory { get; }

        string LogsDirectory { get; }
    }
}
