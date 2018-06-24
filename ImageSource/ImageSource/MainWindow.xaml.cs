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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 設定combobox的初始值
            AddComboBox01.Items.Insert(0, "");
            AddComboBox02.Items.Insert(0, "");
            AddComboBox03.Items.Insert(0, "");
            AddComboBox04.Items.Insert(0, "");
            AddComboBox05.Items.Insert(0, "");
            // 設定combobox的初始值
            SearchComboBox01.Items.Insert(0, "");
            SearchComboBox02.Items.Insert(0, "");
            SearchComboBox03.Items.Insert(0, "");
            SearchComboBox04.Items.Insert(0, "");
            SearchComboBox05.Items.Insert(0, "");
            // 設定combobox的初始選項
            AddComboBox01.SelectedIndex = 0;
            AddComboBox02.SelectedIndex = 0;
            AddComboBox03.SelectedIndex = 0;
            AddComboBox04.SelectedIndex = 0;
            AddComboBox05.SelectedIndex = 0;
            // 設定combobox的初始選項
            SearchComboBox01.SelectedIndex = 0;
            SearchComboBox02.SelectedIndex = 0;
            SearchComboBox03.SelectedIndex = 0;
            SearchComboBox04.SelectedIndex = 0;
            SearchComboBox05.SelectedIndex = 0;
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            /*
            // 之後要判斷是否是第一次開啟程式 不然會每次開都加一次空白選項
            AddComboBox01.Items.Add("");
            AddComboBox02.Items.Add("");
            AddComboBox03.Items.Add("");
            AddComboBox04.Items.Add("");
            AddComboBox05.Items.Add("");*/
            
         
        }


        // 
        string theopenfile;
        // 用來暫存listbox中拉入的所有檔案路徑
        List<string> allTheFiles = new List<string>();
        // 用來永久儲存按下確認鈕後 加上TAG的檔案路徑和TAG
        List<string> taggedFiles = new List<string>();
        int listboxIndex = 0;
        
        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {

            //Listbox1.Items.RemoveAt(Listbox1.SelectedIndex);
            /*
            // 將listbox選中的檔案存入路徑列表的index
            listboxIndex = Listbox1.SelectedIndex;
            try
            {
                // 利用該index打開檔案
                Process.Start(allTheFiles[listboxIndex]);
            }
            catch
            {

            }*/
            // 按下確認鈕後 將listbox裡有的檔案的檔案路徑存入taggedFiles串列中
            for (int i = 0; i < allTheFiles.Count; i++)
            {
                taggedFiles.Add(allTheFiles[i] + "|" + AddComboBox01.SelectedItem.ToString() + "|" + AddComboBox02.SelectedItem.ToString() + "|" + AddComboBox03.SelectedItem.ToString() + "|" + AddComboBox04.SelectedItem.ToString() + "|" + AddComboBox04.SelectedItem.ToString());  
            }

            // 重置listbox中的東西跟allthefiles串列以便下次使用
            Listbox1.Items.Clear();
            allTheFiles.Clear();
            
            ImageArea_Refresh();

        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(taggedFiles[2]);
            try
            {
                allTheFiles.RemoveAt(Listbox1.SelectedIndex);
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
            Listbox1.Items.Clear();
            /*
            // 產生新的文字方塊
            TextBlock tb = new TextBlock();
            tb.Text = "暴打翔太";
            tb.Background = Brushes.Yellow;
            tb.Padding = new Thickness(10);
            // 放入 StackPanel 中
            ImageArea.Children.Add(tb);
            imageShow imageshow = new imageShow();
            imageshow.TheImagePath = allTheFiles[0];
            imageshow.FileName = "123";
            ImageArea.Children.Add(imageshow);*/
        }

        private void AddTagBtn_Click(object sender, RoutedEventArgs e)
        {
            string addto = AddToComboBox.Text;
            // 如果按下了按鈕 並且使用者有在輸入框內輸入文字 
            if (AddTagTextBox.Text != "")
            {
                // 取得addTagcombox現在的值 並選擇要加入到哪一個TAG
                switch (addto)
                {
                    case "Tag1":
                    {
                            AddComboBox01.Items.Add(AddTagTextBox.Text);
                            SearchComboBox01.Items.Add(AddTagTextBox.Text);
                            AddTagTextBox.Text = "";
                            break;
                    }
                    case "Tag2":
                        {
                            AddComboBox02.Items.Add(AddTagTextBox.Text);
                            SearchComboBox02.Items.Add(AddTagTextBox.Text);
                            AddTagTextBox.Text = "";
                            break;
                        }
                    case "Tag3":
                        {
                            AddComboBox03.Items.Add(AddTagTextBox.Text);
                            SearchComboBox03.Items.Add(AddTagTextBox.Text);
                            AddTagTextBox.Text = "";
                            break;
                        }
                    case "Tag4":
                        {
                            AddComboBox04.Items.Add(AddTagTextBox.Text);
                            SearchComboBox04.Items.Add(AddTagTextBox.Text);
                            AddTagTextBox.Text = "";
                            break;
                        }
                    case "Tag5":
                        {
                            AddComboBox05.Items.Add(AddTagTextBox.Text);
                            SearchComboBox05.Items.Add(AddTagTextBox.Text);
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

        // 搜尋並更新ImageArea的自訂方法
        public void ImageArea_Refresh()
        {
            // 先重置ImageArea內的東西
            ImageArea.Children.Clear();



            // ---搜尋
            for (int i = 0; i < taggedFiles.Count; i++)
            {   //                                                       0     1    2    3    4    5
                // 這個tempforsearch陣列需要能容納至少6個變數 分別為(檔案路徑|Tag1|Tag2|Tag3|Tag4|Tag5)
                string[] tempforSearch = new string[10];

                // 先一個一個拆解taggedFiles內的東西
                tempforSearch = taggedFiles[i].Split('|');

                // 需要符合的數量
                int needTomatchNumber = 0;
                // 比對後共符合的數量
                int nowMatch = 0;
                // 這兩個變數在之後用來判定要不要將此物件加入imageArea

                // 先計算如果要符合搜尋條件需要符合幾次
                    if (SearchComboBox01.SelectedItem.ToString() != "")
                    {
                        needTomatchNumber++;
                    }
                    if (SearchComboBox02.SelectedItem.ToString() != "")
                    {
                        needTomatchNumber++;
                    }
                    if (SearchComboBox03.SelectedItem.ToString() != "")
                    {
                        needTomatchNumber++;
                    }
                    if (SearchComboBox04.SelectedItem.ToString() != "")
                    {
                        needTomatchNumber++;
                    }
                    if (SearchComboBox05.SelectedItem.ToString() != "")
                    {
                        needTomatchNumber++;
                    }
                

                // 逐一比對Tag1~Tag5 ((OMG想了好幾遍才寫出只會顯示聯集的搜尋
                for (int tag = 1; tag <= 5; tag++)
                {

                        // 比對Tag1
                        switch (SearchComboBox01.SelectedItem.ToString() == tempforSearch[tag] && SearchComboBox01.SelectedItem.ToString() != "" )
                        {
                            case true:
                                {
                                    // 如果關鍵字符合 用來計算符合幾次的變數+1
                                    nowMatch++;
                                    break;
                                }
                            // 如果不符合 繼續比對下去
                            case false:
                            {   // 比對Tag2
                                switch (SearchComboBox02.SelectedItem.ToString() == tempforSearch[tag] && SearchComboBox02.SelectedItem.ToString() != "")
                                {
                                    case true:
                                        {
                                            nowMatch++;
                                            break;
                                        }
                                    case false:
                                        {   // 比對Tag3
                                            switch (SearchComboBox03.SelectedItem.ToString() == tempforSearch[tag] && SearchComboBox03.SelectedItem.ToString() != "")
                                            {
                                                case true:
                                                    {
                                                        nowMatch++;
                                                        break;
                                                    }
                                                case false:
                                                    {   // 比對Tag4
                                                        switch (SearchComboBox04.SelectedItem.ToString() == tempforSearch[tag] && SearchComboBox04.SelectedItem.ToString() != "")
                                                        {
                                                            case true:
                                                                {
                                                                    nowMatch++;
                                                                    break;
                                                                }
                                                            case false:
                                                                {   // 比對Tag5
                                                                    switch (SearchComboBox05.SelectedItem.ToString() == tempforSearch[tag] && SearchComboBox05.SelectedItem.ToString() != "")
                                                                    {
                                                                        case true:
                                                                            {
                                                                                nowMatch++;
                                                                                break;
                                                                            }
                                                                        case false:
                                                                            { break; }
                                                                    }
                                                                    break;
                                                                }
                                                        }
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                }
                                break;
                            }

                        }
                    
                    /*
                    if (SearchComboBox01.SelectedItem.ToString() == tempforSearch[tag])
                    {
                        isMatch = true;
                    }
                    else if(SearchComboBox02.SelectedItem.ToString() == tempforSearch[tag])
                    {
                        isMatch = true;
                    }
                    else if (SearchComboBox03.SelectedItem.ToString() == tempforSearch[tag])
                    {
                        isMatch = true;
                    }
                    else if (SearchComboBox04.SelectedItem.ToString() == tempforSearch[tag])
                    {
                        isMatch = true;
                    }
                    else if (SearchComboBox05.SelectedItem.ToString() == tempforSearch[tag])
                    {
                        isMatch = true;
                    }*/
                }

                // 如果比對符合 加入一個imageShow物件 並將現在的數據指定給他
                if (nowMatch >= needTomatchNumber)
                {
                    imageShow imageshow = new imageShow();
                    // 圖片路徑存在temforSearch的第一個 將他指定給imageShow物件
                    imageshow.TheImagePath = tempforSearch[0];

                    //不需要這行 (我寫在imageShow物件了 他會自己抓)
                    //imageshow.FileName = "123";

                    // 設定完了 加入imageShow物件~
                    ImageArea.Children.Add(imageshow);

                    // 重置判斷用的變數
                    nowMatch = 0;
                    needTomatchNumber = 0;
                }

            }
        }
    }
}
