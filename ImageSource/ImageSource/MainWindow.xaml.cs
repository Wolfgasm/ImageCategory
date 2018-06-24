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

        private void Window_Activated(object sender, EventArgs e)
        {

        }


        // 
        string theopenfile;
        // 用來儲存listbox中的所有檔案路徑
        List<string> allTheFiles = new List<string>();
        int listboxIndex = 0;

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            //Listbox1.Items.RemoveAt(Listbox1.SelectedIndex);

            // 將listbox選中的檔案存入路徑列表的index
            listboxIndex = Listbox1.SelectedIndex;
            try
            {
                // 利用該index打開檔案
                Process.Start(allTheFiles[listboxIndex]);
            }
            catch
            {

            }
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
                    
                    if (System.IO.Path.GetExtension(dropFilepath).Contains(".jpg") || System.IO.Path.GetExtension(dropFilepath).Contains(".png") || System.IO.Path.GetExtension(dropFilepath).Contains(".jpeg") || System.IO.Path.GetExtension(dropFilepath).Contains(".gif"))
                    {
                        // 儲存這次拉入的檔案路徑
                        allTheFiles.Add(dropFilepath);

                        listBoxItem.Content = System.IO.Path.GetFileNameWithoutExtension(dropFilepath);


                        
                        
                        listBoxItem.ToolTip = dropPath;
                        Listbox1.Items.Add(listBoxItem);
                        
                    }

                }


            }
        }



        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            /*
            // 產生新的文字方塊
            TextBlock tb = new TextBlock();
            tb.Text = "暴打翔太";
            tb.Background = Brushes.Yellow;
            tb.Padding = new Thickness(10);
            // 放入 StackPanel 中
            ImageArea.Children.Add(tb);*/
            imageShow imageshow = new imageShow();
            imageshow.TheImagePath = allTheFiles[0];
            imageshow.FileName = "123";
            ImageArea.Children.Add(imageshow);
        }

        private void AddTagBtn_Click(object sender, RoutedEventArgs e)
        {
            string addto = AddToComboBox.Text;
            if (AddTagTextBox.Text != "")
            {
                switch (addto)
                {
                    case "Tag1":
                    {
                            AddComboBox01.Items.Add(AddTagTextBox.Text);
                            AddTagTextBox.Text = "";
                            break;
                    }
                    case "Tag2":
                        {
                            AddComboBox02.Items.Add(AddTagTextBox.Text);
                            AddTagTextBox.Text = "";
                            break;
                        }
                    case "Tag3":
                        {
                            AddComboBox03.Items.Add(AddTagTextBox.Text);
                            AddTagTextBox.Text = "";
                            break;
                        }
                    case "Tag4":
                        {
                            AddComboBox04.Items.Add(AddTagTextBox.Text);
                            AddTagTextBox.Text = "";
                            break;
                        }
                    case "Tag5":
                        {
                            AddComboBox05.Items.Add(AddTagTextBox.Text);
                            AddTagTextBox.Text = "";
                            break;
                        }

                }


            }
        }

        private void AddToComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            AddToComboBox.Items.Add("Tag1");
            AddToComboBox.Items.Add("Tag2");
            AddToComboBox.Items.Add("Tag3");
            AddToComboBox.Items.Add("Tag4");
            AddToComboBox.Items.Add("Tag5");
        }


    }
}
