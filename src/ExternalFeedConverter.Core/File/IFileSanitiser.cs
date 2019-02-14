namespace ExternalFeedConverter.Core.File
{
    public interface IFileSanitiser
    {
        string[] Sanitise(string input);
    }
}