namespace ImageMatcherDisplay
{
    using System.IO;
    public class ImageFile
    {
        public FileInfo ImageFileInfo { get; set; }
        public bool used { get; set; } = false;
        public bool discard { get; set; } = false;
    }
}
