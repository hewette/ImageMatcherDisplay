﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Drawing;
using System.Windows.Forms.Design;
using WinForms = System.Windows.Forms;
namespace ImageMatcherDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WinForms.FolderBrowserDialog folderBrowserDialog1;
        private FileInfo configFileInfo;
        ImageMatcherFactory ImageMatcherFactory = new ImageMatcherFactory();
        public MainWindow()
        {
            InitializeComponent();
            this.folderBrowserDialog1 = new WinForms.FolderBrowserDialog();
            this.folderBrowserDialog1.ShowNewFolderButton = false;
        }

        private void MenuItemGetImage_OnClick(object sender, RoutedEventArgs e)
        {
            this.folderBrowserDialog1.SelectedPath = ImageMatcherFactory.GetConfig().ImagesFolder;
            WinForms.DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == WinForms.DialogResult.OK)
            {
                var folderName = folderBrowserDialog1.SelectedPath;
                ImageMatcherFactory.SetConfig(folderName);
                bool fileOpened = false;
                if (!fileOpened)
                {
                    ImageMatcherFactory.PrepareImageFileList(folderName);
                    var imageSource = ImageMatcherFactory.GetListImageFilesandNames();
                }
            }
        }

        private void MenuItemSaveConfig_OnClick(object sender, RoutedEventArgs e)
        {
            if (configFileInfo == null)
            {
                WinForms.SaveFileDialog configFileSaveFileDialog = new WinForms.SaveFileDialog();
                if (configFileSaveFileDialog.ShowDialog()== System.Windows.Forms.DialogResult.OK)

                    ImageMatcherFactory.SaveConfigToFile(configFileSaveFileDialog.FileName);
            }
        }

        private void MenuItem_OpenConfig_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                ImageMatcherFactory.LoadConfigFromFile(openFileDialog.FileName);
        }
    }
}


//TODO folder picker - This stalled - thread?
//TODO file picker - load image class list
//TODO Image Grid
//TODO Image Choose
//TODO Image class
//TODO Image Class List
//TODO Image magnify
//TODO Remove matched image
//TODO Score
//TODO multiple images locations
//TODO Switch monitors
//TODO Score config - Present/Match/Better image/Loose
//TODO Reset Score
//TODO Set max image nos
//TODO Salmon button
//TODO Timer
