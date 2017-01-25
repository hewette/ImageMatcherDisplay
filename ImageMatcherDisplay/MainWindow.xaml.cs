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
using WinForms = System.Windows.Forms;
namespace ImageMatcherDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WinForms.FolderBrowserDialog folderBrowserDialog1;
        private string openFileName, folderName;

        private bool fileOpened = false;
        public MainWindow()
        {
            InitializeComponent();
            List<KeyValuePair<string, string>> images =
                new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string,string>("Image1", @"C:\Users\EricHewett\Pictures\Lonely Tree.jpg"),
                    new KeyValuePair<string,string>("Image2", @"C:\Users\EricHewett\Pictures\Lonely Tree.jpg"),
                    new KeyValuePair<string,string>("Image3", @"C:\Users\EricHewett\Pictures\Lonely Tree.jpg")
                };

            imageList.ItemsSource = images;


            this.folderBrowserDialog1 = new WinForms.FolderBrowserDialog();
            this.folderBrowserDialog1.ShowNewFolderButton = false;

            // Default to the My Documents folder.
            //this.folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyPictures;
        }

        private void MenuItemGetImage_OnClick(object sender, RoutedEventArgs e)
        {
            WinForms.DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == WinForms.DialogResult.OK)
            {
                folderName = folderBrowserDialog1.SelectedPath;
                if (!fileOpened)
                {
                    // No file is opened, bring up openFileDialog in selected path.

                }
            }
        }

        //OpenFileDialog openFileDialog = new OpenFileDialog();
        //    if (openFileDialog.ShowDialog() == true)
        //        txtEditor.Text = File.ReadAllText(openFileDialog.FileName);

    }
}


//TODO folder picker 
//TODO file picker - load image class list
//TODO Image Grid
//TODO Image Choose
//TODO Image class
//TODO Image Class List
//TODO Image magnify
//TODO Remove matched image
//TODO Score
//TODO multiple images locagtions
//TODO Switch monitors
//TODO Score config - Present/Match/Better image/Loose
//TODO Reset Score
//TODO Set max image nos
//TODO Salmon button
//TODO Timer
