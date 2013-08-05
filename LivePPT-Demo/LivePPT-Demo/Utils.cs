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
using System.Windows.Resources;   

namespace LivePPT_Demo{

    public static class Utils
    {
        public static BitmapImage GetImage(string filename)
        {
            string imgLocation = Application.Current.Resources["ImagesLocation"].ToString();//ImagesLocation为在App.xaml中定义的资源，表示路径代码如下：   
            // <system:String x:Key="ImagesLocation">Resouces/Pictures/</system:String>   
            StreamResourceInfo imageResource = Application.GetResourceStream(new Uri(imgLocation + filename, UriKind.Relative));//获取图像信息数据   
            BitmapImage image = new BitmapImage();//定义一个图像类型的变量   
            image.SetSource(imageResource.Stream);
            return image;
            //将获取的图像数据赋给该图像变量，并返回该图像   
        }
    }   

}
