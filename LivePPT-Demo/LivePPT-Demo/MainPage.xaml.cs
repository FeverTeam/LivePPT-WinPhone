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
using System.Collections.Specialized;

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
            //InitializeConfItemModel();

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
        //private ObservableCollection<FlowItem> _pictureList = new ObservableCollection<FlowItem>();
        private ObservableCollection<ConfItemModel> _ConfItemModelList = new ObservableCollection<ConfItemModel>();

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

                ConfItemModel _w = new ConfItemModel();
                _w.Image = _bi;
                _w.Filename = _p.Name;

                
                

                //ImageBrush ib = new ImageBrush();
                //ib.ImageSource = _bi;

                //_w.BackupgroupPicture = ib;

                _ConfItemModelList.Add(_w);

                picLimit++;
                if (picLimit >= 20)
                { break; }
            }


            lstPicture.ItemsSource = null;
            lstPicture.ItemsSource = _ConfItemModelList;
            //fic3d.ItemsSource = null;
            //fic3d.ItemsSource = _pictureList;
            
        }
        

       

        private void StartCof_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/ViewImages.xaml", UriKind.Relative));
        }

        public ImageSource Picture;
        //event NotifyCollectionChangedEventHandler CollectionChanged;

        private void lstPicture_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            string target = "/ViewImages.xaml";
            target += string.Format("?imageBox.Source={0}", lstPicture.ItemsSource.ToString());
            this.NavigationService.Navigate(new Uri(target, UriKind.Relative));*/

            this.NavigationService.Navigate(new Uri("/ViewImages.xaml", UriKind.Relative));
        }


        

        /*
        private void InitializeConfItemModel()
        {
            ConfItemModel.Add(new ConfItemModel() { Filename = "Desert.jpg", Image = Utils.GetImage("Desert.jpg") });
            ConfItemModel.Add(new ConfItemModel() { Filename = "Field.jpg", Image = Utils.GetImage("Field.jpg") });//获取相对路径下的图像资源添加到集合中。   
            ConfItemModel.Add(new ConfItemModel() { Filename = "Flower.jpg", Image = Utils.GetImage("Flower.jpg") });
            ConfItemModel.Add(new ConfItemModel() { Filename = "Hydrangeas.jpg", Image = Utils.GetImage("Hydrangeas.jpg") });
            ConfItemModel.Add(new ConfItemModel() { Filename = "Jellyfish.jpg", Image = Utils.GetImage("Jellyfish.jpg") });
            ConfItemModel.Add(new ConfItemModel() { Filename = "Koala.jpg", Image = Utils.GetImage("Koala.jpg") });
            ConfItemModel.Add(new ConfItemModel() { Filename = "Leaves.jpg", Image = Utils.GetImage("Leaves.jpg") });
            ConfItemModel.Add(new ConfItemModel() { Filename = "Lighthouse.jpg", Image = Utils.GetImage("Lighthouse.jpg") });
            ConfItemModel.Add(new ConfItemModel() { Filename = "Penguins.jpg", Image = Utils.GetImage("Penguins.jpg") });
            ConfItemModel.Add(new ConfItemModel() { Filename = "Rocks.jpg", Image = Utils.GetImage("Rocks.jpg") });
        }
          */

    }

    
    public class FlowItem
    {
        public string Name { get; set; }
        public ImageSource Picture { get; set; }
        public ImageBrush BackupgroupPicture { get; set; }
    }
}