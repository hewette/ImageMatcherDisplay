namespace ImageMatcherDisplay
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;

    public class GridViewHelper
    {
        public GridViewHelper(IImageMatcherConfig imageMatcherConfig)
        {
            this._imageMatcherConfig = imageMatcherConfig;
        }

        public _gridClickEventDelegate GridClickEventHandler { get; set; }
        private IImageMatcherConfig _imageMatcherConfig;

        public void prepareGrid(Grid ImageGrid, List<ImageFile> ListImageFile)
        {
            if (ListImageFile.Count == 0)
            {
                return;
            }
            var cd = new ColumnDefinition();
            for (int i = 0; i < _imageMatcherConfig.NumberofColumnsInImageGrid; i++)
            {
                ImageGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            int imageRows = (int)Math.Ceiling((float)ListImageFile.Count / (float)_imageMatcherConfig.NumberofColumnsInImageGrid);
            imageRows = imageRows <= 0 ? 1 : imageRows;
            int currentImageNo = 0;
            for (int iRow = 0; iRow < imageRows; iRow++)
            {
                ImageGrid.RowDefinitions.Add(new RowDefinition());
                for (int iColumn = 0; iColumn < _imageMatcherConfig.NumberofColumnsInImageGrid; iColumn++)
                {
                    if (currentImageNo > ListImageFile.Count - 1) break;
                    var btn = new System.Windows.Controls.Button();
                    var img = new System.Windows.Controls.Image()
                    {
                        //btn.Name = currentImageNo.ToString();
                        Height = 500, //todo magic no
                        Width = 500,  //todo magic no
                        Margin = new Thickness(5),
                        Source = new BitmapImage(new Uri(ListImageFile[currentImageNo].ImageFileInfo.FullName))
                    };
                    btn.Content = img;
                    btn.ToolTip = ListImageFile[currentImageNo++].ImageFileInfo.FullName;
                    Grid.SetColumn(btn, iColumn);
                    Grid.SetRow(btn, iRow);
                    btn.Click += new RoutedEventHandler(GridClickEventHandler);
                    ImageGrid.Children.Add(btn);
                }
            }
        }
    }
}
