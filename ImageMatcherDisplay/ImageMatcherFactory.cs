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

        public ImageMatcherConfig GetConfig(bool createConfig)
        {
            if (this.ImageMatcherConfig != null)
            {
                if (this.ImageMatcherConfig.ListImageFile != null)
                {
                    this.ListImageFile = this.ImageMatcherConfig.ListImageFile;
                }
                return this.ImageMatcherConfig;
            }

            CreateConfigFile(createConfig);
            return this.ImageMatcherConfig;
        }

        public void CreateConfigFile(bool createConfig)
        {
            if (createConfig == CREATE_CONFIG)
            {
                this.ImageMatcherConfig = new ImageMatcherConfig()
                {
                    ImagesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                };
            }
        }

        public void SetConfig(string selectedFolder)
        {
            if (this.ImageMatcherConfig == null)
            {
                this.ImageMatcherConfig = new ImageMatcherConfig();
            }

            if (selectedFolder.Length == 0 && !Directory.Exists(selectedFolder))
            {
                this.ImageMatcherConfig.ImagesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }
            else
            {
                this.ImageMatcherConfig.ImagesFolder = selectedFolder;
            }
        }

        public void PrepareImageFileList(string path)
        {
            var imageFileProcessor = new ImageFileListProcessor();
            this.ListImageFile = imageFileProcessor.ProcessFolder(path);
            if (this.ImageMatcherConfig == null) //TODO refactor
            {
                this.ImageMatcherConfig = new ImageMatcherConfig();
            }
            this.ImageMatcherConfig.ListImageFile = this.ListImageFile;
        }

        public void SaveConfigToFile(string configFileName)
        {
            var Serializer = new JsonSerializer();
            using (var sw = new StreamWriter(configFileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                Serializer.Serialize(writer, this.ImageMatcherConfig);
            }
        }

        public void LoadConfigFromFile(string configFileNameToOpen)
        {
            using (var file = File.OpenText(configFileNameToOpen))
            {
                var serializer = new JsonSerializer();
                this.ImageMatcherConfig = (ImageMatcherConfig)serializer.Deserialize(file, typeof(ImageMatcherConfig));
            }
        }

        public void DisplayGrid(Grid ImageGrid)
        {
            var GridViewHelper = new GridViewHelper(this.ImageMatcherConfig);
            GridViewHelper.GridClickEventHandler = this.GridClickEventHandler;
            GridViewHelper.PrepareGrid(ImageGrid, this.ListImageFile);
            GridViewHelper = null;
        }
    }
}
