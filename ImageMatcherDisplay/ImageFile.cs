using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMatcherDisplay
{
    public class ImageFile
    {
        public FileInfo ImageFileInfo { get; set; }
        public bool used { get; set; } = false;
        public bool discard { get; set; } = false;
    }
}
