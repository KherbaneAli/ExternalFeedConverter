namespace ExternalFeedConverter.Core.Files
{
    public interface IFileProvider
    {
        string[] ReadAllLines(string input);
    }
}