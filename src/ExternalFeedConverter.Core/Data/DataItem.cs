using System;

namespace ExternalFeedConverter.Core.Data
{
    public class DataItem
    {
        public DataItem(int index, double girth, double height, double volume, string type, bool chopped)
        {
            Height = height;
            Girth = girth;
            Index = index;
            Volume = volume;
            Type = type;
            Chopped = chopped;

        }

        public int Index { get; }
        public double Girth { get; }
        public double Height { get; }
        public double Volume { get; }
        public string Type { get; }
        public Boolean Chopped { get; }
    }
}