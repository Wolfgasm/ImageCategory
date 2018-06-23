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
using System.Diagnostics;

namespace ImageSource
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // 用來儲存檔案路徑
        string theopenfile;
        // 用來儲存listbox中的檔案路徑
        List<string> allTheFiles = new List<string>();
        int listboxIndex = 0;

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            //Listbox1.Items.RemoveAt(Listbox1.SelectedIndex);

            // 將listbox選中的檔案存入路徑列表的index
            listboxIndex = Listbox1.SelectedIndex;
            // 利用該index打開檔案
            Process.Start(allTheFiles[listboxIndex]);
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Listbox1.Items.RemoveAt(Listbox1.SelectedIndex);
            }
            catch
            {

            }
        }

        private void Listbox1_Drop(object sender, DragEventArgs e)
        {
           

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                
                string[] dropPath = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                foreach (string dropFilepath in dropPath)
                {

                    ListBoxItem listBoxItem = new ListBoxItem();
                    
                    if (System.IO.Path.GetExtension(dropFilepath).Contains(".jpg") || System.IO.Path.GetExtension(dropFilepath).Contains(".png"))
                    {
                        allTheFiles.Add(dropFilepath);

                        listBoxItem.Content = System.IO.Path.GetFileNameWithoutExtension(dropFilepath);

                        // 儲存這次拉入的檔案路徑
                        //theopenfile = dropFilepath;
                        
                        listBoxItem.ToolTip = dropPath;
                        Listbox1.Items.Add(listBoxItem);
                    }

                }


            }
        }


    }
}
