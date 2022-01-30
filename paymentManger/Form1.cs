using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace paymentManger
{
    public partial class Form1 : Form
    {
        List<CSV> csv_datas = new List<CSV>();
#if DEBUG
        string base_path = Path.Combine(Application.StartupPath, @"..\..\..\..\..\..");
        private System.Windows.Forms.Button Test_Button;
#else
            //デバッグ環境ではないときは実行ファイルとおなじフォルダを読み取りのベースパスにする
        string base_path = Path.Combine(Application.StartupPath);

#endif
        string[] genre = new string[6]
        {
            "分割払い","サブスク(娯楽)","光熱費等","ネットスーパ","娯楽","STEAMの支払い"
        };
        private struct genre_Index
        {
            internal int INSTALL_PAYMENT;
            internal int SUBSCRIBE_TOFUN;
            internal int PAYMENT_TOLIVE;
            internal int PAY_FORNETSPER;
            internal int DEFAULT;
            internal int PAY_FORSTEAM;
        }
        genre_Index Indexes = new genre_Index();
        public Form1()
        {
            InitializeComponent();

            GenerateControls_ini();

            //Regist index of genre to struct

            Indexes.INSTALL_PAYMENT = Array.IndexOf(genre, "分割払い");
            Indexes.SUBSCRIBE_TOFUN = Array.IndexOf(genre, "サブスク(娯楽)");
            Indexes.PAYMENT_TOLIVE = Array.IndexOf(genre, "光熱費等");
            Indexes.PAY_FORNETSPER = Array.IndexOf(genre, "ネットスーパ");
            Indexes.DEFAULT = Array.IndexOf(genre, "娯楽");
            Indexes.PAY_FORSTEAM = Array.IndexOf(genre, "STEAMの支払い");

        }
        private void load_original_data_Click(object sender, EventArgs e)
        {
            /*
             * ..\..\..\..\..\..\
             * 六つ前の改装に戻る
             */
            csv_datas.Clear();
            string load_dir = Path.Combine(base_path, "data", "csv", "original");
            string[] files = Directory.GetFiles(load_dir);
            List<string> object_date = new List<string>();
            foreach (string file in files)
            {

                csv_datas.Add(CsvLoader.LoadCSVFile(file, "\""));
                string date = Path.GetFileNameWithoutExtension(file);
                object_date.Add(date);

            }
            for (int i = 0; i < csv_datas.Count; i++)
            {

                csv_datas[i].TExtract_Column_data("利用日", "利用店名・商品名", "[0-9]{1,2}月支払金額", "支払方法");
                csv_datas[i].Extract_condition((key, value) =>
                {
                    if (key == "利用日")
                    {
                        if (String.IsNullOrEmpty(value)) return false;
                    }else if(key == "利用店名・商品名")
                    {
                        if (value == "ﾄｳｷﾕｳﾃﾞﾝﾃﾂ ｼﾞﾖｳｼ") return false;
                    }
                    return true;
                });
                csv_datas[i].Regist_New_Column("支払い時期", object_date[i]);
                csv_datas[i].RenameTitle("[0-9]{1,2}月支払金額", "当月支払金額");
                string save_path = Path.Combine(base_path, "data", "csv", "saved_data");

                if (!Directory.Exists(save_path)) Directory.CreateDirectory(save_path);

                save_path = Path.Combine(save_path, object_date[i] + ".csv");
                SetGenreToCsv(csv_datas[i]);
                csv_datas[i].ToFile(save_path);

            }
            ResetGraphItemFromCsvDatas();
            SaveOptimizedCsv();

        }
        private void CheckedVisibleBox(object sender,EventArgs e)
        {
            CheckBox changedBox = (CheckBox)sender;
            int num = (int)changedBox.Tag;
            this.chart1.Series[num].Enabled = changedBox.Checked;
            return;
        }
        private void SetGenreToCsv(CSV csv_data)
        {

            csv_data.Regist_New_Column("ジャンル", genre[Indexes.DEFAULT]);
            IDictionary< List<string>,string> genre_trigger = new Dictionary<List<string>,string>()
            {
                {new List<string>(){"*YOUTUBE","ニコニコプレミアム","ｱﾏｿﾞﾝﾌﾟﾗｲﾑｶｲﾋ","ﾈｯﾄﾌﾘｯｸｽ"},genre[Indexes.SUBSCRIBE_TOFUN]},
                {new List<string>(){"KDDI", "ｿﾌﾄﾊﾞﾝｸM", "ﾄｳｷﾖｳﾃﾞﾝﾘﾖｸ","ガス" },genre[Indexes.PAYMENT_TOLIVE]},
                {new List<string>(){"STEAM"},genre[Indexes.PAY_FORSTEAM]},
                {new List<string>(){"ネットスーパー"},genre[Indexes.PAY_FORNETSPER]}
            };

            csv_data.do_func((csv) =>
            {

                int line = 0;
                foreach (string value in csv.GetRowData("利用店名・商品名"))
                {

                    foreach (List<string> keys in genre_trigger.Keys.ToList())
                    {
                        foreach (string key in keys)
                        {
                            if (value.IndexOf(key)!=-1)
                            {
                                csv.EditItemValue("ジャンル", line, genre_trigger[keys]);
                            }
                        }
                    }
                    line++;
                }
                line = 0;
                foreach(string value in csv.GetRowData("支払方法"))
                {
                    if (value.IndexOf("分割") != -1)
                    {
                        csv.EditItemValue("ジャンル", line, genre[Indexes.INSTALL_PAYMENT]);
                    }
                    line++;
                }
            });

        }
        private void ResetGraphItemFromCsvDatas()
        {
            for(int i = 0; i < genre.Length; i++)
            {
                this.chart1.Series[i].Points.Clear();
            }
            foreach (CSV csv_data in csv_datas)
            {
                for (int i = 0; i < genre.Length; i++)
                {
                    DateTime time = DateTime.Parse(csv_data.GetCellData("支払い時期", 0));
                    int sum = GetmaxPaymentFromCsv(csv_data,genre[i]);
                    this.chart1.Series[i].Points.AddXY(time, sum);
                }

            }

        }
        private int GetmaxPaymentFromCsv(CSV csv_data,string genre)
        {
            var dum = csv_data.Duplicate();
            dum.Extract_condition((key, value) =>
            {
                if (key == "ジャンル")
                {
                    if (value == genre)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            });
            string[] row_datas = dum.GetRowData("当月支払金額");
            int sum_money = 0;
            foreach(string row_data in row_datas)
            {
                int money = int.Parse(row_data);
                sum_money += money;
            }
            return sum_money;
            
        }
        private void SaveOptimizedCsv()
        {
            string[] title_optimize = new string[]
            {
                "当月支払金額",
                "ジャンル",
                "支払い時期"
            };
            string save_base = Path.Combine(base_path, "data", "csv", "optimize_data");
            if(!Directory.Exists(save_base))    Directory.CreateDirectory(save_base);

            foreach(CSV csv_data in csv_datas)
            {
                var titles = csv_data.Title.ToArray();
                foreach(string title in titles)
                {
                    if (!title_optimize.Contains(title)) csv_data.Delete_Column_data(title);
                }
                string date = csv_data.GetRowData("支払い時期")[0];
                string save_path = Path.Combine(save_base, date) + ".csv";
                csv_data.ToFile(save_path);
            }
            
        }
        private void GenerateControls_ini()
        {
            int ind = 0;
            foreach (var serie in this.chart1.Series)
            {
                serie.Name = ind + "";
                ind++;
            }
            ind = 0;
            foreach (var serie in this.chart1.Series)
            {
                serie.Name = genre[ind];
                ind++;
            }
            Point ini_location = new Point(0, 0);
            int del_y = 22;
            int series_cnt = this.chart1.Series.Count;
            for (int i = 0; i < series_cnt; i++)
            {
                var serie = this.chart1.Series[series_cnt - 1 - i];
                Point location = new Point(ini_location.X, ini_location.Y + i * del_y);
                string checkbox_name = serie.Name;
                CheckBox checkBox = new CheckBox()
                {
                    Location = location,
                    Text = checkbox_name,
                    Checked = true,
                    Tag = (object)(series_cnt - 1 - i)
                };
                checkBox.CheckedChanged += new EventHandler(CheckedVisibleBox);
                this.panel1.Controls.Add(checkBox);
            }
            #region DebugOnly
#if DEBUG
            this.Test_Button = new System.Windows.Forms.Button();
            // 
            // Test_Button
            // 
            this.Test_Button.Location = new System.Drawing.Point(525, 509);
            this.Test_Button.Name = "Test_Button";
            this.Test_Button.Size = new System.Drawing.Size(108, 23);
            this.Test_Button.TabIndex = 3;
            this.Test_Button.Text = "テストを実行(All)";
            this.Test_Button.UseVisualStyleBackColor = true;
            this.Test_Button.Click += new System.EventHandler(this.Test_Button_Click);
            this.Controls.Add(this.Test_Button);
#endif
            #endregion

        }
        #region デバック用の関数です。デバック時以外の時はコンパイルされません。
#if DEBUG
        private void Test_Button_Click(object sender, EventArgs e)
        {

            //CSVLoaderのテスト
            CSV csv_data = CsvLoader.LoadCSVFile(Path.Combine(base_path, "data", "csv","test", "test_data01.csv"));

            //CSVクラスのテスト
            int count = csv_data.ItemCount;

            var extract_column = csv_data.extractItemFromColumnRegexAsDictionary("test1",@"test[34]");
            var extract_row = csv_data.extractItemFromRowNumberAsDictionary(0, 2);


            csv_data.Regist_New_Column("test5", "5");
            csv_data.Delete_Column_data("test5");
            csv_data.Regist_New_Column("abc", "5");
            csv_data.Delete_Column_data(4);
            csv_data.EditItemValue("test4", 0, "よん");
            csv_data.Delete_Row_data(0);
            count = csv_data.ItemCount;

            var dup = csv_data.Duplicate();

            if (dup.Equals(csv_data))
            {

                Console.WriteLine("正常に複製されました");

            }
            csv_data.TExtract_Column_data("test1","test3");
            csv_data.RenameTitle("test[13]", "Remamed");
            var csv_str_data = csv_data.ToString();

            csv_data = CsvLoader.LoadCSVFile(Path.Combine(Directory.GetCurrentDirectory(), "data", "test", "csv", "test_data00.csv"));

            //jsonのテスト
            ConfigDatas.Json_Test();


        }
#endif
        #endregion


        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}
