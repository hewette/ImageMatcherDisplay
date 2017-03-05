using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMatcherDisplay
{
    public class ImageMatcherConfig : IImageMatcherConfig
    {
        private const int DefaultColumnCount = 4;
        public string ImagesFolder { get; set; }
        public int NumberofColumnsInImageGrid { get; set; } = DefaultColumnCount;
        public List<ImageFile> ListImageFile { set; get; }
    }
}
