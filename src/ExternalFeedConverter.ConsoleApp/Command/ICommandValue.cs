namespace ExternalFeedConverter.ConsoleApp.Command
{
    public interface ICommandValue
    {
        string Name { get; set; }
        string Value { get; set; }
    }
}