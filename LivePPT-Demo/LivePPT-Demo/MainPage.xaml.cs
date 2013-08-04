using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;

namespace LivePPT_Demo
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();

            // 将 listbox 控件的数据上下文设置为示例数据
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
            GetWP7Picture();

        }

        // 为 ViewModel 项加载数据
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        PictureCollection _pictureCollection = null;
        private ObservableCollection<FlowItem> _pictureList = new ObservableCollection<FlowItem>();

        void GetWP7Picture()
        {
            MediaLibrary library = new MediaLibrary();
            _pictureCollection = library.Pictures;
            int picLimit = 0;           //foreach语句break标志

            if (_pictureCollection.Count == 0) return;


            foreach (Picture _p in _pictureCollection)
            {
                Stream _s = _p.GetImage();
                BitmapImage _bi = new BitmapImage();
                _bi.SetSource(_s);

                FlowItem _w = new FlowItem();
                _w.Picture = _bi;
                _w.Name = _p.Name;

                ImageBrush ib = new ImageBrush();
                ib.ImageSource = _bi;

                _w.BackupgroupPicture = ib;

                _pictureList.Add(_w);

                picLimit++;
                if (picLimit >= 20)
                { break; }
            }


            //fic3d.ItemsSource = null;
            //fic3d.ItemsSource = _pictureList;
            
        }

       

        private void StartCof_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/ViewImages.xaml", UriKind.Relative));
        }
    }

    public class FlowItem
    {
        public string Name { get; set; }
        public ImageSource Picture { get; set; }
        public ImageBrush BackupgroupPicture { get; set; }
    }
}