namespace ExternalFeedConverter.Core.Data
{
    public class DataItem
    {
        public DataItem(string index, string girth, string height, string volume)
        {
            Height = height;
            Girth = girth;
            Index = index;
            Volume = volume;
        }

        public string Index { get; }
        public string Girth { get; }
        public string Height { get; }
        public string Volume { get; }
    }
}