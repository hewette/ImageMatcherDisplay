namespace ImageMatcherDisplay
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Controls;

    public class ImageMatcherFactory
    {

        public const bool CREATE_CONFIG = true;
        public const bool DONT_CREATE_CONFIG = false;
        public _gridClickEventDelegate GridClickEventHandler { get; set; }
        public List<ImageFile> ListImageFile { private set; get; }
        private ImageMatcherConfig ImageMatcherConfig;

        //public System.Windows.Controls.Image ProjectedIamge {get;set;}

        public ImageMatcherConfig GetConfig(bool createConfig)
        {
            if (ImageMatcherConfig != null)
            {
                if (ImageMatcherConfig.ListImageFile != null)
                {
                    ListImageFile = ImageMatcherConfig.ListImageFile;
                }
                return ImageMatcherConfig;
            }

            CreateConfigFile(createConfig);
            return ImageMatcherConfig;
        }

        public void CreateConfigFile(bool createConfig)
        {
            if (createConfig == CREATE_CONFIG)
            {
                ImageMatcherConfig = new ImageMatcherConfig()
                {
                    ImagesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                };
            }
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
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                Serializer.Serialize(writer, ImageMatcherConfig);
            }
        }

        public void LoadConfigFromFile(string configFileNameToOpen)
        {
            using (StreamReader file = File.OpenText(configFileNameToOpen))
            {
                JsonSerializer serializer = new JsonSerializer();
                ImageMatcherConfig = (ImageMatcherConfig)serializer.Deserialize(file, typeof(ImageMatcherConfig));
            }
        }

        public void DisplayGrid(Grid ImageGrid)
        {
            GridViewHelper GridViewHelper = new GridViewHelper(ImageMatcherConfig);
            GridViewHelper.GridClickEventHandler = GridClickEventHandler;
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
