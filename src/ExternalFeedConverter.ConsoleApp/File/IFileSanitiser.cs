namespace ExternalFeedConverter.ConsoleApp.File
{
    public interface IFileSanitiser
    {
        string[] Sanitise(string input);
    }
}