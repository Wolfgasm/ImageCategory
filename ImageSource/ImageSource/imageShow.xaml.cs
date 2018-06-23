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

namespace ImageSource
{
    /// <summary>
    /// imageShow.xaml 的互動邏輯
    /// </summary>
    public partial class imageShow : UserControl
    {
        public imageShow()
        {
            InitializeComponent();
        }

        private void Preview_Image_KeyDown(object sender, KeyEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri(@"D:\桌面\patches\patches3\1KcaCbHTSDaQSKGDwBpI.jpg", UriKind.Absolute));
            Preview_Image.Source = imagetemp;
        }
        //Image image = new Image(@"D:\桌面\patches\patches3\1KcaCbHTSDaQSKGDwBpI.jpg");

    }
}