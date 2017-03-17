namespace ImageMatcherDisplay
{
    using System.Collections.Generic;
    public class ImageMatcherConfig : IImageMatcherConfig
    {
        private const int DefaultColumnCount = 4;
        public string ImagesFolder { get; set; }
        public int NumberofColumnsInImageGrid { get; set; } = DefaultColumnCount;
        public List<ImageFile> ListImageFile { set; get; }
    }
}
