using Microsoft.Win32;
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
        ImageMatcherFactory ImageMatcherFactory = new ImageMatcherFactory();
        public MainWindow()
        {
            InitializeComponent();
            this.folderBrowserDialog1 = new WinForms.FolderBrowserDialog();
            this.folderBrowserDialog1.ShowNewFolderButton = false;
        }

        private void MenuItemGetImage_OnClick(object sender, RoutedEventArgs e)
        {
            this.folderBrowserDialog1.SelectedPath = ImageMatcherFactory.GetConfig(ImageMatcherFactory.CREATE_CONFIG).ImagesFolder;
            WinForms.DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == WinForms.DialogResult.OK)
            {
                var folderName = folderBrowserDialog1.SelectedPath;
                ImageMatcherFactory.SetConfig(folderName);
                bool fileOpened = false;
                if (!fileOpened)
                {
                    ImageMatcherFactory.PrepareImageFileList(folderName);
                    ImageMatcherFactory.DisplayGrid(ImageGrid);
                }
            }
        }

        private void MenuItem_SaveConfig_OnClick(object sender, RoutedEventArgs e)
        {
            if (ImageMatcherFactory.GetConfig(ImageMatcherFactory.DONT_CREATE_CONFIG) == null)
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
            {
                ImageMatcherFactory.LoadConfigFromFile(openFileDialog.FileName);
                var imfc = ImageMatcherFactory.GetConfig(ImageMatcherFactory.CREATE_CONFIG);
                ImageMatcherFactory.PrepareImageFileList(imfc.ImagesFolder);
                ImageMatcherFactory.DisplayGrid(ImageGrid);
            }
        }

        private void MenuItem_NewConfig_OnClick(object sender, RoutedEventArgs e)
        {
            if (ImageMatcherFactory.GetConfig(ImageMatcherFactory.DONT_CREATE_CONFIG) != null)
            {
                WinForms.SaveFileDialog configFileSaveFileDialog = new WinForms.SaveFileDialog();
                if (configFileSaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)

                    ImageMatcherFactory.SaveConfigToFile(configFileSaveFileDialog.FileName);
            }
            ImageMatcherFactory.CreateConfigFile(ImageMatcherFactory.CREATE_CONFIG);
        }

        private void MenuItem_Close_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Image_Clicked(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Image ButtonImage = (System.Windows.Controls.Image)((Button)sender).Content;
            projectedImage.Source = ButtonImage.Source;
            projectedImage.Height =500;
            projectedImage.Width = 600;
            //grdDetails.Visibility = Visibility.Collapsed;
            //grdZoomImage.Visibility = Visibility.Visible;
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

//manual gather - NewPrimary name ----------------------------------
//WinApi.DISPLAY_DEVICE ddOne = new WinApi.DISPLAY_DEVICE();

//ddOne.cb = Marshal.SizeOf(ddOne);
//deviceID = 1;
//WinApi.User_32.EnumDisplayDevices(null, deviceID, ref ddOne, 0);
//string NewPrimary = ddOne.DeviceName;

//WinApi.DEVMODE ndm6 = NewDevMode();
//result = (WinApi.DisplaySetting_Results)WinApi.User_32.ChangeDisplaySettingsEx(NewPrimary, 
//          ref ndm6, (IntPtr)null, (int)WinApi.DeviceFlags.CDS_SET_PRIMARY | 
//          (int)WinApi.DeviceFlags.CDS_UPDATEREGISTRY, IntPtr.Zero);
//Console.WriteLine("Action 3.2 result:" + result.ToString());

//System.Windows.Forms.Screens

