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
        bool isSelected = false;
        string tag1, tag2, tag3, tag4, tag5;
        string theIndex;
        string theData;
        // 新增一個叫做 deletebtn 的事件
        public event EventHandler deletebtn_pressed;
        public event EventHandler Selected_image;

        
        

        public bool Selected
        {
            get
            {
                return isSelected;
            }
            set
            {
                if (value == false)
                {
                    SelectMark.Visibility = Visibility.Collapsed;
                    isSelected = false;
                }
                else if (value == true)
                {
                    SelectMark.Visibility = Visibility.Visible;
                    isSelected = true;
                }
            }

        }

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
                try
                {
                    // 設置此函數時 取得設置時的數值(就是檔案路徑)並存入imagetemp變數
                    BitmapImage imagetemp = new BitmapImage(new Uri(value.ToString(), UriKind.Absolute));
                    Preview_Image.Source = imagetemp;
                    //FileName.Text = value.ToString();
                }
                catch
                {
                    MessageBox.Show("遺失了一張圖片路徑,這可能是因為C:\\temp中的文件遭到手動修改" + "\r\n" + ",建議您在左側刪除顯示遺失的物件");
                }
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
        public string TheIndex
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



        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            deletebtn_pressed(this, null);
        }

        


        public imageShow()
        {
            InitializeComponent();
        }

        private void Preview_Image_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            select();
            Selected_image(this, null);
            Process.Start(Preview_Image.Source.ToString());
            
        }

        private void TheFileName_Loaded(object sender, RoutedEventArgs e)
        {
            // 取得存在該路徑檔案的檔名 不含副檔名
            FileName = Path.GetFileNameWithoutExtension(TheImagePath);
          
        }

        public void select()
        {
            if (SelectMark.Visibility == Visibility.Collapsed)
            {
                SelectMark.Visibility = Visibility.Visible;
                isSelected = true;
            }
            else if (SelectMark.Visibility == Visibility.Visible)
            {
                SelectMark.Visibility = Visibility.Collapsed;
                isSelected = false;
            }
            
        }
    }
}