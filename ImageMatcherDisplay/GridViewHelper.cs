using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WinForms = System.Windows.Forms;
using Microsoft.Win32;

using System.Windows;
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
using System.Windows.Forms;

namespace ImageMatcherDisplay
{
    class GridViewHelper
    {
        IImageMatcherConfig _imageMatcherConfig;
        public GridViewHelper(IImageMatcherConfig imageMatcherConfig)
        {
            _imageMatcherConfig = imageMatcherConfig;
        }
        public void prepareGrid(Grid ImageGrid, List<ImageFile> ListImageFile)
        {
            if (ListImageFile.Count == 0) return;
            var cd = new ColumnDefinition();
            for (int i = 0; i< _imageMatcherConfig.NumberofColumnsInImageGrid;i++)
            {
                ImageGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            int imageRows = (int)Math.Ceiling((float)ListImageFile.Count / (float)_imageMatcherConfig.NumberofColumnsInImageGrid);
            imageRows = imageRows <= 0 ? 1 : imageRows;
            int currentImageNo = 0;
            for (int iRow = 0;  iRow< imageRows;iRow++ )
            {
                ImageGrid.RowDefinitions.Add(new RowDefinition());
                for (int iColumn = 0; iColumn < _imageMatcherConfig.NumberofColumnsInImageGrid; iColumn++)
                {
                    if (currentImageNo > ListImageFile.Count - 1) break;
                    var btn = new System.Windows.Controls.Button();
                    var img = new System.Windows.Controls.Image();
                    //btn.Name = currentImageNo.ToString();
                    img.Height = 500; //todo magic no
                    img.Width = 500;  //todo magic no
                    img.Margin = new Thickness(5);
                    img.Source = new BitmapImage(new Uri(ListImageFile[currentImageNo++].ImageFileInfo.FullName));
                    btn.Content = img;
                    btn.ToolTip = ListImageFile[currentImageNo++].ImageFileInfo.FullName;
                    Grid.SetColumn(btn, iColumn);
                    Grid.SetRow(btn, iRow);
                    btn.Click += ImageButtonClicked;
                    ImageGrid.Children.Add(btn);
                }
            }
        }

        private void ImageButtonClicked(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show( "clicked image button" + ((System.Windows.Controls.Button)sender).ToolTip);
            System.Windows.Controls.Image ButtonImage = (System.Windows.Controls.Image)(((System.Windows.Controls.Button)sender).Content);
            //projectedImage.Source = ButtonImage.Source;
            //projectedImage.Height =500;
            //projectedImage.Width = 600;

        }
    }
}
