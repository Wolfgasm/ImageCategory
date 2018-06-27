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
using System.IO;


namespace ImageSource
{
    /* 筆記 紀錄一下這次缺點 想到就寫
    
        1.程式碼很亂
        2.combobox應該可以用陣列包起來 現在這樣要寫很多次
        3.搜尋這樣寫超級吃效能 還要再學習

    */

     

    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // 新建資料夾路徑
        string folder = @"C:\temp\";


        // taggedFile存檔路徑
        string path = @"C:\temp\taggedFile.txt";
        // Tag存檔路徑
        string tagPath = @"C:\temp\Tags.txt";


        // 用來暫存listbox中拉入的所有檔案路徑
        List<string> allTheFiles = new List<string>();
        // 用來永久儲存按下確認鈕後 加上TAG的檔案路徑和TAG
        List<string> taggedFiles = new List<string>();

        // 當程式關閉時
        private void Window_Closed(object sender, EventArgs e)
        {
            // 儲存taggedfile
            if (!Directory.Exists(folder))
            {
                System.IO.Directory.CreateDirectory(folder);
            }

            // 存檔
            System.IO.File.WriteAllLines(path, taggedFiles);
 
            var temp = new string[5];


            // 儲存第1個combobox
            for (int i = 0; i < AddComboBox01.Items.Count; i++)
            {
                AddComboBox01.SelectedIndex = i;
                // 避免每次存檔都多存一個空格
                if (!(i == AddComboBox01.Items.Count - 1))
                {
                    temp[0] += (AddComboBox01.Text + "|");
                }
                else { temp[0] += (AddComboBox01.Text ); }
            }
            // 儲存第2個combobox
            for (int i = 0; i < AddComboBox02.Items.Count; i++)
            {
                AddComboBox02.SelectedIndex = i;

                // 避免每次存檔都多存一個空格
                if (!(i == AddComboBox02.Items.Count - 1))
                {
                    temp[1] += (AddComboBox02.Text + "|");
                }
                else { temp[1] += (AddComboBox02.Text); }
            }
            // 儲存第3個combobox
            for (int i = 0; i < AddComboBox03.Items.Count; i++)
            {
                AddComboBox03.SelectedIndex = i;

                // 避免每次存檔都多存一個空格
                if (!(i == AddComboBox03.Items.Count - 1))
                {
                    temp[2] += (AddComboBox03.Text + "|");
                }
                else { temp[2] += (AddComboBox03.Text); }
            }
            // 儲存第4個combobox
            for (int i = 0; i < AddComboBox04.Items.Count; i++)
            {
                AddComboBox04.SelectedIndex = i;

                // 避免每次存檔都多存一個空格
                if (!(i == AddComboBox04.Items.Count - 1))
                {
                    temp[3] += (AddComboBox04.Text + "|");
                }
                else { temp[3] += (AddComboBox04.Text); }
            }
            // 儲存第5個combobox
            for (int i = 0; i < AddComboBox05.Items.Count; i++)
            {
                AddComboBox05.SelectedIndex = i;

                // 避免每次存檔都多存一個空格
                if (!(i == AddComboBox05.Items.Count - 1))
                {
                    temp[4] += (AddComboBox05.Text + "|");
                }
                else { temp[4] += (AddComboBox05.Text); }
            }


            // TAG存檔
            System.IO.File.WriteAllLines(tagPath, temp);

        }

        // 開啟程式時
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

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

            // ----taggedFiles讀檔
            try
            {
                // 讀取檔案內容到陣列裡
                var lines = System.IO.File.ReadAllLines(path); ;
                foreach (string line in lines)
                {
                    taggedFiles.Add(line);
                }
            }
            catch
            {
                // 如果目的點沒有資料夾新建一個資料夾
                if (!Directory.Exists(folder))
                {
                    System.IO.Directory.CreateDirectory(folder);
                }
                // 存檔
                System.IO.File.WriteAllLines(path, taggedFiles);
            }

            // ----Tag讀檔
            try
            {
                // 讀取檔案內容到陣列裡
                var lines = System.IO.File.ReadAllLines(tagPath);

                // 拆解字串
                string[] combobox01Data = lines[0].Split('|');
                string[] combobox02Data = lines[1].Split('|');
                string[] combobox03Data = lines[2].Split('|');
                string[] combobox04Data = lines[3].Split('|');
                string[] combobox05Data = lines[4].Split('|');

                // 將陣列一個一個加入combobox01~05
                foreach (string data in combobox01Data)
                {
                    AddComboBox01.Items.Add(data);
                    SearchComboBox01.Items.Add(data);

                }
                foreach (string data in combobox02Data)
                {
                    AddComboBox02.Items.Add(data);
                    SearchComboBox02.Items.Add(data);
                }
                foreach (string data in combobox03Data)
                {
                    AddComboBox03.Items.Add(data);
                    SearchComboBox03.Items.Add(data);
                }
                foreach (string data in combobox04Data)
                {
                    AddComboBox04.Items.Add(data);
                    SearchComboBox04.Items.Add(data);
                }
                foreach (string data in combobox05Data)
                {
                    AddComboBox05.Items.Add(data);
                    SearchComboBox05.Items.Add(data);
                }

            }
            catch
            {
                // 如果目的點沒有資料夾新建一個資料夾
                if (!Directory.Exists(folder))
                {
                    System.IO.Directory.CreateDirectory(folder);
                }
                // 存檔
                System.IO.File.WriteAllLines(path, taggedFiles);
            }


            // 設定combobox的初始值 第一次打開程式時加入一個空白選項
            if (AddComboBox01.Items.Count == 0) AddComboBox01.Items.Insert(0, "");
            if (AddComboBox02.Items.Count == 0) AddComboBox02.Items.Insert(0, "");
            if (AddComboBox03.Items.Count == 0) AddComboBox03.Items.Insert(0, "");
            if (AddComboBox04.Items.Count == 0) AddComboBox04.Items.Insert(0, "");
            if (AddComboBox05.Items.Count == 0) AddComboBox05.Items.Insert(0, "");

            // 設定搜尋combobox的初始值 如上
            if (SearchComboBox01.Items.Count == 0) SearchComboBox01.Items.Insert(0, "");
            if(SearchComboBox02.Items.Count == 0) SearchComboBox02.Items.Insert(0, "");
            if(SearchComboBox03.Items.Count == 0) SearchComboBox03.Items.Insert(0, "");
            if(SearchComboBox04.Items.Count == 0) SearchComboBox04.Items.Insert(0, "");
            if(SearchComboBox05.Items.Count == 0) SearchComboBox05.Items.Insert(0, "");

            // 重整頁面
            ImageArea_Refresh();



        }

        // 按下確認鈕時
        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {


            // 按下確認鈕後 將listbox裡有的檔案的檔案路徑存入taggedFiles串列中
                for (int i = 0; i < allTheFiles.Count; i++)
                 {
                    // 0為路徑 1~5為TAG 6為GUID
                    taggedFiles.Add(allTheFiles[i] + "|" + AddComboBox01.SelectedItem.ToString() + "|" + AddComboBox02.SelectedItem.ToString() + "|" + AddComboBox03.SelectedItem.ToString() + "|" + AddComboBox04.SelectedItem.ToString() + "|" + AddComboBox04.SelectedItem.ToString() + "|" + Guid.NewGuid().ToString("N"));
                }
            

            // 重置listbox中的東西跟allthefiles串列以便下次使用
            Listbox1.Items.Clear();
            allTheFiles.Clear();

            // 重整imageArea內的物件
            ImageArea_Refresh();
            



        }

        // 按下移除鈕時
        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // 從暫存陣列移除
                allTheFiles.RemoveAt(Listbox1.SelectedIndex);
                // 刪除選中的圖片
                Listbox1.Items.Remove(Listbox1.SelectedItem);
            }
            catch { }
           


        }

        //按下取消鍵
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            //清除Listbox內的東西
            Listbox1.Items.Clear();
        }

        // 將檔案拉入listbox中時觸發
        private void Listbox1_Drop(object sender, DragEventArgs e)
        {
           

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {

                    //string[] dropPath = e.Data.GetData(DataFormats.FileDrop, true) as string[]; // -----------------------------------------------
                    var dropPath = e.Data.GetData(DataFormats.FileDrop, true) as string[];
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
              
                var theID = ((imageShow)sender).TheIndex;

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

        // 點到圖片時顯示該圖片帶有的TAG
        private void ShowImformation(object sender, EventArgs e)
        {
            if (((imageShow)sender).Selected == true )
            {
                AddComboBox01.SelectedItem = ((imageShow)sender).Tag1;
                AddComboBox02.SelectedItem = ((imageShow)sender).Tag2;
                AddComboBox03.SelectedItem = ((imageShow)sender).Tag3;
                AddComboBox04.SelectedItem = ((imageShow)sender).Tag4;
                AddComboBox05.SelectedItem = ((imageShow)sender).Tag5;
            }
            
        }




        // 新增自訂TAG的方法
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

        // 設定[加入到....]的combobox選項的初始值
        private void AddToComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            AddToComboBox.Items.Add("Tag1");
            AddToComboBox.Items.Add("Tag2");
            AddToComboBox.Items.Add("Tag3");
            AddToComboBox.Items.Add("Tag4");
            AddToComboBox.Items.Add("Tag5");
        }

        // 搜尋並更新ImageArea的自訂方法 這邊超級吃資源------------------------------------------------
        public void ImageArea_Refresh()
        {
            // 先重置ImageArea內的東西
            ImageArea.Children.Clear();



            // ---搜尋
            for (int i = 0; i < taggedFiles.Count ; i++)
            {   //                                                       0     1    2    3    4    5   6
                // 這個tempforsearch陣列需要能容納至少7個變數 分別為(檔案路徑|Tag1|Tag2|Tag3|Tag4|Tag5|ID)
                //string[] tempforSearch = new string[10];-------------------------------------------------------------------------------------
                var tempforSearch = new string[10];

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
                

                // 逐一比對Tag1~Tag5 
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
                    // 新增imageShow物件
                    imageShow imageshow = new imageShow();

                    // 圖片路徑存在temforSearch的第一個 將他指定給imageShow物件
                    imageshow.TheImagePath = tempforSearch[0];

                    //imageshow.TheIndex = int.Parse(tempforSearch[6]);

                    // 新增事件
                    imageshow.deletebtn_pressed += new EventHandler(deletebtn_pressed);
                    imageshow.Selected_image += new EventHandler(ShowImformation);

                    // 將專屬GUID加入此物件 以後要刪除還是幹嘛都可以用
                    imageshow.TheIndex = tempforSearch[6];

                    // 將圖片屬性存入自訂元件
                    imageshow.Tag1 = tempforSearch[1];
                    imageshow.Tag2 = tempforSearch[2];
                    imageshow.Tag3 = tempforSearch[3];
                    imageshow.Tag4 = tempforSearch[4];
                    imageshow.Tag5 = tempforSearch[5];

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

        private void LoseFocus(object sender, EventArgs e)
        {
            ((imageShow)sender).Selected = false;
        }





    }
}
