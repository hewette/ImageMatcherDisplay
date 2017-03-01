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
        public void prepareGrid(Grid ImageGrid)
        {
           var cd = new ColumnDefinition();
            for (int i = 0; i< _imageMatcherConfig.NumberofColumnsInImageGrid;i++)
            {
                ImageGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
    }
}
