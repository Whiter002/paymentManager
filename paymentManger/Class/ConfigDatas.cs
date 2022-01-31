using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Windows.Forms;
using System.Text.Encodings.Web;
using paymentManger.Class;

namespace paymentManger
{
    static internal class ConfigDatas
    {
        //分類情報などのコンフィグデータをここから呼び出すために作られたクラスです。

        static SeriesDatas sd = new SeriesDatas();
        static Dictionary<string,SeriesClassificationData> SeriesClassifications = new Dictionary<string, SeriesClassificationData>();
#if DEBUG
        static public SeriesBander sb;
#else
        static SeriesBander sb;
#endif
        static List<string> use_columns = new List<string>();

        static private string Read_Json_(string path)
        {
            StreamReader sr = new StreamReader(path);
            string json = sr.ReadToEnd();
            sr.Close();
            return json;
        }

        static internal void LoadJsonFiles(string base_path)
        {
            string config_dir = Path.Combine(base_path, "data", "config");
            string[] pathes = new string[]
            {
                Path.Combine(config_dir,"series_names.json"),
                Path.Combine(config_dir, "series_detail.json")
            };

            string json_str = File.ReadAllText(pathes[0]);
            var options = new JsonSerializerOptions
            {
                // JavaScriptEncoder.Createでエンコードしない文字を指定するのも可
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                // 読みやすいようインデントを付ける
                WriteIndented = true
            };

            sd = JsonSerializer.Deserialize<SeriesDatas>(json_str);

            json_str = File.ReadAllText(pathes[1]);

            SeriesClassifications = JsonSerializer.Deserialize<Dictionary<string, SeriesClassificationData>>(json_str);
            GetColumns();

        }
        static private void GetColumns()
        {
            List<string> columns = new List<string>();
            foreach(SeriesClassificationData scd in SeriesClassifications.Values)
            {
                var new_columns = (from x in scd.BasesSeries where !columns.Contains(x) select scd.BasesSeries).ToArray();
                if (new_columns.Length == 0) continue;
                columns.AddRange(new_columns[0]);

            }
            use_columns.Clear();
            use_columns.AddRange(columns);
        }

        static internal void Classificate(CSV csv)
        {

            int item_count = csv.ItemCount;
            for(int i = 0; i< item_count; i++)
            {

                foreach(KeyValuePair<string,SeriesClassificationData> pair in SeriesClassifications)
                {
                    string id = pair.Key;
                    SeriesClassificationData scd = pair.Value;
                    foreach(string label in scd.BasesSeries)
                    {
                        string data = csv.GetCellData(label,i);
                        Classificate(id, data, csv, scd, i);
                    }

                }


            }

        }
        static private void Classificate(string id, string data,CSV csv,SeriesClassificationData scd,int i)
        {
            string genre = sd.OtherSeriesFromName(id);
            string column_name = "ジャンル";
            foreach (string com_value in scd.ComValue)
            {
                switch (scd.Operators)
                {
                    case "eq":
                        if (data == com_value)
                        {
                            csv.EditItemValue(column_name, i, genre);
                            return;
                        }
                        break;
                    case "neq":
                        if (data != com_value)
                        {
                            csv.EditItemValue(column_name, i, genre);
                            return;
                        }
                        break;
                    case "in":
                        if (data.IndexOf(com_value) != -1)
                        {
                            csv.EditItemValue(column_name, i, genre);
                            return;
                        }
                        break;
                    case "nin":
                        if (data.IndexOf(com_value) == -1)
                        {
                            csv.EditItemValue(column_name, i, genre);
                            return;
                        }
                        break;
                    case "le":
                        int toInt_le = int.Parse(data);
                        if (toInt_le < int.Parse(com_value))
                        {

                            csv.EditItemValue(column_name, i, genre);
                            return;
                        }
                        break;
                    case "mo":
                        int toInt_mo = int.Parse(data);
                        if (toInt_mo > int.Parse(com_value))
                        {

                            csv.EditItemValue(column_name, i, genre);
                            return;
                        }
                        break;
                }


            }

        }

        static internal string DefaultGenre
        {
            get { return sd.DefaultSeries; }
        }
        static internal string[] AllSeriesNames
        {
            get { return sd.AllSeriesNames; }
        }
        static internal int SeriesNameCount
        {
            get { return AllSeriesNames.Length; }
        }
        static internal string[] UseColumns
        {
            get { return use_columns.ToArray(); }
        }
#region DebugOnlyFunctoins
#if DEBUG
        static internal void Json_Test()
        {

            IDictionary<string, string> test = new Dictionary<string, string>()
            {
                {"Test1","are"},
                {"Test2","rate"},
                {"Test3","ate"},
                {"Test4","tar"},
                {"Test5","ter"}
            };

            string test_str = JsonSerializer.Serialize(test);
            var options = new JsonSerializerOptions
            {
                // JavaScriptEncoder.Createでエンコードしない文字を指定するのも可
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                // 読みやすいようインデントを付ける
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            };


            string json_str = Read_Json_Debug(0);
            var load_json1 = JsonSerializer.Deserialize<SeriesDatas>(json_str, options);

            /*
             *
             *jsonファイルの更新に伴ってデータの互換性が失われため
            　json_str = Read_Json_Debug(1);
            　var load_json2 = JsonSerializer.Deserialize<Dictionary<string,SeriesBander>>(json_str,options);
            */

            json_str = Read_Json_Debug(2);
            var load_json3 = JsonSerializer.Deserialize<Dictionary<string, SeriesBander.ClassificatableSeriesData>>(json_str, options);

            json_str = Read_Json_Debug(3);
            var load_json4 = JsonSerializer.Deserialize<SeriesBander>(json_str, options);


            string bander_json = JsonSerializer.Serialize(load_json4,options);
            var reload_json = JsonSerializer.Deserialize<SeriesBander>(bander_json, options);

            reload_json.Initialize();

            sb = reload_json;

        }
        static private string Read_Json_Debug(int file_num)
        {
            string[] path = new string[] {
                Path.Combine(Application.StartupPath, @"..\..\..\..\..\..",@"data\json_test","define_series_test.json"),
                Path.Combine(Application.StartupPath, @"..\..\..\..\..\..",@"data\json_test","difine_classification_series_test.json"),
                Path.Combine(Application.StartupPath, @"..\..\..\..\..\..",@"data\json_test","simple_test.json"),
                Path.Combine(Application.StartupPath, @"..\..\..\..\..\..",@"data\json_test","new_jsonTest.json")
            };
            StreamReader sr = new StreamReader(path[file_num]);
            string json = sr.ReadToEnd();
            sr.Close();
            return json;
        }
        public struct Dum
        {
            public string name { get; set; }
            public int view_num { get; set; }
        }
#endif
#endregion
    }
}
