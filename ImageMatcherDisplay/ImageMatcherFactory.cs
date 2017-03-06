using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Controls;

namespace ImageMatcherDisplay
{
    public class ImageMatcherFactory
    {
        public List<ImageFile> ListImageFile { private set; get; }
        private ImageMatcherConfig ImageMatcherConfig;

    
        public ImageMatcherConfig GetConfig()
        {
            if (ImageMatcherConfig != null)
            {
                if(ImageMatcherConfig.ListImageFile!=null)
                {
                    ListImageFile = ImageMatcherConfig.ListImageFile;
                }
                return ImageMatcherConfig;
            }
            ImageMatcherConfig = new ImageMatcherConfig();
            ImageMatcherConfig.ImagesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures); 
            return ImageMatcherConfig;
        }

        public void SetConfig(string selectedFolder)
        {
            if (ImageMatcherConfig == null)
            {
                ImageMatcherConfig = new ImageMatcherConfig();
            }

            if (selectedFolder.Length == 0 && !Directory.Exists(selectedFolder))
            {
                ImageMatcherConfig.ImagesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }
            else
            {
                ImageMatcherConfig.ImagesFolder = selectedFolder;
            }
        }

        public void PrepareImageFileList(string path)
        {
            ImageFileListProcessor imageFileProcessor = new ImageFileListProcessor();
            ListImageFile = imageFileProcessor.ProcessFolder(path);
            if (ImageMatcherConfig == null) //TODO refactor
            {
                ImageMatcherConfig = new ImageMatcherConfig();
            }
            ImageMatcherConfig.ListImageFile = ListImageFile;
        }

        public void SaveConfigToFile(string configFileName)
        { 
            JsonSerializer Serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(configFileName))
            using(JsonWriter writer = new JsonTextWriter(sw))
            {
                Serializer.Serialize(writer, ImageMatcherConfig);
            }
        }

        public void LoadConfigFromFile(string configFileNameToOpen)
        {
            using(StreamReader file = File.OpenText(configFileNameToOpen))
            {
                JsonSerializer serializer = new JsonSerializer();
                ImageMatcherConfig = (ImageMatcherConfig)serializer.Deserialize(file, typeof(ImageMatcherConfig));
            }
        }

        public void DisplayGrid(Grid ImageGrid)
        {
            GridViewHelper GridViewHelper = new GridViewHelper(ImageMatcherConfig);
            GridViewHelper.prepareGrid(ImageGrid, ListImageFile);
            GridViewHelper = null;
        }

        //publc List<KeyValuePair<string, string>> GetListImageFilesandNames(bool used=false, bool discarded=false)
        //{
        //    return ListImageFile.Where(f => f.discard == discarded && f.used == used)
        //        .Select(imageFile => new KeyValuePair<string, string>(imageFile.ImageFileInfo.Name, imageFile.ImageFileInfo.FullName))
        //        .ToList();
        //}

        //public List<KeyValuePair<string, Image>> GetListImageFilesandNames(bool used = false, bool discarded = false)
        //{
        //    return ListImageFile.Where(f => f.discard == discarded && f.used == used)
        //                .Select(imageFile => new KeyValuePair<string, Image>(
        //                    imageFile
        //                        .ImageFileInfo.Name, Image.FromFile(imageFile.ImageFileInfo.FullName)
        //                        .GetThumbnailImage(120, 120, () => false, IntPtr.Zero))
        //            )
        //        .ToList();
        //}

    }
}
