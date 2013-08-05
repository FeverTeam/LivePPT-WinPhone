using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;   
using System.ComponentModel;   

namespace LivePPT_Demo
{
    public class ConfItemModel : INotifyPropertyChanged
    {
        private string _Filename;
        public string Filename
        {
            get { return _Filename; }
            set
            {
                _Filename = value;
                NotifyPropertyChanged("Filename");
            }
        }
        private BitmapImage _Image;
        public BitmapImage Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                NotifyPropertyChanged("Image");
            }
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
   


    }
}
