using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMatcherDisplay
{
    public class ImageFile
    {
        public string filename { get; set; }
        public bool used { get; set; } = false;
        public bool discard { get; set; } = false;
    }
}
