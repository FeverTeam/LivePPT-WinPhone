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
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;

namespace LivePPT_Demo
{
    public partial class ViewImages : PhoneApplicationPage
    {
        public ViewImages()
        {
            InitializeComponent();
        }

        private void changeImage_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage imageInbox = new BitmapImage(new Uri("/LivePPT-Demo;component/Images/Lighthouse.jpg", UriKind.Relative));
            imageBox.Source = imageInbox; 
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Login_Register.xaml", UriKind.Relative));
        }

        
    }
}