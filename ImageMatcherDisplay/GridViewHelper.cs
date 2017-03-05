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
            //double x = ListImageFile.Count / _imageMatcherConfig.NumberofColumnsInImageGrid;
            double imageRowsDBL = Math.Ceiling((float)ListImageFile.Count / (float)_imageMatcherConfig.NumberofColumnsInImageGrid);
            int imageRows = (int)imageRowsDBL;
            imageRows = imageRows <= 0 ? 1 : imageRows;
            for (int iRow = 0;  iRow< imageRows;iRow++ )
            {
                ImageGrid.RowDefinitions.Add(new RowDefinition());
                for (int iColumn = 0; iColumn < _imageMatcherConfig.NumberofColumnsInImageGrid; iColumn++)
                {
                    int currentImageNo = (iRow * iRow == 0 ? 0 : _imageMatcherConfig.NumberofColumnsInImageGrid + 1) * (iColumn);
                    if (currentImageNo > ListImageFile.Count - 1) break;
                    var img = new System.Windows.Controls.Image();
                    img.Height = 200;
                    img.Width = 100;
                    img.Source = new BitmapImage(new Uri(ListImageFile[currentImageNo].ImageFileInfo.FullName));
                    Grid.SetColumn(img, iColumn);
                    Grid.SetRow(img, iRow);
                    ImageGrid.Children.Add(img);
                }
            }
        }
    }
}
