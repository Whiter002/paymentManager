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
            string path = Path.Combine(config_dir, "series_data.json");

            var options = new JsonSerializerOptions
            {
                // JavaScriptEncoder.Createでエンコードしない文字を指定するのも可
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                // 読みやすいようインデントを付ける
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            };

            string json_str = Read_Json(path);
            sb = JsonSerializer.Deserialize<SeriesBander>(json_str, options);
            sb.Initialize();
            UpdateUsesColumns();

        }
        static private void UpdateUsesColumns()
        {
            use_columns.Clear();
            use_columns.AddRange(sb.UsedColumn);
        }

        static internal void Classificate(CSV csv)
        {
            CSVExtender.ChangeGenreInCSV(sb, csv);
        }
        static internal string DefaultGenre
        {
            get { return sb.DefaultSeries.Base_info.Name; }
        }
        static internal string[] AllSeriesNames
        {
            get { return sb.SeriesNameList; }
        }
        static internal string[] SeriesSortByView
        {
            get { return (from x in sb.SortedByView select x.Base_info.Name.ToString()).ToArray(); }
        }
        static internal int SeriesNameCount
        {
            get { return AllSeriesNames.Length; }
        }
        static internal string[] UseColumns
        {
            get { return use_columns.ToArray(); }
        }
        static private string Read_Json(string path)
        {
            StreamReader sr = new StreamReader(path);
            string json = sr.ReadToEnd();
            sr.Close();
            return json;
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

            string json_str;

            /*
             *
             *jsonファイルの更新に伴ってデータの互換性が失われため
            string json_str = Read_Json_Debug(0);
            var load_json1 = JsonSerializer.Deserialize<SeriesDatas>(json_str, options);
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
