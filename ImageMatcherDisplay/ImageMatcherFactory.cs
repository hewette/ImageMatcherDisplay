using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ImageMatcherDisplay
{
    public class ImageMatcherFactory
    {
        public List<ImageFile> ListImageFile { private set; get; }
        public void PrepareImageFileList(string path)
        {
            ImageFileListProcessor imageFileProcessor = new ImageFileListProcessor();
            ListImageFile=imageFileProcessor.ProcessFolder(path);
        }

        public List<KeyValuePair<string, string>> GetListImageFilesandNames(bool used=false, bool discarded=false)
        {
            return ListImageFile.Where(f => f.discard == discarded && f.used == used)
                .Select(imageFile => new KeyValuePair<string, string>(imageFile.ImageFileInfo.Name, imageFile.ImageFileInfo.FullName))
                .ToList();
        }
    }
}
