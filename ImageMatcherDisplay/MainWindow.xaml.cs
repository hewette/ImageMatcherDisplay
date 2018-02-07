namespace ImageMatcherDisplay
{
    using Microsoft.Win32;
    using System.Windows;
    using WinForms = System.Windows.Forms;
    using System.Windows.Threading;

    public delegate void _gridClickEventDelegate(object sender, RoutedEventArgs e);

    public partial class MainWindow : Window
    {
        private WinForms.FolderBrowserDialog folderBrowserDialog1;
        private ImageMatcherFactory _imageMatcherFactory = new ImageMatcherFactory();
        private _gridClickEventDelegate _gridClickEventHandler;
        private DispatcherTimer _timer = new DispatcherTimer();
        private int _timerTime = 0;

        public MainWindow()
        {
            InitializeComponent();
            this.folderBrowserDialog1 = new WinForms.FolderBrowserDialog()
            {
                ShowNewFolderButton = false
            };
            this._gridClickEventHandler = this.Image_Clicked;
            this._imageMatcherFactory.GridClickEventHandler = this._gridClickEventHandler;
            this._timer.Tick += this.timer_Tick;
        }

        private void MenuItemGetImage_OnClick(object sender, RoutedEventArgs e)
        {
            this.folderBrowserDialog1.SelectedPath = this._imageMatcherFactory.GetConfig(ImageMatcherFactory.CREATE_CONFIG).ImagesFolder;
            var result = this.folderBrowserDialog1.ShowDialog();
            if (result == WinForms.DialogResult.OK)
            {
                string folderName = this.folderBrowserDialog1.SelectedPath;
                this._imageMatcherFactory.SetConfig(folderName);
                bool fileOpened = false;
                if (!fileOpened)
                {
                    this._imageMatcherFactory.PrepareImageFileList(folderName);
                    this._imageMatcherFactory.DisplayGrid(this.ImageGrid);
                }
            }
        }

        private void MenuItem_SaveConfig_OnClick(object sender, RoutedEventArgs e)
        {
            if (this._imageMatcherFactory.GetConfig(ImageMatcherFactory.DONT_CREATE_CONFIG) == null)
            {
                var configFileSaveFileDialog = new WinForms.SaveFileDialog();
                if (configFileSaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this._imageMatcherFactory.SaveConfigToFile(configFileSaveFileDialog.FileName);
                }
            }
        }

        private void MenuItem_OpenConfig_OnClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                this._imageMatcherFactory.LoadConfigFromFile(openFileDialog.FileName);
                var imfc = this._imageMatcherFactory.GetConfig(ImageMatcherFactory.CREATE_CONFIG);
                this._imageMatcherFactory.PrepareImageFileList(imfc.ImagesFolder);
                this._imageMatcherFactory.DisplayGrid(this.ImageGrid);
            }
        }

        private void MenuItem_NewConfig_OnClick(object sender, RoutedEventArgs e)
        {
            if (this._imageMatcherFactory.GetConfig(ImageMatcherFactory.DONT_CREATE_CONFIG) != null)
            {
                var configFileSaveFileDialog = new WinForms.SaveFileDialog();
                if (configFileSaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this._imageMatcherFactory.SaveConfigToFile(configFileSaveFileDialog.FileName);
                }
            }
            this._imageMatcherFactory.CreateConfigFile(ImageMatcherFactory.CREATE_CONFIG);
        }

        private void MenuItem_Close_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Image_Clicked(object sender, RoutedEventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("clicked image button" + ((System.Windows.Controls.Button)sender).ToolTip);
            var ButtonImage = (System.Windows.Controls.Image)(((System.Windows.Controls.Button)sender).Content);
            this.projectedImage.Stretch = System.Windows.Media.Stretch.Fill;
            //.Windows.Controls.Image ButtonImage = (System.Windows.Controls.Image)((Button)sender).Content;
            this.projectedImage.Source = ButtonImage.Source;
            this.tabProjectedImage.IsSelected = true;
        }

        private void ImageButtonClicked(object sender, RoutedEventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show( "clicked image button" + ((System.Windows.Controls.Button)sender).ToolTip);
            var ButtonImage = (System.Windows.Controls.Image)(((System.Windows.Controls.Button)sender).Content);
            //MainTabGroup.SelectedIndex=1;
            //projectedImage.Source = ButtonImage.Source;
            //projectedImage.Height =500;
            //projectedImage.Width = 600;
        }

        private void btnTimer_Click(object sender, RoutedEventArgs e)
        {
            if (!this._timer.IsEnabled)
            {
                this._timerTime = 0;
                this._timer.Interval = System.TimeSpan.FromSeconds(1);
                this._timer.Start();
                this.btnTimer.Content = "Stop Timer";
            }
            else
            {
                this._timer.Stop();
                this.btnTimer.Content = "Start Timer";
            }
        }

        void timer_Tick(object sender, System.EventArgs e)
        {
            this.lblTime.Text = "The Clock is ticking: " + this._timerTime++.ToString();
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

