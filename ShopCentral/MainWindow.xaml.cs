using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.IO;

namespace ShopCentral
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //Get Rewuest -----------------
            //string urlPath = String.Format("https://jsonplaceholder.typicode.com/posts");
            //WebRequest requestObjectGet = WebRequest.Create(urlPath);
            //requestObjectGet.Method = "GET";
            //HttpWebResponse responseObj = null;
            //responseObj = (HttpWebResponse)requestObjectGet.GetResponse();

            //string test = null;
            //using (Stream stream = responseObj.GetResponseStream())
            //{
            //    StreamReader sr = new StreamReader(stream);
            //    test = sr.ReadToEnd();
            //    test_lbl.Content =  test;
            //    sr.Close();
            //}

            //Post Request ------------------------------
            string urlPath2 = String.Format("https://personal-hm11mvg2.outsystemscloud.com/ShopCentral/rest/ShopAPI/CreateItem");

            string purchaseVal = purchaseTotal_textbox.Text;
            string postData = "{\"Name\": \"Name3\",  \"Barcode\": \"1234567891234567\",  \"IsActive\": \"true\",  \"CategoryID\": \"1\",  \"Price\": \"$purchaseVal\"}";
            WebRequest requestObjPost = WebRequest.Create(urlPath2);
            requestObjPost.Method ="POST";
            requestObjPost.ContentType = "application/json";

            using(var streamWriter = new StreamWriter(requestObjPost.GetRequestStream()))
            {
                streamWriter.Write(postData);
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = requestObjPost.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    
                        var result2 = streamReader.ReadToEnd();
                    test_lbl.Content = result2;
                }
            }
        }
    }
}
