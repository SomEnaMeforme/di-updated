namespace TagCloudDI.WordHandlers
{
    public interface IWordFilter
    {
        public bool Accept(string word);
    }
}