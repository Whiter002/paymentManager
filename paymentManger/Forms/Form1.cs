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
using paymentManger.Forms;
using paymentManger.Class;

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
        string[] series_names_view;
        public Form1()
        {
            InitializeComponent();
            ConfigDatas.LoadJsonFiles(base_path);
            series_names_view = ConfigDatas.SeriesSortByView;
            GenerateControls_ini();
            //Regist index of genre to struct

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
            List<string> csv_file_name = new List<string>();
            foreach (string file in files)
            {

                csv_datas.Add(CSV.LoadCSVFile(file, "\""));
                string date = Path.GetFileNameWithoutExtension(file);
                csv_file_name.Add(date);

            }
            for (int i = 0; i < csv_datas.Count; i++)
            {
                List<string> use_columns = new List<string>()
                {
                    "利用日", "[0-9]{1,2}月支払金額"
                };
                use_columns.AddRange(ConfigDatas.UseColumns);
                csv_datas[i].TExtract_Column_data(use_columns.ToArray());
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
                csv_datas[i].Regist_New_Column("支払い時期", csv_file_name[i]);
                csv_datas[i].RenameTitle("[0-9]{1,2}月支払金額", "当月支払金額");
                string save_path = Path.Combine(base_path, "data", "csv", "saved_data");

                if (!Directory.Exists(save_path)) Directory.CreateDirectory(save_path);

                save_path = Path.Combine(save_path, csv_file_name[i] + ".csv");
                SetGenreToCsv(csv_datas[i]);
                csv_datas[i].ToFile(save_path);

            }//データを整理する
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
            csv_data.Regist_New_Column("ジャンル", ConfigDatas.DefaultGenre);
            ConfigDatas.Classificate(csv_data);

        }
        private void ResetGraphItemFromCsvDatas()
        {
            for(int i = 0; i < ConfigDatas.SeriesNameCount; i++)
            {
                this.chart1.Series[i].Points.Clear();
            }
            foreach (CSV csv_data in csv_datas)
            {
                for (int i = 0; i < ConfigDatas.SeriesNameCount; i++)
                {
                    DateTime time = DateTime.Parse(csv_data.GetCellData("支払い時期", 0));
                    int sum = GetmaxPaymentFromCsv(csv_data, series_names_view[i]);
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
            foreach(string name in series_names_view)
            {
                System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series()
                {

                    ChartArea = "ChartArea1",
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn,
                    Legend = "Legend1",
                    Name = name,
                    XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime,
                    YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
                };
                this.chart1.Series.Add(series);
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
            this.Test_Button.Location = new System.Drawing.Point(520, 470);
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
            CSV csv_data =CSV.LoadCSVFile(Path.Combine(base_path, "data", "csv","test", "test_data01.csv"));

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

            //csv_data = CsvLoader.LoadCSVFile(Path.Combine(Directory.GetCurrentDirectory(), "data", "test", "csv", "test_data00.csv"));

            //jsonのテスト
            ConfigDatas.Json_Test();

            ConfigDatas.LoadJsonFiles(base_path);
            dup = CSV.LoadCSVFile(Path.Combine(base_path,"data","csv","saved_data", "2021-12.csv"), "\"");
            dup.Delete_Column_data("ジャンル");
            dup.Regist_New_Column("ジャンル",ConfigDatas.DefaultGenre);
            CSVExtender.ChangeGenreInCSV(ConfigDatas.sb, dup);
        }
#endif
        #endregion



        private void 分類の追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new EditSeriesForm());
        }
        private void 支払い情報の追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new EditItemsForm());
        }
        private void OpenForm(Form form,bool this_enabled=false)
        {
            this.Enabled = this_enabled;
            DialogResult dr = form.ShowDialog();
            this.Enabled = true;
        }

    }
}
