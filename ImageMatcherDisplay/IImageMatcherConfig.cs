namespace ImageMatcherDisplay
{
    public interface IImageMatcherConfig
    {
        string ImagesFolder { get; set; }
        int NumberofColumnsInImageGrid { get; set; }
    }
}