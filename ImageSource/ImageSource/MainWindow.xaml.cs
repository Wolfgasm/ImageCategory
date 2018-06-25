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

        private void Window_Closed(object sender, EventArgs e)
        {

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

        // 用來暫存listbox中拉入的所有檔案路徑
        List<string> allTheFiles = new List<string>();
        // 用來永久儲存按下確認鈕後 加上TAG的檔案路徑和TAG
        List<string> taggedFiles = new List<string>();

        
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
                // 0為路徑 1~5為TAG 6為GUID
                taggedFiles.Add(allTheFiles[i] + "|" + AddComboBox01.SelectedItem.ToString() + "|" + AddComboBox02.SelectedItem.ToString() + "|" + AddComboBox03.SelectedItem.ToString() + "|" + AddComboBox04.SelectedItem.ToString() + "|" + AddComboBox04.SelectedItem.ToString() + "|" + Guid.NewGuid().ToString("N"));  
            }

            // 重置listbox中的東西跟allthefiles串列以便下次使用
            Listbox1.Items.Clear();
            allTheFiles.Clear();
            
            ImageArea_Refresh();
            //MessageBox.Show(taggedFiles[1]);

        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {


            /*
            MessageBox.Show(taggedFiles[2]);
            try
            {
                allTheFiles.RemoveAt(Listbox1.SelectedIndex);
                Listbox1.Items.RemoveAt(Listbox1.SelectedIndex);
                
            }
            catch
            {

            }*/

        }
        
        // 將檔案拉入listbox中時觸發
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

        // 按下imageShow上的刪除鈕的自訂事件
        private void deletebtn_pressed(object sender, EventArgs e)
        {
            
            try
            {
                /*
                // 發現這樣很費工 重寫成下面的方式6/24

                //這個a會回傳帶有file字頭的路徑 斜線還是反的 我不知道怎麼辦啦幹
                //喔幹我知道怎麼辦了啦幹
                //1.去除file:斜線斜線斜線的字頭
                string a = ((imageShow)sender).TheImagePath.Trim(new Char[] { 'f', 'i', 'l','e',':','/','/','/'});

                // ---搜尋含有跟此物件一樣的路徑的串列位置 抓出來移除
                // 一個一個比對(很吃效能的感覺...)
                for (int i = 0; i < taggedFiles.Count; i++)

                {
                    // 新增一個可以容納taggedfile的陣列 其實6就夠了但是我多加一點保險
                    string[] findpath = new string[10];

                    // 將儲存的路徑跟TAG字串分割
                    findpath = taggedFiles[i].Split('|');

                    // 路徑存在第一個 所以用findpath[0]
                    //2. 把斜線倒過來才跟對象物件所存的TheImagePath比較
                    findpath[0] = findpath[0].Replace(@"\", "/");

                    // 如果路徑一樣 
                    if (findpath[0] == a)
                    {
                        // 從串列中刪除
                        taggedFiles.RemoveAt(i);
                    }

                    // 測試用
                    //MessageBox.Show(a +"------"+ findpath[0]);


                }*/
            }
            catch { }

            try
            {
                // 取得觸發此事件的物件的ID
                string theID = ((imageShow)sender).TheIndex;

                // 搜尋含有此ID的串列
                for (int i = 0; i < taggedFiles.Count; i++)
                {
                    // 新增一個能容納資料的陣列 並將資料分割進去 這邊要用的是temp[6]中存的GUID
                    string[] temp = new string[10];
                    temp = taggedFiles[i].Split('|');

                    
                    // 如果找到ID一樣的串列成員
                    if (temp[6] == theID)
                    {
                        // 將他移除
                        taggedFiles.RemoveAt(i);
                    }
                        
                }
            }
            catch  {}

            // 從imageArea移除觸發此事件的物件
            ImageArea.Children.Remove((imageShow)sender);

            

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Listbox1.Items.Clear();

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
            for (int i = 0; i < taggedFiles.Count ; i++)
            {   //                                                       0     1    2    3    4    5   6
                // 這個tempforsearch陣列需要能容納至少7個變數 分別為(檔案路徑|Tag1|Tag2|Tag3|Tag4|Tag5|ID)
                string[] tempforSearch = new string[10];

                // 先一個一個拆解taggedFiles內的東西
                tempforSearch = taggedFiles[i].Split('|');

                // 儲存需要符合的數量
                int needTomatchNumber = 0;
                // 儲存比對後共符合的數量
                int nowMatch = 0;
                // 以上這兩個變數在之後用來判定要不要將此物件加入imageArea

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

                }

                // 如果比對符合 加入一個imageShow物件 並將現在的數據指定給他
                if (nowMatch >= needTomatchNumber)
                {
                    imageShow imageshow = new imageShow();
                    // 圖片路徑存在temforSearch的第一個 將他指定給imageShow物件
                    imageshow.TheImagePath = tempforSearch[0];

                    //imageshow.TheIndex = int.Parse(tempforSearch[6]);

                    // 新增事件
                    imageshow.deletebtn_pressed += new EventHandler(deletebtn_pressed);

                    // 將專屬ID加入此物件 以後要刪除還是幹嘛都可以用
                    imageshow.TheIndex = tempforSearch[6];

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

        private void SearchStartBtn_Click(object sender, RoutedEventArgs e)
        {
            ImageArea_Refresh();
        }
    }
}
