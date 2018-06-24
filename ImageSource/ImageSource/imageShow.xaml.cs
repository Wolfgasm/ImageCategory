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
//using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;

namespace ImageSource
{
    /// <summary>
    /// imageShow.xaml 的互動邏輯
    /// </summary>
    public partial class imageShow : UserControl
    {
        string tag1, tag2, tag3, tag4, tag5;
        int theIndex;
        string theData;
        // 設定按鈕圖片的 get 和 set 封裝
        public string TheImagePath
        {
            get
            {
                string path = Preview_Image.Source + "" ;
                return path;
            }
            set
            {
                // 設置此函數時 取得設置時的數值(就是檔案路徑)並存入imagetemp變數
                BitmapImage imagetemp = new BitmapImage(new Uri(value.ToString(), UriKind.Absolute));
                Preview_Image.Source = imagetemp;
                //FileName.Text = value.ToString();
            }
            
        }
        // 設定檔名的GETSET
        public string FileName
        {
            get
            {
                return TheFileName.Text;
            }
            set
            {
                TheFileName.Text = value.ToString();
            }


        }

        public string Tag1
        {
            get
            {
                return tag1;
            }
            set
            {
                tag1 = value.ToString();
            }

        }

        public string Tag2
        {
            get
            {
                return tag2;
            }
            set
            {
                tag2 = value.ToString();
            }

        }
        public string Tag3
        {
            get
            {
                return tag3;
            }
            set
            {
                tag3 = value.ToString();
            }

        }
        public string Tag4
        {
            get
            {
                return tag4;
            }
            set
            {
                tag4 = value.ToString();
            }

        }
        public string Tag5
        {
            get
            {
                return tag5;
            }
            set
            {
                tag5 = value.ToString();
            }

        }
        public int TheIndex
        {
            get
            {
                return theIndex;
            }
            set
            {
                theIndex = value;
            }

        }

        private void Preview_Image_GotFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("FUCK");
        }
        // 新增一個叫做 deletebtn 的事件
        public event EventHandler deletebtn_pressed;


        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            deletebtn_pressed(this, null);
        }

        /*
public string data
{
   get
   {
       return theData;
   }
   set
   {
       string[] temp = new string[10];
       temp = value.Split('|');
       theData = temp[6];                
   }

}*/

        public imageShow()
        {
            InitializeComponent();
        }

        private void Preview_Image_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            BitmapImage imagetemp = new BitmapImage(new Uri(@"D:\桌面\patches\patches3\1KcaCbHTSDaQSKGDwBpI.jpg", UriKind.Absolute));
            Preview_Image.Source = imagetemp;
            */
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            
            // 單擊時利用路徑打開檔案
            //Process.Start(TheImagePath);
        }

        private void TheFileName_Loaded(object sender, RoutedEventArgs e)
        {
            // 取得存在該路徑檔案的檔名 不含副檔名
            FileName = Path.GetFileNameWithoutExtension(TheImagePath);
          
        }
    }
}