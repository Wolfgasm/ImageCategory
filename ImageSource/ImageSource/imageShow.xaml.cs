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
using System.Drawing;
using System.Windows.Interop;



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
        string thedata;
        // 設定按鈕圖片的 get 和 set 封裝
        public string TheImagePath
        {
            get
            {
                /* string path = Preview_Image.Source + "" ;
                 return path;*/
                return thedata;
            }
            set
            {
                try
                {
                    //------------------------------------------------------------------------------------------------這邊在吃效能------------------------------------------------------------------------------------------------
                    // 設置此函數時 取得設置時的數值(就是檔案路徑)並存入imagetemp變數
                    /*BitmapImage imagetemp = new BitmapImage(new Uri(value.ToString(), UriKind.Absolute));
                    Preview_Image.Source = imagetemp;*/
                    //--------------------以下
                    /*
                    using (BinaryReader loader = new BinaryReader(File.Open(value, FileMode.Open)))
                    {
                        FileInfo fd = new FileInfo(value);
                        int Length = (int)fd.Length;
                        byte[] buf = new byte[Length];
                        buf = loader.ReadBytes((int)fd.Length);
                        loader.Dispose();
                        loader.Close();


                        //开始加载图像
                        BitmapImage bim = new BitmapImage();
                        bim.BeginInit();
                        //bim.StreamSource = 
                        bim.StreamSource = new MemoryStream(buf);
                        bim.EndInit();
                        Preview_Image.Source = bim;
                        GC.Collect(); //强制回收资源
                    }*/
                    
                    System.IO.FileStream fs =new System.IO.FileStream(value,System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    thedata = value;
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();
                    fs.Dispose();

                    System.IO.MemoryStream ms = new System.IO.MemoryStream(buffer);
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = ms;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                    ms.Close();
                    ms.Dispose();
                    Preview_Image.Source = bitmapImage;
                    


                    //MessageBox.Show(Preview_Image.Source.Width + "");





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
                try
                {
                    TheFileName.Text = value.ToString();
                }
                catch
                {
                }
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
            // Process.Start(Preview_Image.Source.ToString());

            try
            {
                Process.Start(thedata);
            }
            catch
            {

            }
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

        private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            // BitmapImage bitmapImage = new BitmapImage(new Uri("../Images/test.png", UriKind.Relative));

            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new Bitmap(bitmap);
            }

      
        }
        private BitmapImage Bitmap2BitmapImage(Bitmap bitmap)
        {
            BitmapSource i = Imaging.CreateBitmapSourceFromHBitmap(
                           bitmap.GetHbitmap(),
                           IntPtr.Zero,
                           Int32Rect.Empty,
                           BitmapSizeOptions.FromEmptyOptions());
            return (BitmapImage)i;
        }
    }
}