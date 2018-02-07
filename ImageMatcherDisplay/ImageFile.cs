namespace ImageMatcherDisplay
{
    using System.IO;
    public class ImageFile
    {
        public FileInfo ImageFileInfo { get; set; }
        public bool Used { get; set; } = false;
        public bool Discard { get; set; } = false;
    }
}
