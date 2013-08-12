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
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LivePPT_Demo
{
    public partial class Login_Register : PhoneApplicationPage
    {
        public Login_Register()
        {
            InitializeComponent();            
        }       

        private void DisplayPassword_Checked(object sender, RoutedEventArgs e)
        {
            //PasswordInputInfo.Text = (string) Password.PasswordChar;
        }

        private void SaveUserInfo_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RegisterCommit_Click(object sender, RoutedEventArgs e)
        {
            
        }


        #region HTTP网络请求
        public void httpGet(string url)
        {
            try
            {
                //请求地址
                
                //创建WebRequest类
                HttpWebRequest request = HttpWebRequest.CreateHttp(new Uri(url));

                //设置请求方式GET POST
                request.Method = "GET";

                //返回应答请求异步操作的状态
                request.BeginGetResponse(responseCallback, request);
            }
            catch (WebException e)
            {
                //网络相关异常处理
            }
            catch (Exception e)
            {
                //异常处理
            }
        }

        private void responseCallback(IAsyncResult result)
        {
            try
            {
                //获取异步操作返回的的信息
                HttpWebRequest request = (HttpWebRequest)result.AsyncState;
                //结束对 Internet 资源的异步请求
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
                //解析应答头
                //parseRecvHeader(response.Headers);
                //获取请求体信息长度
                long contentLength = response.ContentLength;
                
                //获取应答码
                int statusCode = (int)response.StatusCode;
                string statusText = response.StatusDescription;                

                //应答头信息验证
                using (Stream stream = response.GetResponseStream())
                {
                    //获取请求信息
                    StreamReader read = new StreamReader(stream);
                    //string msg = read.ReadToEnd();
                    //Deployment.Current.Dispatcher.BeginInvoke(() =>
                    //{
                    //    textBlock1.Text = msg;
                    //});
                }

            }
            catch (WebException e)
            {
                //连接失败

            }
            catch (Exception e)
            {
                //异常处理

            }

        }

        public void httpPost(string url)
        {
            try
            {
                //请求地址
                
                //创建WebRequest类
                HttpWebRequest request = HttpWebRequest.CreateHttp(new Uri(url));

                //设置请求方式GET POST
                request.Method = "POST";

                //返回应答请求异步操作的状态
                request.BeginGetRequestStream(requestCallback, request);
            }
            catch (WebException e)
            {
                //网络相关异常处理
            }
            catch (Exception e)
            {
                //异常处理
            }
        }

        private void requestCallback(IAsyncResult result)
        {
            try
            {
                //获取异步操作返回的的信息
                HttpWebRequest request = (HttpWebRequest)result.AsyncState;
                //结束对 Internet 资源的异步请求
                StreamWriter postStream = new StreamWriter(request.EndGetRequestStream(result));
                postStream.WriteLine("作者：宇之乐");
                postStream.WriteLine("出处：http://www.cnblogs.com/huizhang212/");

                //返回应答请求异步操作的状态
                request.BeginGetResponse(responseCallback, request);
            }
            catch (WebException e)
            {
                //异常处理

            }
            catch (Exception e)
            {
                //异常处理

            }
        }
        #endregion

    }

    #region 用户信息
    public class UserInfo
    {
        public string email { get; set; }
        public string password { get; set; }        
    }

    public class LoginInfo : UserInfo
    {
        public string url = "http://liveppt.net/app/login";
    }

    public class RegisterInfo : UserInfo
    {
        public string url = "http://liveppt.net/app/register";
    }
    #endregion
}