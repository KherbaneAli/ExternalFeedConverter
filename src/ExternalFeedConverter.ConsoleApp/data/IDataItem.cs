namespace ExternalFeedConverter.ConsoleApp.Data
{
    public interface IDataItem
    {
        string Index { get; }
        string Girth { get; }
        string Height { get; }
        string Volume { get; }
    }
}