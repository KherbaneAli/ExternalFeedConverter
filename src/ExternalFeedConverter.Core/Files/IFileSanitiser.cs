namespace ExternalFeedConverter.Core.Files
{
    public interface IFileSanitiser
    {
        string[] Sanitise(string input);
    }
}